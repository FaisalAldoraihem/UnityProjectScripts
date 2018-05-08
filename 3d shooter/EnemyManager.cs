using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject[] enemy;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;


    void Start ()
    {
        InvokeRepeating ("Spawn", spawnTime, spawnTime);
    }


    void Spawn ()
    {
        if(playerHealth.currentHealth <= 0f)
        {
            return;
        }

        int spawnPointIndex = Random.Range (0, spawnPoints.Length);
        if(spawnPointIndex == 0)
        {
            Instantiate(enemy[2],spawnPoints[0].position,spawnPoints[0].rotation);
        }

        else if (spawnPointIndex == 1)
        {
            Instantiate(enemy[0], spawnPoints[1].position, spawnPoints[1].rotation);
        }

        else if (spawnPointIndex == 2)
        {
            Instantiate(enemy[1], spawnPoints[2].position, spawnPoints[2].rotation);
        }

    }
}
