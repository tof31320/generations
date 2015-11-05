using UnityEngine;
using System.Collections;

public class Couple : MonoBehaviour, GameObjectUpdatable, TreeLayoutElement
{
    public Person personA = null;

    public Person personB = null;

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
        personA.transform.position = new Vector3(parent.transform.position.x - 1,
                                                 parent.transform.position.y,
                                                 parent.transform.position.z);

        personB.transform.position = new Vector3(parent.transform.position.x + 1,
                                                 parent.transform.position.y,
                                                 parent.transform.position.z);
    }
}
