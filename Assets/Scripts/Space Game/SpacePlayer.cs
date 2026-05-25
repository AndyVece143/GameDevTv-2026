using Unity.VisualScripting;
using UnityEngine;

public class SpacePlayer : MonoBehaviour
{
    public float speed;
    private Rigidbody2D body;
    public BoxCollider2D boxCollider;
    public enum State
    {
        Standard,
        NoMove,
        Knockback,
    }
    public State state;
    public Animator anim;
    public SpaceLaser laser;
    private float timer;
    private float shootTimer = 0.25f;
    public AudioClip shootSound;
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
            case State.Standard:
                Movement();
                break;
            case State.NoMove:
                break;
            case State.Knockback:
                Knockback();
                break;
        }
    }

    private void Movement()
    {
        timer = 0.3f;
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        body.linearVelocity = new Vector2(horizontalInput * speed, verticalInput * speed);

        shootTimer -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && shootTimer <= 0)
        {
            Debug.Log("SHOOT");
            SoundManager.instance.PlaySound(shootSound);
            SpaceLaser newLaser = Instantiate(laser);
            newLaser.transform.position = transform.position;
            newLaser.player = true;
            shootTimer = 0.25f;
        }
    }

    private void Knockback()
    {
        body.linearVelocity = new Vector2(-2 * speed, 0);
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            state = State.Standard;
        }
    }

    public void StopMoving()
    {
        //anim.SetBool("move", false);
        body.linearVelocity = new Vector2(0, 0);
        state = State.NoMove;
    }

    public void SelfDestruct()
    {
        Destroy(gameObject);
    }
}
