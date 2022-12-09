using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour {

    private float stepSize;
    private GameObject cellsContainer;

    private Cell[] cells;
    [SerializeField] private GameObject cellPrefab;
    [SerializeField] private GameObject blockPrefab;


    private void Start() {
        cellsContainer = GameObject.FindWithTag("CellsContainer");

        Cell.SetBlockPrefab(blockPrefab);

        SpriteRenderer sr = cellPrefab.GetComponent<SpriteRenderer>();
        stepSize = 5f;

        GenerateMap(5);
    }


    public void GenerateMap(byte size) {
        cells = new Cell[size*size];

        float numForCentrating = Mathf.Floor((float)size/2); // for centrating

        int arrayIndex = 0;

        for(float i = 0; i <= numForCentrating*2; i++) {
            for(float j = 0; j <= numForCentrating*2; j++) {
                Cell cell = GenerateCell(i-numForCentrating, j-numForCentrating);

                cells[arrayIndex] = cell;




                bool top = j != size-1;
                bool left = i != 0;
                bool right = i != size-1;
                bool bottom = j != 0;

                // Debug.Log("i: " + i + ", j: " + j + ", size: " + size + ", top: " + top + ", left: " + left + ", right: " + right + ", bottom: " + bottom);

                bool[] allowedContainers = {top, left, right, bottom};

                cell.blocksContainer.SetAlowingContainers(allowedContainers);




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
