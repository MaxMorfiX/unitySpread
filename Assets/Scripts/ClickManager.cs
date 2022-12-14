using UnityEngine;

public class ClickManager : MonoBehaviour {

    private void Update() {
        if (Input.GetMouseButtonUp(0)) {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null && hit.collider.gameObject.CompareTag("Cell")) {
                hit.collider.gameObject.GetComponent<Cell>().AddNewBlock();
            }
        }
    }

}
