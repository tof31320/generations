using UnityEngine;
using System.Collections;

public class RandomModel : MonoBehaviour {

    public GameObject personGameObject;
    public GameObject coupleGameObject;
    public Avatars avatars;

    private static RandomModel _instance = null;
    public static RandomModel instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindGameObjectWithTag("RandomModel").GetComponent<RandomModel>();
            }
            return _instance;
        }
    }

    public Person RandomPerson(Person parentA, Person parentB)
    {
        /*GameObject g = Instantiate(personGameObject, Vector3.zero, Quaternion.identity) as GameObject;

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
        */
        Person.Sexe sexe = RandomSexe();

        Person person = CreatePerson(parentA, parentB, RandomNames.PickName(sexe), avatars.RandomAvatar(sexe), sexe);
        
        return person;
    }

    public Person.Sexe RandomSexe()
    {
        if (Random.Range(-1, 1) >= 0)
        {
            return Person.Sexe.MALE;
        }
        else
        {
            return Person.Sexe.FEMALE;
        }
    }

    public Couple RandomCouple()
    {        
        return CreateCouple(RandomPerson(null, null), RandomPerson(null, null));
    }

    public Person CreatePerson(Person parentA, Person parentB, string name = null, Sprite avatar = null, Person.Sexe sexe = Person.Sexe.MALE)
    {
        GameObject g = Instantiate(personGameObject, Vector3.zero, Quaternion.identity) as GameObject;

        Person person = g.GetComponent<Person>();
        person.parentA = parentA;
        person.parentB = parentB;

       
        person.sexe = sexe;
        if (name == null)
        {
            person.personName = RandomNames.PickName(person.sexe);
        }
        else
        {
            person.personName = name;
        }
        if (avatar == null)
        {
            person.avatar = avatars.RandomAvatar(person.sexe);
        }
        else
        {
            person.avatar = avatar;
        }        
        person.naissance = GameController.instance.annee;

        return person;
    }

    public Couple CreateCouple(Person a, Person b)
    {
        GameObject g = Instantiate(coupleGameObject, Vector3.zero, Quaternion.identity) as GameObject;

        Couple couple = g.GetComponent<Couple>();
        couple.personA = a;
        couple.personB = b;

        return couple;
    }
}
