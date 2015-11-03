using UnityEngine;
using System.Collections.Generic;

public class GameSpeedUpdater : MonoBehaviour {

    public float gameSpeed = 0.5f;

    private float _lastUpdateTime = 0f;

    public bool paused = false;

    private List<GameObjectUpdatable> updatables = null;

    public void RegisterObject(GameObjectUpdatable updatable)
    {
        if (updatables == null)
        {
            updatables = new List<GameObjectUpdatable>();
        }
        if (!updatables.Contains(updatable)) {
            updatables.Add(updatable);
        }
    }

    public void UnregisterObject(GameObjectUpdatable updatable)
    {
        updatables.Remove(updatable);
    }
	
	// Update is called once per frame
	void Update () {

        if (paused)
        {
            _lastUpdateTime = Time.time;
        }

        if (Time.time - _lastUpdateTime > gameSpeed)
        {
            UpdateGame();
            _lastUpdateTime = Time.time;
        }
	}

    public void UpdateGame()
    {
        for(int i = 0; i < updatables.Count; i++)
        {
            updatables[i].OnUpdateGame();
        }
    }
}
