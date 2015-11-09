using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class VictoryDefeatManager : MonoBehaviour {

    public List<VictoryDefeat> victories = null;

    public List<VictoryDefeat> defeats = null;

    public void StartCheckVictoryAndDefeat()
    {
        victories = new List<VictoryDefeat>();
        victories.Add(new GenerationsNumberReachedVictory(GameController.instance, 10));

        defeats = new List<VictoryDefeat>();
        defeats.Add(new EverybodyDeadDefeat());

        StartCoroutine("CheckVictoriesAndDefeats");
    }

    public void StopCheckVictoryAndDefeat()
    {
        StopCoroutine("CheckVictoriesAndDefeats");
    }

    IEnumerator CheckVictoriesAndDefeats()
    {
        while (true)
        {            
            for (int i = 0; i < defeats.Count; i++)
            {
                if (defeats[i].Check())
                {
                    GameController.instance.Defeat(defeats[i]);
                }
                yield return new WaitForEndOfFrame();
            }
            for (int i = 0; i < victories.Count; i++)
            {
                if (victories[i].Check())
                {
                    GameController.instance.Victory(victories[i]);
                }
                yield return new WaitForEndOfFrame();
            }
        }
    }

	// Update is called once per frame
	void Update () {
	
	}
}
