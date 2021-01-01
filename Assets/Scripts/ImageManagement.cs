using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageManagement : MonoBehaviour
{
    [SerializeField] private List<GameObject> FemaleSprites;
    [SerializeField] private List<GameObject> MaleSprites;

    [SerializeField] private string Name;
    [SerializeField] public bool Gender;
    [SerializeField] private GameObject GenderButtons;
    
    [SerializeField] public string Victim;

    [SerializeField] private GameObject Intro;
    [SerializeField] private Text Intro_Greet;

    [SerializeField] private GameObject Textbox; // this is the dialogue box of victim to be set active
    [SerializeField] private Text text; // this is the main dialogue of the victim

    [SerializeField] private SpriteRenderer currentSprite;

    [SerializeField] private GameObject AfterIntro;
    [SerializeField] private Button MyNameButton;

    [SerializeField] private Text name;

    [SerializeField] private GameObject FailBox;
    
    [SerializeField] private GameObject NiceToMeetYouOptions;
    [SerializeField] private Button ManagerButton;
    [SerializeField] private Button TerminalButton;

    // Success Route

    [SerializeField] private GameObject KeyCardOptions;
    [SerializeField] private Button CanIseeButton;
    [SerializeField] private Button AskButton;
    [SerializeField] private Button MakeCardButton;

    [SerializeField] private GameObject FollowMeOptions;
    //[SerializeField] private Button ThreeHoursButton;

    // Failure Route

    [SerializeField] private GameObject SoBasicallyOptions;
    [SerializeField] private Button WhatTools;
    [SerializeField] private Button TerminalButton2;

    [SerializeField] private GameObject AceAuditOptions;
    [SerializeField] private Button HowUseButton;

    [SerializeField] private GameObject AuditHowToOptions;
    [SerializeField] private Button WhatHappensButton;

    //flag

    [SerializeField] private GameObject Flag;

    
    private void Awake()
    {
        GenderButtons.SetActive(true);
        MyNameButton.onClick.AddListener(delegate { Succeed(AfterIntro, NiceToMeetYouOptions, "Nice to meet you! So what can I do for you?", 7); });
        ManagerButton.onClick.AddListener(delegate { Succeed(NiceToMeetYouOptions, SoBasicallyOptions, "Ah, so basically what I do on the daily, is monitor for security breaches in the main database.", 8); });
        TerminalButton.onClick.AddListener(delegate { Succeed(NiceToMeetYouOptions, KeyCardOptions, "You need a key card, but once you have that, you basically have the same privileges as the CEO.", 6); });
        TerminalButton2.onClick.AddListener(delegate { Succeed(SoBasicallyOptions, KeyCardOptions, "You need a key card, but once you have that, you basically have the same privileges as the CEO.", 6); });
        CanIseeButton.onClick.AddListener(delegate { Succeed(KeyCardOptions, FollowMeOptions, "Yep, follow me and I'll show you around.", 6); });
        AskButton.onClick.AddListener(delegate { Succeed(KeyCardOptions, FollowMeOptions, "Yep, follow me and I'll show you around.", 6); });
        MakeCardButton.onClick.AddListener(delegate { Failure2("Yep, come back to me when you get your keycard.", 7); });
        WhatTools.onClick.AddListener(delegate { Succeed(SoBasicallyOptions, AceAuditOptions, "Oh, we use Ace Audits. Basically, it just runs thorough scans throughout the system, but you need credentials to even run it.", 7); });
        HowUseButton.onClick.AddListener(delegate { Succeed(AceAuditOptions, AuditHowToOptions, "Yeah, sure. You just log in and there will be an option to just run audits. Simple, right?", 6); });
        WhatHappensButton.onClick.AddListener(delegate { Failure2("It detects foreign connections to our database. If someone unknown connects, they are automatically denied access.", 7); });


    }
    public void SayNext(string line)
    {
        text.text = line;
    }

    public void Male()
    {
        Gender = true;
        Name = "James";
        Victim = "Julie";
        GenderButtons.SetActive(false);
        Debug.Log("Player is Male");
        //FemaleSprites[6].SetActive(true);
        currentSprite.sprite = FemaleSprites[6].GetComponent<SpriteRenderer>().sprite;
        Intro.SetActive(true);
        Intro_Greet.text = "Hey! You must be " + Victim + "! I'm the new intern here who is supposed to be shadowing you!";
        
    }
    public void Female()
    {
        Gender = false;
        Victim = "Malcolm";
        Name = "Ashley";
        GenderButtons.SetActive(false);
        Debug.Log("Player is Female");
        //MaleSprites[6].SetActive(true);
        currentSprite.sprite = MaleSprites[6].GetComponent<SpriteRenderer>().sprite;
        Intro.SetActive(true);
        Intro_Greet.text = "Hey! You must be " + Victim + "! I'm the new intern here who is supposed to be shadowing you!";
    }

    public void ChangeSprite(int index, bool gender)
    {
        if (gender) // Male, so change female sprite
        {
            currentSprite.sprite = FemaleSprites[index].GetComponent<SpriteRenderer>().sprite;
        }
        else // Female, so change male sprite
        {
            currentSprite.sprite = MaleSprites[index].GetComponent<SpriteRenderer>().sprite;
        }
    }

    public void Hello(bool success) // first encounter
    {
        Textbox.SetActive(true);
        Intro.SetActive(false);
        if (success == true)
        {
            SayNext(Victim + ": Hello, nice to meet you... uh.. Sorry, didn't catch your name there.");
            AfterIntro.SetActive(true);
            name.text = name.text + " " + Name+ ".";
        }
        else
        {
            SayNext(Victim + ": Who do you think you're talking to like that? Get lost, loser.");
            ChangeSprite(0, Gender);
            FailBox.SetActive(true);
        }
    }

    public void Failure(string failtext)
    {
        foreach (GameObject f in GameObject.FindGameObjectsWithTag("Fail"))
        {
            f.SetActive(true); 
        }
        foreach (GameObject g in GameObject.FindGameObjectsWithTag("options"))
        {
            g.SetActive(false);
        }
        SayNext(Victim + ": " + failtext);
        ChangeSprite(0, Gender);
        FailBox.SetActive(true);
    }

    public void Failure2(string failtext, int index)
    {
        foreach (GameObject f in GameObject.FindGameObjectsWithTag("Fail"))
        {
            f.SetActive(true);
        }
        foreach (GameObject g in GameObject.FindGameObjectsWithTag("options"))
        {
            g.SetActive(false);
        }
        SayNext(failtext);
        ChangeSprite(index, Gender);
        FailBox.GetComponentInChildren<Text>().text = "I've learned nothing new. " + FailBox.GetComponentInChildren<Text>().text;
        FailBox.SetActive(true);
    }

    public void Succeed(GameObject toDisable, GameObject toEnable, string NextLine, int index)
    {
        toDisable.SetActive(false);
        toEnable.SetActive(true);
        text.text = Victim + ": " + NextLine;
        ChangeSprite(index, Gender);
    }

    public void CapFlag()
    {
        Flag.SetActive(true);
        ChangeSprite(8, Gender);
        foreach (GameObject g in GameObject.FindGameObjectsWithTag("options"))
        {
            g.SetActive(false);
        }
        SayNext(Victim + ": Alright! Glad I could help. See you whenever you finish up! I'll head to lunch first.");
    }

    public void ResetScene()
    {
        Name = null;
        Victim = null;
        GenderButtons.SetActive(true);
        currentSprite.sprite = null;
        FailBox.SetActive(false);
        Textbox.SetActive(false);
    }

}
