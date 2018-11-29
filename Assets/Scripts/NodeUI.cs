using UnityEngine;
using System.Collections;

public class NodeUI : MonoBehaviour {
	
	public GameObject ui;
	
	[HideInInspector]
	public int upgradeCost;	
	
	private Node target;
	
	public void SetTarget( Node _target ) {
		target = _target;
		transform.position = target.GetBuildPosition();
		upgradeCost = target.turretBlueprint.upgradeCost;
		ui.SetActive( true );
	}
	
	public void Hide() {
		ui.SetActive( false );
	}
	
	public void Upgrade() {
		target.UpgradeTurret();
		BuildManager.instance.DeselectNode();
	}
	
	public bool TargetIsUpgraded() {
		return target.isUpgraded;
	}
}
