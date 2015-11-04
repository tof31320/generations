using UnityEngine;
using System.Collections;

public class NodeSelection : MonoBehaviour {

    public Node node = null;

    public SpriteRenderer selectionSpriteRenderer;

    private bool _selected = false;
    public bool selected
    {
        get { return _selected; }
        set
        {
            _selected = value;
        }
    }
	
    void Start()
    {
        node = GetComponent<Node>();
    }   
	
	// Update is called once per frame
	void Update () {
        if (selected && !selectionSpriteRenderer.enabled)
        {
            selectionSpriteRenderer.enabled = true;

        }else if (!selected && selectionSpriteRenderer.enabled)
        {
            selectionSpriteRenderer.enabled = false;
        }
	}    

    public void OnMouseOver()
    {
        selected = true;
    }

    public void OnMouseExit()
    {
        if (GameController.instance.nodeSelected == null 
        || GameController.instance.nodeSelected != node) {
            selected = false;
        }
    }    

    public void OnMouseDown()
    {        
        GameController.instance.nodeSelected = node;        
    }
}
