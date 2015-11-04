using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour, GameObjectUpdatable {

    private static GameController _instance = null;    

    public int annee = 1;
    public int generation = 1;

    public GameSpeedUpdater gameSpeedManager;

    public UIMenuManager menuManager;

    void Awake()
    {
        gameSpeedManager = GetComponent<GameSpeedUpdater>();
        menuManager = GetComponent<UIMenuManager>();

        gameSpeedManager.RegisterObject(this);
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

    private Node _nodeSelected = null;
    public Node nodeSelected
    {
        get
        {
            return _nodeSelected;
        }
        set
        {
            if (_nodeSelected != null)
            {
                _nodeSelected.GetComponent<NodeSelection>().selected = false;
            }
            _nodeSelected = value;
			
            menuManager.detailsNodeMenu.node = _nodeSelected;
            menuManager.activeMenu = menuManager.detailsNodeMenu;
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

    public void OnUpdateGame()
    {
        annee++;        
    }
}
