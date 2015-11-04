using UnityEngine;
using System.Collections;

public class UIMenuManager : MonoBehaviour {

    public static float SwapMenuSpeed = 0.2f;

    public UIMenuDetailsNode detailsNodeMenu;

    private UIMenu _activeMenu = null;
    public UIMenu activeMenu
    {
        get { return _activeMenu; }
        set
        {
            if (_activeMenu != null)
            {
                _activeMenu.show = false;
            }
            _activeMenu = value;
            _activeMenu.show = true;
        }
    }
}
