using UnityEngine;
using System.Collections;

public class Evelator : MonoBehaviour {

	bool moveUp = false;
	bool moveDown = false;

	public GameObject player;

	void Start () {

	}

	void OnCollisionEnter (Collision collision) {
		if (collision.collider.name == "Player") {
			moveUp = true;
		}
	}

	void Update () {
		Rigidbody rb = GetComponent<Rigidbody> ();
		Debug.Log (rb.velocity);
		if (transform.position.y >= 10) {
			moveUp = false;
		} 


		if (moveUp) {
			rb.velocity = Vector3.up * 10;
		} 
	}
}
