using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void ButtonTest()
    {
        Debug.Log("Button Has Been Pressed");
    }

    public void MenuButton(string buttonName)
    {
        Debug.Log($"Button: {buttonName} is Clicked");
    }

}
