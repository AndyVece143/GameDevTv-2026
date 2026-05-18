using System.Collections;
using UnityEngine;

public class TestGame : MonoBehaviour
{
    public TGPlayer player;
    public BoxCollider2D goal;
    public enum State
    {
        Playing,
        NotPlaying
    }
    public State state;
    public GameManager manager;
    public NPC npc;
    public MinigameTextBox startInstructions;
    public MinigameTextBox winScreen;
    private bool win = false;
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

    //Pretend update method
    private void Playing()
    {
        if (goal.IsTouching(player.boxCollider) && win == false)
        {
            Debug.Log("Game done");
            //manager.BackToMainGame();
            //npc.WinGameDialogue();
            //state = State.NotPlaying;
            win = true;
            StartCoroutine(EndGame());

        }
    }

    //public void StartGame()
    //{
    //    state = State.Playing;
    //    player.state = TGPlayer.State.Standard;
    //}

    public IEnumerator StartGame()
    {
        yield return new WaitForSeconds(1.4f);
        MinigameTextBox newTextBox = Instantiate(startInstructions);
        yield return new WaitForSeconds(5);
        state = State.Playing;
        player.state = TGPlayer.State.Standard;
    }

    public IEnumerator EndGame()
    {
        MinigameTextBox newTextBox = Instantiate(winScreen);
        player.StopMoving();
        yield return new WaitForSeconds(5);
        StartCoroutine(manager.BackToMainGame());
        StartCoroutine(npc.WinGameDialogue());
        //manager.BackToMainGame();
        //npc.WinGameDialogue();
        state = State.NotPlaying;
    }
}
