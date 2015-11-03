using UnityEngine;
using System.Collections;

public class NodeSelection : MonoBehaviour {

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
}
