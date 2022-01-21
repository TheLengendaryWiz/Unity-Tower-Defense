using System.Collections;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public static int enemiesAlive = 0;
    public GameManager gameManager;
    public Wave[] waves;
    public TextMesh wavenumber;
    public Transform spaenPoint;
    public float timeBetweenWaves = 5f;
    private float countdown = 2f;
    [HideInInspector]
    public int waveNo = 0;
    private void Update()
    {
        if (enemiesAlive>0)
        {
            return;
        }
        if (waveNo == waves.Length)
        {
            gameManager.WinLevel();
            this.enabled = false;
        }
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }
        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        wavenumber.text = string.Format("{0:00.00}", countdown);
    }

    IEnumerator SpawnWave()
    {
        playerStats.rounds++;
        Wave wave = waves[waveNo];
        enemiesAlive = wave.count;
        for (int i = 0; i < wave.count; i++)
        {
            SpanEnemy(wave.enemy);
            yield return new WaitForSeconds(1/wave.rate);
        }
        waveNo++;
    }

    private void SpanEnemy(GameObject enemyPrefab)
    {
        Instantiate(enemyPrefab,spaenPoint.position,spaenPoint.rotation);
    }
    private void Start()
    {
        enemiesAlive = 0;
    }
}