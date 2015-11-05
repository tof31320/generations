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
        return false;
    }
}