using UnityEngine;

public class Block : MonoBehaviour {
    public byte ownerId = 0;
    public new Transform transform;

    public Vector3 velocity;
    public GameObject recentCell;

    public static Color32[] playersColors;



    
    private void OnEnable() {
        transform = GetComponent<Transform>();
    }


    private void Update() {
        transform.position += velocity;
    }


    private void OnTriggerEnter2D(Collider2D collider) {
        if(velocity == new Vector3()) return;
        if(collider.gameObject == recentCell) return;
        if(collider.gameObject.tag != "Cell") return;

        velocity = new Vector3();
        collider.gameObject.GetComponent<Cell>().AddBlock(this);
    }

    public void SetOwner(byte ownerId) {
        Debug.Log("recent: " + this.ownerId + ", new: " + ownerId);
        this.ownerId = ownerId;
        GetComponent<SpriteRenderer>().color = playersColors[ownerId];
    }



}
