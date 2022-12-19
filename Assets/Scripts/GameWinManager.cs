using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameWinManager : MonoBehaviour {

    [SerializeField] GameObject gameWinMenu;
    [SerializeField] Text gameWinText;
    [SerializeField] Text playerColorHinterText;
    public static Color32[] playersColors = new Color32[4];
    public static string[] playersColorsNames = new string[4];

    public void Show() {
        gameWinMenu.SetActive(true);
    }

    public void Hide() {
        gameWinMenu.SetActive(false);
    } 

    public void Show(byte playerId) {
        gameWinText.text = "Player " + (playerId + 1) + " won the game!";
        playerColorHinterText.text = "(" + playersColorsNames[playerId] + " one)";
        playerColorHinterText.color = playersColors[playerId];
    }

}
