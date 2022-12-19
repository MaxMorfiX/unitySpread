using UnityEngine;

public class MapGenerator : MonoBehaviour {

    private float stepSize;
    private GameObject cellsContainer;
    public static byte mapSize = 5;

    public static GameObject cellPrefab;
    public static GameObject cameraGO;


    private void Start() {
        cellsContainer = GameObject.FindWithTag("CellsContainer");

        SpriteRenderer sr = cellPrefab.GetComponent<SpriteRenderer>();
        stepSize = 5f;

        Cell.Cells = GenerateMap(mapSize);
    }


    public Cell[] GenerateMap(byte size) {
        Cell[] cells = new Cell[size*size];

        float numForCentering = Mathf.Floor((float)size/2); // for centering

        int arrayIndex = 0;

        for(int i = 0; i < size; i++) {
            for(int j = 0; j < size; j++) {
                Cell cell = GenerateCell(i, j, size, size);

                cells[arrayIndex] = cell;




                bool top = j != size-1;
                bool left = i != 0;
                bool right = i != size-1;
                bool bottom = j != 0;

                // Debug.Log("i: " + i + ", j: " + j + ", size: " + size + ", top: " + top + ", left: " + left + ", right: " + right + ", bottom: " + bottom);

                bool[] allowedContainers = {top, left, right, bottom};

                cell.blocksContainer.SetAllowedContainers(allowedContainers);




                arrayIndex++;
            }
        }

        float camSize = size*stepSize*0.7f;

        cameraGO.GetComponent<Camera>().orthographicSize = camSize;

        return cells;
    }

    private Cell GenerateCell(int i, int j, int maxI, int maxJ) {
        GameObject cell = Instantiate(cellPrefab, cellsContainer.transform);

        Vector3 pos = new Vector3(i, j, 0);

        Vector3 centratingVec = new Vector3((maxI-1)/2f, (maxJ-1)/2f, 0);
        pos -= centratingVec;
        
        cell.GetComponent<Transform>().position = pos*stepSize;

        return cell.GetComponent<Cell>();
    }

}
