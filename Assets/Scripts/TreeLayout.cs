using UnityEngine;
using System.Collections;

public class TreeLayout : MonoBehaviour {

    // Dimensions     
    public static float GAPSIZE_H = 0f;
    public static float GAPSIZE_W = 0f;

    public Node rootNode = null;

    void Start()
    {
        rootNode.UpdateChildrenNodes();
        rootNode.LayoutChildren(this);
    }

    public void UpdateLayout()
    {
        rootNode.LayoutChildren(this);
    }

    public void Update()
    {
        UpdateLayout();
    }
}
