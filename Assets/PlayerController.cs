using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    Rigidbody2D mRigidBody;

	// Use this for initialization
	void Start () {
        mRigidBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(1))
        {
            mRigidBody.bodyType = RigidbodyType2D.Dynamic;
        }
	}
}
