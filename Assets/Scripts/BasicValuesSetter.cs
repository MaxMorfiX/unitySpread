using UnityEngine;

public class BasicValuesSetter : MonoBehaviour {
    public GameObject lastClickedCellPointer;
    public GameObject cameraGO;
    public GameObject cellPrefab;
    public GameObject blockPrefab;
    public AudioClip cellExplosionSound;
    public PlayersController playersController;
    public GameWinManager gameWinManager;
    public GameUIAndStatisticsManager gameUIAndStatisticsManager;
    public Color32[] playersColors = new Color32[4];
    public string[] playersColorsNames = new string[4];

    private void Start() {
        Cell.blockPrefab = blockPrefab;
        Cell.playersController = playersController;
        Cell.playersColors = playersColors;
        Cell.gameWinManager = gameWinManager;
        Cell.explosionSound = cellExplosionSound;
        Cell.lastClickedCellPointer = lastClickedCellPointer;
        Block.playersColors = playersColors;
        MapGenerator.cellPrefab = cellPrefab;
        MapGenerator.cameraGO = cameraGO;
        ClickManager.playersController = playersController;
        GameWinManager.playersColors = playersColors;
        GameWinManager.playersColorsNames = playersColorsNames;
        GameWinManager.playersController = playersController;
        PlayersController.gameUIAndStatisticsManager = gameUIAndStatisticsManager;
        PlayersController.gameWinManager = gameWinManager;
        // GameUIAndStatisticsManager.playersController = playersController;
    }

    public static void ResetValues() {
        Block.NowFlyingBlocksCount = 0;
        Block.blocks = new Block[0];
    }
}
