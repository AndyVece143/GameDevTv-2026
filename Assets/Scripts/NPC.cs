using System;
using System.Collections;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public GameManager manager;
    public BigDialogue greeting;
    public BigDialogue winGame;
    public BigDialogue postGame;

    public int dialogueState = 0;
    public Player player;
    public BoxCollider2D boxCollider;
    public bool interactable;
    public string gameName;
    public bool talker0;
    public bool talker1;
    public bool talker2;
    public bool checker = false;
    public string npcName;
    public CameraController mainCamera;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = Player.FindAnyObjectByType<Player>();
        boxCollider = GetComponent<BoxCollider2D>();
        mainCamera = CameraController.FindAnyObjectByType<CameraController>();
        interactable = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (boxCollider.IsTouching(player.boxCollider))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (player.state != Player.State.NoMove)
                {
                    //interactable = false;
                    player.StopMoving(1);
                    player.state = Player.State.NoMove;
                    player.talkIcon.enabled = false;
                    mainCamera.state = CameraController.State.StayStill;

                    switch (dialogueState)
                    {
                        case 0:
                            BigDialogue newBigDialogue = Instantiate(greeting);
                            newBigDialogue.transitionToGame = true;
                            newBigDialogue.npcGamer = this;
                            if (talker0)
                            {
                                newBigDialogue.character1.isActiveSpeaker = true;
                            }
                            else
                            {
                                newBigDialogue.character2.isActiveSpeaker = true;
                            }
                            break;
                        case 1:
                            BigDialogue postBigDialogue = Instantiate(postGame);
                            if (talker2)
                            {
                                postBigDialogue.character1.isActiveSpeaker = true;
                            }
                            else
                            {
                                postBigDialogue.character2.isActiveSpeaker = true;
                            }
                            checker = true;
                            break;
                    }
                }
            }
        }
    }

    public void GoToGame()
    {
        switch (gameName)
        {
            case "Test Game":
                StartCoroutine(manager.TestGameTime());
                break;
            case "Maze Game":
                StartCoroutine(manager.MazeGameTime());
                break;
            case "Apple Game":
                StartCoroutine(manager.AppleGameTime());
                break;
            case "Quiz Game 1":
                StartCoroutine(manager.QuizGame1Time());
                break;
            case "Road Game 1":
                StartCoroutine(manager.RoadGame1Time());
                break;
            case "Flower Game":
                StartCoroutine(manager.FlowerGameTime());
                break;
            case "Platformer Game":
                StartCoroutine(manager.PlatformerGameTime());
                break;
            case "Quiz Game 2":
                StartCoroutine(manager.QuizGame2Time());
                break;
            case "Quiz Game 3":
                StartCoroutine(manager.QuizGame3Time());
                break;
            case "Road Game 2":
                StartCoroutine(manager.RoadGame2Time());
                break;
            case "Road Game 3":
                StartCoroutine(manager.RoadGame3Time());
                break;
            case "Developer":
                dialogueState++;
                break;
            case "Yuri Game":
                StartCoroutine(manager.YuriGameTime());
                break;
            case "Space Game":
                StartCoroutine(manager.SpaceGameTime());
                break;
        }
    }

    public IEnumerator WinGameDialogue()
    {
        yield return new WaitForSeconds(2.5f);
        dialogueState++;
        BigDialogue winDialogue = Instantiate(winGame);
        if (talker1)
        {
            winDialogue.character1.isActiveSpeaker = true;
        }
        else
        {
            winDialogue.character2.isActiveSpeaker = true;
        }

        switch (npcName)
        {
            case "Terance":
                manager.teranceFriendship++;
                break;
            case "Annabelle":
                manager.yuriFriendship++;
                break;
            case "Sophia":
                manager.smartsFriendship++;
                break;
            case "Meemaw":
                manager.meemawFriendship++;
                break;
        }
    }
}
