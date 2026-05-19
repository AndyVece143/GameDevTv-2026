using System.Collections;
using TMPro;
using UnityEngine;

public class MazeGame : MonoBehaviour
{
    public MazePlayer player;
    public BoxCollider2D goal;
    public int coinAmount;

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
    public TextMeshProUGUI coinText;

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
        if (goal.IsTouching(player.capsuleCollider) && win == false && coinAmount == 3)
        {
            Debug.Log("Maze game done");
            win = true;
            StartCoroutine(EndGame());
        }
    }

    public void GetCoin()
    {
        coinAmount++;
    }

    public void UpdateText()
    {
        coinText.text = "Coins: " + coinAmount + "/3";
    }

    public IEnumerator StartGame()
    {
        yield return new WaitForSeconds(1.4f);
        MinigameTextBox newTextBox = Instantiate(startInstructions);
        yield return new WaitForSeconds(5);
        state = State.Playing;
        player.state = MazePlayer.State.Standard;
    }

    public IEnumerator EndGame()
    {
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
