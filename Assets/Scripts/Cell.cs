using UnityEngine;

public class Cell : MonoBehaviour {
    public BlocksContainer blocksContainer;
    [SerializeField] private GameObject centerCycle;


    public static GameObject blockPrefab;
    public static Color32[] playersColors;
    public static PlayersController playersController;
    public byte energy = 0;
    public byte maxEnergy = 0;

    private Transform tr;

    public void AddBlock(Block block) {
        energy++;
        if(this.energy == 1) centerCycle.SetActive(true);
        blocksContainer.AddBlock(block);

        centerCycle.GetComponent<SpriteRenderer>().color = playersColors[block.ownerId];

        if(energy >= maxEnergy) {
            blocksContainer.ThrowAwayBlocks();
            centerCycle.SetActive(false);
            energy -= maxEnergy;
        }
    }

    public void AddNewBlock(byte blockOwner) {
        GameObject blockGO = Instantiate(blockPrefab);
        Block block = blockGO.GetComponent<Block>();
        
        block.SetOwner(blockOwner);

        AddBlock(block);
    }
    public void AddNewBlock() {
        AddNewBlock(playersController.currPlayer);
    }

}