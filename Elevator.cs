using UnityEngine;
using System.Collections;

public class Elevator : MonoBehaviour
{

	bool moveUp = false;
	int waitTime = 0;
	public GameObject player;


	void Start ()
	{

	}

	void OnCollisionEnter (Collision collision)
	{
		if (withPlayer (collision)) {
			moveUp = true;
		}
	}

	void OnCollisionExit (Collision collision)
	{
		if (withPlayer (collision)) {
			moveUp = false;
		}
	}

	bool withPlayer (Collision collision)
	{
		return collision.collider.name == player.name;
	}

	void Update ()
	{
		Rigidbody rb = GetComponent<Rigidbody> ();


		if (transform.position.y >= 14) {
			rb.velocity = Vector3.zero;
			rb.Sleep ();
			waitTime++;

			if (waitTime > 25) {
				rb.WakeUp ();
				waitTime = 0;
			}
			return;
		}

		if (moveUp) {
			rb.velocity = Vector3.up * 5;
		} else if (!moveUp) {
			rb.velocity = Vector3.down * 3;
		}
	}
}
