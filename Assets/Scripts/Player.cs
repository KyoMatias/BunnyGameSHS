using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Camera playerCam;
    [SerializeField] private string CharacterName;
    [SerializeField] private float health;
    [SerializeField] private float stamina;
    [SerializeField] private float interactDistance = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InteractBind();
    }

    public void InteractBind()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            PlayerInteract();
        }
    }

    public void PlayerInteract()
    {
        var layermask0 = 1 << 0;
        var layermask3 = 1 << 8;
        var finalmask = layermask0 | layermask3;
        
        RaycastHit hit;
        Ray ray = playerCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        
        if (Physics.Raycast(ray, out hit, interactDistance,finalmask))
        {
            Interact interactScript = hit.transform.GetComponent<Interact>();
            if (interactScript)
            {
                interactScript.CallInteract(this);
            }
        }
    }
}
