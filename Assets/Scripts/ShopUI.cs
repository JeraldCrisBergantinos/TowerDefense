using UnityEngine;

[ExecuteInEditMode]
public class ShopUI : MonoBehaviour {
	
	public Rect standardTurretItemRect;
	public Texture standardTurretIcon;
	
	public Rect missileLauncherItemRect;
	public Texture missileLauncherIcon;
	
	public Rect turretPriceRect;
	public GUIStyle turretPriceStyle;
	
	public float iconOffset = 5f;
	
	public Shop shop;

	void OnGUI () {
		DisplayStandardTurretItem();
		DisplayMissileLauncherItem();
	}
	
	void DisplayStandardTurretItem() {
		float x = Screen.width * 0.5f - iconOffset * 0.5f - standardTurretItemRect.width;
		float y = Screen.height - standardTurretItemRect.height;
		Rect rect = new Rect( x, y, standardTurretItemRect.width, standardTurretItemRect.height );
		if ( GUI.Button( rect, standardTurretIcon ) )
			shop.SelectStandardTurret();
		
		x = x + (standardTurretItemRect.width - turretPriceRect.width) * 0.5f;
		y = Screen.height - turretPriceRect.height;
		rect = new Rect( x, y, turretPriceRect.width, turretPriceRect.height );
		GUI.Label( rect, "$100", turretPriceStyle );
	}
	
	void DisplayMissileLauncherItem() {
		float x = Screen.width * 0.5f + iconOffset * 0.5f;
		float y = Screen.height - missileLauncherItemRect.height;
		Rect rect = new Rect( x, y, missileLauncherItemRect.width, missileLauncherItemRect.height );
		if ( GUI.Button( rect, missileLauncherIcon ) )
			shop.SelectMissileLauncher();
		
		x = x + (missileLauncherItemRect.width - turretPriceRect.width) * 0.5f;
		y = Screen.height - turretPriceRect.height;
		rect = new Rect( x, y, turretPriceRect.width, turretPriceRect.height );
		GUI.Label( rect, "$250", turretPriceStyle );
	}
}
