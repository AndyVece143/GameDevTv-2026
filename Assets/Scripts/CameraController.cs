using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    private Vector3 offset = new Vector3(0f, 0f, -10f);
    private float smoothTime = 0.15f;
    private Vector3 velocity = Vector3.zero;
    public PlatformerPlayer platformerPlayer;

    public enum State
    {
        FollowPlayer,
        StayStill,
        RoadGame1,
        RoadGame2,
        RoadGame3,
        Platformer,
    }
    public State state;

    public GameManager manager;
    public RoadGame roadGame1;
    public RoadGame roadGame2;
    public RoadGame roadGame3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case State.FollowPlayer:
                FollowPlayer();
                break;
            case State.StayStill:
                break;
            case State.RoadGame1:
                FollowRoad1();
                break;
            case State.Platformer:
                FollowPlatformer();
                break;
            case State.RoadGame2:
                FollowRoad2();
                break;
            case State.RoadGame3:
                FollowRoad3();
                break;
        }
    }

    private void FollowPlayer()
    {
        Vector3 targetPosition = player.position + offset;
        targetPosition.y = 0;

        switch (manager.dayNumber)
        {
            case 0:
                if (targetPosition.x < 0)
                {
                    targetPosition.x = 0;
                }

                if (targetPosition.x > 42)
                {
                    targetPosition.x = 42;
                }
                break;

            case 1:
                if (targetPosition.x < 70)
                {
                    targetPosition.x = 70;
                }

                if (targetPosition.x > 112)
                {
                    targetPosition.x = 112;
                }
                break;

            case 2:
                if (targetPosition.x < 140)
                {
                    targetPosition.x = 140;
                }

                if (targetPosition.x > 182)
                {
                    targetPosition.x = 182;
                }
                break;
        }
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }

    private void FollowRoad1()
    {
        Vector3 targetPosition = roadGame1.player.transform.position + offset;
        targetPosition.y = roadGame1.transform.position.y;

        if (targetPosition.x < 21.45f)
        {
            targetPosition.x = 21.45f;
        }

        if (targetPosition.x > 58.55f)
        {
            targetPosition.x = 58.55f;
        }
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }

    private void FollowRoad2()
    {
        Vector3 targetPosition = roadGame2.player.transform.position + offset;
        targetPosition.y = roadGame2.transform.position.y;

        if (targetPosition.x < 21.45f)
        {
            targetPosition.x = 21.45f;
        }

        if (targetPosition.x > 58.55f)
        {
            targetPosition.x = 58.55f;
        }
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }

    private void FollowRoad3()
    {
        Vector3 targetPosition = roadGame3.player.transform.position + offset;
        targetPosition.y = roadGame3.transform.position.y;

        if (targetPosition.x < 21.45f)
        {
            targetPosition.x = 21.45f;
        }

        if (targetPosition.x > 58.55f)
        {
            targetPosition.x = 58.55f;
        }
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }

    private void FollowPlatformer()
    {
        Vector3 targetPosition = platformerPlayer.transform.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }

}
