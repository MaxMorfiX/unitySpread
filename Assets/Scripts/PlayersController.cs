using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersController : MonoBehaviour {

    public byte currPlayer = 0;
    
    private void Update() {
        if(Input.GetKeyDown("1")) {
            currPlayer = 0;
        } else if(Input.GetKeyDown("2")) {
            currPlayer = 1;
        } else if(Input.GetKeyDown("3")) {
            currPlayer = 2;
        } else if(Input.GetKeyDown("4")) {
            currPlayer = 3;
        }
    }

}
