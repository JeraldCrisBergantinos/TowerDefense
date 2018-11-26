using UnityEngine;

public class Enemy : MonoBehaviour {
	
	public float startSpeed = 10f;
	
	[HideInInspector]
	public float speed;
	
	public float offset = 0.2f;
	
	public float health = 100f;
	public int moneyGain = 50;
	
	public GameObject deathEffect;
	public float skinThickness = 0.5f;
	
	void Start() {
		speed = startSpeed;
	}
	
	public void TakeDamage( float amount ) {
		health -= amount;
		
		if ( health <= 0 ) {
			Die();
		}
	}
	
	public void Slow( float percent ) {
		speed = startSpeed * ( 1f - percent );
	}
	
	void Die() {
		PlayerStats.Money += moneyGain;
		
		GameObject effect = Instantiate( deathEffect, transform.position, Quaternion.identity ) as GameObject;
		Destroy( effect, 5f );
		
		Destroy( gameObject );
	}
}
