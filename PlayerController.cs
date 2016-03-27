using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float sensitivity = 3;
	private Rigidbody rb;
	public float rotSpeed = 4.0f;
	public Camera theCamera;
	private Vector3 moveDirection;
	private Vector3 tempTarget;
	public float jumpVelocity = 7;
	private float distToGround = 0.6f;
	public float maxSpeed;
	private Animator animator;


	void Start () {
		rb = GetComponent<Rigidbody> ();
		rb.mass = 5f;
		rb.useGravity = true;
		rb.drag = 0.1f;
		animator = gameObject.GetComponentInChildren<Animator> ();
	}


	public void updateAnimation () {

		bool isHolding = gameObject.GetComponent<GrabAndDrop> ().isHolding ();

		if (!groundCheck()) {
			animator.SetInteger ("AnimParam", 2);
			return;
		}

		if (isHolding) {
			if (Input.GetKey("w") || Input.GetKey("s")) {
				animator.SetInteger ("AnimParam", 3);
			} else if (Input.GetKey("d") || Input.GetKey("a")) {
				animator.SetInteger ("AnimParam", 1);
			} else {
				animator.SetInteger ("AnimParam", 2);
			}
		} else {
			if (Input.GetKey("w") || Input.GetKey("s")) {
				animator.SetInteger ("AnimParam", 0);
			} else if (Input.GetKey("d") || Input.GetKey("a")) {
				animator.SetInteger ("AnimParam", 4);
			} else {
				animator.SetInteger ("AnimParam", 5);
			}
		}
	}


	void FixedUpdate (){
		updateAnimation ();
		updateRotation ();
		moveCharacter ();
	}



	private void updateRotation () {

		Quaternion rotation = theCamera.transform.rotation;
		rotation.x = 0;
		rotation.z = 0;
		rotation *= Quaternion.Euler(0, 90, 0);

		transform.rotation = rotation;
	}


	private void moveCharacter () {
		if (!groundCheck ()) {
			return;
		}

		tempTarget = Input.GetAxis ("Vertical") * theCamera.transform.forward + Input.GetAxis ("Horizontal") * theCamera.transform.right;
		tempTarget.y = 0f;

		if (tempTarget.magnitude == 0) {
			rb.velocity = new Vector3 (0f, rb.velocity.y, 0f);
		} else {
			if (Input.GetKey (KeyCode.LeftShift)) {
				tempTarget *= 1.5f;
				animator.speed = 5;
			} else {
				animator.speed = 3;
			}
			rb.velocity = new Vector3(tempTarget.x*10, rb.velocity.y, tempTarget.z*10);
		}
		
		if ((Input.GetKeyDown ("space")) && groundCheck ()) {
			rb.velocity += new Vector3 (0f, jumpVelocity, 0f);
			animator.SetInteger ("AnimParam", 2);
		}
	}
		

	bool groundCheck() {
		bool ray1 = Physics.Raycast(transform.position + new Vector3(1f, 0f, 0f), Vector3.down, distToGround);
		bool ray2 = Physics.Raycast(transform.position, Vector3.down, distToGround);
		bool ray3 = Physics.Raycast(transform.position - new Vector3(1f, 0f, 0f), Vector3.down, distToGround);
		return ray1 || ray2 || ray3;
	}

}
