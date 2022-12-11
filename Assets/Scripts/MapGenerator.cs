using UnityEngine;

public class MapGenerator : MonoBehaviour {

    private float stepSize;
    private GameObject cellsContainer;

    private Cell[] cells;
    public static GameObject cellPrefab;


    private void Start() {
        cellsContainer = GameObject.FindWithTag("CellsContainer");

        SpriteRenderer sr = cellPrefab.GetComponent<SpriteRenderer>();
        stepSize = 5f;

        GenerateMap(9);
    }


    public void GenerateMap(byte size) {
        cells = new Cell[size*size];

        float numForCentering = Mathf.Floor((float)size/2); // for centering

        int arrayIndex = 0;

        for(float i = 0; i <= numForCentering*2; i++) {
            for(float j = 0; j <= numForCentering*2; j++) {
                Cell cell = GenerateCell(i-numForCentering, j-numForCentering);

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
    }

    private Cell GenerateCell(float i, float j) {
        GameObject cell = Instantiate(cellPrefab, cellsContainer.transform);

        Vector3 pos = new Vector3(i*stepSize, j*stepSize, 0);
        
        cell.GetComponent<Transform>().position = pos;

        return cell.GetComponent<Cell>();
    }

}
