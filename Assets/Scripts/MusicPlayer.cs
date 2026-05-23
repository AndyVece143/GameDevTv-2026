using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public AudioSource source;
    public AudioClip parkTheme;
    public AudioClip gamerTheme;
    public AudioClip outdoorTheme;
    public AudioClip quizTheme;
    public AudioClip roadTheme;
    public AudioClip yuriTheme;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchSong(string minigame)
    {
        source.Stop();

        switch (minigame)
        {
            case "Park":
                source.clip = parkTheme;
                break;
            case "Gamer":
                source.clip = gamerTheme;
                break;
            case "Outdoor":
                source.clip = outdoorTheme;
                break;
            case "Quiz":
                source.clip = quizTheme;
                break;
            case "Road":
                source.clip = roadTheme;
                break;
            case "Yuri":
                source.clip = yuriTheme;
                break;
        }
        source.Play();
        source.loop = true;
    }
}
