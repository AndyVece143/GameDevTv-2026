using Unity.VisualScripting;
using UnityEngine;

public class Wheelbarrow : MonoBehaviour
{
    public int appleCount;
    public Animator anim;
    public float countdown;
    public AppleGame game;
    [SerializeField] private AudioClip collectApple;
    [SerializeField] private AudioClip dropoffApple;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        appleCount = 0;
        anim = GetComponent<Animator>();
        countdown = 0.3f;
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetInteger("appleAmount", appleCount);
        countdown -= Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Apple" && appleCount < 5 && collision.GetComponent<Apple>().canCollect == true)
        {
            appleCount++;
            Destroy(collision.gameObject);
            SoundManager.instance.PlaySound(collectApple);
        }

        if (collision.tag == "Apple" && appleCount >= 5)
        {
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Drop Off" && countdown <= 0 && appleCount > 0)
        {
            //Debug.Log("Sanes");
            game.IncreaseScore();
            appleCount--;
            countdown = 0.3f;
            SoundManager.instance.PlaySound(dropoffApple);
        }
    }
}
