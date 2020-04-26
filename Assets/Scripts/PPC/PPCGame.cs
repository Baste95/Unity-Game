using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PPCGame : MonoBehaviour
{
    public GameObject[] TouchToChange = new GameObject[6];
    public GameObject[] ImageToChange = new GameObject[2];
    public Text ScorePlayerText, ScoreIAText, ResultText;
    public Image PlayerImage, IAImage;
    public Sprite[] TabSprite = new Sprite[3];
    public AudioSource WinSound, LossSound;

    private int PlayerPoints = 0, IAPoints = 0;
    private bool CanPlay = true;

    private string PlayerSign, IASign;
    private string[] TabString = new string []{ "Paper", "Rock", "Cut" };

    public void SetActiveTTC(bool cond)
    {
        foreach(GameObject Go in TouchToChange)
        {
            Go.SetActive(cond);
        }
    }

    public void SetActiveITT(bool cond)
    {
        foreach (GameObject Go in ImageToChange)
        {
            Go.SetActive(cond);
        }
    }

    public void Play(string cond)
    {
        CanPlay = false;
        SetActiveTTC(false);
        PlayerSign = cond;
        if(cond == "Paper")
        {
            PlayerImage.sprite = TabSprite[0];
        }

        else if (cond == "Rock")
        {
            PlayerImage.sprite = TabSprite[1];
        }

        else if (cond == "Cut")
        {
            PlayerImage.sprite = TabSprite[2];
        }
        IAPlay();
    }

    public void IAPlay()
    {
        System.Random rnd = new System.Random();
        int num = rnd.Next(3);
        IASign = TabString[num];
        IAImage.sprite = TabSprite[num];
        Verification();
    }


    public void Verification()
    {
        SetActiveITT(true);
        if(PlayerSign == "Paper" && IASign == "Cut")
        {
            IAPoints++;
            ResultText.text = "Point pour l'adversaire.";
            LossSound.Play();
        }

        else if (PlayerSign == "Paper" && IASign == "Rock")
        {
            PlayerPoints++;
            ResultText.text = "Point pour toi.";
            WinSound.Play();
        }

        else if(PlayerSign == "Rock" && IASign == "Paper")
        {
            IAPoints++;
            ResultText.text = "Point pour l'adversaire.";
            LossSound.Play();
        }

        else if (PlayerSign == "Rock" && IASign == "Cut")
        {
            PlayerPoints++;
            ResultText.text = "Point pour toi.";
            WinSound.Play();
        }

        else if (PlayerSign == "Cut" && IASign == "Rock")
        {
            IAPoints++;
            ResultText.text = "Point pour l'adversaire.";
            LossSound.Play();
        }

        else if (PlayerSign == "Cut" && IASign == "Paper")
        {
            PlayerPoints++;
            ResultText.text = "Point pour toi.";
            WinSound.Play();
        }

        else
        {
            ResultText.text = "Match Nul.";
        }

        ScoreIAText.text = ""+IAPoints;
        ScorePlayerText.text = ""+PlayerPoints;

        if (PlayerPoints == 5 || IAPoints == 5)
        {
            Invoke("Win", 3);
        }
        else
        {
            Invoke("Clean", 3);
        }
    }


    public void Win()
    {
        if(PlayerPoints == 5)
        {
            ResultText.text = "Félicitation tu as gagné!";
            Parameters.PPCQuest = true;
            Parameters.QuestAchieved++;
            Parameters.Spawner = "PPC";
        }

        else
        {
            ResultText.text = "Tu as perdu.";
        }
        Invoke("Quit", 2);
    }



    public void Clean()
    {
        ResultText.text = "Choisit ton signe.";
        SetActiveITT(false);
        SetActiveTTC(true);
        CanPlay = true;
    }

    public void Quit()
    {
        StartCoroutine(LoadYourAsyncScene());
    }

    IEnumerator LoadYourAsyncScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("OpenWorld");
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (CanPlay && Input.GetButtonDown("Button_X"))
        {
            
            Play("Cut");
        }

        if (CanPlay && Input.GetButtonDown("Button_Square"))
        {
            
            Play("Rock");
        }

        if (CanPlay && Input.GetButtonDown("Button_Circle"))
        {
            
            Play("Paper");
        }

        if (Input.GetButtonDown("Button_Option"))
        {
            StartCoroutine(LoadYourAsyncScene());
        }
    }
}
