using UnityEngine;

public class Block : MonoBehaviour {
    public byte ownerId = 0;
    public Transform transform;



    
    private void OnEnable() {
        transform = GetComponent<Transform>();
    }
}
