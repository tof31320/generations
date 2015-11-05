using UnityEngine;
using System.Collections;

public class TreeLayout : MonoBehaviour {

    // Dimensions     
    public static float GAPSIZE_H = 0f;
    public static float GAPSIZE_W = 0f;

    public GameObject linkGameObject;
    
    public Node rootNode = null;

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

    public void UpdateLayout()
    {
        if (rootNode != null) {
            rootNode.UpdateChildrenNodes();
            rootNode.LayoutWithChildren(this);
            rootNode.CreateLinksWithChildren(linkGameObject);
        }
    }

    public void Update()
    {
        //rootNode.UpdateChildrenNodes();


        if (Input.GetKeyDown(KeyCode.Space))
        {
            UpdateLayout();
        }        
    }
}
