using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class GameManager : MonoBehaviour
{
    // Singleton Instance of the GameManager.
    public static GameManager Instance { get; private set;}

    private void Awake() {
        InitializateComponents();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InitializateComponents()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        } 

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
