using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {
	
	public void Retry() {
		Application.LoadLevel( 0 );
	}
	
	public void Menu() {
		Debug.Log( "Menu" );
	}
}
