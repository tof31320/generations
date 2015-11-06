using UnityEngine;
using System.Collections;

public class Avatars : MonoBehaviour {

    public Sprite[] spritesMales;
    public Sprite[] spritesFemales;

    public Sprite RandomAvatar(Person.Sexe sexe = Person.Sexe.NONE)
    {
        if (sexe == Person.Sexe.NONE)
        {
            if (Random.value * 100 % 2 == 0)
            {
                sexe = Person.Sexe.MALE;
            }
            else
            {
                sexe = Person.Sexe.FEMALE;
            }
        }

        if (sexe == Person.Sexe.MALE)
        {
            return RandomSprite(spritesMales);
        }else
        {
            return RandomSprite(spritesFemales);
        }       
    }

    private Sprite RandomSprite(Sprite[] sprites)
    {
        if (sprites.Length == 0)
        {
            return null;
        }

        int index = Random.Range(0, sprites.Length);
        return sprites[index];
    }
}
