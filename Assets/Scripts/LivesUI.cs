using UnityEngine;
using System.Collections;

public class LivesUI : MonoBehaviour {
	
	public TextMesh livesText;
	
	// Update is called once per frame
	void Update () {
		livesText.text = PlayerStats.Lives.ToString() + " LIVES";
	}
}
