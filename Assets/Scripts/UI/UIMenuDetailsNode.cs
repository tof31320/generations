using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIMenuDetailsNode : UIMenu {

    private Node _node;
    public Node node
    {
        get { return _node; }
        set
        {
            _node = value;
            if (_node != null) {
                nodeLifeTime = node.GetComponent<NodeLifeTime>();
            }
            else
            {
                nodeLifeTime = null;
            }
        }
    }

    private NodeLifeTime nodeLifeTime = null;
   
    public Text txtAge;
    public Text txtHealth;

	// Use this for initialization
	void Start () {
        rectTransform = GetComponent<RectTransform>();
    }  
	
	// Update is called once per frame
	void Update () {
        UpdateMenu();

        if (nodeLifeTime != null)
        {
            txtTitle.text = nodeLifeTime.node.nodeName;
            txtAge.text = nodeLifeTime.age + " ans";
            txtHealth.text = nodeLifeTime.health * 100.0f + "%";
        }
	}
}
