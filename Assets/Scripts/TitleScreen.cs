using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;

public class TitleScreen : MonoBehaviour
{
    public GameObject mainTitle;
    public GameObject credits;
    public GameObject controls;
    public float duration;

    private float buttonTimer;
    public LevelLoader loader;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log(mainTitle.transform.position);
        Debug.Log(credits.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        buttonTimer -= Time.deltaTime;
    }

    public void SlideLeft()
    {
        if (buttonTimer <= 0)
        {
            StartCoroutine(MoveElements(false));
            buttonTimer = duration;
        }
    }

    public void SlideRight()
    {
        if (buttonTimer <= 0)
        {
            StartCoroutine(MoveElements(true));
            buttonTimer = duration;
        }
    }

    public void StartGame()
    {
        loader.LoadNextLevel("Prologue");
    }

    IEnumerator MoveElements(bool right)
    {
        float time = 0;
        float moveAmount = 18.53f;
        if (!right)
        {
            moveAmount = -18.53f;
        }

        Vector2 titleVector = new Vector2(mainTitle.transform.position.x + moveAmount, 0);
        Vector2 creditsVector = new Vector2(credits.transform.position.x + moveAmount, 0);
        Vector2 controlsVector = new Vector2(controls.transform.position.x + moveAmount, 0);

        while (time < duration)
        {
            time += Time.deltaTime;
            credits.gameObject.transform.position = Vector2.Lerp(credits.transform.position, creditsVector, time / duration);
            mainTitle.gameObject.transform.position = Vector2.Lerp(mainTitle.transform.position, titleVector, time / duration);
            controls.gameObject.transform.position = Vector2.Lerp(controls.transform.position, controlsVector, time / duration);

            yield return null;
        }
    }
}
