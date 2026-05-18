using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum State
    {
        Overworld,
        MazeGame,
        TestGame
    }
    public State state;
    public Player player;
    public CameraController mainCamera;

    public TestGame testGame;
    public FadeToBlack fadeToBlack;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        state = State.Overworld;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator TestGameTime()
    {
        fadeToBlack.BecomeTrans();
        yield return new WaitForSeconds(1.1f);
        mainCamera.state = CameraController.State.StayStill;
        mainCamera.transform.position = new Vector3(testGame.transform.position.x, testGame.transform.position.y, -10);
        state = State.TestGame;
        //testGame.StartGame();
        StartCoroutine(testGame.StartGame());
    }

    public IEnumerator BackToMainGame()
    {
        fadeToBlack.BecomeTrans();
        yield return new WaitForSeconds(1.1f);
        mainCamera.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);
        mainCamera.state = CameraController.State.FollowPlayer;
    }
}
