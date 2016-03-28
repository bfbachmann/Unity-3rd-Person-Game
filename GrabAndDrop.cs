using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GrabAndDrop : MonoBehaviour
{

	public Camera playerCamera;
	GameObject grabbedObject;
	float grabbedObjectSize;
	Vector3 positionOffset;

	void Start (){
	}


	GameObject getMouseHoverObject (float range)
	{
		Vector3 position = gameObject.transform.position;
		position.y -= 0.1f;
		RaycastHit raycastHit;
		Vector3 forward = playerCamera.transform.forward;
		forward.y = 0f;
		Vector3 target = position + forward * range;
		Debug.Log ("Target: " + target);
		Debug.Log ("Position: " + position);

		if (Physics.Linecast (position, target, out raycastHit)) {
			GameObject grabObject = raycastHit.collider.gameObject;
			if (grabObject.GetComponent<Grabable>() != null) {
				return grabObject;
			}
		}
		return null;
	}


	public bool isHolding() {
		return (grabbedObject != null);
	}


	bool canGrab (GameObject grabObject)
	{
		if (grabObject == null || grabObject.GetComponent<Rigidbody> () == null) {
			return false;
		} else if (grabObject.name == "Terrain") {
			return false;
		} else {
			return true;
		}
	}

	void tryGrab (GameObject grabObject)
	{
		if (grabObject == null || !canGrab (grabObject)) {
			return;
		}
		grabbedObject = grabObject;
		grabbedObjectSize = grabObject.GetComponent<Renderer> ().bounds.size.magnitude;
	}

	void drop ()
	{
		if (grabbedObject != null) {

			if (grabbedObject.GetComponent<Rigidbody> () != null) {
				grabbedObject.GetComponent<Rigidbody> ().velocity = Vector3.zero;
			}

			grabbedObject = null;
		}
	}

	void throwObject ()
	{
		if (grabbedObject == null) {
			return;
		}
		Vector3 forward = playerCamera.transform.forward;
		forward.y = 0.7f;
		forward *= 10;
		grabbedObject.GetComponent<Rigidbody> ().velocity = forward;
		grabbedObject = null;
	}

	void Update ()
	{
		if (grabbedObject == null) {
			if (Input.GetMouseButtonDown (1)) {
				tryGrab (getMouseHoverObject (5));
				gameObject.GetComponent<PlayerController> ().updateAnimation();
			}
		} else {
			if (!Input.GetMouseButton(1)) {
				drop ();
				gameObject.GetComponent<PlayerController> ().updateAnimation();
			}
			else if (Input.GetMouseButtonDown(0)) {
				throwObject ();
				gameObject.GetComponent<PlayerController> ().updateAnimation();
			} else {
				Vector3 forward = playerCamera.transform.forward * (float) (grabbedObjectSize/2);
				forward.y = 0.7f;
				positionOffset = gameObject.transform.forward*0.4f - gameObject.transform.right;
				Vector3 newPosition = gameObject.transform.position + forward + Vector3.up;
				grabbedObject.transform.position = newPosition + positionOffset;
				grabbedObject.transform.rotation = playerCamera.transform.rotation;
			}
		}
	}
}
