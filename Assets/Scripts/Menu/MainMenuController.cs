using UnityEngine;
using System.Collections;

public class MainMenuController : MonoBehaviour, Menu {

    private MenuManager menuManager = null;

    public void Awake()
    {
        menuManager = GameObject.Find("Canvas").GetComponent<MenuManager>();
    }

    public string GetMenuName()
    {
        return "main";
    }

    public GameObject GetGameObject()
    {
        return gameObject;
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void NewGame()
    {
        menuManager.ShowMenu(menuManager.newFamilyMenu);
    }

    public void LoadGame()
    {

    }

    public void DisplayOptions()
    {

    }

    public void DisplayCredits()
    {

    }
    
    public void ExitGame()
    {
        Application.Quit();
    }

    public void OnShow()
    {

    }
}
