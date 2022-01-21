using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform target;
    enemy targetenemy;
    public float slowPer = .5f;
    public Light impactLight;
    public int damageOverTime = 30;
    public Transform partToRotate;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float range = 15f;
    public float fireSpeed = 1f;
    private float fireCountdown = 0f;
    public float speed = 5f;
    public bool UseLaser = false;
    public LineRenderer lineRenderer;
    public ParticleSystem impacteffect;
    private string enemiesTag = "enemy";

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }
    void UpdateTarget()
    {
        GameObject[] Enemies = GameObject.FindGameObjectsWithTag(enemiesTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in Enemies)
        {
            float DistanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (DistanceToEnemy < shortestDistance)
            {
                shortestDistance = DistanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        if (nearestEnemy != null && shortestDistance < range)
        {
            target = nearestEnemy.transform;
            targetenemy = target.GetComponent<enemy>();
        }
        else
        {
            target = null;
        }
    }
    void Update()
    {
        
        if (target == null)
        {
            if (UseLaser)
            {
                if (lineRenderer.enabled)
                {
                    lineRenderer.enabled = false;
                    impacteffect.Stop();
                    impactLight.enabled = false;
                }
            }
            return;
        }
            
        LockOnTarget();
        if (UseLaser)
        {
            useLaser();
        }
        else
        {
            if (fireCountdown <= 0)
            {
                Shoot();
                fireCountdown = 1 / fireSpeed;
            }
            fireCountdown -= Time.deltaTime;
        }
        
    }

    private void useLaser()
    {
        targetenemy.TakeDamage(damageOverTime * Time.deltaTime);
        targetenemy.Slow(slowPer);
        if (!lineRenderer.enabled)
        {
            lineRenderer.enabled = true;
            impacteffect.Play();
            impactLight.enabled = true;
        }
        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, target.position);
        Vector3 dir = firePoint.position-target.position;
        impacteffect.transform.rotation = Quaternion.LookRotation(dir);
        impacteffect.transform.position = target.position+dir.normalized * .5f;
    }

    private void LockOnTarget()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookROtation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookROtation, Time.deltaTime * speed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    private void Shoot()
    {

        GameObject bulletGO = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        if (bullet != null)
        {
            bullet.Chase(target);
        }
    }
    
}
    

