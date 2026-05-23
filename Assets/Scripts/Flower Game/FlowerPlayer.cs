using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class FlowerPlayer : MonoBehaviour
{
    public float speed;
    private Rigidbody2D body;
    public BoxCollider2D boxCollider;

    public enum State
    {
        Standard,
        NoMove,
        Cheer,
        Refill,
        Pour,
        HitStun,
    }
    public State state;
    public Animator anim;
    public float water;
    public GameObject waterBubble;
    public GameObject shadow;
    public Sink sink;
    public Flower flower;
    [SerializeField] private LayerMask groundLayer;
    private float hitStunTime;
    private float iFrameTimer;
    public bool iFrames;
    [SerializeField] private AudioClip hurtSound;
    private float waterTimer;
    public float waterAmount;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        waterTimer = 0.5f;
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
            case State.Refill:
                Refill();
                break;
            case State.Pour:
                Pour();
                break;
            case State.HitStun:
                HitStun();
                break;
        }
    }

    private void Movement()
    {
        anim.SetBool("pour", false);
        shadow.SetActive(true);
        hitStunTime = 0;
        float horizontalInput = Input.GetAxis("Horizontal");
        body.linearVelocity = new Vector2(horizontalInput * speed, body.linearVelocity.y);

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
            //Physics2D.IgnoreLayerCollision(6, 7, false);
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

    private void Refill()
    {
        body.linearVelocity = new Vector2(0, 0);
        anim.SetBool("move", false);
        sink.state = Sink.State.On;
        waterTimer -= Time.deltaTime;
        if (waterTimer <= 0)
        {
            water += waterAmount;
            waterTimer = 0.5f;
        }
        //water += 0.5f;

        if (Input.GetKeyUp(KeyCode.Space) || water >= 100)
        {
            state = State.Standard;
            sink.state = Sink.State.Off;
            waterBubble.SetActive(false);
        }
    }

    private void Pour()
    {
        body.linearVelocity = new Vector2(0, 0);
        anim.SetBool("pour", true);
        flower.state = Flower.State.Growing;
        waterTimer -= Time.deltaTime;
        if (waterTimer <= 0)
        {
            water -= waterAmount;
            waterTimer = 0.5f;
        }
        //water -= 0.5f;

        if (Input.GetKeyUp(KeyCode.Space) || water <= 0)
        {
            state = State.Standard;
            flower.state = Flower.State.Still;
            waterBubble.SetActive(false);
        }
    }

    private void HitStun()
    {
        hitStunTime += Time.deltaTime;
        anim.SetBool("hurt", true);
        if (IsGrounded() && hitStunTime >= 0.2f)
        {
            anim.SetBool("hurt", false);
            state = State.Standard;
            iFrames = true;
            iFrameTimer = 2;
        }
    }

    private void KnockBack()
    {
        Physics2D.IgnoreLayerCollision(6, 7);
        SoundManager.instance.PlaySound(hurtSound);
        shadow.SetActive(false);
        water = Mathf.Floor(water / 2);

        if (IsFacingRight())
        {
            body.linearVelocity = new Vector2(-3f, 5f);
        }
        else
        {
            body.linearVelocity = new Vector2(3f, 5f);
        }
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
        if (iFrames == false && state != State.HitStun && collision.gameObject.tag == "Apple")
        {
            if (collision.gameObject.GetComponent<FlowerApple>().dead == false)
            {
                Debug.Log("Hit");
                state = State.HitStun;
                KnockBack();
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Refill" && Input.GetKey(KeyCode.Space) && water < 100)
        {
            state = State.Refill;
            //water += 0.5f;
        }

        if (collision.gameObject.tag == "Plant" && Input.GetKey(KeyCode.Space) && water > 0 && state != State.Cheer)
        {
            state = State.Pour;
            //water -= 0.5f;
        }
        if (collision.gameObject.tag == "Refill" && water < 100)
        {
            waterBubble.SetActive(true);
        }

        if (collision.gameObject.tag == "Plant" && water > 0)
        {
            waterBubble.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        waterBubble.SetActive(false);
    }
}
