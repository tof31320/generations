using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RandomNames {

    private static List<string> names = new List<string>();   

    static RandomNames(){
        names.Add("Léon");
        names.Add("Albert");
        names.Add("Paul");
        names.Add("Eric");
        names.Add("Jean");
        names.Add("Max");
        names.Add("Joe");
        names.Add("Franck");
        names.Add("José");
        names.Add("Antoine");
    }

    public static string PickName()
    {
        if (names.Count == 0)
        {
            return "Anonyme";
        }

        int index = Random.Range(0, names.Count - 1);

        return names[index];
    }
}
