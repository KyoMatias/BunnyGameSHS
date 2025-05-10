using System.Collections;
using UnityEngine;

public class InteractableManager : MonoBehaviour
{
    [SerializeField]private float timeChecker;
    [SerializeField] private bool HasInteracted;
    [SerializeField] private InteractableObject interactableObject;

    private void Awake()
    {
        if (interactableObject != null)
        {
            interactableObject.OnInteractWithObject += SetClock;
        }
        else
        {
            Debug.LogError("InteractableObject is not assigned in " + gameObject.name);
        }
    }

    void Start()
    {
        HasInteracted = false;
    }

    public void SetClock(bool value)
    {
        HasInteracted = value;

        if (HasInteracted)
        {
            StartCoroutine(StartTimer());
        }

    }
    
    //Works as the main timer for the interact event.
    IEnumerator StartTimer()
    {
        yield return new WaitForSeconds(timeChecker);
        interactableObject.OnInteractEnd.Invoke();
        HasInteracted = false; // Reset interaction after event triggers
        
    }

    private void OnDestroy()
    {
        if (interactableObject != null)
        {
            interactableObject.OnInteractWithObject -= SetClock;
        }
    }
}