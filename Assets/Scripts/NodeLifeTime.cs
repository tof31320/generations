using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NodeLifeTime : MonoBehaviour {

    public int naissance = 0;

    public Node node = null;

    public bool dead = false;

    public enum MariageState
    {
        MARRIED,
        SINGLE,
        DIVORCED,
        WIDOWER
    }
    public MariageState state = MariageState.SINGLE;

    public int age
    {
        get
        {
            return GameController.instance.annee - naissance;
        }
    }

    public float health = 1f;

    public List<LifeModifier> modifiers = null;

	// Use this for initialization
	void Start () {
        node = GetComponent<Node>();

        // Les modificateurs 
        modifiers = new List<LifeModifier>();

        AddDefaultModifiers();
    }

    void AddDefaultModifiers()
    {
        modifiers.Add(new DeathModifier(this));
    }
	
	// Update is called once per frame
	void Update () {

        if (health <= 0f)
        {
            health = 0f;

            if (!dead)
            {
                dead = true;

                Death();
            }
        }
	}

    public void OnUpdateGame()
    {
        for(int i = 0; i < modifiers.Count; i++)
        {
            modifiers[i].OnUpdate();
        }
    }

    public void Death()
    {
        Debug.Log(node.name + " est mort(e) !");
        node.OnDeath();
    }
}
