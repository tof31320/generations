using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIMenuDetailsNode : UIMenu {

    public Person person;

    public Image avatar;

    public Text txtAge;
    public Text txtHealth;

    public Button btnUnion;

	// Use this for initialization
	void Start () {
        rectTransform = GetComponent<RectTransform>();
    }  
	
	// Update is called once per frame
	void Update () {
        UpdateMenu();

        if (person != null)
        {
            avatar.sprite = person.avatar;
            txtTitle.text = person.personName;
            txtAge.text = person.age + " ans";
            txtHealth.text = person.health * 100.0f + "%";

            btnUnion.interactable = person.state == Person.MariageState.SINGLE || person.state == Person.MariageState.DIVORCED;
        }
	}

    private Person RandomPerson()
    {         
        GameObject g = Instantiate(personGameObject, Vector3.zero, Quaternion.identity) as GameObject;

        Person person = g.GetComponent<Person>();
        person.parentA = parentA;
        person.parentB = parentB;

        person.sexe = RandomSexe();
        person.personName = RandomNames.PickName(person.sexe);
        person.avatar = avatars.RandomAvatar(person.sexe);

        if (parentA != null)
        {
            person.naissance = parentA.naissance + Random.Range(18, 40);
        }

        return person;
    }
}

    public void MakeUnion()
    {
        Person random = RandomPerson();

        GameController.instance.MakeUnionWith(person, random);
    }
}
