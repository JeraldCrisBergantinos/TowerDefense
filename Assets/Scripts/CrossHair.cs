using UnityEngine;
using System.Collections;

public class CrossHair : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		transform.Rotate( Vector3.up * 100 * Time.deltaTime );
	}
}
