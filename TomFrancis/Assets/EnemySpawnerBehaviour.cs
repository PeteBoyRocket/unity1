using UnityEngine;

public class EnemySpawnerBehaviour : MonoBehaviour
{
    public GameObject spawnPoint;
    public GameObject enemyPrefab;
    public float secondsBetweenSpawns;
    private float secondsSinceLastSpawn;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void FixedUpdate()
    {
        this.secondsSinceLastSpawn += Time.fixedDeltaTime;

        if (this.secondsSinceLastSpawn >= this.secondsBetweenSpawns)
        {
            Instantiate(this.enemyPrefab, this.spawnPoint.transform.position, this.spawnPoint.transform.rotation);
            this.secondsSinceLastSpawn = 0;
        }
    }
}
