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
        UpdateLayout();
    }   

    public void UpdateLayout()
    {
        if (rootNode != null) {
            rootNode.UpdateChildrenNodes();
            rootNode.LayoutChildren(this);
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
