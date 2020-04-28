using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public float speed;
    public float secondsUntilDestroyed;
    public float damage;

    // Start is called before the first frame update
    void Start()
    {
        var rigidBody = this.GetComponent<Rigidbody>();
        rigidBody.velocity = this.transform.forward * this.speed;
    }

    // Update is called once per frame
    void Update()
    {
        this.secondsUntilDestroyed -= Time.deltaTime;

        if (this.secondsUntilDestroyed < 1)
        {
            this.transform.localScale *= this.secondsUntilDestroyed;
        }

        if (this.secondsUntilDestroyed <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        var bulletBehaviour = collision.gameObject.GetComponent<BulletBehaviour>();
        if (bulletBehaviour != null)
        {
            // I've hit another bullet!
            return;
        }

        var enemyBehaviour = collision.gameObject.GetComponent<EnemyBehaviour>();
        if (enemyBehaviour != null)
        {
            var healthSystem = collision.gameObject.GetComponent<HealthSystem>();
            if (healthSystem == null)
            {
                Destroy(collision.gameObject);

            }
            else
            {
                healthSystem.TakeDamage(this.damage);
            }

            Destroy(this.gameObject);
        }
    }
}
