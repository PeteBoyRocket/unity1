using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        var rigidBody = this.GetComponent<Rigidbody>();
        rigidBody.velocity = this.transform.forward * this.speed;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
