using UnityEngine;

public class PlatformerCoin : MonoBehaviour
{
    public PlatformerGame game;
    [SerializeField] private AudioClip pickupSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlatformerPlayer")
        {
            SoundManager.instance.PlaySound(pickupSound);
            game.GetCoin();
            Destroy(gameObject);
        }
    }
}
