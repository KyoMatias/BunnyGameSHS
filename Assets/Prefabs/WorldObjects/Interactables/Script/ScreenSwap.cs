using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using Unity.VisualScripting;
using UnityEngine;

public class ScreenSwap : MonoBehaviour
{
    [SerializeField] private GameObject _tapScreen;
    [SerializeField] private GameObject _balanceScreen;

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
            break;
            case ScreenState.Balance:
            _balanceScreen.SetActive(true);
            _tapScreen.SetActive(false);
            break ;
            default:
            _tapScreen.SetActive(true);
            _balanceScreen.SetActive(false) ;
            break ;
        }
    }

}
