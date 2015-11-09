using UnityEngine;
using System;
using System.Collections.Generic;

public class EverybodyDeadDefeat : VictoryDefeat
{
    private bool enabled = true;

    public void SetEnabled(bool enabled)
    {
        this.enabled = enabled;
    }

    public bool Enabled()
    {
        return enabled;
    }

    public bool Check()
    {     
        return CheckIfDead(TreeLayout.instance.rootNode);
    }

    private bool CheckIfDead(Node node)
    {
        for(int i = 0; i < node.children.Count; i++)
        {
            bool dead = CheckIfDead(node.children[i]);
            if (!dead)
            {
                return false;
            }
        }

        if (node.element is Couple)
        {
            return ((Couple)node.element).personA.dead && ((Couple)node.element).personB.dead;
        }
        else
        {
            return ((Person)node.element).dead;
        }
    }
}