using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Node : MonoBehaviour
{
    private Node _parent = null;
    public Node parent
    {
        get { return _parent; }
        set
        {
            _parent = value;
            if (_parent != null)
            {
                transform.parent = _parent.transform;
            }
        }
    }

    public List<Node> children = null;

    private TreeLayoutElement _element;
    public TreeLayoutElement element {
        get { return _element; }
        set
        {
            _element = value;
            _element.GetTransform().parent = transform;
            _element.GetTransform().localPosition = Vector3.zero;
            _element.SetNode(this);

            TreeLayout.instance.updateRequired = true;
        }
    }

    public float childrenWidth = 0f;

    private List<GameObject> links = null;

    public void AddNodeChild(Node child)
    {
        child.parent = this;

        TreeLayout.instance.updateRequired = true;
    }

    public void ClearLinks()
    {
        for (int i = 0; links != null && i < links.Count; i++)
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
            /*Link link = ln.GetComponent<Link>();
            link.nodeA = this;
            link.nodeB = children[i];*/

            children[i].CreateLinksWithChildren(linkGameObject);
        }
    }

    public void LayoutWithChildren(TreeLayout layout)
    {
        element.Layout(this);

        float y = transform.position.y - element.GetLayoutHeight();

        Vector3 next = new Vector3(transform.position.x, y, transform.position.z);
        if (children.Count == 0)
        {
            return;
        }
        else
        {
            for (int i = 0; i < children.Count; i++)
            {
                children[i].transform.position = next;

                next = new Vector3(next.x + children[i].GetLayoutWidth(), next.y, next.z);

                children[i].LayoutWithChildren(layout);
            }
        }
    }

    public float GetLayoutWidth()
    {
        if (children.Count == 0)
        {
            return element.GetLayoutWidth();
        }
        else
        {
            float _width = element.GetLayoutWidth();
            for (int i = 0; i < children.Count; i++)
            {
                _width += children[i].GetLayoutWidth();
            }

            return _width;
        }
    }

    public void UpdateChildrenNodes()
    {
        children = new List<Node>();

        for (int i = 0; i < transform.childCount; i++)
        {
            Node child = transform.GetChild(i).GetComponent<Node>();
            if (child != null)
            {
                children.Add(child);

                child.parent = this;
                child.UpdateChildrenNodes();
            }
        }
    }
}
