using UnityEngine;



public class EnvironmentMover : MonoBehaviour
{
    [SerializeField] private MoveDirection direction = MoveDirection.Right;
    public EnemyData enemyData = null;
    private Transform playerTransform;
    private TrackManager trackManager;
    private Vector3 moveDirection;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        trackManager = FindObjectOfType<TrackManager>();

        // Determine the direction vector based on the selected enum
        switch (direction)
        {
            case MoveDirection.Left:
                moveDirection = Vector3.left;
                break;
            case MoveDirection.Right:
                moveDirection = Vector3.right;
                break;
            case MoveDirection.Forward:
                moveDirection = Vector3.forward;
                break;
            case MoveDirection.Backward:
                moveDirection = Vector3.back;
                break;
        }
    }

    void Update()
    {
        float speed = trackManager.environmentSpeed;
        transform.Translate(speed * Time.deltaTime * moveDirection);
        CheckForDestroying();
    }

    void CheckForDestroying()
    {
        if (transform.position.z < playerTransform.position.z - 5)
        {
            Destroy(gameObject);
        }
    }
}
