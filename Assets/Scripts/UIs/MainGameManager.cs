using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainGameManager : MonoBehaviour {

    public float settingsMoveSpeed = 1.5f;

    [SerializeField] RectTransform settings;
    private bool areSettingsOpened = false;
    private int frameOfMovingSettingsAnimation = 0;

    public void GoToMainMenu() {
        SceneManager.LoadScene("MainMenu");
    }

    public void RestartScene() {
        BasicValuesSetter.ResetValues();
        SceneManager.LoadScene("MainGame");
    }

    public void NewGame() {
        SceneManager.LoadScene("NewGameEditor");
    }

    public void ToggleSettings() {
        areSettingsOpened = !areSettingsOpened;
        frameOfMovingSettingsAnimation = 0;
    }

    private void Update() {
        HandleSettingsToggling();
    }

    private void HandleSettingsToggling() {
        if(settings.anchoredPosition.y == 0 && areSettingsOpened ||
           settings.anchoredPosition.y == settings.rect.height && !areSettingsOpened) return;
        
        float y = 0f;

        if(areSettingsOpened) 
            y = settings.anchoredPosition.y-settingsMoveSpeed*Time.deltaTime;
        else if(!areSettingsOpened) 
            y = settings.anchoredPosition.y+settingsMoveSpeed*Time.deltaTime;

        y = Mathf.Clamp(y, 0, settings.rect.height);

        settings.anchoredPosition = new Vector2(settings.anchoredPosition.x, y);
    }

    private void Start() {
        settings.anchoredPosition = new Vector2(settings.anchoredPosition.x, settings.rect.height);
    }

}