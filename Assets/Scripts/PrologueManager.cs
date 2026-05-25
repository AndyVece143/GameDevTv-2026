using System.Collections;
using UnityEngine;

public class PrologueManager : MonoBehaviour
{
    public SoloBigDialogue dialogue;
    public BigDialogue epilogueDialogue;
    public LevelLoader loader;
    public bool prologue;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(StartCutscene());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToNextScene()
    {
        if (prologue)
        {
            loader.LoadNextLevel("MainGame");
        }
        else
        {
            loader.LoadNextLevel("Title");
        }
    }

    private IEnumerator StartCutscene()
    {
        yield return new WaitForSeconds(1);
        if (prologue)
        {
            SoloBigDialogue newDialogue = Instantiate(dialogue);
        }
        else
        {
            BigDialogue newEpilogue = Instantiate(epilogueDialogue);
            newEpilogue.character1.isActiveSpeaker = true;
        }
    }
}
