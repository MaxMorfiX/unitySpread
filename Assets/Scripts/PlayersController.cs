using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersController : MonoBehaviour {

    public static GameUIAndStatisticsManager gameUIAndStatisticsManager;

    public byte[] playerScores = new byte[4];

    public byte round = 0;
    public byte currPlayer = 0;
    public byte maxPlayers = 4;
    public bool changePlayersByButtons = false;
    public bool calculateScoreEveryFrame = true;
    public bool[] arePlayersInGame = new bool[4];

    private void Start() {
        for(byte i = 0; i < maxPlayers; i++) {
            arePlayersInGame[i] = true;
        }

    }
    
    private void Update() {
        if(changePlayersByButtons) HandleChangingPlayersByButtons();

        if(!arePlayersInGame[currPlayer]) {
            NextPlayer();
        }

        if(!(calculateScoreEveryFrame || Block.NowFlyingBlocksCount == 0)) return;

        playerScores = calcPlayerScores();
        gameUIAndStatisticsManager.showCurrPlayerScores(playerScores);

        if(round == 0) return;

        for(byte i = 0; i < playerScores.Length; i++) {
            if(playerScores[i] == 0) {
                arePlayersInGame[i] = false;
            } else {
                arePlayersInGame[i] = true;
            }
        }
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
            round++;
        }

        if(!arePlayersInGame[currPlayer]) {
            NextPlayer();
            return;
        }

        // Debug.Log("next player: " + currPlayer);

        gameUIAndStatisticsManager.ShowCurrPlayer(currPlayer);
    }

    public byte[] calcPlayerScores() {

        byte[] playerScores = new byte[4];

        foreach(Cell cell in Cell.Cells) {
            if(cell.isFilled) {
                playerScores[cell.playerOwnerId]++;
            }
        }

        return playerScores;
    }

}
