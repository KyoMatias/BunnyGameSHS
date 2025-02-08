using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class GameManager : MonoBehaviour
{
    // Singleton Instance of the GameManager.
    public static GameManager Instance { get; private set;}
    
    public GameObject PlayerBase;
    public float CutsceneDuration;
    public static float PlayerHP;
    public static float SprintLength;
    public static bool Active;


    private void Awake() {
        InitializateSingleton();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InitializateSingleton()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        } 

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void StartGame(float playerHP, bool active)
    {
        
    }

    

}

//Create 