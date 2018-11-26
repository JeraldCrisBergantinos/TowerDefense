using UnityEngine;
using System.Collections;

public class SpectrumAnalyzer : MonoBehaviour {
	
	public GameObject[] nodes;

	// Use this for initialization
	void Start () {
		nodes = GameObject.FindGameObjectsWithTag( "Node" );
	}
	
	// Update is called once per frame
	void Update () {
		float[] spectrum = new float[1024];
        AudioListener.GetSpectrumData(spectrum, 0, FFTWindow.Rectangular );
        float l1 = spectrum [0] + spectrum [2] + spectrum [4];
        float l2 = spectrum [10] + spectrum [11] + spectrum [12];
        float l3 = spectrum[20] + spectrum [21] + spectrum [22];
        float l4 = spectrum [40] + spectrum [41] + spectrum [42] + spectrum [43];
        float l5 = spectrum [80] + spectrum [81] + spectrum [82] + spectrum [83];
        float l6 = spectrum [160] + spectrum [161] + spectrum [162] + spectrum [163];
        float l7 = spectrum [320] + spectrum [321] + spectrum [322] + spectrum [323];

		for( int i = 0; i < nodes.Length; i++ ) {
			Vector3 oldScale = nodes[i].gameObject.transform.localScale;
			switch (i%7) {
			case 0:
                nodes[i].gameObject.transform.localScale = new Vector3(oldScale.x, l1 * 10 * 0.5f, oldScale.z); // base drum
                break;
            case 1:
                nodes[i].gameObject.transform.localScale = new Vector3(oldScale.x, l2 * 20 * 0.5f, oldScale.z); // base guitar
                break;
            case 2:
                nodes[i].gameObject.transform.localScale = new Vector3(oldScale.x, l3 * 40 * 0.5f, oldScale.z);
                break;
            case 3:
                nodes[i].gameObject.transform.localScale = new Vector3(oldScale.x, l4 * 80 * 0.5f, oldScale.z);
                break;
            case 4:
                nodes[i].gameObject.transform.localScale = new Vector3(oldScale.x, l5 * 160 * 0.5f, oldScale.z);
                break;
            case 5:
                nodes[i].gameObject.transform.localScale = new Vector3(oldScale.x, l6 * 320 * 0.5f, oldScale.z);
                break;
            case 6:
                nodes[i].gameObject.transform.localScale = new Vector3(oldScale.x, l7 * 640 * 0.5f, oldScale.z); //*tsk tsk tsk
                break;
			}
		}

	}
}
