using UnityEngine;
using System.Collections;

public class LifeModifier {

    public NodeLifeTime nodeLife;

    public LifeModifier(NodeLifeTime node)
    {
        this.nodeLife = node;
    }

	public virtual void OnUpdate()
    {

    }
}
