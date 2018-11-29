using UnityEngine;

public class ShopUI : MonoBehaviour {
	
	[System.Serializable]
	public class Item {
		public Texture icon;
		public string price;
		public bool interactive = true;
		public Texture disabledIcon;
		
		[HideInInspector]
		public Texture startIcon;
	}
	
	public Item[] turretItems;
	public Item[] nodeItems;
	
	public Rect itemRect;
	public Rect priceRect;
	public GUIStyle priceStyle;
	
	public float iconOffset = 5f;
	public Shop shop;
	public NodeUI nodeUI;
	
	public int upgradeButtonIndex = 0;
	
	BuildManager buildManager;
	
	void Start() {
		buildManager = BuildManager.instance;
		
		foreach (Item item in nodeItems) {
			item.startIcon = item.icon;
		}
	}

	void OnGUI () {
		DisplayItems();
	}
	
	void DisplayItems() {
		if ( !buildManager.CanBuild && !buildManager.HasNode )
			DisplayTurretItems();
		else if ( buildManager.CanBuild )
			DisplayTurretItems();
		else if ( buildManager.HasNode )
			DisplayNodeItems();
	}
	
	void DisplayItems( Item[] items, bool turretOnly ) {
		for (int i = 0; i < items.Length; i++) {
			float startX = ( Screen.width - itemRect.width * items.Length - iconOffset * ( items.Length - 1 ) ) * 0.5f;
			float adjustX = ( itemRect.width + iconOffset ) * i;
			float x = startX + adjustX;
			float y = Screen.height - itemRect.height;
			Rect rect = new Rect( x, y, itemRect.width, itemRect.height );
			if ( GUI.Button( rect, items[i].icon ) ) {
				if ( items[i].interactive )
					SelectItem( i, turretOnly );
			}
			
			x = x + (itemRect.width - priceRect.width) * 0.5f;
			y = Screen.height - priceRect.height;
			rect = new Rect( x, y, priceRect.width, priceRect.height );
			GUI.Label( rect, items[i].price, priceStyle );
		}
	}
	
	void DisplayTurretItems() {
		DisplayItems( turretItems, true );
	}
	
	void DisplayNodeItems() {
		if ( nodeUI.TargetIsUpgraded() ) {
			nodeItems[upgradeButtonIndex].price = "DONE";
			nodeItems[upgradeButtonIndex].interactive = false;
			nodeItems[upgradeButtonIndex].icon = nodeItems[upgradeButtonIndex].disabledIcon;
		}
		else {
			nodeItems[upgradeButtonIndex].price = "$" + nodeUI.upgradeCost.ToString();
			nodeItems[upgradeButtonIndex].interactive = true;
			nodeItems[upgradeButtonIndex].icon = nodeItems[upgradeButtonIndex].startIcon;
		}
		
		DisplayItems( nodeItems, false );
	}
	
	void SelectItem( int i, bool turretOnly ) {
		if ( turretOnly ) {
			SelectTurretItem(i);
		}
		else {
			SelectNodeItem(i);
		}
	}
		
	void SelectTurretItem( int i ) {
		switch (i) {
			case 0:
				shop.SelectStandardTurret();
				break;
			case 1:
				shop.SelectMissileLauncher();
				break;
			case 2:
				shop.SelectLaserBeamer();
				break;
			default:
			break;
		}
	}
		
	void SelectNodeItem( int i ) {
		switch (i) {
			case 0:
				nodeUI.Upgrade();
				break;
			default:
				break;
		}
	}
	
	bool CanDisplayItem {
		get {
			return ( ( buildManager.CanBuild && !buildManager.HasNode ) ||
				( !buildManager.CanBuild && buildManager.HasNode ) );
		}
	}
}