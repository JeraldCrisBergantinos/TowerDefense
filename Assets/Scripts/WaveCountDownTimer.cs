using UnityEngine;

public class WaveCountDownTimer : MonoBehaviour {

	public string text;
	public Rect rect;
	public GUIStyle style;
	
	void OnGUI() {
		rect.width = text.Length * rect.height;
		rect.x = ( Screen.width - rect.width ) * 0.5f;
		rect.y = ( Screen.height - rect.height ) * 0.025f;
		GUI.Label( rect, text, style );
	}
	
}
