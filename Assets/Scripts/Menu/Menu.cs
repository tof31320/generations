using UnityEngine;
using System;
using System.Collections.Generic;

public interface Menu
{
    string GetMenuName();

    GameObject GetGameObject();

    void OnShow();    
}

