using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Node : MonoBehaviour {

    public Node parent = null;

    public List<Node> children = null;

    public float width = 1f;
    public float height = 1f;

    public float childrenWidth = 0f;

	// Use this for initialization
	void Start () {        
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    public void LayoutChildren(TreeLayout layout)
    {
        float y = transform.position.y - TreeLayout.GAPSIZE_H - height;

        if (children.Count == 0)
        {
            return;

        }
        else
        {
            childrenWidth = GetLayoutWidth();

            Vector3 next = new Vector3(transform.position.x, y, transform.position.z);
            float step = childrenWidth / children.Count;
           
            for (int i = 0; i < children.Count; i++)
            {
                children[i].transform.position = new Vector3(next.x + step * i, next.y, next.z);

                children[i].LayoutChildren(layout);
            }
        }
    }

    public float GetLayoutWidth()
    {
        if (children.Count == 0)
        {
            return width;
        }
        else
        {
            float _width = width;
            for(int i = 0; i < children.Count; i++)
            {
                _width += children[i].GetLayoutWidth();
            }
            //_width += (children.Count - 1) * TreeLayout.GAPSIZE_W;

            return _width;
        }
    }

    public void UpdateChildrenNodes()
    {
        children = new List<Node>();

        for(int i = 0; i < transform.childCount; i++)
        {
            Node child = transform.GetChild(i).GetComponent<Node>();
            if(child != null)
            {
                children.Add(child);

                child.parent = this;
                child.UpdateChildrenNodes();
            }
        }
    }
}
