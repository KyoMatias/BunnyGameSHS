using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class GameManager : MonoBehaviour
{
    //Master Game Manager
    
    /*
    * Script is already has a Singleton Instance, therefore the script is on DontDestroy().
    
    GameManager Functions
    
    -Connect to every other manager in the game.
    -Get the current and active variables for references.
    -Control the flow of the game.
    */
    
    [Header(("Manager Components"))]
    public InteractableManager interactableManager;
    public MenuManager menuManager;
    public DialogueManager dialogueManager;
    
    
    
    
    
    // Singleton Instance of the GameManager.
    public static GameManager Instance { get; private set;}

	//Connects to the Main Player Prefab. must be flexible to make it expand to its other components    
    public GameObject PlayerBase;

    public float CutsceneDuration;//remove this shit

	[Header("Player Settings")]
	public static string PlayerName;
	public static int PlayerID;
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