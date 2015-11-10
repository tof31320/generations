using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NewFamilyMenuController : MonoBehaviour, Menu {

    public GameObject newFamilyGameObject = null;

    public MenuManager menuManager = null;

    public InputField familyNameInput = null;

    public InputField rootName = null;

    public Sprite defaultAvatar = null;

    public void Awake()
    {
        menuManager = GameObject.Find("Canvas").GetComponent<MenuManager>();
    }

	public string GetMenuName()
    {
        return "newFamily";
    }

    public GameObject GetGameObject()
    {
        return gameObject;
    }

    public void Back()
    {
        menuManager.ShowMenu(menuManager.mainMenu);
    }

    public void Play()
    {
        // Vérif form

        // Init
        InitGame();

        Application.LoadLevel(1);
    }

    public void InitGame()
    {
        GameObject g = Instantiate(newFamilyGameObject, Vector3.zero, Quaternion.identity) as GameObject;
        g.name = "NewFamilyDetails";
        Family family = g.GetComponent<Family>();

        family.lastName = familyNameInput.text;
        family.ancesterName = rootName.text;
        family.ancesterAvatar = defaultAvatar;
        family.ancesterSexe = Person.Sexe.MALE;
    }

    public void OnShow()
    {
        familyNameInput.Select();
    }
}
