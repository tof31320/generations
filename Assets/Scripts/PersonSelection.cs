using UnityEngine;
using System.Collections;

public class PersonSelection : MonoBehaviour {

    public Person person = null;

    public SpriteRenderer selectionSpriteRenderer;

    private bool _selected = false;
    public bool selected
    {
        get { return _selected; }
        set
        {
            _selected = value;
        }
    }

    void Start()
    {
        person = GetComponent<Person>();
    }

    // Update is called once per frame
    void Update()
    {
        if (selected && !selectionSpriteRenderer.enabled)
        {
            selectionSpriteRenderer.enabled = true;

        }
        else if (!selected && selectionSpriteRenderer.enabled)
        {
            selectionSpriteRenderer.enabled = false;
        }
    }

    public void OnMouseOver()
    {
        selected = true;
    }

    public void OnMouseExit()
    {
        if (GameController.instance.personSelected == null
        || GameController.instance.personSelected != person)
        {
            selected = false;
        }
    }

    public void OnMouseDown()
    {
        GameController.instance.personSelected = person;
    }
}
