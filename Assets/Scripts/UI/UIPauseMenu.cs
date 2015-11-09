using UnityEngine;
using System.Collections;

public class UIPauseMenu : MonoBehaviour {

	public void Continue()
    {
        gameObject.SetActive(false);
    }

    public void BackToMainMenu()
    {
        Application.LoadLevel(0);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
