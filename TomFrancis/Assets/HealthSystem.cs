using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public float health;

    public void TakeDamage(float damageAmount)
    {
        this.health -= damageAmount;
        if (this.health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
