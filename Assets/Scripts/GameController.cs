using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour, GameObjectUpdatable {

    private static GameController _instance = null;

    public int ANNEE = 1800;
    public int annee = 1;
    public int generation = 1;

    public CameraController cameraController;
    public GameSpeedUpdater gameSpeedManager;
    public VictoryDefeatManager victoryManager;        

    public UIMenuManager menuManager;

    public Transform tree = null;
    public GameObject personGameObject;

    void Awake()
    {
        cameraController = Camera.main.GetComponent<CameraController>();
        gameSpeedManager = GetComponent<GameSpeedUpdater>();
        menuManager = GetComponent<UIMenuManager>();

        gameSpeedManager.RegisterObject(this);

        InitGame();
    }   

    public void InitGame()
    {
        GameObject familyGameObject = GameObject.Find("NewFamilyDetails");

        Family family = familyGameObject.GetComponent<Family>();

        GameObject ancester = Instantiate(personGameObject, Vector3.zero, Quaternion.identity) as GameObject;
        ancester.transform.parent = tree;

        Person p = ancester.GetComponent<Person>();
        p.personName = family.ancesterName;
        p.family = family;

        personSelected = p;

        victoryManager.StartCheckVictoryAndDefeat();
    }

    public static GameController instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
            }
            return _instance;
        }
        set { }
    }

    private Person _personSelected = null;
    public Person personSelected
    {
        get
        {
            return _personSelected;
        }
        set
        {
            if (_personSelected != null)
            {
                _personSelected.GetComponent<PersonSelection>().selected = false;
            }
            _personSelected = value;
			
            menuManager.detailsNodeMenu.person = _personSelected;
            menuManager.activeMenu = menuManager.detailsNodeMenu;

            cameraController.FocusOnNode(_personSelected);
        }
    }

    public bool pause
    {
        get { return gameSpeedManager.paused; }
        set
        {
            gameSpeedManager.paused = value;
        }
    }

    public float gameSpeed
    {
        get
        {
            return gameSpeedManager.gameSpeed;
        }
        set
        {
            gameSpeedManager.gameSpeed = value;
        }
    }

    public void RegisterUpdatableObject(GameObjectUpdatable updatable)
    {
        gameSpeedManager.RegisterObject(updatable);
    }

    public void UnregisterUpdatableObject(GameObjectUpdatable updatable)
    {
        gameSpeedManager.UnregisterObject(updatable);
    }

    public void Victory(VictoryDefeat victory)
    {
        Debug.Log("Victoire: " + victory);

        victoryManager.StopCheckVictoryAndDefeat();
    }

    public void Defeat(VictoryDefeat defeat)
    {
        Debug.Log("Defeat: " + defeat);

        victoryManager.StopCheckVictoryAndDefeat();
    }
    
    public void OnUpdateGame()
    {
        annee++;        
    }
}
