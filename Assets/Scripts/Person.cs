using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Person : MonoBehaviour, GameObjectUpdatable, TreeLayoutElement
{
    public Family family = null;

    public Node node = null;

    public Person parentA = null;

    public Person parentB = null;

    public string personName = null;

    public int naissance = 0;

    public bool dead = false;

    public List<LifeModifier> modifiers = null;

    public float layoutWidth = 1f;

    public SpriteRenderer spriteRenderer = null;

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

    private Color _color = Color.white;
    public Color color
    {
        get { return _color; }
        set
        {
            _color = value;
        }
    }

    public float health = 1f;

    public void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (transform.parent != null)
        {
            node = transform.parent.GetComponent<Node>();
        }        
        modifiers = new List<LifeModifier>();

        AddDefaultModifiers();

        GameController.instance.RegisterUpdatableObject(this);
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
        color = Color.black;
        //Debug.Log(node.name + " est mort(e) !");
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

        // gestion de la couleur du sprite
        spriteRenderer.color = Color.Lerp(spriteRenderer.color, color, 0.1f);
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
