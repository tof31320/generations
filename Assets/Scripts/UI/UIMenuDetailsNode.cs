using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIMenuDetailsNode : UIMenu {

    public Person person;
   
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
            txtTitle.text = person.personName;
            txtAge.text = person.age + " ans";
            txtHealth.text = person.health * 100.0f + "%";
        }
	}
}
