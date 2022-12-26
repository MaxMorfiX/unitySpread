using UnityEngine;

public class Cell : MonoBehaviour {
    public BlocksContainer blocksContainer;
    [SerializeField] private GameObject centerCycle;
    public static AudioClip explosionSound;
    public static Cell[] Cells;
    public static GameWinManager gameWinManager;


    public static GameObject blockPrefab;
    public static Color32[] playersColors;
    public static PlayersController playersController;

    public byte energy = 0;
    public byte maxEnergy = 0;
    public byte playerOwnerId = 0;
    public bool isFilled = false;

    private Transform tr;

    public void AddBlock(Block block) {
        energy++;
        if(this.energy == 1) {
            centerCycle.SetActive(true);
            isFilled = true;
        }
        blocksContainer.AddBlock(block);

        centerCycle.GetComponent<SpriteRenderer>().color = playersColors[block.ownerId];

        playerOwnerId = block.ownerId;

        if(energy >= maxEnergy) {
            if(MainGameManager.playSounds) {
                playersController.GetComponent<AudioSource>().PlayOneShot(explosionSound);
            }
            blocksContainer.ThrowAwayBlocks();
            centerCycle.SetActive(false);
            energy -= maxEnergy;

            if(energy <= 0) isFilled = false;
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

    public void OnClick() {
        
        if(isFilled && playerOwnerId != playersController.currPlayer ||
           Block.NowFlyingBlocksCount > 0 || 
           !playersController.arePlayersInGame[playersController.currPlayer] ||
           gameWinManager.isGameStopped) {
            return;
        }
        // Debug.Log("isFilled: " + isFilled + ", playerOwnerId: " + playerOwnerId + ", currPlayer: " + playersController.currPlayer);
        AddNewBlock();

        playersController.NextPlayer();
    }

}