using UnityEngine;

public class UIControllerPrincipal : MonoBehaviour
{
    public GameObject uiMenu;
    public GameObject uiGameplay;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ActivarMenu();  //Al inciar, mostramos Menu
    }

    public void ActivarMenu()
    {
        uiMenu.SetActive(true);
        uiGameplay.SetActive(false);
    }
    public void ActivarGameplay()
    {
        uiMenu.SetActive(false);
        uiGameplay.SetActive(true);
    }
}
