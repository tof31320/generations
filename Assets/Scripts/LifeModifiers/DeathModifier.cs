using UnityEngine;
using System.Collections;

public class DeathModifier : LifeModifier {

    public int deathAge = 100;

	public DeathModifier(NodeLifeTime node) : base(node)
    {
        nodeLife = node;

        deathAge = Random.Range(40, 120);

        Debug.Log("Age de fin: " + deathAge);
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        if (nodeLife.age > deathAge - 10f
        && nodeLife.health > 0.9f)
        {
            nodeLife.health = 0.8f;
        }
        else if(nodeLife.age > deathAge)
        {
            nodeLife.health = 0f;
        }
    }
}
