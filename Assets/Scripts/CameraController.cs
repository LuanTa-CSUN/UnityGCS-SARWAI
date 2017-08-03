using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject drone;
	public float position;

	void Start () {
        // Checks height of terrain at starting point
        // places cameras at height + specified offset

		position = drone.transform.position.y;
		transform.Translate (drone.transform.position);
		}

	void LateUpdate () {
		transform.position = drone.transform.position;
	}
}
