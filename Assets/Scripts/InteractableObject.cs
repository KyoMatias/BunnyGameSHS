using System;
using System.Collections;
using System.Collections.Generic;
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
    
    public void Interact()
    {
        OnInteract.Invoke();
        OnInteractWithObject.Invoke(true);
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
