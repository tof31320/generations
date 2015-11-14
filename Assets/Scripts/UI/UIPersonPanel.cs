using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIPersonPanel : MonoBehaviour {

    private Person _person = null;
    public Person person
    {
        get { return _person; }
        set
        {
            _person = value;

            UpdatePanel();
        }
    }

    public Text txtName;
    public Image avatar;
    public Text txtAge;
    public Slider healthBar;

    public void UpdatePanel()
    {
        if (person == null)
        {
            return;
        }

        txtName.text = person.personName + " " + person.family.lastName;
        avatar.sprite = person.avatar;
        txtAge.text = person.age + "";
        healthBar.value = person.health;
    }
}
