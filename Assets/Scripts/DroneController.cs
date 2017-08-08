﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEditor;

public class DroneController : MonoBehaviour {

	public float speed;
    public float hoverHeightOffset;
    public float hoverForce;
	public Terrain myTerrain;

	private Rigidbody droneBody;
	private float terrainHeight;
	private float droneHeight;
	private float MoveHorizontal;
	private float MoveVertical;
    private Vector3 appliedForce;
	private GameObject terrain;

    void Awake()
    {
        droneBody = GetComponent<Rigidbody>();

        // Checks for center size of terrain
        // Calculates center of terrain based on size, creates vector
        Vector3 terrainSize = myTerrain.terrainData.size;
        Vector3 location = new Vector3(terrainSize.x / 2, transform.position.y, terrainSize.z / 2);

        // Checks height of terrain at starting point
        // places drone at height + specified offset
        terrainHeight = myTerrain.SampleHeight(location);
        droneHeight = terrainHeight - (transform.position.y % terrainHeight);
        Debug.Log(droneHeight);
        transform.Translate(terrainSize.x / 2, droneHeight + hoverHeightOffset, terrainSize.z / 2);
    }

	void Update () {
		MoveHorizontal = Input.GetAxis ("Horizontal");
		MoveVertical = Input.GetAxis ("Vertical");
	}

	void FixedUpdate () {
		Ray ray = new Ray (transform.position, -transform.up);
		RaycastHit hit;

        // Checks player height above ground
        // If below threshold, applies Force to compensate
        if (Physics.Raycast(ray, out hit, hoverHeightOffset))
        {
            float proportionalheight = (hoverHeightOffset - hit.distance) / hoverHeightOffset;
            appliedForce = Vector3.up * proportionalheight * hoverForce;
            droneBody.AddForce(appliedForce);
        }

        // To compensate for unnecessary bobbing, check if drone is *above* threshold
        // If true, apply opposing Force to compensate
        else if (ray.origin.y > hoverHeightOffset)
        {
            Vector3 correctForce = new Vector3(0, -hoverForce, 0);
            droneBody.AddForce(correctForce);
        }

        // Take user input and move drone accordingly
        // Will be adapted for automation, though using "AddRelativeForce" results in application of acceleration
		Vector3 movement = new Vector3 (MoveHorizontal, 0, MoveVertical);
		droneBody.AddRelativeForce (movement * speed);
	}
}
