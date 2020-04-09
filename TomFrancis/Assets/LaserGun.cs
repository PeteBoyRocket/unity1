using UnityEngine;

public class LaserGun : MonoBehaviour
{
    public GameObject laserPrefab;
    private GameObject laser;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var fireKeyDown = true;// Input.GetKey(KeyCode.Space);
        if (fireKeyDown)
        {
            if (this.laser == null)
            {
                this.laser = Instantiate(this.laserPrefab, this.transform);
            }
        }
        else
        {
            if (this.laser != null)
            {
                Destroy(this.laser);
            }
        }


    }
}
