using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using Unity.VisualScripting;
using UnityEngine;

public class ScreenSwap : MonoBehaviour
{
    [Header("Screen Settings")]
    [SerializeField] private GameObject _tapScreen;
    [SerializeField] private GameObject _balanceScreen;
    
    [Header("Arrow Settings")]
    [SerializeField] private GameObject _greenArrow;
    [SerializeField] private GameObject _redArrow;

    public enum ScreenState
    {
        Tap,
        Balance,
        Deny,
    }

    public ScreenState SState;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //SwitchScreen();
    }

    [Button]
    public void TapScreen()
    {
        SwitchScreen(ScreenState.Tap);
    }

    [Button]
    public void BalanceScreen()
    {
        SwitchScreen(ScreenState.Balance);
    }

    public void SwitchScreen(ScreenState screenState)
    {
        SState = screenState;
        switch (SState)
        {
            case ScreenState.Tap:
            _tapScreen.SetActive(true);
            _balanceScreen.SetActive(false);
            _greenArrow.SetActive(false);
            _redArrow.SetActive(true);
            break;
            case ScreenState.Balance:
            _balanceScreen.SetActive(true);
            _tapScreen.SetActive(false);
            _greenArrow.SetActive(true);
            _redArrow.SetActive(false);
            
            break ;
            default:
            _tapScreen.SetActive(true);
            _balanceScreen.SetActive(false) ;
            
            break ;
        }
    }

}
