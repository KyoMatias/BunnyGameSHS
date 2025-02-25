using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class InteractableObject : MonoBehaviour
{
    public string Message;
    
    public UnityEvent OnInteract;
    public UnityEvent OnInteractEnd;
    public event Action<bool> OnInteractWithObject;
    public float postInteractionTimer;
    [SerializeField]private float mainTimer;
    [SerializeField] private bool isInteracting;

    private void Start()
    {
        isInteracting = false;
    }

    public void Interact()
    {
        OnInteract.Invoke();
        OnInteractWithObject.Invoke(true);
    }

    public void TickInteract()
    {
        isInteracting = true;
    }
    private void Update()
    {
        if (isInteracting)
        {
            mainTimer += Time.deltaTime;
            if (mainTimer >= postInteractionTimer)
            {
                EndInteraction();
                mainTimer = 0;
            }
        }
    }

    [ContextMenu("EndInteraction")]
    public void EndInteraction()
    {
        isInteracting = false;
        OnInteractEnd.Invoke();
    }




    public void ShowHover()
    {
        Debug.Log("Object is Interactable");
    }

    public void HideHover()
    {
        Debug.Log("Object is No Longer interactable");
    }
    
}
