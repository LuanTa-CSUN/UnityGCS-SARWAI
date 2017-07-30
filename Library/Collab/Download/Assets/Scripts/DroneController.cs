using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DroneController : MonoBehaviour {

	public float speed;
    public float hoverHeightOffset;
    public float hoverForce;
    public Terrain myTerrain;
 

	private Rigidbody droneBody;
	private float droneHeight;
	private float MoveHorizontal;
	private float MoveVertical;
    private Vector3 appliedForce;

	void Start () {
		droneBody = GetComponent<Rigidbody>();

        // Checks height of terrain at starting point
        // places cameras at height + specified offset
		droneHeight = myTerrain.SampleHeight (transform.position);
        transform.Translate(0, droneHeight + hoverHeightOffset, 0);
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
        // Will be adapted for automation, though using AddRelativeForce results in use of application of acceleration
		Vector3 movement = new Vector3 (MoveHorizontal, 0, MoveVertical);
		droneBody.AddRelativeForce (movement * speed);
	}
}
