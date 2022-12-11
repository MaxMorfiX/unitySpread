using UnityEngine;

public class Cell : MonoBehaviour {
    public BlocksContainer blocksContainer;
    [SerializeField] private GameObject centerCycle;


    public static GameObject blockPrefab;
    public byte energy = 0;
    public byte maxEnergy = 0;

    private Transform tr;

    public void AddBlock(Block block) {
        energy++;
        if(this.energy == 1) centerCycle.SetActive(true);
        blocksContainer.AddBlock(block);

        if(energy >= maxEnergy) {
            blocksContainer.ThrowAwayBlocks();
            centerCycle.SetActive(false);
            energy -= maxEnergy;
        }
    }

    public void AddNewBlock() {
        GameObject blockGO = Instantiate(blockPrefab);
        Block block = blockGO.GetComponent<Block>();
        
        block.ownerId = 0;

        AddBlock(block);
    }

}