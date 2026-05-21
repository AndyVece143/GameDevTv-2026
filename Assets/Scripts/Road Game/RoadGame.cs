using UnityEngine;
using System.Collections;

public class RoadGame : MonoBehaviour
{
    public RoadPlayer player;
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
    public FadeToBlack fadeToBlack;
    public BoxCollider2D goal;
    public Transform respawnPoint;
    public int roadGameNumber;
    public CameraController mainCamera;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        state = State.NotPlaying;
        respawnPoint = player.transform;
        mainCamera = CameraController.FindAnyObjectByType<CameraController>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case State.Playing:
                Playing();
                break;
            case State.NotPlaying:
                break;
        }
    }

    private void Playing()
    {
        if (goal.IsTouching(player.boxCollider) && win == false)
        {
            win = true;
            StartCoroutine(EndGame());
        }
    }

    public IEnumerator RespawnPlayer()
    {
        mainCamera.state = CameraController.State.StayStill;
        yield return new WaitForSeconds(3);
        fadeToBlack.BecomeTransFast();
        yield return new WaitForSeconds(0.5f);
        player.transform.position = respawnPoint.position;
        player.transform.rotation = new Quaternion(0, 0, 0, 0);
        player.state = RoadPlayer.State.Standard;

        switch (roadGameNumber)
        {
            case 1:
                mainCamera.state = CameraController.State.RoadGame1;
                break;
        }
    }

    public IEnumerator StartGame()
    {
        yield return new WaitForSeconds(1.4f);
        MinigameTextBox newTextBox = Instantiate(startInstructions);
        yield return new WaitForSeconds(5);
        state = State.Playing;
        player.state = RoadPlayer.State.Standard;
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
