using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float playerspeed = 5f;
    [SerializeField] private float playerjumpforce = 5f;
    private bool isGrounded = true;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MovePlayer(Vector3 input)
    {
        Vector3 inputXZPlane = new(input.x, 0, input.z);
        Vector3 inputYPlane = new(0, input.y, 0);
        rb.AddForce(inputXZPlane * playerspeed);
        if (isGrounded)
        {
            rb.AddForce(inputYPlane * playerjumpforce, ForceMode.Impulse);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            ScoreKeeper.instance.AddPoint();
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
