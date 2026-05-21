using System.Collections;
using UnityEngine;

public class Car : MonoBehaviour
{
    public float speed;
    private Rigidbody2D body;
    public BoxCollider2D boxCollider;
    public Sprite redCar;
    public Sprite blueCar;
    public Sprite grayCar;
    public Sprite greenCar;
    public Sprite orangeCar;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        SetCarColor();
    }

    // Update is called once per frame
    void Update()
    {
        body.linearVelocity = new Vector2(body.linearVelocity.x, -speed);
    }

    private void SetCarColor()
    {
        int i = Random.Range(0, 5);

        switch (i)
        {
            case 0:
                this.GetComponent<SpriteRenderer>().sprite = redCar;
                break;
            case 1:
                this.GetComponent<SpriteRenderer>().sprite = blueCar;
                break;
            case 2:
                this.GetComponent<SpriteRenderer>().sprite = grayCar;
                break;
            case 3:
                this.GetComponent<SpriteRenderer>().sprite = greenCar;
                break;
            case 4:
                this.GetComponent<SpriteRenderer>().sprite = orangeCar;
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "KillCar")
        {
            Destroy(gameObject);
        }
    }
}
