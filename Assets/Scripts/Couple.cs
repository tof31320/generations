using UnityEngine;
using System.Collections;

public class Couple : MonoBehaviour, GameObjectUpdatable, TreeLayoutElement
{
    public Node node = null;

    private Person _personA = null;
    public Person personA
    {
        get { return _personA; }
        set
        {
            _personA = value;
            if (_personA != null)
            {
                _personA.state = Person.MariageState.MARRIED;
                _personA.transform.parent = transform;
            }
        }
    }

    private Person _personB = null;
    public Person personB
    {
        get { return _personB; }
        set
        {
            _personB = value;
            if (_personB != null)
            {
                _personB.state = Person.MariageState.MARRIED;
                _personB.transform.parent = transform;
            }
        }
    }

    public float layoutWidth = 2f;
    public float layoutGapSize = 1f;

    public SpriteRenderer spriteRenderer;

    public void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        GameController.instance.RegisterUpdatableObject(this);
    }

    void OnDestroy()
    {
        if (GameObject.FindGameObjectWithTag("GameController") != null) {
            GameController.instance.UnregisterUpdatableObject(this);
        }
    }

    public void OnUpdateGame()
    {

    }

    public void Layout(Node parent)
    {
        personA.transform.position = new Vector3(parent.transform.position.x - (layoutGapSize / 2f),
                                                 parent.transform.position.y,
                                                 parent.transform.position.z);

        personB.transform.position = new Vector3(parent.transform.position.x + (layoutGapSize / 2f),
                                                 parent.transform.position.y,
                                                 parent.transform.position.z); 
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
