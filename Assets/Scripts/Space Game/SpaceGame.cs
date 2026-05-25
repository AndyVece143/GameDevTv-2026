using UnityEngine;
using System.Collections;
using TMPro;
using Unity.VisualScripting;

public class SpaceGame : MonoBehaviour
{
    public SpacePlayer player;
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
    public SpaceEnemy enemy;
    public TextMeshProUGUI healthText;

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
            case State.Playing:
                Playing();
                break;
            case State.NotPlaying:
                break;
        }
        UpdateText();
    }

    private void Playing()
    {
        if (enemy.health <= 0 && win == false)
        {
            win = true;
            StartCoroutine(EndGame());
        }
    }

    private void UpdateText()
    {
        healthText.text = "Boss Health: " + enemy.health + "/30";
    }

    public IEnumerator StartGame()
    {
        yield return new WaitForSeconds(1.4f);
        MinigameTextBox newTextBox = Instantiate(startInstructions);
        yield return new WaitForSeconds(5);
        state = State.Playing;
        player.state = SpacePlayer.State.Standard;
        enemy.state = SpaceEnemy.State.Standard;
    }

    public IEnumerator EndGame()
    {
        MinigameTextBox newTextBox = Instantiate(winScreen);
        player.StopMoving();
        //player.CheerTime();
        yield return new WaitForSeconds(5);
        StartCoroutine(manager.BackToMainGame());
        StartCoroutine(npc.WinGameDialogue());
        //manager.BackToMainGame();
        //npc.WinGameDialogue();
        state = State.NotPlaying;
        player.SelfDestruct();
    }
}
