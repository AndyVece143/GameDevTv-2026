using UnityEngine;

public class ConnectionsUI : MonoBehaviour
{
    public GameManager manager;
    public MenuIcons teranceIcon;
    public MenuIcons yuriIcon;
    public MenuIcons smartsIcon;
    public MenuIcons meemawIcon;

    public Sprite huh;
    public Sprite teranceImage;
    public Sprite yuriImage;
    public Sprite smartsImage;
    public Sprite meemawImage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Terance();
        Meemaw();
        Yuri();
        Smarts();
    }

    private void Terance()
    {
        if (manager.teranceFriendship == 0)
        {
            teranceIcon.nameText.text = "";
            teranceIcon.image.sprite = huh;
            teranceIcon.image.preserveAspect = true;
            teranceIcon.descriptionText.text = "";
        }

        else
        {
            teranceIcon.nameText.text = "Terance";
            teranceIcon.image.sprite = teranceImage;
            teranceIcon.image.preserveAspect = true;
            teranceIcon.descriptionText.text = "A nine year old boy who likes playing video games. He frequently gets stuck and needs help.";
        }
    }

    private void Meemaw()
    {
        if (manager.meemawFriendship == 0)
        {
            meemawIcon.nameText.text = "";
            meemawIcon.image.sprite = huh;
            meemawIcon.image.preserveAspect = true;
            meemawIcon.descriptionText.text = "";
        }
        else
        {
            meemawIcon.nameText.text = "Meemaw";
            meemawIcon.image.sprite = meemawImage;
            meemawIcon.image.preserveAspect = true;
            meemawIcon.descriptionText.text = "A nice old lady who has lived here longer than the rest. She has trouble crossing the street.";
        }
    }

    private void Yuri()
    {
        if (manager.yuriFriendship == 0)
        {
            yuriIcon.nameText.text = "";
            yuriIcon.image.sprite = huh;
            yuriIcon.image.preserveAspect = true;
            yuriIcon.descriptionText.text = "";
        }
        else
        {
            yuriIcon.nameText.text = "Annabelle";
            yuriIcon.image.sprite = yuriImage;
            yuriIcon.image.preserveAspect = true;
            yuriIcon.descriptionText.text = "A very pretty lady who enjoys nature. I hope we can spend more time together.";
        }
    }

    private void Smarts()
    {
        if (manager.smartsFriendship == 0)
        {
            smartsIcon.nameText.text = "";
            smartsIcon.image.sprite = huh;
            smartsIcon.image.preserveAspect = true;
            smartsIcon.descriptionText.text = "";
        }
        else
        {
            smartsIcon.nameText.text = "Sophia";
            smartsIcon.image.sprite = smartsImage;
            smartsIcon.image.preserveAspect = true;
            smartsIcon.descriptionText.text = "A young girl who is enrolled in a private school. She needs help learning some subjects.";
        }

    }
}
