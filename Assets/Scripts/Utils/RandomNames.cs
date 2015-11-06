using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RandomNames {

    private static List<string> namesMales = new List<string>();
    private static List<string> namesFemales = new List<string>();

    static RandomNames(){
        namesMales.Add("Léon");
        namesMales.Add("Albert");
        namesMales.Add("Paul");
        namesMales.Add("Eric");
        namesMales.Add("Jean");
        namesMales.Add("Max");
        namesMales.Add("Joe");
        namesMales.Add("Franck");
        namesMales.Add("José");
        namesMales.Add("Antoine");

        namesFemales.Add("Jessica");
        namesFemales.Add("Léa");
        namesFemales.Add("Pauline");
        namesFemales.Add("Patty");
        namesFemales.Add("Jenny");
        namesFemales.Add("Vanessa");
        namesFemales.Add("Sarah");
        namesFemales.Add("Margie");
        namesFemales.Add("Malo");
        namesFemales.Add("Antoinette");
    }

    public static string PickName(Person.Sexe sexe = Person.Sexe.MALE)
    {
        if (sexe == Person.Sexe.MALE)
        {
            return RandomName(namesMales);
        }
        else
        {
            return RandomName(namesFemales);
        }
    }

    private static string RandomName(List<string> names)
    {
        if (names.Count == 0)
        {
            return "Anonyme";
        }
        int index = Random.Range(0, names.Count);

        return names[index];
    }
}
