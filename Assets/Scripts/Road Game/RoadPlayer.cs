using UnityEngine;

public class RoadPlayer : MonoBehaviour
{
    public float speed;
    private Rigidbody2D body;
    public BoxCollider2D boxCollider;

    public enum State
    {
        Standard,
        NoMove,
        Cheer,
        Hurt,
    }
    public State state;
    public Animator anim;
    public RoadGame game;
    public GameObject shadow1;
    public GameObject shadow2;

    [SerializeField] private AudioClip explosion;
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
            case State.Cheer:
                Cheering();
                break;
            case State.Hurt:
                Hurt();
                break;
        }
    }

    private void Movement()
    {
        anim.SetBool("hurt", false);
        shadow1.SetActive(true);
        shadow2.SetActive(true);

        float horizontalInput = Input.GetAxis("Horizontal");
        body.linearVelocity = new Vector2(horizontalInput * speed, body.linearVelocity.y);

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

    private void Hurt()
    {
        anim.SetBool("hurt", true);
        transform.position += new Vector3(4.0f, 10.0f, 0) * Time.deltaTime;
        transform.Rotate(Vector3.forward * (1000 * Time.deltaTime));

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Car" && state != State.Hurt)
        {
            state = State.Hurt;
            shadow1.SetActive(false);
            shadow2.SetActive(false);
            SoundManager.instance.PlaySound(explosion);
            StartCoroutine(game.RespawnPlayer());
        }

        if (collision.tag == "Checkpoint")
        {
            game.respawnPoint = collision.transform;
        }
    }
}
