using UnityEngine;

public class BasicValuesSetter : MonoBehaviour {
    public GameObject cellPrefab;
    public GameObject blockPrefab;

    private void Start() {
        Cell.blockPrefab = blockPrefab;
        MapGenerator.cellPrefab = cellPrefab;
    }
}
