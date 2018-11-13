using UnityEngine;

public class Node : MonoBehaviour {
	
	public Color hoverColor;
	public Vector3 positionOffset;
	
	private Renderer rend;
	private Color startColor;
	
	private GameObject turret;
	
	void Start() {
		rend = GetComponent<Renderer>();
		startColor = rend.material.color;
	}

	void OnMouseEnter() {
		rend.material.color = hoverColor;
	}
	
	void OnMouseExit() {
		rend.material.color = startColor;
	}
	
	void OnMouseDown() {
		if ( turret != null ) {
			Debug.Log( "Can't build here! - TODO: Display on screen." );
			return;
		}
		
		GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
		turret = Instantiate( turretToBuild, transform.position + positionOffset, transform.rotation ) as GameObject;
	}
}
