using UnityEngine;
using System.Collections;

public class Couple : MonoBehaviour, GameObjectUpdatable
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
}
