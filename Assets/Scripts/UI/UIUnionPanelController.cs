using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UIUnionPanelController : MonoBehaviour {

    public CanvasGroup canvasGroup;

    public UIPersonPanel personPanel = null;

    public Person personSelected
    {
        get { return personPanel.person; }
        set { personPanel.person = value; }
    }

    public void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        visible = false;
    }

    public bool visible
    {
        get { return canvasGroup.alpha > 0f; }
        set
        {
            if (value)
            {
                canvasGroup.alpha = 1f;
                canvasGroup.blocksRaycasts = true;
            }
            else
            {
                canvasGroup.alpha = 0f;
                canvasGroup.blocksRaycasts = false;
            }            
        }
    }

    public List<Person> persons = null;

    private static UIUnionPanelController _instance = null;

    public static UIUnionPanelController instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindGameObjectWithTag("UI_UnionPanel").GetComponent<UIUnionPanelController>();           
            }
            return _instance;
        }
    }    

    private void DestroyPersons()
    {
        if (persons == null)
        {
            return;
        }
        for(int i = 0; i < persons.Count; i++)
        {
            Person p = persons[i];
            Destroy(p.gameObject);
        }
    }

    private void FindPersons()
    {
        DestroyPersons();

        persons = new List<Person>();

        for(int i = 0; i < 4; i++)
        {
            persons.Add(RandomModel.instance.RandomPerson(null, null));
        }
    }
}
