using UnityEngine;
using System.Collections;

public class Family : MonoBehaviour {

    public string lastName = null;

    public string ancesterName = null;

    public Sprite ancesterAvatar = null;

    public Person.Sexe ancesterSexe = Person.Sexe.MALE;

    public void Awake()
    {
        DontDestroyOnLoad(this);        
    }    
}
