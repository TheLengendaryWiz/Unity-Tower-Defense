using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public float ExplosionRadius=0F;
    public float speed = 70f;
    public int damage = 50;
    public GameObject bulletImpact;
    public void Chase(Transform _target)
    {
        target = _target;
    }
    void Update()
    {
        if (target==null)
        {
            Destroy(gameObject);
            return;
        }
        Vector3 dir = target.position - transform.position;
        float DistanceThisFrame = speed * Time.deltaTime;
        if (dir.magnitude <= DistanceThisFrame)
        {
            HitTarget();
            return;
        }
        transform.Translate(dir.normalized * DistanceThisFrame,Space.World);
        transform.LookAt(target);
    }

    private void HitTarget()
    {
        GameObject effectins = Instantiate(bulletImpact, target.position, transform.rotation);
        Destroy(effectins, 5f);

        if (ExplosionRadius > 0f)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }
        Destroy(gameObject);
    }

    private void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, ExplosionRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "enemy")
            {
                Damage(collider.transform);
            }
        }
    }

    private void Damage(Transform Enemy)
    {
        enemy e =Enemy.GetComponent<enemy>();
        if (e != null)
        {
            e.TakeDamage(damage);
        }
    }
    
}