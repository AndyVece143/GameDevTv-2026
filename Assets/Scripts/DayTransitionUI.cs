using System.Collections;
using TMPro;
using UnityEngine;

public class DayTransitionUI : MonoBehaviour
{
    public Animator anim;
    public TextMeshProUGUI dayText;
    public TextMeshProUGUI dayText2;
    public GameManager manager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FadeToBlack()
    {
        anim.SetTrigger("black");
    }

    public IEnumerator SwitchDays(int dayNumber)
    {
        Debug.Log(dayNumber);
        StartCoroutine(manager.ControlPlayerAgain());
        switch (dayNumber)
        {
            case 0:
                dayText.text = "Day 1";
                dayText2.text = "Day 2";
                break;
            case 1:
                dayText.text = "Day 2";
                dayText2.text = "Day 3";
                break;

        }
        anim.SetTrigger("switchday");
        yield return new WaitForSeconds(1.5f);
        
/*        if (dayNumber == 0)
        {
            Debug.Log("HELP");
        }
        switch (dayNumber)
        {
            case 0:
                Debug.Log("Do something");
                dayText.text = "Day 2";
                break;
            case 1:
                dayText.text = "Day 3";
                break;
        }*/

    }
}
