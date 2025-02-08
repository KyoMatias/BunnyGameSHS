using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using NaughtyAttributes;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private CameraLook camLook;
    [SerializeField] private Movement movement;
    
    public enum PlayerPhase
    {
        Free,
        Standing,
        Walking,
        Running,
        InChase,
        Fatigued,
        Stunned,
        Spooked,
        Scared,
        Dead,
    }

    [SerializeField] private PlayerPhase Phase;

    #region ManagerSingleton

    [Header("Camera Settings")]
    private bool CamLock;

    [Button]
    public void EnableLock()
    {
        CamLock = true;
    }

    [Button]
    public void DisableLock()
    {
        CamLock = false;
    }

    [Header("Player Settings")]
    private static PlayerManager _instance;
    public static PlayerManager Instance
    {
        get
        {
            if( _instance == null )
            {
                Debug.LogError("PlayerManager Not Found");
            }
            return _instance;
        }
    }
    #endregion
    private void Awake() {
        if(_instance)
        {
            Destroy(gameObject);
        }
        else 
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }
        camLook = GetComponent<CameraLook>();
        movement = GetComponent<Movement>();  
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CameraSetup();
        SelectPlayerPhase(Phase);
    }

    void SelectPlayerPhase(PlayerPhase phase)
    {
        switch(phase)
        {
            case PlayerPhase.Free:
            Debug.Log(phase);
            camLook.SetCamera(true);
            break;
            case PlayerPhase.Standing:
            Debug.Log(phase);
            break;
            default:
            camLook.SetCamera(true);
            break;
        }
    }

    void CameraSetup()
    {
        camLook.SetCamera(CamLock);
    }
}
