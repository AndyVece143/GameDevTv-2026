using UnityEngine;

public class SpaceLaser : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D body;
    public bool player;
    public AudioClip hurt;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        body.linearVelocity = (speed * transform.right);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.tag == "Scarecrow")
        //{
        //    return;
        //}
        if (!player && collision.gameObject.tag == "Player")
        {
            Debug.Log("player hit");
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }

        if (!player && collision.gameObject.tag == "Player")
        {
            Debug.Log("player hit");
            SoundManager.instance.PlaySound(hurt);
            collision.gameObject.GetComponent<SpacePlayer>().state = SpacePlayer.State.Knockback;
            Destroy(gameObject);
        }
        if (player && collision.gameObject.tag == "Enemy")
        {
            SoundManager.instance.PlaySound(hurt);
            collision.gameObject.GetComponent<SpaceEnemy>().TakeDamage();
            Destroy(gameObject);
        }
    }
}
