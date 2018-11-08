using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour {

	Transform target;
	int camZoomStart = 10;
	int camZoomMax = 20;
	int camZoomMin = 5;

	//test
	
	// Use this for initialization
	void Start () {
		target = GameObject.Find("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (target) {
			transform.position = new Vector3 (target.position.x, target.position.y, -10f);

			CameraZoom ();
		}
	}

	void CameraZoom (){
		if (Input.GetAxis ("Mouse ScrollWheel") < 0 && Camera.main.orthographicSize < camZoomMax) {
			Camera.main.orthographicSize += 1;
		}
		if (Input.GetAxis ("Mouse ScrollWheel") > 0 && Camera.main.orthographicSize > camZoomMin) {
			Camera.main.orthographicSize -= 1;
		}
	}
}
