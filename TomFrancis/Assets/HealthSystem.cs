using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public float maxHealth;
    public GameObject healthBarPrefab;
    public GameObject deathEffectPrefab;
    private HealthBarBehaviour healthBarBehaviour;
    private float currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        this.currentHealth = this.maxHealth;
        var healthBarObject = Instantiate(this.healthBarPrefab, References.canvas.transform);
        this.healthBarBehaviour = healthBarObject.GetComponent<HealthBarBehaviour>();
    }

    public void TakeDamage(float damageAmount)
    {
        this.currentHealth -= damageAmount;
        if (this.currentHealth <= 0)
        {
            if (this.deathEffectPrefab != null)
            {
                Instantiate(this.deathEffectPrefab, this.transform.position, this.transform.rotation);
            }

            Destroy(this.gameObject);
        }
    }

    private void OnDestroy()
    {
        if (this.healthBarBehaviour != null)
        {
            Destroy(this.healthBarBehaviour.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        var currentHealthFraction = this.currentHealth / this.maxHealth;
        this.healthBarBehaviour.ShowHealthFraction(currentHealthFraction);

        this.healthBarBehaviour.transform.position = Camera.main.WorldToScreenPoint(this.transform.position + Vector3.up * 2);
    }
}
