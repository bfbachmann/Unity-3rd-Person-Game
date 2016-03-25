using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float sensitivity = 3;
	private Rigidbody rb;
	public float rotSpeed = 4.0f;
	public Camera theCamera;
	private Vector3 moveDirection;
	private Vector3 tempTarget;
	public float jumpVelocity = 3;
	private float distToGround = 3f;
	public float maxSpeed;
	Vector3 slowdownScale = new Vector3(0.2f, 1f, 0.2f);


	void Start () {
		rb = GetComponent<Rigidbody> ();
		rb.mass = 5f;
		rb.useGravity = true;
		rb.drag = 0.1f;
	}



	void FixedUpdate (){
		updateRotation ();
		moveCharacter ();
	}



	private void updateRotation () {
		
		Vector3 cameraForward = theCamera.transform.TransformDirection (Vector3.forward);
		cameraForward.y = 0f;
		cameraForward = cameraForward.normalized;

		Vector3 cameraRight = new Vector3 (cameraForward.z, 0.0f, -cameraForward.x);

		float vert = Input.GetAxisRaw ("Vertical");
		float hor = Input.GetAxisRaw ("Horizontal");

		Vector3 tempTarget = hor * cameraRight + vert * cameraForward;
		if (tempTarget != Vector3.zero) {
			moveDirection = Vector3.RotateTowards (moveDirection, tempTarget, rotSpeed * Mathf.Deg2Rad * Time.deltaTime, 1000);
			moveDirection = moveDirection.normalized;
			transform.rotation = Quaternion.LookRotation (moveDirection);
		}

	}


	private void moveCharacter () {
		tempTarget = Input.GetAxis ("Vertical") * theCamera.transform.forward + Input.GetAxis ("Horizontal") * theCamera.transform.right;
		tempTarget.y = 0f;
		float speedLimit = maxSpeed;

		if (tempTarget.magnitude == 0 && groundCheck ()) {
			rb.velocity = new Vector3 (0f, rb.velocity.y, 0f);
		} else {
			if (Input.GetKey (KeyCode.LeftShift)) {
				speedLimit = 20f;
				tempTarget *= 2;
			}
			rb.velocity = tempTarget*10;
		}
		
		if ((Input.GetKeyDown ("space")) && groundCheck ()) {
			rb.velocity += new Vector3 (0f, jumpVelocity, 0f);
		}
	}
		

	bool groundCheck() {
		return Physics.Raycast(transform.position, -Vector3.up, distToGround);
	}

}
