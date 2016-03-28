using UnityEngine;
using System.Collections;

public class Grabable : MonoBehaviour {

	public GameObject holder;

	// Use this for initialization
	void Start () {
	
	}

	void OnCollisionEnter () {
//		holder.BroadcastMessage("drop");
	}

	// Update is called once per frame
	void Update () {
	}
}
