using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour {

    Rigidbody2D rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}

    private void OnMouseDrag()
    {
        Vector2 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        rb.AddForce((newPos - (Vector2)transform.position) * 50);
    }
}
