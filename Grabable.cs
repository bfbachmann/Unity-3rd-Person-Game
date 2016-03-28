using UnityEngine;
using System.Collections;

public class Grabable : MonoBehaviour {

	public GameObject holder;

	// Use this for initialization
	void Start () {
	
	}

	void OnCollisionEnter (Collision collision) {
//		holder.BroadcastMessage("clipping", collision.impulse);
		gameObject.GetComponent<Rigidbody> ().AddForce (collision.impulse);
	}

	// Update is called once per frame
	void Update () {
	}
}
