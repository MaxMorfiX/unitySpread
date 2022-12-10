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
        
    }

    public void AddBlock(Block block) {
        block.transform.parent = allowedContainers[owner.energy-1].transform;
        block.transform.localPosition = new Vector3();
    }
}