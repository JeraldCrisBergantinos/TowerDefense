using UnityEngine;
using System.Collections;

public class MoneyUI : MonoBehaviour {
	
	public TextMesh moneyText;
	
	// Update is called once per frame
	void Update () {
		moneyText.text = "$" + PlayerStats.Money.ToString();
	}
}
