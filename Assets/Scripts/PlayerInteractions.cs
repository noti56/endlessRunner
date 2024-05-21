using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    // Start is called before the first frame update
    private GameManager gameManager;
    [SerializeField] private GameObject onPointParticle;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip coffeeSound;
    [SerializeField] private int coffePowerUpAmount = 10;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();



    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("obstacle"))
        {
            EnemyData enemyData = other.gameObject.GetComponent<EnvironmentMover>().enemyData;
            // gameManager.EndGame();

            if (enemyData == null) return;
            gameManager.HandleObstacleEvent(enemyData);
            return;
        }

        if (other.gameObject.CompareTag("cofee"))
        {
            gameManager.AddCofeePower(coffePowerUpAmount);
            Destroy(other.gameObject);
            Instantiate(onPointParticle, other.gameObject.transform.position, Quaternion.identity);
            audioSource.PlayOneShot(coffeeSound);
        }
    }
}
