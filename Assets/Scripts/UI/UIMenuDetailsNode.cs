using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIMenuDetailsNode : UIMenu {

    public Person person
    {
        get { return personPanel.person; }
        set
        {
            personPanel.person = value;
            updateRequired = true;
        }
    }

    public bool updateRequired = false;

    public UIPersonPanel personPanel;   

    public Button btnUnion;

	// Use this for initialization
	void Start () {
        rectTransform = GetComponent<RectTransform>();
    }  
	
	// Update is called once per frame
	void Update () {
        UpdateMenu();

        

        if (updateRequired && person != null)
        {
            Debug.Log("UpdatePanel..");
            btnUnion.interactable = person.state == Person.MariageState.SINGLE || person.state == Person.MariageState.DIVORCED;
            updateRequired = false;
        }        
	}    

    public void MakeUnion()
    {
        bool pauseStateBeforeDisplay = GameController.instance.pause;
        /*Person random = RandomModel.instance.RandomPerson(null, null);
        
        GameController.instance.MakeUnionWith(person, random);*/
        GameController.instance.pause = true;

        UIUnionPanelController.instance.visible = true;
        UIUnionPanelController.instance.personSelected = person;
    }
}
