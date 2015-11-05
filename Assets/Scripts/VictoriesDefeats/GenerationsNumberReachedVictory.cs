using System;
using System.Collections.Generic;

public class GenerationsNumberReachedVictory : VictoryDefeat
{
    public GameController gameController;

    public int nbGenerationsToReach = 9999;

    private bool enabled = true;

    public GenerationsNumberReachedVictory(GameController gameController, int nbGenerations)
    {
        this.gameController = gameController;
        this.nbGenerationsToReach = nbGenerations;
    }

    public bool Check()
    {
        return gameController.generation > nbGenerationsToReach;
    }

    public void SetEnabled(bool enabled)
    {
        this.enabled = enabled;
    }

    public bool Enabled()
    {
        return enabled;
    }
}

