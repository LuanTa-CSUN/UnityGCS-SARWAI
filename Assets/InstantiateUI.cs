using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateUI : MonoBehaviour {

	// Instantiates the UI for use on the World Space
    // Plan to adapt to Singleton implementation to keep across scenes
    void Awake()
    {
        GameObject ui = (GameObject)Resources.Load("UIPrefab");
        Instantiate(ui, new Vector3(0, 0, 0), Quaternion.identity, transform);
    }
}
