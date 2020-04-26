using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public int Remains = 1;
    private int test;
    void Awake()
    {
        test = Remains;
    }

    public void RefreshText()
    {
        Text RemainsText;
        RemainsText = GameObject.Find("Canvas/Remains").GetComponent<Text>();
        RemainsText.text = "Zombies Restant: " + Remains;
        if(Remains <= 0)
        {
            Parameters.QuestAchieved++;
            Parameters.FPSQuest = true;
            RemainsText.text = "Tout les Zombies ont été tués.";
            Invoke("Quit", 2);
        }
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

    void Update()
    {
        if (Input.GetButtonDown("Button_Option"))
        {
            StartCoroutine(LoadYourAsyncScene());
        }
        if(test != Remains) {
            RefreshText();
            test--;
        }
        
    }
}
