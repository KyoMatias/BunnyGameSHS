using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateColliders : MonoBehaviour
{
    [SerializeField] private GameObject GOcollider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ColliderOpen()
    {
        GOcollider.gameObject.SetActive(false);
    }

    public void ColliderClose()
    {
        GOcollider.gameObject.SetActive(true);
    }
}
