using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewGameEditor : MonoBehaviour {
    
    [SerializeField] Text HowManyPlayersNumberText;
    [SerializeField] Text MapSizeNumText;

    public void AddPlayer() {
        PlayersController.maxPlayers = (byte)Mathf.Clamp(PlayersController.maxPlayers+1, 2, 4);
        HowManyPlayersNumberText.text = PlayersController.maxPlayers.ToString();
    }
    public void DeletePlayer() {
        PlayersController.maxPlayers = (byte)Mathf.Clamp(PlayersController.maxPlayers-1, 2, 4);
        HowManyPlayersNumberText.text = PlayersController.maxPlayers.ToString();
    }
    public void IncreaceMapSize() {
        MapGenerator.mapSize = (byte)Mathf.Clamp(MapGenerator.mapSize+1, 2, 100);
        MapSizeNumText.text = MapGenerator.mapSize + "x" + MapGenerator.mapSize;
    }
    public void DecreaceMapSize() {
        MapGenerator.mapSize = (byte)Mathf.Clamp(MapGenerator.mapSize-1, 2, 100);
        MapSizeNumText.text = MapGenerator.mapSize + "x" + MapGenerator.mapSize;
    }
    public void Play() {
        BasicValuesSetter.ResetValues();
        SceneManager.LoadScene("MainGame");
    }
    private void Start() {
        HowManyPlayersNumberText.text = PlayersController.maxPlayers.ToString();
        MapSizeNumText.text = MapGenerator.mapSize + "x" + MapGenerator.mapSize;
    }

}
