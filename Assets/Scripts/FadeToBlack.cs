using UnityEngine;

public class FadeToBlack : MonoBehaviour
{
    public Animator anim;

    public void BecomeTrans()
    {
        anim.Play("trans");
    }

    public void BecomeTransFast()
    {
        anim.Play("transfast");
    }
}
