using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float speed;
    private Rigidbody rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        this.rigidBody = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (References.thePlayer == null)
        {
            return;
        }

        var vectorToPlayer = References.thePlayer.transform.position - this.transform.position;
        this.rigidBody.velocity = vectorToPlayer.normalized * this.speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        var playerBehaviour = collision.gameObject.GetComponent<PlayerBehaviour>();
        if (playerBehaviour == null)
        {
            return;
        }

        var healthSystem = collision.gameObject.GetComponent<HealthSystem>();
        if (healthSystem == null)
        {
            return;
        }

        healthSystem.TakeDamage(1);
    }
}
