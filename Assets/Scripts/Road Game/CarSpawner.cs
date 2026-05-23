using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public Car car;
    public float minTime;
    public float maxTime;
    public float timer;
    public RoadGame game;
    public float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer = Random.Range(minTime, maxTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (game.state == RoadGame.State.Playing)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                SpawnCar();
            }
        }
    }

    private void SpawnCar()
    {
        Car newCar = Instantiate(car);
        newCar.transform.position = transform.position;
        newCar.speed = speed;
        timer = Random.Range(minTime, maxTime);
    }
}
