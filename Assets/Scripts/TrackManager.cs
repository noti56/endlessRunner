using UnityEngine;
using System.Collections;

public class TrackManager : MonoBehaviour
{
    [SerializeField] private GameObject groundPrefab;
    [SerializeField] private Transform player;
    [SerializeField] private GameObject[] Items;

    public float environmentSpeed;
    [SerializeField] private float speedMultiplier = 1.5f;
    [SerializeField] private float timeSpeedInterval = 10f; // Time interval to multiply the speed
    [SerializeField] private float timePerEnemy = 3f; // Time interval to multiply the speed

    [SerializeField] private int enemiesAmountPerTime = 3;
    [SerializeField] private int spaceBetweenEnemies = 20;
    [SerializeField] private float rightSpot = 1;
    [SerializeField] private float leftSpot = -1;
    private Vector3 nextSpawnPoint;
    private int lastItemSpawned;
    private float lastHorizontalSpawned;
    private bool initFirstEnemies = false;
    void Start()
    {
        nextSpawnPoint = new Vector3(0, 0, spaceBetweenEnemies);

        StartCoroutine(IncreaseSpeedOverTime());
        StartCoroutine(SpawnStuff());

    }

    public void SpawnSegment()
    {
        Instantiate(groundPrefab, nextSpawnPoint, Quaternion.identity);

        int obstacleType = Random.Range(0, Items.Length);
        if (obstacleType == lastItemSpawned)
        {
            obstacleType = Random.Range(0, Items.Length);
        }
        lastItemSpawned = obstacleType;

        GameObject obstaclePrefab = Items[obstacleType];

        // Randomly choose between left and right spot
        float horizontalPosition = Random.Range(0, 2) == 0 ? leftSpot : rightSpot;
        lastHorizontalSpawned = horizontalPosition;

        // Instantiate the obstacle at the chosen position
        Instantiate(obstaclePrefab, nextSpawnPoint + new Vector3(lastHorizontalSpawned, 1, 0), Quaternion.identity);

        nextSpawnPoint += new Vector3(0, 0, spaceBetweenEnemies);
    }

    private IEnumerator IncreaseSpeedOverTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeSpeedInterval);
            environmentSpeed *= speedMultiplier;
        }
    }
    private IEnumerator SpawnStuff()
    {
        while (true)
        {
            if (initFirstEnemies)
            {
                yield return new WaitForSeconds(timePerEnemy);
            }
            initFirstEnemies = true;
            for (int i = 0; i < enemiesAmountPerTime; i++)
            {
                SpawnSegment();

            }
        }
    }
}
