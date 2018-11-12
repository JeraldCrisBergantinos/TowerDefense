using UnityEngine;
using System.Collections;

public class WaveSpawner : MonoBehaviour {
	
	public Transform enemyPrefab;
	public Transform spawnPoint;
	public float timeBetweenWaves = 5f;
	public float timeBetweenSpawns = 0.5f;
	public WaveCountDownTimer waveCountDownTimer;
	
	private float countDown = 2f;
	private int waveIndex = 0;
	
	void Update() {
		if ( countDown <= 0f ) {
			StartCoroutine( SpawnWave() );
			countDown = timeBetweenWaves;
		}
		
		countDown -= Time.deltaTime;
		waveCountDownTimer.text = Mathf .Round(countDown).ToString();
	}
	
	IEnumerator SpawnWave() {
		++waveIndex;
		
		for (int i = 0; i < waveIndex; i++) {
			SpawnEnemy();
			yield return new WaitForSeconds( timeBetweenSpawns );
		}
	}
	
	void SpawnEnemy() {
		Instantiate( enemyPrefab, spawnPoint.position, spawnPoint.rotation );
	}
	
}
