using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LaserBeam : MonoBehaviour
{
    public float laserWidth = 1.0f;
    public float noise = 1.0f;
    public float maxLength = 50.0f;
    public Color color = Color.red;

    LineRenderer lineRenderer;
    int length;

    //The particle system, in this case sparks which will be created by the Laser
    ParticleSystem endEffect;

    // Use this for initialization
    void Start()
    {
        this.lineRenderer = this.GetComponent<LineRenderer>();
        this.lineRenderer.startWidth = this.laserWidth;
        this.lineRenderer.endWidth = this.laserWidth;

        this.endEffect = this.GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        this.RenderLaser();
    }

    void RenderLaser()
    {
        // Shoot our laserbeam forwards!
        this.UpdateLength();

        this.lineRenderer.startColor = this.color;
        this.lineRenderer.endColor = this.color;

        // Move through the Array
        for (int i = 0; i < this.length; i++)
        {
            // Set the position here to the current location and project it in the forward direction of the object it is attached to
            var x = this.transform.position.x + i * this.transform.forward.x + Random.Range(-this.noise, this.noise);
            var y = this.transform.position.y;
            var z = i * this.transform.forward.z + Random.Range(-this.noise, this.noise) + this.transform.position.z;
            var offset = new Vector3(x, y, z);

            this.lineRenderer.SetPosition(i, offset);
        }
    }

    void UpdateLength()
    {
        // Raycast from the location of the cube forwards
        RaycastHit[] hit;
        hit = Physics.RaycastAll(this.transform.position, this.transform.forward, this.maxLength);
        int i = 0;
        while (i < hit.Length)
        {
            // Check to make sure we aren't hitting triggers but colliders
            if (!hit[i].collider.isTrigger)
            {
                this.length = (int)Mathf.Round(hit[i].distance) + 2;

                // Move our End Effect particle system to the hit point and start playing it
                if (this.endEffect)
                {
                    this.endEffect.transform.position = hit[i].point;
                    if (!this.endEffect.isPlaying)
                    {
                        this.endEffect.Play();
                    }
                }

                this.lineRenderer.positionCount = this.length;
                return;
            }
            i++;
        }

        // If we're not hitting anything, don't play the particle effects
        if (this.endEffect)
        {
            if (this.endEffect.isPlaying)
            {
                this.endEffect.Stop();
            }
        }

        this.length = (int)this.maxLength;
        this.lineRenderer.positionCount = this.length;
    }
}
