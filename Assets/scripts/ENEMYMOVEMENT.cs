using UnityEngine;
[RequireComponent(typeof(enemy))]
public class ENEMYMOVEMENT : MonoBehaviour
{
    Transform target;
    int wavePointIndex = 0;
    private enemy ENEMY;
    private void Start()
    {
        target = waypoints.points[0];
        ENEMY = GetComponent<enemy>();
    }
    private void GetNextWayPoint()
    {
        if (wavePointIndex >= waypoints.points.Length - 1)
        {
            EndPoint();
            return;
        }
        wavePointIndex++;
        target = waypoints.points[wavePointIndex];
    }

    private void EndPoint()
    {
        WaveSpawner.enemiesAlive--;
        playerStats.lives--;
        Destroy(gameObject);
    }
    private void Update()
    {
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * ENEMY.speed * Time.deltaTime, Space.World);
        if (Vector3.Distance(transform.position, target.position) <= 0.6f)
        {
            GetNextWayPoint();
        }
        ENEMY.speed = ENEMY.Startspeed;
    }
}