using UnityEngine;

public class Cloud : MonoBehaviour
{
    public float speed;
    private Rigidbody2D body;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        body.linearVelocity = new Vector2(-speed, body.linearVelocity.y);

        if (transform.position.x <= -14)
        {
            transform.position = new Vector2(11, transform.position.y);
        }
    }
}
