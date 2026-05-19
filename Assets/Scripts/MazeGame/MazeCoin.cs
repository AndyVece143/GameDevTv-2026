using UnityEngine;

public class MazeCoin : MonoBehaviour
{
    public MazeGame mazeGame;
    [SerializeField] private AudioClip pickupSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "MazePlayer")
        {
            SoundManager.instance.PlaySound(pickupSound);
            mazeGame.GetCoin();
            Destroy(gameObject);
        }
    }

}
