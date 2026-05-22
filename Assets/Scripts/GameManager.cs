using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum State
    {
        Overworld,
        MazeGame,
        TestGame,
        AppleGame,
        QuizGame,
        RoadGame,
    }
    public State state;
    public Player player;
    public CameraController mainCamera;

    public TestGame testGame;
    public FadeToBlack fadeToBlack;
    public MazeGame mazeGame;
    public GameObject mazeGameUI;
    public AppleGame appleGame;
    public GameObject appleGameUI;
    public QuizGame quizGame1;
    public RoadGame roadGame1;
    public FlowerGame flowerGame;
    public GameObject flowerGameUI;
    public int dayNumber;
    public int teranceFriendship;
    public int meemawFriendship;
    public int yuriFriendship;
    public int smartsFriendship;
    public MusicPlayer music;

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

    public IEnumerator MazeGameTime()
    {
        fadeToBlack.BecomeTrans();
        yield return new WaitForSeconds(1.1f);
        mazeGameUI.SetActive(true);
        mainCamera.state = CameraController.State.StayStill;
        mainCamera.transform.position = new Vector3(mazeGame.transform.position.x, mazeGame.transform.position.y, -10);
        mainCamera.GetComponent<Camera>().orthographicSize = 15f;
        state = State.MazeGame;
        StartCoroutine(mazeGame.StartGame());
        music.SwitchSong("Gamer");
    }

    public IEnumerator AppleGameTime()
    {
        fadeToBlack.BecomeTrans();
        yield return new WaitForSeconds(1.1f);
        appleGameUI.SetActive(true);
        mainCamera.state = CameraController.State.StayStill;
        mainCamera.transform.position = new Vector3(appleGame.transform.position.x, appleGame.transform.position.y, -10);
        state = State.AppleGame;
        StartCoroutine(appleGame.StartGame());
        music.SwitchSong("Outdoor");
    }

    public IEnumerator QuizGame1Time()
    {
        fadeToBlack.BecomeTrans();
        yield return new WaitForSeconds(1.1f);
        mainCamera.state = CameraController.State.StayStill;
        mainCamera.transform.position = new Vector3(quizGame1.transform.position.x, quizGame1.transform.position.y, -10);
        state = State.QuizGame;
        StartCoroutine(quizGame1.StartGame());
        music.SwitchSong("Quiz");
    }

    public IEnumerator RoadGame1Time()
    {
        fadeToBlack.BecomeTrans();
        yield return new WaitForSeconds(1.1f);
        mainCamera.state = CameraController.State.RoadGame1;
        mainCamera.transform.position = new Vector3(roadGame1.transform.position.x, roadGame1.transform.position.y, -10);
        state = State.RoadGame;
        StartCoroutine(roadGame1.StartGame());
        music.SwitchSong("Road");
    }

    public IEnumerator FlowerGameTime()
    {
        fadeToBlack.BecomeTrans();
        yield return new WaitForSeconds(1.1f);
        mainCamera.state = CameraController.State.StayStill;
        flowerGameUI.SetActive(true);
        mainCamera.transform.position = new Vector3(flowerGame.transform.position.x, flowerGame.transform.position.y, -10);
        state = State.AppleGame;
        StartCoroutine(flowerGame.StartGame());
        music.SwitchSong("Outdoor");
    }

    public IEnumerator BackToMainGame()
    {
        fadeToBlack.BecomeTrans();
        yield return new WaitForSeconds(1.1f);
        mainCamera.GetComponent<Camera>().orthographicSize = 5f;
        mazeGameUI.SetActive(false);
        appleGameUI.SetActive(false);
        flowerGameUI.SetActive(false);
        mainCamera.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);
        mainCamera.state = CameraController.State.FollowPlayer;
        music.SwitchSong("Park");
    }
}
