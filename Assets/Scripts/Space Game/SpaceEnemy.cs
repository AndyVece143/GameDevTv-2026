using UnityEngine;

public class SpaceEnemy : MonoBehaviour
{
    public SpacePlayer player;
    private float timer = 1.5f;
    public int health;

    public BoxCollider2D boxCollider;

    public enum State
    {
        Standard,
        NoMove,
        Dead,
    }
    public State state;
    public Animator anim;
    public Transform shootPlace;
    public SpaceLaser laser;
    public AudioClip shootSound;
    public AudioClip explosion;
    public float speed;
    public Rigidbody2D body;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        body = GetComponent<Rigidbody2D>();
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
            case State.Dead:
                Dead();
                break;
            
        }
    }

    private void Movement()
    {
        body.linearVelocity = new Vector2(0, speed);

        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            ShootGun();
            timer = 1.5f;
        }
    }

    private void Dead()
    {
        transform.position += new Vector3(4.0f, 10.0f, 0) * Time.deltaTime;
        transform.Rotate(Vector3.forward * (1000 * Time.deltaTime));

        if (transform.position.x >= 200)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage()
    {
        health--;
        if (health <= 0)
        {
            SoundManager.instance.PlaySound(explosion);
            state = State.Dead;
        }
    }

    private void ShootGun()
    {
        SoundManager.instance.PlaySound(shootSound);
        Vector3 targetDirection = player.transform.position - shootPlace.transform.position;
        //float angle = Vector3.Angle(transform.forward, targetDirection);
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
        //Quaternion rotation = Quaternion.LookRotation(targetDirection);
        Quaternion rotation = Quaternion.Euler(0, 0, angle);
        //Debug.Log(angle);
        //SpaceLaser newLaser = Instantiate(laser, shootPlace.position, Quaternion.Euler(new Vector3(0, 0, angle + 180)));

        SpaceLaser newLaser = Instantiate(laser, shootPlace.position, rotation);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall" && state != State.Dead)
        {
            speed = -speed;
        }
    }
}
