using UnityEngine;
using System.Collections;

public class WaveSpawner : MonoBehaviour {
	
	public Transform enemyPrefab;
	public Transform spawnPoint;
	public float timeBetweenWaves = 5f;
	public float timeBetweenSpawns = 0.5f;
	public TextMesh waveCountDownTimer;
	
	private float countDown = 2f;
	private int waveIndex = 0;
	
	void Update() {
		if ( countDown <= 0f ) {
			StartCoroutine( SpawnWave() );
			countDown = timeBetweenWaves;
		}
		
		countDown -= Time.deltaTime;
		countDown = Mathf.Clamp( countDown, 0f, Mathf.Infinity );
		waveCountDownTimer.text = string.Format( "{0:00.00}", countDown );
	}
	
	IEnumerator SpawnWave() {
		++waveIndex;
		++PlayerStats.Rounds;
		
		for (int i = 0; i < waveIndex; i++) {
			SpawnEnemy();
			yield return new WaitForSeconds( timeBetweenSpawns );
		}
	}
	
	void SpawnEnemy() {
		Instantiate( enemyPrefab, spawnPoint.position, spawnPoint.rotation );
	}
	
}
