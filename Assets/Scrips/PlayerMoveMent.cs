using UnityEngine;

public class PlayerMoveMent : MonoBehaviour
{

    public float Speed;
    float move;

    public float JumpForce;
    public bool IsJump;

    Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        move = Input.GetAxis("Horizontal");

        rb.linearVelocity = new Vector2(move * Speed, rb.linearVelocity.y);

        //jump
        if(Input.GetButtonDown("Jump") && !IsJump)
        {
            rb.AddForce(new Vector2(rb.linearVelocity.x, JumpForce));
            Debug.Log("Jump");
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            IsJump = false;
        }
        
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            IsJump = true;
        }
    }
}
