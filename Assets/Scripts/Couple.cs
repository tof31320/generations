using UnityEngine;
using System.Collections;

public class Couple : MonoBehaviour, GameObjectUpdatable, TreeLayoutElement
{
    public Person personA = null;

    public Person personB = null;

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
        GameController.instance.UnregisterUpdatableObject(this);
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
