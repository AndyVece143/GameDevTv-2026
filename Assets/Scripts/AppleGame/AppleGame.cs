using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class AppleGame : MonoBehaviour
{
    public int appleAmount;
    public Wheelbarrow wheelbarrow;
    public ApplePlayer player;
    public int score;
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
    public bool win = false;
    public AppleTree tree1;
    public AppleTree tree2;

    public TextMeshProUGUI appleText;
    public TextMeshProUGUI scoreText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        state = State.NotPlaying;
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case State.NotPlaying:
                break;
            case State.Playing:
                Playing();
                break;
        }
        UpdateText();
    }

    private void Playing()
    {
        if (score >= 20 && win == false)
        {
            win = true;
            StartCoroutine(EndGame());
        }
    }

    public void IncreaseScore()
    {
        score++;
    }

    private void UpdateText()
    {
        appleText.text = "Apples: " + wheelbarrow.appleCount + "/5";
        scoreText.text = "Score: " + score + "/20";
    }

    public IEnumerator StartGame()
    {
        yield return new WaitForSeconds(1.4f);
        MinigameTextBox newTextBox = Instantiate(startInstructions);
        yield return new WaitForSeconds(5);
        state = State.Playing;
        player.state = ApplePlayer.State.Standard;
        tree1.spawnApples = true;
        tree2.spawnApples = true;
    }

    public IEnumerator EndGame()
    {
        MinigameTextBox newTextBox = Instantiate(winScreen);
        tree1.spawnApples = false;
        tree2.spawnApples = false;
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
