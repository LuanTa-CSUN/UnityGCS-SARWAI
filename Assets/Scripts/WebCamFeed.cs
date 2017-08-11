using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WebCamFeed : MonoBehaviour {

	public RawImage webcamfeed;

    // Not entirely sure how this works
	void Start () {
		WebCamTexture webcamTexture = new WebCamTexture();
		webcamfeed.texture = webcamTexture;
		webcamfeed.material.mainTexture = webcamTexture;
		webcamTexture.Play();
	}
}
