using System.Collections;
using UnityEngine;

public class DayTransition : MonoBehaviour
{
    public GameManager manager;
    public Player player;
    public DayTransitionUI dayUI;
    public BoxCollider2D boxCollider;
    public SoloBigDialogue dialogue;
    private bool transition = false;
    public int friendshipValue;
    public Transform nextDaySpawn;
    public CameraController mainCamera;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (boxCollider.IsTouching(player.boxCollider) && transition == false)
        {
            if (manager.dayNumber == friendshipValue - 1 && manager.yuriFriendship == friendshipValue && manager.teranceFriendship == friendshipValue && manager.meemawFriendship == friendshipValue && manager.smartsFriendship == friendshipValue)
            {
                transition = true;
                StartCoroutine(CoolTransition());
            }
        }
    }

    private IEnumerator CoolTransition()
    {
        player.StopMoving(1);
        dayUI.FadeToBlack();
        yield return new WaitForSeconds(1.1f);
        mainCamera.state = CameraController.State.StayStill;
        player.transform.position = nextDaySpawn.position;
        mainCamera.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);
        manager.dayNumber++;
        SoloBigDialogue newSoloDialogue = Instantiate(dialogue);
    }
}
