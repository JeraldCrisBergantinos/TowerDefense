using UnityEngine;
using System.Collections;

public class GameOverAnimation : MonoBehaviour {
	
	public GameOverUI gameOverUI;

	public float titleDropY;
	public Color titleFadeColor;
	
	public float roundsScale;
	public Color roundsFadeColor;
	
	public float retryScale;
	public float menuScale;
	
	float startRoundsScale;
	float startRoundsSurvivedScale;
	
	Rect startRetryRect;
	Color startRetryColor;
	float startRetryFontSizePercent;
	
	Rect startMenuRect;
	Color startMenuColor;
	float startMenuFontSizePercent;
	
	void OnEnable() {
		startRoundsScale = gameOverUI.rounds.fontSizePercent;
		startRoundsSurvivedScale = gameOverUI.roundsSurvived.fontSizePercent;
		
		startRetryRect = gameOverUI.retry.rectPercent;
		startRetryColor = gameOverUI.retry.style.normal.textColor;
		startRetryFontSizePercent = gameOverUI.retry.fontSizePercent;
		
		startMenuRect = gameOverUI.menu.rectPercent;
		startMenuColor = gameOverUI.menu.style.normal.textColor;
		startMenuFontSizePercent = gameOverUI.menu.fontSizePercent;
		
		StartCoroutine( "Animate" );
	}
	
	void OnDisable() {
		StopCoroutine( "Animate" );
	}
	
	IEnumerator Animate() {
		while ( true ) {
			gameOverUI.title.rectPercent.y = titleDropY;
			gameOverUI.title.style.normal.textColor = titleFadeColor;
			
			gameOverUI.rounds.fontSizePercent = startRoundsScale * roundsScale;
			gameOverUI.roundsSurvived.fontSizePercent = startRoundsSurvivedScale * roundsScale;
			
			gameOverUI.rounds.style.normal.textColor = roundsFadeColor;
			gameOverUI.roundsSurvived.style.normal.textColor = roundsFadeColor;
			
			gameOverUI.retry.rectPercent.width = startRetryRect.width * retryScale;
			gameOverUI.retry.rectPercent.height = startRetryRect.height * retryScale;
			gameOverUI.retry.style.normal.textColor = startRetryColor * retryScale;
			gameOverUI.retry.fontSizePercent = startRetryFontSizePercent * retryScale;
			
			gameOverUI.menu.rectPercent.width = startMenuRect.width * menuScale;
			gameOverUI.menu.rectPercent.height = startMenuRect.height * menuScale;
			gameOverUI.menu.style.normal.textColor = startMenuColor * menuScale;
			gameOverUI.menu.fontSizePercent = startMenuFontSizePercent * menuScale;
			
			yield return null;
		}
	}
}
