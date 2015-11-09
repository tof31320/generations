using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UI_GameStatusBar : MonoBehaviour {

    public Text txtFamilyName = null;

    public Text txtAnnee = null;

    public Text txtGeneration = null;

    public Slider gameSpeedSlider = null;

    public Button btnOptions = null;

    public UIPauseMenu pauseMenu = null;

    public void Start()
    {
        gameSpeedSlider.value = GameController.instance.gameSpeedManager.gameSpeed;
    }

    public void Update()
    {
        txtAnnee.text = GameController.instance.annee + "";
        txtGeneration.text = GameController.instance.generation + "";
    }

    public void TogglePause()
    {
        GameController.instance.pause = !GameController.instance.pause; 
    }

    public void OnGameSpeedChange()
    {
        GameController.instance.gameSpeed = 1f - gameSpeedSlider.value;
    }

    public void PauseMenu()
    {
        GameController.instance.pause = true;
        pauseMenu.gameObject.SetActive(true);
    }
}
