using UnityEngine;
using System.Collections;

public class NodeLifeTime : MonoBehaviour {

    public int naissance = 0;

    public Node node = null;

    public int age
    {
        get
        {
            return GameController.instance.annee - naissance;
        }
    }

    public float health = 1f;

	// Use this for initialization
	void Start () {
        node = GetComponent<Node>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
