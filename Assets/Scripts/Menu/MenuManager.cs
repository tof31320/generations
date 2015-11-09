using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MenuManager : MonoBehaviour {

    public MainMenuController mainMenu = null;

    public NewFamilyMenuController newFamilyMenu = null;

    private Menu currentMenu = null;

	// Use this for initialization
	void Start () {
        HideMenu(newFamilyMenu);
        ShowMenu(mainMenu);
    }
	
	public void ShowMenu(Menu menu)
    {
        if (currentMenu != null)
        {
            currentMenu.GetGameObject().SetActive(false);
        }
        if (menu != null)
        {
            currentMenu = menu;
            menu.GetGameObject().SetActive(true);
            menu.OnShow();
        }
    }

    public void HideMenu(Menu menu = null)
    {
        if (menu == null && currentMenu != null)
        {
            currentMenu.GetGameObject().SetActive(false);

        }else if (menu != null)
        {
            menu.GetGameObject().SetActive(false);
        }
    }
}
