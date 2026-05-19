using System.Collections;
using UnityEngine;

public class MinigameTextBox : MonoBehaviour
{
    public Canvas canvas;
    public float duration;

    public GameObject textBox;
    private Vector3 textBoxPosition;
    private Vector3 textBoxEndPosition;
    public float distance;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canvas = GetComponent<Canvas>();
        canvas.worldCamera = Camera.main;
        SetPosition();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetPosition()
    {
        textBoxPosition = textBox.transform.position;

        int i = Random.Range(0, 4);

        switch (i)
        {
            case 0:
                textBox.transform.position = new Vector3(textBox.transform.position.x + distance, textBox.transform.position.y, textBox.transform.position.z);
                break;

            case 1:
                textBox.transform.position = new Vector3(textBox.transform.position.x - distance, textBox.transform.position.y, textBox.transform.position.z);
                break;

            case 2:
                textBox.transform.position = new Vector3(textBox.transform.position.x, textBox.transform.position.y + distance, textBox.transform.position.z);
                break;

            case 3:
                textBox.transform.position = new Vector3(textBox.transform.position.x, textBox.transform.position.y - distance, textBox.transform.position.z);
                break;
        }
        textBoxEndPosition = textBox.transform.position;
        StartCoroutine(MoveSpriteBeginning());
    }

    IEnumerator MoveSpriteBeginning()
    {
        float time = 0;

        while (time < duration)
        {
            time += Time.deltaTime;
            textBox.transform.position = Vector3.Lerp(textBox.transform.position, textBoxPosition, time / duration);
            yield return null;
        }

        yield return new WaitForSeconds(3f);
        StartCoroutine(MoveSpriteEnd());
    }

    IEnumerator MoveSpriteEnd()
    {
        float time = 0;

        while (time < duration)
        {
            time += Time.deltaTime;
            textBox.transform.position = Vector3.Lerp(textBox.transform.position, textBoxEndPosition, time / duration);
            yield return null;
        }
    }
}
