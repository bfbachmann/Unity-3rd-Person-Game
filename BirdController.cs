using UnityEngine;
using System.Collections;

public class BirdController : MonoBehaviour {

	public GameObject player;
	float maxDistance = 10;
	Vector3 offset = new Vector3(0f, 4f, 0f);
	float minSpeed = 6f;

	void Start () {
		gameObject.GetComponentInChildren<Animator> ().speed = 3;
	}
	
	void Update () {

		if ((player.transform.position - transform.position).magnitude <= minSpeed) {
			circlePlayer ();
		} else {
			updateMovement ();
		}
		updateRotation ();	
	}

	void updateMovement () {
		gameObject.GetComponent<Rigidbody>().velocity = player.transform.position + offset - transform.position;
	}

	void updateRotation () {
		Rigidbody rb = gameObject.GetComponent<Rigidbody> ();
		transform.forward = rb.velocity;
	}

	void circlePlayer() {
		float current = Time.time;
		gameObject.GetComponent<Rigidbody>().velocity = player.transform.position - transform.position + offset + new Vector3 (5* Mathf.Cos (current), 0f, 5*Mathf.Sin(current));
	}
}
