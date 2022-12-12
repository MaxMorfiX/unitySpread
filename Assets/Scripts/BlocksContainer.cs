using System;
using UnityEngine;

public class BlocksContainer : MonoBehaviour {
    private Block[] blocks;
    private bool[] allowedToPlaceContainers = new bool[4];
    private GameObject[] allowedContainers = new GameObject[4];

    [SerializeField] Cell owner;
    [SerializeField] GameObject[] containers = new GameObject[4];

    public void SetAllowedContainers(bool[] AllowedContainers) {
        this.allowedToPlaceContainers = AllowedContainers;

        byte allowedI = 0;

        for(int i = 0; i < allowedToPlaceContainers.Length; i++) {
            GameObject container = containers[i];
            container.SetActive(allowedToPlaceContainers[i]);

            if(!allowedToPlaceContainers[i]) continue;

            allowedContainers[allowedI] = container;
            allowedI++;
        }

        Array.Resize(ref allowedContainers, allowedI + 1);
        Array.Resize(ref blocks, allowedI + 1);

        owner.maxEnergy = (byte)(allowedI);
    }

    public void AddBlock(Block newBlock) {
        newBlock.transform.parent = allowedContainers[owner.energy-1].transform;
        newBlock.transform.localPosition = new Vector3();
        newBlock.recentCell = owner.gameObject;
        blocks[owner.energy - 1] = newBlock;

        foreach(Block block in blocks) {
            if(block == null) continue;
            block.SetOwner(newBlock.ownerId);
        }
    }

    public void ThrowAwayBlocks() {
        foreach(Block block in blocks) {
            if(block == null) continue;

            Vector3 vel = (block.transform.localPosition + block.transform.parent.localPosition)*0.01f;
            block.velocity = vel;
        }

        Array.Clear(blocks, 0, blocks.Length);
    }
}