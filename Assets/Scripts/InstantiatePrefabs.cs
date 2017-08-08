using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatePrefabs : MonoBehaviour {

    public List<Object> prefabs; 

    // Instantiates prefabs as part of a scene
    // Done this way to allow for adaptable additions to multiple seperate scenes
    // Hard coded - would like to find another way in the future
	void Awake () {
        prefabs = new List<Object>();

		GameObject terrain = (GameObject)Resources.Load ("TerrainPrefab");
		GameObject drone = (GameObject)Resources.Load ("DronePrefab");
		GameObject camera = (GameObject)Resources.Load("CameraRigPrefab");

		prefabs.Add(Instantiate(terrain, new Vector3(0,0,0), Quaternion.identity, transform));
		prefabs.Add(Instantiate(drone, new Vector3(0,0,0), Quaternion.identity, transform));
		prefabs.Add(Instantiate(camera, new Vector3(0,0,0), Quaternion.identity, transform));
	}
}
