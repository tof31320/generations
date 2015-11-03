using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Node : MonoBehaviour, GameObjectUpdatable {

    public string name = "";

    public Node parent = null;

    public List<Node> children = null;

    public float width = 1f;
    public float height = 1f;

    public float childrenWidth = 0f;

    private List<GameObject> links = null;

    public NodeLifeTime nodeLifeTime = null;

    private Color _spriteColor = Color.white;
    private SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Awake () {        
        nodeLifeTime = GetComponent<NodeLifeTime>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        GameController.instance.RegisterUpdatableObject(this);
    }

    public void SetSpriteColor(Color color)
    {
        _spriteColor = color;
    }

    public void OnDeath()
    {
        GameController.instance.UnregisterUpdatableObject(this);
        SetSpriteColor(Color.black);
	}	

    void OnDestroy()
    {
        GameController.instance.UnregisterUpdatableObject(this);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (_spriteColor != spriteRenderer.color)
        {
            spriteRenderer.color = Color.Lerp(spriteRenderer.color, _spriteColor, 0.1f);
        }
    }

    public void ClearLinks()
    {
        for(int i = 0; links != null && i < links.Count; i++)
        {
            Destroy(links[i]);
        }
    }

    public void CreateLinksWithChildren(GameObject linkGameObject)
    {
        ClearLinks();

        links = new List<GameObject>();

        for (int i = 0; i < children.Count; i++)
        {
            GameObject ln = Instantiate(linkGameObject, transform.position, Quaternion.identity) as GameObject;
            links.Add(ln);

            LineRenderer lineRenderer = ln.GetComponent<LineRenderer>();            
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, children[i].transform.position);            

            children[i].CreateLinksWithChildren(linkGameObject);
        }
    }

    public void LayoutChildren(TreeLayout layout)
    {
        float y = transform.position.y - TreeLayout.GAPSIZE_H - height;

        Vector3 next = new Vector3(transform.position.x, y, transform.position.z);

        if (children.Count == 0)
        {
            return;

        }
        else
        {
            for(int i = 0; i < children.Count; i++)
            {
                children[i].transform.position = next;

                next = new Vector3(next.x + children[i].GetLayoutWidth() + TreeLayout.GAPSIZE_W, next.y, next.z);
                
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

    public void OnUpdateGame()
    {
        nodeLifeTime.OnUpdateGame();
    }
}
