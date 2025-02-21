using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ITurnstile : MonoBehaviour
{
    // Other Code Shit
    // Player interacts with scanner
    // flaps open
    //after 5 seconds, flaps close and the turnstile is ready again.

    public Interact openGate;
    [SerializeField] private InteractableObject IObject;

    private void OnEnable()
    {
        if (openGate)
        {
            openGate.GetInteractEvent.HasInteracted += OpenTurnstile;
        }
    }


    private void OnDisable()
    {
        if (openGate)
        {
            openGate.GetInteractEvent.HasInteracted -= OpenTurnstile;
        }
    }

    void Start()
    {
        Debug.Log("Layer Index: " + gameObject.layer);
        Debug.Log("Layer Name: " + LayerMask.LayerToName(gameObject.layer));
    }

    public void OpenTurnstile()
    {
        Debug.Log("Open Turnstile");
        IObject.OnInteract.Invoke();
    }
}

