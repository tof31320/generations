using UnityEngine;
using System.Collections;

public class DeathModifier : LifeModifier {

    public int deathAge = 100;

	public DeathModifier(Person person) : base(person)
    {        
        deathAge = Random.Range(40, 120);

        Debug.Log("Age de fin: " + deathAge);
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        if (person.age > deathAge - 10f
        && person.health > 0.9f)
        {
            person.health = 0.8f;
        }
        else if(person.age > deathAge)
        {
            person.health = 0f;
        }
    }
}
