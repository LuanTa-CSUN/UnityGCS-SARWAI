using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject drone;
	public Terrain myTerrain;
	public float hoverHeightOffset;

	private Vector3 offset;
	private float cameraHeight;

	void Start () {
        // Checks height of terrain at starting point
        // places cameras at height + specified offset
		cameraHeight = myTerrain.SampleHeight (transform.position);
		transform.Translate (0, cameraHeight + hoverHeightOffset, 0);

		offset = transform.position - drone.transform.position;
	}

	void LateUpdate () {
		transform.position = drone.transform.position + offset;
	}
}
