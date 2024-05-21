using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] Animator animator;
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioSource audioSource;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();

    }

    void Update()
    {
        // Horizontal movement (optional for side-stepping)
        float moveHorizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(moveHorizontal, 0, 0);

        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rb.velocity.y) < 0.01f)
        {
            audioSource.PlayOneShot(jumpSound);
            animator.SetTrigger("jump");
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }



}
