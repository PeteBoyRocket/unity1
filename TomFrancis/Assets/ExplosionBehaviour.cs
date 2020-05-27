using UnityEngine;

public class ExplosionBehaviour : MonoBehaviour
{
    public float secondsToExist;
    private float secondsWeveBeenAlive;
    private Vector3 maxScale;

    // Start is called before the first frame update
    void Start()
    {
        this.maxScale = this.transform.localScale;
        this.transform.localScale = Vector3.zero;
    }

    private void FixedUpdate()
    {
        this.secondsWeveBeenAlive += Time.fixedDeltaTime;
        if (this.secondsWeveBeenAlive >= this.secondsToExist)
        {
            Destroy(this.gameObject);
        }
        else
        {
            var lifeFraction = this.secondsWeveBeenAlive / this.secondsToExist;
            this.transform.localScale = Vector3.Lerp(Vector3.zero, this.maxScale, lifeFraction);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var healthSystem = other.gameObject.GetComponent<HealthSystem>();
        if (healthSystem == null)
        {
            return;
        }

        healthSystem.TakeDamage(10);
    }
}
