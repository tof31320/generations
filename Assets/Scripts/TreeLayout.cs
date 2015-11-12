using UnityEngine;
using System.Collections;

public class TreeLayout : MonoBehaviour {

    public GameObject nodeGameObject;

    // Dimensions     
    public static float GAPSIZE_H = 2.5f;
    public static float GAPSIZE_W = 0f;

    public GameObject linkGameObject;

    public bool updateRequired = false;

    private Node _rootNode = null;
    public Node rootNode
    {
        get { return _rootNode; }
        set
        {
            _rootNode = value;
            if (_rootNode != null)
            {
                _rootNode.transform.parent = transform;
            }
        }
    }

    private static TreeLayout _instance;
    public static TreeLayout instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindGameObjectWithTag("Tree").GetComponent<TreeLayout>();
            }
            return _instance;
        }
        set
        {
            _instance = value;
        }
    }

    void Start()
    {
        if (rootNode == null)
        {
            rootNode = FindRootNode();
        }
        UpdateLayout();
    }   

    public Node FindRootNode()
    {        
        for(int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).GetComponent<Node>() != null)
            {
                return transform.GetChild(i).GetComponent<Node>();
            }
        }
        return null;
    }

    public Node CreateNode(Node parent, TreeLayoutElement element)
    {
        GameObject g = Instantiate(nodeGameObject, Vector3.zero, Quaternion.identity) as GameObject;

        Node node = g.GetComponent<Node>();
        node.parent = parent;
        node.element = element;        

        return node;
    }

    public void UpdateLayout()
    {
        if (rootNode != null) {
            rootNode.UpdateChildrenNodes();
            rootNode.LayoutWithChildren(this);
            rootNode.CreateLinksWithChildren(linkGameObject);

            updateRequired = false;
        }
    }

    public void Update()
    {
        //rootNode.UpdateChildrenNodes();


        if (updateRequired)
        {
            UpdateLayout();
        }        
    }
}
