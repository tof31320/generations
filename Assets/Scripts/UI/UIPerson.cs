using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIPerson : MonoBehaviour {

    public Person person = null;

    public Canvas canvas = null;

    public Text txtName = null;

    public Slider healthSlider;

    // Use this for initialization
    void Start () {
        person = GetComponent<Person>();
        canvas = GetComponentInChildren<Canvas>();
    }
	
	// Update is called once per frame
	void Update () {
        txtName.text = person.personName + (!person.dead ? " (" + person.age + ")" : "(Mort)");
        healthSlider.value = person.health;
    }
}
