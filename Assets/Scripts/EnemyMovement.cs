using UnityEngine;
using System.Collections;

[RequireComponent( typeof(Enemy) )]
public class EnemyMovement : MonoBehaviour {
	
	private Transform target;
	private int waypointIndex = 0;
	private Enemy enemy;
	
	void Start() {
		target = Waypoints.points[0];
		enemy = GetComponent<Enemy>();
	}
	
	void Update() {
		Vector3 dir = target.position - transform.position;
		transform.Translate( dir.normalized * enemy.speed * Time.deltaTime, Space.World );
		
		if ( Vector3.Distance(transform.position,target.position) <= enemy.offset ) {
			GetNextWaypoint();
		}
		
		enemy.speed = enemy.startSpeed;
	}
	
	void GetNextWaypoint() {
		if ( waypointIndex >= Waypoints.points.Length - 1 ) {
			EndPath();
			return;
		}
		
		++waypointIndex;
		target = Waypoints.points[waypointIndex];
	}
	
	void EndPath() {
		PlayerStats.Lives--;
		Destroy( gameObject );
	}
}
