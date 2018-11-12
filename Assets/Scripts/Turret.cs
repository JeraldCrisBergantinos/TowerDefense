using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour {
	
	public float range = 15f;
	public float updateTargetInterval = 0.5f;
	public string enemyTag = "Enemy";
	public Transform partToRotate;
	public float turnSpeed = 10f;
	public float fireRate = 1f;
	public GameObject bulletPrefab;
	public Transform firePoint;
	
	private Transform target;
	private float fireCountDown = 0f;

	// Use this for initialization
	void Start () {
		InvokeRepeating( "UpdateTarget", 0f, updateTargetInterval );
	}
	
	void UpdateTarget() {
		GameObject[] enemies = GameObject.FindGameObjectsWithTag( enemyTag );
		float shortestDistance = Mathf.Infinity;
		GameObject nearestEnemy = null;
		
		foreach (GameObject enemy in enemies) {
			float distanceToEnemy = Vector3.Distance( transform.position, enemy.transform.position );
			if ( distanceToEnemy < shortestDistance ) {
				shortestDistance = distanceToEnemy;
				nearestEnemy = enemy;
			}
		}
		
		if ( nearestEnemy != null && shortestDistance <= range ) {
			target = nearestEnemy.transform;
		}
		else {
			target = null;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if ( target == null )
			return;
		
		//target lock on
		Vector3 dir = target.position - transform.position;
		Quaternion lookRotation = Quaternion.LookRotation( dir );
		Vector3 rotation = Quaternion.Lerp( partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed ).eulerAngles;
		partToRotate.rotation = Quaternion.Euler( 0f, rotation.y, 0f );
		
		if ( fireCountDown <= 0f ) {
			Shoot();
			fireCountDown = 1f / fireRate;
		}
		
		fireCountDown -= Time.deltaTime;
	}
	
	void Shoot() {
		GameObject bulletGO = Instantiate( bulletPrefab, firePoint.position, firePoint.rotation ) as GameObject;
		Bullet bullet = bulletGO.GetComponent<Bullet>();
		
		if ( bullet != null ) {
			bullet.Seek( target );
		}
	}
	
	void OnDrawGizmosSelected() {
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere( transform.position, range );
	}
}
