using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIMenuDetailsNode : UIMenu {

    public Person person;

    public Image avatar;

    public Text txtAge;
    public Text txtHealth;

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
        }
	}
}
