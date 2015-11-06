using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Person : MonoBehaviour, GameObjectUpdatable, TreeLayoutElement
{
    public Node node = null;

    public Person parentA = null;

    public Person parentB = null;

    public string personName = null;

    public int naissance = 0;

    public bool dead = false;

    public List<LifeModifier> modifiers = null;

    public float layoutWidth = 1f;

    private Sprite _avatar = null;
    public Sprite avatar
    {
        get
        {
            return _avatar;
        }
        set
        {
            _avatar = value;
            GetComponent<SpriteRenderer>().sprite = _avatar;
        }
    }

    public enum MariageState
    {
        MARRIED,
        SINGLE,
        DIVORCED,
        WIDOWER
    }
    public MariageState state = MariageState.SINGLE;

    public enum Sexe
    {
        MALE,
        FEMALE,
        NONE
    }
    public Sexe sexe = Sexe.MALE;

    public int age
    {
        get
        {
            return GameController.instance.annee - naissance;
        }
    }

    public float health = 1f;

    public void Start()
    {
        if (transform.parent != null)
        {
            node = transform.parent.GetComponent<Node>();
        }        
        modifiers = new List<LifeModifier>();

        AddDefaultModifiers();
    }

    void AddDefaultModifiers()
    {
        modifiers.Add(new DeathModifier(this));
    }

    public void OnUpdateGame()
    {
        for (int i = 0; i < modifiers.Count; i++)
        {
            modifiers[i].OnUpdate();
        }
    }
    
    public void Death()
    {
        Debug.Log(node.name + " est mort(e) !");
        //node.OnDeath();
    }

    public void CheckHealth()
    {
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

    public void Update()
    {
        CheckHealth();
    }

    public void Layout(Node parent)
    {
        transform.position = parent.transform.position;
    }

    public Transform GetTransform()
    {
        return transform;
    }

    public float GetLayoutWidth()
    {
        return layoutWidth;
    }

    public float GetLayoutHeight()
    {
        return TreeLayout.GAPSIZE_H;
    }
}
