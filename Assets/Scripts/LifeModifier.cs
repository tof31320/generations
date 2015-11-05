using UnityEngine;
using System.Collections;

public class LifeModifier {

    public Person person;

    public LifeModifier(Person person)
    {
        this.person = person;
    }

	public virtual void OnUpdate()
    {
    }
}
