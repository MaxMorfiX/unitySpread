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
    public static PlayersController playersController;

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

        Show();
    }

    private void Update() {

        if(gameWinMenu.activeInHierarchy || playersController.round == 0) return;

        byte countOfPlayersInGame = 0;
        int[] playersBlocksCount = new int[4];

        foreach(Block block in Block.blocks) {
            if(playersBlocksCount[block.ownerId] == 0) countOfPlayersInGame++;

            playersBlocksCount[block.ownerId] ++;
        }

        if(countOfPlayersInGame != 1) return;

        for(byte i = 0; i < playersBlocksCount.Length; i++) {
            if(playersBlocksCount[i] > 1) {
                Show(i);
            }
        }
    }

}
