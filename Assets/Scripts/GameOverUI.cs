using UnityEngine;
using System.Collections;

public class GameOverUI : MonoBehaviour {
	
	public GUITexture background;
	
	[System.Serializable]
	public class CustomUI {
		public Rect rectPercent;
		public string text;
		public GUIStyle style;
		public float fontSizePercent;
	}
	
	public CustomUI title;
	public CustomUI rounds;
	public CustomUI roundsSurvived;
	public CustomUI retry;
	public CustomUI menu;
	
	enum ButtonType {
		Retry,
		Menu
	}
	
	public GameOver gameOver;

	// Use this for initialization
	void Start () {
		background.pixelInset = new Rect( 0, 0, Screen.width, Screen.height );
	}
	
	void OnGUI() {
		DisplayTitle();
		DisplayRounds();
		DisplayRoundsSurvived();
		DisplayRetry();
		DisplayMenu();
	}
	
	void DisplayTitle() {
		DisplayLabel( title );
	}
	
	void DisplayRounds() {
		DisplayLabel( rounds );
	}
	
	void DisplayRoundsSurvived() {
		DisplayLabel( roundsSurvived );
	}
	
	void DisplayLabel( CustomUI customUI ) {
		Rect rect = customUI.rectPercent;
		rect.width = Screen.width * Mathf.Clamp( rect.width, 0f, 1f );
		rect.height = Screen.height * Mathf.Clamp( rect.height, 0f, 1f );
		rect.x = ( Screen.width - rect.width ) * 0.5f;
		rect.y = Screen.height * Mathf.Clamp( rect.y, 0f, 1f );
		
		customUI.style.fontSize = (int)( Screen.height * Mathf.Clamp( customUI.fontSizePercent, 0f, 1f ) );
		
		GUI.Label( rect, customUI.text, customUI.style );
	}
	
	void DisplayRetry() {
		DisplayButton( retry, ButtonType.Retry );
	}
	
	void DisplayMenu() {
		DisplayButton( menu, ButtonType.Menu );
	}
	
	void DisplayButton( CustomUI customUI, ButtonType type ) {
		Rect rect = customUI.rectPercent;
		rect.x = Screen.width * Mathf.Clamp( rect.x, 0f, 1f );
		rect.y = Screen.height * Mathf.Clamp( rect.y, 0f, 1f );
		rect.width = Screen.width * Mathf.Clamp( rect.width, 0f, 1f );
		rect.height = Screen.height * Mathf.Clamp( rect.height, 0f, 1f );
		
		customUI.style.fontSize = (int)( Screen.height * Mathf.Clamp( customUI.fontSizePercent, 0f, 1f ) );
		
		if ( GUI.Button( rect, customUI.text, customUI.style ) ) {
			ButtonClick( type );
		}
	}
	
	void ButtonClick( ButtonType type ) {
		switch (type) {
			case ButtonType.Retry:
				gameOver.Retry();
				break;
			case ButtonType.Menu:
				gameOver.Menu();
				break;
			default:
				break;
		}
	}
	
	void OnEnable() {
		rounds.text = PlayerStats.Rounds.ToString();
	}
}
