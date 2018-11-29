using UnityEngine;

public class Node : MonoBehaviour {
	
	public Color hoverColor;
	public Color notEnoughMoneyColor;
	public Vector3 positionOffset;
	
	[HideInInspector]
	public TurretBlueprint turretBlueprint;
	
	[HideInInspector]
	public bool isUpgraded = false;
	
	private Renderer rend;
	private Color startColor;
	
	BuildManager buildManager;
	
	private GameObject turret;
	
	void Start() {
		rend = GetComponent<Renderer>();
		startColor = rend.material.color;
		buildManager = BuildManager.instance;
	}
	
	public Vector3 GetBuildPosition() {
		return transform.position + positionOffset;
	}

	void OnMouseEnter() {
		if ( turret != null ) {
			rend.material.color = hoverColor;
			return;
		}
		else if ( !buildManager.CanBuild ) {
			return;
		}
		
		if ( buildManager.HasMoney ) {
			rend.material.color = hoverColor;
		}
		else {
			rend.material.color = notEnoughMoneyColor;
		}
	}
	
	void OnMouseExit() {
		rend.material.color = startColor;
	}
	
	void OnMouseDown() {
		if ( turret != null ) {
			buildManager.SelectNode( this );
			return;
		}
		else {
			buildManager.DeselectNode();
		}
		
		if ( !buildManager.CanBuild ) {
			return;
		}
		
		BuildTurret( buildManager.GetTurretToBuild() );
	}
	
	void BuildTurret( TurretBlueprint bluePrint ) {
		if ( PlayerStats.Money < bluePrint.cost ) {
			Debug.Log( "Not enough money to build that!" );
			return;
		}
		
		PlayerStats.Money -= bluePrint.cost;
		
		Vector3 buildPos = GetBuildPosition();
		GameObject _turret = Instantiate( bluePrint.prefab, buildPos, Quaternion.identity ) as GameObject;
		turret = _turret;
		
		turretBlueprint = bluePrint;
		
		GameObject effect = Instantiate( buildManager.buildEffect, buildPos, Quaternion.identity ) as GameObject;
		Destroy( effect, 5f );
		
		Debug.Log( "Turret built!" );
	}
	
	public void UpgradeTurret() {
		if ( PlayerStats.Money < turretBlueprint.upgradeCost ) {
			Debug.Log( "Not enough money to upgrade that!" );
			return;
		}
		
		PlayerStats.Money -= turretBlueprint.upgradeCost;
		
		//Get rid of the old turret
		Destroy( turret );
		
		//Build a new turret
		Vector3 buildPos = GetBuildPosition();
		GameObject _turret = Instantiate( turretBlueprint.upgradePrefab, buildPos, Quaternion.identity ) as GameObject;
		turret = _turret;
		
		GameObject effect = Instantiate( buildManager.buildEffect, buildPos, Quaternion.identity ) as GameObject;
		Destroy( effect, 5f );
		
		isUpgraded = true;
		
		Debug.Log( "Turret upgraded!" );
	}
}
