using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject drone;

	private Vector3 offset;

	void Start () {
        // Checks height of terrain at starting point
        // places cameras at height + specified offset

		transform.Translate (0, drone.transform.position.y, 0);

		offset = transform.position - drone.transform.position;
	}

	void LateUpdate () {
		transform.position = drone.transform.position + offset;
	}
}
