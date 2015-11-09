using UnityEngine;
using System.Collections;

public class Link : MonoBehaviour {

    public LineRenderer lineRenderer;

    private Node _nodeA = null;
    private Node _nodeB = null;

    public Node nodeA {
        get { return _nodeA; }
        set
        {
            _nodeA = value;
            if (_nodeA != null)
            {
                lineRenderer.SetPosition(0, _nodeA.transform.position);
            }
        }
    }

    public Node nodeB
    {
        get { return _nodeB; }
        set
        {
            _nodeB = value;
            if (_nodeB != null)
            {
                lineRenderer.SetPosition(1, _nodeA.transform.position);
            }
        }
    }

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

	// Update is called once per frame
	void Update () {

        if (nodeA != null && nodeB != null)
        {
            lineRenderer.SetPosition(0, nodeA.transform.position);
            lineRenderer.SetPosition(1, nodeB.transform.position);
        }
    }
}
