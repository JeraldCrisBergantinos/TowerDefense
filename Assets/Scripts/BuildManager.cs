using UnityEngine;

public class BuildManager : MonoBehaviour {
	
	public static BuildManager instance;
	
	public GameObject standardTurretPrefab;
	public GameObject missileLauncherPrefab;
	
	public GameObject buildEffect;
	
	private TurretBlueprint turretToBuild;
	
	void Awake() {
		if ( instance != null ) {
			Debug.LogError( "More than one BuildManager in the scene." );
			return;
		}
		
		instance = this;
	}
	
	public bool CanBuild {
		get {
			return turretToBuild != null;
		}
	}
	
	public bool HasMoney {
		get {
			return PlayerStats.Money >= turretToBuild.cost;
		}
	}
	
	public void BuildTurretOn( Node node ) {
		if ( PlayerStats.Money < turretToBuild.cost ) {
			Debug.Log( "Not enough money to build that!" );
			return;
		}
		
		PlayerStats.Money -= turretToBuild.cost;
		
		Vector3 buildPos = node.GetBuildPosition();
		GameObject turret = Instantiate( turretToBuild.prefab, buildPos, Quaternion.identity ) as GameObject;
		node.turret = turret;
		
		GameObject effect = Instantiate( buildEffect, buildPos, Quaternion.identity ) as GameObject;
		Destroy( effect, 5f );
		
		Debug.Log( "Turret built! Money left: " + PlayerStats.Money );
	}
	
	public void SelectTurretToBuild( TurretBlueprint turret ) {
		turretToBuild = turret;
	}
	
}
