using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NodeUIManager : MonoBehaviour {

    public Node node = null;

    public NodeLifeTime nodeLife = null;

    public Canvas canvas = null;

    public Text txtName = null;

    public Slider healthSlider;

	// Use this for initialization
	void Start () {
        node = GetComponent<Node>();
        nodeLife = node.GetComponent<NodeLifeTime>();
        canvas = GetComponentInChildren<Canvas>();        
    }
	
	// Update is called once per frame
	void Update () {
        txtName.text = node.name + (!nodeLife.dead ? " (" + nodeLife.age + ")" : "(Mort)");
        healthSlider.value = nodeLife.health;         

        txtName.text = node.name + " (" + nodeLife.age + ")";        

    }
}
