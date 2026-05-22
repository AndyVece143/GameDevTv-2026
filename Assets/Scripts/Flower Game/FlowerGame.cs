using UnityEngine;
using System.Collections;

public class FlowerGame : MonoBehaviour
{
    public FlowerPlayer player;
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
    public FlowerTree tree1;
    public FlowerTree tree2;
    public Flower flower;

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
    }

    private void Playing()
    {
        if (flower.growth >= 80 && win == false)
        {
            win = true;
            StartCoroutine(EndGame());
        }
    }

    public IEnumerator StartGame()
    {
        yield return new WaitForSeconds(1.4f);
        MinigameTextBox newTextBox = Instantiate(startInstructions);
        yield return new WaitForSeconds(5);
        state = State.Playing;
        player.state = FlowerPlayer.State.Standard;
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
