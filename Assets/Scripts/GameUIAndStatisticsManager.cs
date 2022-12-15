using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIAndStatisticsManager : MonoBehaviour {

    // public static PlayersController playersController;

    [SerializeField] Text[] playerScoresTexts = new Text[4];
    [SerializeField] Image[] currPlayersImages = new Image[4];

    private void Start() {
        ShowCurrPlayer(0);
    }

    public void ShowCurrPlayer(byte playerId) {
        for(byte i = 0; i < currPlayersImages.Length; i++) {

            Image img = currPlayersImages[i];
            Color32 color = img.color;

            byte a = 50;

            // Debug.Log(i + ", playerId: " + playerId);

            if(i == playerId) {
                a = 255;
            }

            img.color = new Color32(color.r, color.g, color.b, a);
        }
    }

    public void showCurrPlayerScores(byte[] scores) {
        for(byte i = 0; i < scores.Length; i++) {
            Debug.Log(scores.Length + "   " + playerScoresTexts.Length);
            playerScoresTexts[i].text = scores[i].ToString();
        }
    }

}
