using UnityEngine;

public class Flower : MonoBehaviour
{
    private Animator anim;
    public enum State
    {
        Still,
        Growing,
    }
    public State state;
    public AudioSource water;
    private float timer;
    public float amount;
    public float growth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        state = State.Still;
        timer = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case State.Still:
                Still();
                break;
            case State.Growing:
                Growing();
                break;
        }
        anim.SetFloat("growth", growth);
    }

    private void Growing()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            growth += amount;
            timer = 0.5f;
        }
        water.volume = 1;
    }
    private void Still()
    {
        water.volume = 0;
    }
}
