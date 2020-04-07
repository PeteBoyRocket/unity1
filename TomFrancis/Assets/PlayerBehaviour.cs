using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float speed;
    public GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // Movement
        var veritcalAxis = Input.GetAxis("Vertical");
        var horizontalAxis = Input.GetAxis("Horizontal");

        var inputVector = new Vector3(horizontalAxis, 0, veritcalAxis);

        if (inputVector.magnitude > 0)
        {
            var rigidBody = this.GetComponent<Rigidbody>();
            rigidBody.velocity = inputVector * this.speed;

            var lookAtPosition = this.transform.position + inputVector;

            this.transform.LookAt(lookAtPosition);
        }

        // Pew pew
        if (Input.GetKey(KeyCode.Mouse0))
        {
            var bullet = Instantiate(this.bulletPrefab, this.transform.position + this.transform.forward, this.transform.rotation);
            // Destroy(bullet, 1);
        }
    }
}
