using UnityEngine;

public class BasicValuesSetter : MonoBehaviour {
    public GameObject cameraGO;
    public GameObject cellPrefab;
    public GameObject blockPrefab;
    public PlayersController playersController;
    public GameWinManager gameWinManager;
    public GameUIAndStatisticsManager gameUIAndStatisticsManager;
    public Color32[] playersColors = new Color32[4];
    public string[] playersColorsNames = new string[4];

    private void Start() {
        Cell.blockPrefab = blockPrefab;
        Cell.playersController = playersController;
        MapGenerator.cellPrefab = cellPrefab;
        MapGenerator.cameraGO = cameraGO;
        Block.playersColors = playersColors;
        Cell.playersColors = playersColors;
        GameWinManager.playersColors = playersColors;
        GameWinManager.playersColorsNames = playersColorsNames;
        ClickManager.playersController = playersController;
        PlayersController.gameUIAndStatisticsManager = gameUIAndStatisticsManager;
        PlayersController.gameWinManager = gameWinManager;
        // GameUIAndStatisticsManager.playersController = playersController;
    }
}
