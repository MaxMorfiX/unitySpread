using UnityEngine;

public class BasicValuesSetter : MonoBehaviour {
    public GameObject cellPrefab;
    public GameObject blockPrefab;
    public PlayersController playersController;
    public Color32[] playersColors = new Color32[4];

    private void Start() {
        Cell.blockPrefab = blockPrefab;
        Cell.playersController = playersController;
        MapGenerator.cellPrefab = cellPrefab;
        Block.playersColors = playersColors;
        Cell.playersColors = playersColors;
    }
}
