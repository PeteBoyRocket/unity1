using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float speed;
    public GameObject bulletPrefab;
    public float secondsBetweenShots;

    private float secondsSinceLastShot;

    // Start is called before the first frame update
    void Start()
    {
        this.secondsSinceLastShot = this.secondsBetweenShots;
        References.thePlayer = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        // Movement
        var veritcalAxis = Input.GetAxis("Vertical");
        var horizontalAxis = Input.GetAxis("Horizontal");

        var inputVector = new Vector3(horizontalAxis, 0, veritcalAxis);

        var rigidBody = this.GetComponent<Rigidbody>();
        rigidBody.velocity = inputVector * this.speed;

        var rayFromCameraToCursor = Camera.main.ScreenPointToRay(Input.mousePosition);
        var playerPlane = new Plane(Vector3.up, this.transform.position);
        playerPlane.Raycast(rayFromCameraToCursor, out var distanceFromCamera);
        var cursorPosition = rayFromCameraToCursor.GetPoint(distanceFromCamera);

        this.transform.LookAt(cursorPosition);

        // Pew pew
        this.secondsSinceLastShot += Time.deltaTime;
        if (this.secondsSinceLastShot >= this.secondsBetweenShots && Input.GetKey(KeyCode.Mouse0))
        {
            this.secondsSinceLastShot = 0;
            var bullet = Instantiate(this.bulletPrefab, this.transform.position + this.transform.forward, this.transform.rotation);
            // Destroy(bullet, 1);
        }
    }
}
