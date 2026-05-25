using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class YuriGame : MonoBehaviour
{
    public BigDialogue[] dialogues;
    public bool[] talker;
    public int cutscenes = 0;
    public FadeToBlack fadeToBlack;
    public GameObject piePlate;
    public GameObject emptyPlate;
    public GameManager manager;
    public NPC npc;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator StartGame()
    {
        yield return new WaitForSeconds(2);
        BigDialogue newBigDialogue = Instantiate(dialogues[cutscenes]);
        if (talker[cutscenes])
        {
            newBigDialogue.character1.isActiveSpeaker = true;
        }
        else
        {
            newBigDialogue.character2.isActiveSpeaker = true;
        }
        //newBigDialogue.character1.isActiveSpeaker = true;
        cutscenes++;
    }

    public IEnumerator PlayNextCutscene()
    {

        yield return new WaitForSeconds(1.1f);

        if (cutscenes == 2)
        {
            piePlate.SetActive(true);
        }

        if (cutscenes == 6)
        {
            piePlate.SetActive(false);
            emptyPlate.SetActive(true);
        }
        yield return new WaitForSeconds(1.9f);
        BigDialogue newBigDialogue = Instantiate(dialogues[cutscenes]);
        if (talker[cutscenes])
        {
            newBigDialogue.character1.isActiveSpeaker = true;
        }
        else
        {
            newBigDialogue.character2.isActiveSpeaker = true;
        }
        cutscenes++;
    }

    public void DoTransition()
    {
        if (cutscenes == 7)
        {
            StartCoroutine(manager.BackToMainGame());
            StartCoroutine(npc.WinGameDialogue());
            return;
        }
        fadeToBlack.BecomeTrans();
        StartCoroutine(PlayNextCutscene());
    }
}
