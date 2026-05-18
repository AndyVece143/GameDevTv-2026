using UnityEngine;

public class TGPlayer : MonoBehaviour
{
    public float speed;
    private Rigidbody2D body;
    public BoxCollider2D boxCollider;
    
    public enum State
    {
        Standard,
        NoMove
    }
    public State state;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
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
        }
    }

    private void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        body.linearVelocity = new Vector2(horizontalInput * speed, verticalInput * speed);
    }

    public void StopMoving()
    {
        body.linearVelocity = new Vector2(0, 0);
        state = State.NoMove;
    }
}
