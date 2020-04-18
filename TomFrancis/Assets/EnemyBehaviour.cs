using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public GameObject player;
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
        var vectorToPlayer = this.player.transform.position - this.transform.position;
        this.rigidBody.velocity = vectorToPlayer.normalized * this.speed;
    }
}
