using UnityEngine;

public class Cell : MonoBehaviour {
    public BlocksContainer blocksContainer;
    [SerializeField] private GameObject CenterCycle;


    public static GameObject blockPrefab;
    public byte energy = 0;

    private Transform tr;

    public void AddBlock(Block block) {
        energy++;
        if(this.energy == 1) CenterCycle.SetActive(true);
        blocksContainer.AddBlock(block);
    }

    public void AddNewBlock() {
        GameObject blockGO = Instantiate(blockPrefab);
        Block block = blockGO.GetComponent<Block>();
        
        block.ownerId = 0;

        AddBlock(block);
    }

}