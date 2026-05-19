using UnityEngine;

public class BasicReading : MonoBehaviour
{
    public LevelLoader loader;
    private bool transition = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && transition == false)
        {
            transition = true;
            loader.LoadNextLevel("MainGame");
        }
    }
}
