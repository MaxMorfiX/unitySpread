using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocksContainer : MonoBehaviour {
    private Block[] blocks;
    private bool[] allowedToPlaceContainers = new bool[4];

    [SerializeField] Cell owner;
    [SerializeField] GameObject[] containers = new GameObject[4];

    public void SetAlowingContainers(bool[] AllowedContainers) {
        this.allowedToPlaceContainers = AllowedContainers;

        for(int i = 0; i < allowedToPlaceContainers.Length; i++) {
            GameObject container = containers[i];
            container.SetActive(allowedToPlaceContainers[i]);
        }
    }
}