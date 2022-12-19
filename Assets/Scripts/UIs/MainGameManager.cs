using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainGameManager : MonoBehaviour {
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
}