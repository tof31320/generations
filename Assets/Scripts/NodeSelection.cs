using UnityEngine;
using System.Collections;

public class NodeSelection : MonoBehaviour {

    public Node node = null;

    public SpriteRenderer selectionSpriteRenderer;
	
    void Start()
    {
        node = GetComponent<Node>();
    }

    public SpriteRenderer selectionSpriteRenderer;
	
	// Update is called once per frame
	void Update () {	
	}    

    public void OnMouseOver()
    {
        selectionSpriteRenderer.enabled = true;
    }

    public void OnMouseExit()
    {
        selectionSpriteRenderer.enabled = false;
    }

    public void OnMouseDown()
    {
        Debug.Log("OnMouseDown");
        GameController.instance.nodeSelected = node;
    }
}
