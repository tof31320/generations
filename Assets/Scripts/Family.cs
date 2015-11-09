using UnityEngine;
using System.Collections;

public class Family : MonoBehaviour {

    public string lastName = null;

    public string ancesterName = null;

    public void Awake()
    {
        DontDestroyOnLoad(this);        
    }    
}
