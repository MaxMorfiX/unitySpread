using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {
    public byte ownerId = 0;



    
    public void SetValues(byte ownerId) {
        this.ownerId = ownerId;
    }
}
