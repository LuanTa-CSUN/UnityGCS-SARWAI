using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject droneExt;

	private GameObject drone;

    // Checks position of drone, places camera rig at drone,
    // then places camera rig at height + specified offset

    // Would like to find a way to use on multiple drones in the same scene
    // May not be necessary, though, I just don't like hard coding
	void Start () {
		drone = transform.parent.Find("DronePrefab(Clone)").gameObject;
		transform.Translate (drone.transform.position);
		}

	void LateUpdate () {
		transform.position = drone.transform.position;
	}
}
