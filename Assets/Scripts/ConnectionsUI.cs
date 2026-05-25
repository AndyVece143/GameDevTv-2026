using NUnit.Framework.Constraints;
using TMPro;
using Unity.VisualScripting;
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
    public TextMeshProUGUI objectiveText;

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
        Objective();
    }

    private void Terance()
    {
        //if (manager.teranceFriendship == 0)
        //{
        //    teranceIcon.nameText.text = "";
        //    teranceIcon.image.sprite = huh;
        //    teranceIcon.image.preserveAspect = true;
        //    teranceIcon.descriptionText.text = "";
        //}

        //else
        //{
        //    teranceIcon.nameText.text = "Terance";
        //    teranceIcon.image.sprite = teranceImage;
        //    teranceIcon.image.preserveAspect = true;
        //    teranceIcon.descriptionText.text = "A nine year old boy who likes playing video games. He frequently gets stuck and needs help.";
        //}

        switch (manager.teranceFriendship)
        {
            case 0:
                teranceIcon.nameText.text = "";
                teranceIcon.image.sprite = huh;
                teranceIcon.image.preserveAspect = true;
                teranceIcon.descriptionText.text = "";
                break;
            case 1:
                teranceIcon.nameText.text = "Terance";
                teranceIcon.image.sprite = teranceImage;
                teranceIcon.image.preserveAspect = true;
                teranceIcon.descriptionText.text = "A nine year old boy who likes playing video games. He frequently gets stuck and needs help.";
                break;
            case 2:
                teranceIcon.nameText.text = "Terance";
                teranceIcon.image.sprite = teranceImage;
                teranceIcon.image.preserveAspect = true;
                teranceIcon.descriptionText.text = "A nine year old boy who likes playing video games. He got teased for needing help with a a game.";
                break;
            case 3:
                teranceIcon.nameText.text = "Terance";
                teranceIcon.image.sprite = teranceImage;
                teranceIcon.image.preserveAspect = true;
                teranceIcon.descriptionText.text = "A nine year old boy who likes playing video games. He stood up for himself and is fine with help.";
                break;


        }
    }

    private void Meemaw()
    {
        //if (manager.meemawFriendship == 0)
        //{
        //    meemawIcon.nameText.text = "";
        //    meemawIcon.image.sprite = huh;
        //    meemawIcon.image.preserveAspect = true;
        //    meemawIcon.descriptionText.text = "";
        //}
        //else
        //{
        //    meemawIcon.nameText.text = "Meemaw";
        //    meemawIcon.image.sprite = meemawImage;
        //    meemawIcon.image.preserveAspect = true;
        //    meemawIcon.descriptionText.text = "A nice old lady who has lived here longer than the rest. She has trouble crossing the street.";
        //}

        switch (manager.meemawFriendship)
        {
            case 0:
                meemawIcon.nameText.text = "";
                meemawIcon.image.sprite = huh;
                meemawIcon.image.preserveAspect = true;
                meemawIcon.descriptionText.text = "";
                break;
            case 1:
                meemawIcon.nameText.text = "Meemaw";
                meemawIcon.image.sprite = meemawImage;
                meemawIcon.image.preserveAspect = true;
                meemawIcon.descriptionText.text = "A nice old lady who has lived here longer than the rest. She has trouble crossing the street.";
                break;
            case 2:
                meemawIcon.nameText.text = "Meemaw";
                meemawIcon.image.sprite = meemawImage;
                meemawIcon.image.preserveAspect = true;
                meemawIcon.descriptionText.text = "A nice old lady who has lived here longer than the rest. She reminds me of my late grandma.";
                break;
            case 3:
                meemawIcon.nameText.text = "Meemaw";
                meemawIcon.image.sprite = meemawImage;
                meemawIcon.image.preserveAspect = true;
                meemawIcon.descriptionText.text = "A nice old lady who has lived here longer than the rest. She said her real name is 'Melvin'?";
                break;
        }
    }

    private void Yuri()
    {
        //if (manager.yuriFriendship == 0)
        //{
        //    yuriIcon.nameText.text = "";
        //    yuriIcon.image.sprite = huh;
        //    yuriIcon.image.preserveAspect = true;
        //    yuriIcon.descriptionText.text = "";
        //}
        //else
        //{
        //    yuriIcon.nameText.text = "Annabelle";
        //    yuriIcon.image.sprite = yuriImage;
        //    yuriIcon.image.preserveAspect = true;
        //    yuriIcon.descriptionText.text = "A very pretty lady who enjoys nature. I hope we can spend more time together.";
        //}

        switch (manager.yuriFriendship)
        {
            case 0:
                yuriIcon.nameText.text = "";
                yuriIcon.image.sprite = huh;
                yuriIcon.image.preserveAspect = true;
                yuriIcon.descriptionText.text = "";
                break;
            case 1:
                yuriIcon.nameText.text = "Annabelle";
                yuriIcon.image.sprite = yuriImage;
                yuriIcon.image.preserveAspect = true;
                yuriIcon.descriptionText.text = "A very pretty lady who enjoys nature. I hope we can spend more time together.";
                break;
            case 2:
                yuriIcon.nameText.text = "Annabelle";
                yuriIcon.image.sprite = yuriImage;
                yuriIcon.image.preserveAspect = true;
                yuriIcon.descriptionText.text = "A very pretty lady who enjoys nature. She is happy to have found someone to do activities with.";
                break;
            case 3:
                yuriIcon.nameText.text = "Annabelle";
                yuriIcon.image.sprite = yuriImage;
                yuriIcon.image.preserveAspect = true;
                yuriIcon.descriptionText.text = "A very pretty lady who enjoys nature. She... likes me? What is our relationship now?";
                break;
        }
    }

    private void Smarts()
    {
        //if (manager.smartsFriendship == 0)
        //{
        //    smartsIcon.nameText.text = "";
        //    smartsIcon.image.sprite = huh;
        //    smartsIcon.image.preserveAspect = true;
        //    smartsIcon.descriptionText.text = "";
        //}
        //else
        //{
        //    smartsIcon.nameText.text = "Sophia";
        //    smartsIcon.image.sprite = smartsImage;
        //    smartsIcon.image.preserveAspect = true;
        //    smartsIcon.descriptionText.text = "A young girl who is enrolled in a private school. She needs help learning some subjects.";
        //}

        switch (manager.smartsFriendship)
        {
            case 0:
                smartsIcon.nameText.text = "";
                smartsIcon.image.sprite = huh;
                smartsIcon.image.preserveAspect = true;
                smartsIcon.descriptionText.text = "";
                break;
            case 1:
                smartsIcon.nameText.text = "Sophia";
                smartsIcon.image.sprite = smartsImage;
                smartsIcon.image.preserveAspect = true;
                smartsIcon.descriptionText.text = "A young girl who is enrolled in a private school. She needs help learning some subjects.";
                break;
            case 2:
                smartsIcon.nameText.text = "Sophia";
                smartsIcon.image.sprite = smartsImage;
                smartsIcon.image.preserveAspect = true;
                smartsIcon.descriptionText.text = "A young girl who is enrolled in a private school. She wants to live up to her parents.";
                break;
            case 3:
                smartsIcon.nameText.text = "Sophia";
                smartsIcon.image.sprite = smartsImage;
                smartsIcon.image.preserveAspect = true;
                smartsIcon.descriptionText.text = "A young girl who is enrolled in a private school. She's become more comfortable with asking for help.";
                break;
        }
    }

    private void Objective()
    {
        switch (manager.dayNumber)
        {
            case 0:
                if (manager.yuriFriendship == 1 && manager.teranceFriendship == 1 && manager.meemawFriendship == 1 && manager.smartsFriendship == 1)
                {
                    objectiveText.text = "You've met everyone. Time to go home for the day. Go left.";
                }
                else
                {
                    objectiveText.text = "Look around and meet new people.";
                }
                break;
            case 1:
                if (manager.yuriFriendship == 2 && manager.teranceFriendship == 2 && manager.meemawFriendship == 2 && manager.smartsFriendship == 2)
                {
                    objectiveText.text = "You've hung out with everyone today. Time to go home for the day.";
                }
                else
                {
                    objectiveText.text = "Talk to your new connections.";
                }
                break;
            case 2:
                if (manager.yuriFriendship == 3 && manager.teranceFriendship == 3 && manager.meemawFriendship == 3 && manager.smartsFriendship == 3)
                {
                    objectiveText.text = "Your connections are strong. Time to go home for the day.";
                }
                else
                {
                    objectiveText.text = "Talk to your new connections.";
                }
                break;
        }
    }
}
