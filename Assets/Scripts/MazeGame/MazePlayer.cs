using UnityEngine;

public class MazePlayer : MonoBehaviour
{
    public float speed;
    private Rigidbody2D body;
    //public BoxCollider2D boxCollider;
    public CapsuleCollider2D capsuleCollider;

    public enum State
    {
        Standard,
        NoMove,
        Cheer,
    }
    public State state;

    public Animator anim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        //boxCollider = GetComponent<BoxCollider2D>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        state = State.NoMove;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("grounded", true);
        switch (state)
        {
            case State.Standard:
                Movement();
                break;
            case State.NoMove:
                break;
            case State.Cheer:
                Cheering();
                break;
        }
    }

    private void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        body.linearVelocity = new Vector2(horizontalInput * speed, verticalInput * speed);

        //Flip Sprite
        if (horizontalInput > 0.01f)
        {
            transform.localScale = Vector3.one;
        }

        else if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        anim.SetBool("move", horizontalInput != 0 || verticalInput != 0);
    }

    private void Cheering()
    {
        anim.SetBool("cheer", true);
    }

    public void StopMoving()
    {
        body.linearVelocity = new Vector2(0, 0);
        state = State.NoMove;
    }

    public void CheerTime()
    {
        state = State.Cheer;
    }
}
