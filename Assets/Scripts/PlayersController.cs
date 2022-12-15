using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersController : MonoBehaviour {

    public static GameUIAndStatisticsManager gameUIAndStatisticsManager;

    public byte currPlayer = 0;
    public byte maxPlayers = 4;
    public bool changePlayersByButtons = false;
    
    private void Update() {
        if(changePlayersByButtons) HandleChangingPlayersByButtons();
    }

    private void HandleChangingPlayersByButtons() {
        if(Input.GetKeyDown("1")) {
            currPlayer = 0;
        } else if(Input.GetKeyDown("2")) {
            currPlayer = 1;
        } else if(Input.GetKeyDown("3")) {
            currPlayer = 2;
        } else if(Input.GetKeyDown("4")) {
            currPlayer = 3;
        }
    }

    public void NextPlayer() {
        
        currPlayer += 1;
        if(currPlayer >= maxPlayers) { 
            currPlayer = 0;
        }

        // Debug.Log("next player: " + currPlayer);

        gameUIAndStatisticsManager.ShowCurrPlayer(currPlayer);
    }

}
