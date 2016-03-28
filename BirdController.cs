using UnityEngine;
using System.Collections;

public class BirdController : MonoBehaviour {

	public GameObject player;
	Vector3 offset = new Vector3(0f, 4f, 0f);
	float minSpeed = 6f;
	bool sleeping = true;
	bool initialSleep = true;
	Animator birdAnim;

	void Start () {
		birdAnim = gameObject.GetComponentInChildren<Animator> ();
		birdAnim.SetInteger ("BirdParam", 0);
		birdAnim.speed = 3;
	}

	void OnCollisionEnter(Collision collision) {
		if (collision.collider.name != "BlockMan" && !collision.collider.name.Contains("rock")) {
			return;
		}
		if (sleeping) {
			sleeping = false;
			initialSleep = false;
			birdAnim.SetInteger ("BirdParam", 1);
		} else {
			sleeping = true;
			birdAnim.SetInteger ("BirdParam", 0);
		}
	}
	
	void Update () {
		if (initialSleep) {
			gameObject.GetComponent<Rigidbody> ().Sleep ();
		}

		if (sleeping) {
			return;
		}

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
