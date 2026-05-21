using UnityEngine;
using System.Collections;
using TMPro;
using Unity.VisualScripting;

public class QuizGame : MonoBehaviour
{
    public string[] questions;
    public string[] answerAs;
    public string[] answerBs;
    public string[] answerCs;

    //public string question1;
    //public string answer1a;
    //public string answer1b;
    //public string answer1c;

    //public string question2;
    //public string answer2a;
    //public string answer2b;
    //public string answer2c;

    //public string question3;
    //public string answer3a;
    //public string answer3b;
    //public string answer3c;

    private int questionNumber = 0;

    public TMP_Text questionText;
    public TMP_Text answerA;
    public TMP_Text answerB;
    public TMP_Text answerC;

    public QuizPlayer player;

    public string[] answerkey;

    public enum State
    {
        Playing,
        NotPlaying,
    }
    public State state;
    public GameManager manager;
    public NPC npc;
    public MinigameTextBox startInstructions;
    public MinigameTextBox winScreen;
    private bool win = false;
    public Transform respawn;
    public MinigameTextBox correctBox;
    public MinigameTextBox incorrectBox;
    private bool showText = false;

    public FadeToBlack fadeToBlack;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        state = State.NotPlaying;
    }

    // Update is called once per frame
    void Update()
    {
        if (win == false && showText == true)
        {
            DisplayText();
        }
        
        //if (questionNumber == 3 && win == false)
        //{
        //    win = true;
        //    StartCoroutine(EndGame());
        //}
    }

    private void DisplayText()
    {
        //switch (questionNumber)
        //{
        //    case 0:

        //        break;
        //}
        questionText.text = questions[questionNumber];
        answerA.text = answerAs[questionNumber];
        answerB.text = answerBs[questionNumber];
        answerC.text = answerCs[questionNumber];
    }

    public IEnumerator CheckAnswer(string givenAnswer)
    {
        if (givenAnswer == answerkey[questionNumber])
        {
            MinigameTextBox newCorrectBox = Instantiate(correctBox);
            Debug.Log("Correct");
            player.StopMoving();

            yield return new WaitForSeconds(5);
            fadeToBlack.BecomeTransFast();
            yield return new WaitForSeconds(0.5f);
            
            player.transform.position = new Vector3(respawn.position.x, respawn.position.y, respawn.position.z);
            player.state = QuizPlayer.State.Standard;

            if (questionNumber == 2)
            {
                StartCoroutine(EndGame());
                win = true;
            }
            else
            {
                questionNumber++;
            }
        }
        else
        {
            MinigameTextBox newIncorrectBox = Instantiate(incorrectBox);
            Debug.Log("WRONG!!!");
            player.StopMoving();
            yield return new WaitForSeconds(5);
            fadeToBlack.BecomeTransFast();
            yield return new WaitForSeconds(0.5f);
            player.transform.position = new Vector3(respawn.position.x, respawn.position.y, respawn.position.z);
            player.state = QuizPlayer.State.Standard;
        }
    }

    public IEnumerator StartGame()
    {
        yield return new WaitForSeconds(1.4f);
        MinigameTextBox newTextBox = Instantiate(startInstructions);
        yield return new WaitForSeconds(5);
        state = State.Playing;
        player.state = QuizPlayer.State.Standard;
        showText = true;
    }

    public IEnumerator EndGame()
    {
        questionText.text = "You passed!";
        answerA.text = "You";
        answerB.text = "Did";
        answerC.text = "It!";
        MinigameTextBox newTextBox = Instantiate(winScreen);
        player.StopMoving();
        player.CheerTime();
        yield return new WaitForSeconds(5);
        StartCoroutine(manager.BackToMainGame());
        StartCoroutine(npc.WinGameDialogue());
        //manager.BackToMainGame();
        //npc.WinGameDialogue();
        state = State.NotPlaying;
    }
}
