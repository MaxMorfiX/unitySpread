using UnityEngine;

public class Block : MonoBehaviour {

    public static byte NowFlyingBlocksCount = 0;

    public byte ownerId = 0;
    public new Transform transform;
    private Vector3 _velocity = new Vector3();

    public Vector3 velocity {get {return _velocity;}
        set {
            _velocity = value;

            if(velocity != Vector3.zero)
                NowFlyingBlocksCount++;    
        }}
    public GameObject recentCell;

    public static Color32[] playersColors;



    
    private void OnEnable() {
        transform = GetComponent<Transform>();
    }


    private void Update() {
        transform.position += velocity*Time.deltaTime;
    }


    private void OnTriggerEnter2D(Collider2D collider) {
        if(velocity == new Vector3()) return;
        if(collider.gameObject == recentCell) return;
        if(!collider.gameObject.CompareTag("Cell")) return;

        velocity = new Vector3();
        NowFlyingBlocksCount--;
        collider.gameObject.GetComponent<Cell>().AddBlock(this);
    }

    public void SetOwner(byte ownerId) {
        // Debug.Log("recent: " + this.ownerId + ", new: " + ownerId);
        this.ownerId = ownerId;
        GetComponent<SpriteRenderer>().color = playersColors[ownerId];
    }

}
