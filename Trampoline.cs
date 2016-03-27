using UnityEngine;
using System.Collections;

public class Trampoline : MonoBehaviour {

	bool moveUp = false;
	Vector3 defaultPosition;

	void Start () {
		defaultPosition = transform.position;
	}

	void OnCollisionEnter () {
		moveUp = true;
	}

	void OnCollisionExit () {
		moveUp = false;
	}

	bool atMaxHeight() {
		return (transform.position - defaultPosition).magnitude > 3f;
	}

	void Update () {
		if (moveUp && !atMaxHeight()) {
			gameObject.GetComponent<Rigidbody> ().velocity = transform.up * 20;
		} else if (transform.position != defaultPosition) {
			gameObject.GetComponent<Rigidbody> ().velocity = defaultPosition - transform.position;
		}
	}
}
