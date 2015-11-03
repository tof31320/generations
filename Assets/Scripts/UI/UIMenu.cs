using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIMenu : MonoBehaviour {

    public string title = "";

    public Vector2 hiddenPosition = Vector2.zero;
    public Vector2 shownPosition = Vector2.zero;

    public Text txtTitle;
    public RectTransform rectTransform;

    public bool show = false;

	// Use this for initialization
	void Start () {       
        hiddenPosition = transform.position;
	}

    public void UpdateMenu()
    {
        if (show)
        {
            rectTransform.anchoredPosition = Vector3.Lerp(rectTransform.anchoredPosition, shownPosition, UIMenuManager.SwapMenuSpeed);            
        }
        else
        {
            rectTransform.anchoredPosition = Vector3.Lerp(rectTransform.anchoredPosition, hiddenPosition, UIMenuManager.SwapMenuSpeed);
        }        
    }

    public void Close()
    {
        show = false;
    }
}
