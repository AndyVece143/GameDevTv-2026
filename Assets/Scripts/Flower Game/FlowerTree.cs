using UnityEngine;

public class FlowerTree : MonoBehaviour
{
    public FlowerApple apple;
    public float spawnTimer;
    [SerializeField] private GameObject[] spawnPoints;
    public bool spawnApples;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnTimer = Random.Range(1, 2);
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0 && spawnApples == true)
        {
            SpawnApples();
        }
    }

    private void SpawnApples()
    {
        int i = Random.Range(0, 5);

        //See if apple is at spawn position
        Vector3 spawnPos = spawnPoints[i].transform.position;
        float radius = 0.1f;

        if (Physics2D.OverlapCircle(spawnPos, radius))
        {
            //Debug.Log("Uh oh!");
            SpawnApples();
        }

        else
        {
            Instantiate(apple, spawnPos, Quaternion.identity);
            spawnTimer = Random.Range(1, 2);
        }
    }
}
