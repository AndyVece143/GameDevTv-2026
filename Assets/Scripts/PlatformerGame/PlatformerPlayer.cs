using Unity.VisualScripting;
using UnityEngine;

public class PlatformerPlayer : MonoBehaviour
{
    public float jumpForce;
    public float speed;
    private Rigidbody2D body;
    public BoxCollider2D boxCollider;
    [SerializeField] private LayerMask groundLayer;

    public float jumpTime;
    public float jumpTimeCounter;
    private bool isJumping;

    public enum State
    {
        Standard,
        NoMove,
        HitStun,
        Cheer,
    }
    public State state;
    public Animator anim;
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip hurtSound;
    private float hitStunTime;
    private float iFrameTimer;
    public bool iFrames;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        state = State.NoMove;
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case State.NoMove:
                anim.SetBool("grounded", true);
                break;
            case State.Standard:
                Movement();
                break;
            case State.HitStun:
                Hitstun();
                break;
            case State.Cheer:
                Cheering();
                break;
        }
    }

    private void Movement()
    {
        hitStunTime = 0;
        float horizontalInput = Input.GetAxis("Horizontal");
        body.linearVelocity = new Vector2(horizontalInput * speed, body.linearVelocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            SoundManager.instance.PlaySound(jumpSound);
            isJumping = true;
            jumpTimeCounter = jumpTime;
            JumpForceMethod();
        }

        if (Input.GetKey(KeyCode.Space) && isJumping == true)
        {
            if (jumpTimeCounter > 0)
            {
                JumpForceMethod();
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }

        if (IsGrounded())
        {
            body.gravityScale = 1.5f;
        }
        if (!IsGrounded() && body.linearVelocity.y <= 0)
        {
            body.gravityScale = 2;
        }

        iFrameTimer -= Time.deltaTime;
        if (iFrameTimer < 0)
        {
            iFrames = false;
        }

        if (iFrames)
        {
            GetComponent<SpriteRenderer>().color = Color.gray;
        }
        else
        {
            GetComponent<SpriteRenderer>().color = Color.white;
            Physics2D.IgnoreLayerCollision(6, 7, false);
        }

        //Flip Sprite
        if (horizontalInput > 0.01f)
        {
            transform.localScale = Vector3.one;
        }

        else if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        anim.SetBool("move", horizontalInput != 0);
        anim.SetBool("grounded", IsGrounded());
        anim.SetBool("falling", IsFalling());
    }

    private void JumpForceMethod()
    {
        body.linearVelocity = new Vector2(body.linearVelocity.x, jumpForce);
    }

    public bool IsFalling()
    {
        if (body.linearVelocity.y < 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void Hitstun()
    {
        hitStunTime += Time.deltaTime;
        anim.SetBool("hurt", true);
        if (IsGrounded() && hitStunTime >= 0.2f)
        {
            anim.SetBool("hurt", false);
            state = State.Standard;
            iFrames = true;
            iFrameTimer = 3;
        }
    }

    private void KnockBack()
    {
        SoundManager.instance.PlaySound(hurtSound);
        Physics2D.IgnoreLayerCollision(6, 7);
        if (IsFacingRight())
        {
            body.linearVelocity = new Vector2(-3f, 5f);
        }
        else
        {
            body.linearVelocity = new Vector2(3f, 5f);
        }
    }

    private void Cheering()
    {
        anim.SetBool("cheer", true);
        anim.SetBool("pour", false);
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

    public bool IsGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }

    private bool IsFacingRight()
    {
        if (transform.localScale.x == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (iFrames == false && state != State.HitStun)
        {
            if (collision.collider.tag == "Enemy")
            {
                state = State.HitStun;
                KnockBack();
            }
        }
    }
}
