using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour {
    [SerializeField] static GameObject blockPrefab;
    public BlocksContainer blocksContainer;


    private byte energy = 0;

    private Transform tr;

    public void AddBlock(GameObject block) {
        block.transform.parent = tr;
    }

    public void AddNewBlock() {
        GameObject block = Instantiate(blockPrefab);

        block.GetComponent<Block>().ownerId = 0;

        AddBlock(block);
    }

    public static void SetBlockPrefab(GameObject prf) {
        blockPrefab = prf;
    }

}