using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharactersScript : MonoBehaviour
{
    private Object ObjectSelected;
    public AudioSource SpeakingAudio, CompletSong;
    public Text QuestCompletText;
    public Text QuestText;
    public GameObject ButtonA;
    public GameObject ButtonB;
    public GameObject YesText;
    public GameObject NoText;


    private bool CanSummit = true;
    private bool GazeAt = false;

    private string Quest = "";
    private string GazeAtName = "";

    private int NumberOfQuests = 5;

    private string[] RandomQuotes = new string[] { "L'armée est présente sur la plage.", "Bonjour.", "Tu es nouveau dans le coin.", "Les enfants aiment se cacher derière les maisons", "Ici on est fan de Pierre Papier Ciseaux.", "Je crois que quelqu'un à perdue son chien" };

    //Hide Quest;
    public GameObject ChildreHide1;
    public GameObject ChildreHide2;
    public GameObject ChildreHide3;
    private int FoundHided = 0;

    //FarmQuest
    public GameObject Corn;
    private bool CornBool = false;

    //Dog Quest
    public GameObject Dog;

    public void DisplayButtons(bool cond)
    {
        ButtonA.SetActive(cond);
        ButtonB.SetActive(cond);
        YesText.SetActive(cond);
        NoText.SetActive(cond);
    }

    


    //Hide Quest
    public void HideSummit()
    {
        if (Parameters.HideQuest)
        {
            QuestText.text = "Merci encore.";
            Invoke("EraseQuestText", 2);
        }

        else if (CanSummit)
        {
            CanSummit = false;
            Quest = "HideQuest";
            SpeakingAudio.Play();
            DisplayButtons(true);
            QuestText.text = "Veux-tu jouer à cache chache?";  
        }
    }

    public void HideDestroy(GameObject child)
    {
        FoundHided++;
        Object.Destroy(child);
        GazeAt = false;
        if (FoundHided == 3)
        {
            Parameters.QuestAchieved++;
            Parameters.FarmQuest = true;
            QuestComplet();
            QuestText.text = "Les enfants ont été retrouvés.";
            Invoke("EraseQuestText", 2);
        }
        else
        {
            QuestText.text = "Bien joué, encore " + (3 - FoundHided) + " joueurs";
            Invoke("EraseQuestText", 2);
        }
    }

    // Farmer Quest

    public void FarmerSummit()
    {
        if (Parameters.FarmQuest)
        {
            QuestText.text = "Merci encore.";
            Invoke("EraseQuestText", 2);
        }

        else if (CanSummit)
        {
            CanSummit = false;
            Quest = "FarmerQuest";
            SpeakingAudio.Play();
            DisplayButtons(true);
            QuestText.text = "Veux-tu m'aider à récolter le blé?";
        }
    }

    public void CornDestroy(GameObject child)
    {
        Object.Destroy(child);
        GazeAt = false;
        if (Corn.transform.childCount == 1 )
        {
            Object.Destroy(Corn);
            Parameters.QuestAchieved++;
            Parameters.FarmQuest = true;
            QuestComplet();
            CornBool = false;
            QuestText.text = "Le blés a été récoltés.";
            Invoke("EraseQuestText", 2);
        }
    }


    //Dog Quest
    public void DogSummit()
    {
        if (Parameters.DogQuest)
        {
            QuestText.text = "Merci encore.";
            Invoke("EraseQuestText", 2);
        }

        else if (CanSummit)
        {
            CanSummit = false;
            Quest = "DogQuest";
            SpeakingAudio.Play();
            DisplayButtons(true);
            QuestText.text = "J'ai perdue mon chien, aide moi s'il te plait.";
        }
    }

    public void DogDestroy()
    {
        Object.Destroy(Dog);
        Parameters.QuestAchieved++;
        Parameters.DogQuest = true;
        QuestComplet();
        GazeAt = false;
        QuestText.text = "Le chien à été retrouvé";
        Invoke("EraseQuestText", 2);
    }

    //PPC Quest

    public void PPCSummit()
    {
        if (Parameters.PPCQuest)
        {
            QuestText.text = "Merci encore.";
            Invoke("EraseQuestText", 2);
        }

        else if (CanSummit)
        {
            CanSummit = false;
            Quest = "PPCQuest";
            SpeakingAudio.Play();
            DisplayButtons(true);
            QuestText.text = "Tu veux jouer à Pierre Feuille Ciseaux.";
        }
        
    }
    IEnumerator LaunchPPC()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("PPC");
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    // FPS Quest
    public void FPSSummit()
    {
        if (Parameters.FPSQuest)
        {
            QuestText.text = "Merci encore.";
            Invoke("EraseQuestText", 2);
        }

        else if (CanSummit)
        {
            CanSummit = false;
            Quest = "FPSQuest";
            SpeakingAudio.Play();
            DisplayButtons(true);
            QuestText.text = "Des zombies nous attaquent! Aide nous.";
        }

    }
    IEnumerator LaunchFPS()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("FPS");
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    //Function All Quests

    public void LauncherQuest()
    {
        if(GazeAtName == "ChildrenQuest")
        {
            HideSummit();
        }
        else if(GazeAtName == "FarmerBoy")
        {
            FarmerSummit();
        }
        else if(GazeAtName == "CowGirl")
        {
            DogSummit();
        }
        else if(GazeAtName == "CowBoyPPC")
        {
            PPCSummit();
        }
        else if (GazeAtName == "Army")
        {
            FPSSummit();
        }
        
    }
    public void Respond(string cond)
    {
        if (cond == "HideQuest")
        {
            QuestText.text = "Super. Je vais me cacher, trouve moi!";
            DisplayButtons(false);
            Invoke("EraseQuestText", 2);
            CanSummit = true;
            ChildreHide1.SetActive(true);
            ChildreHide2.SetActive(true);
            ChildreHide3.SetActive(true);
        }
        else if(cond == "FarmerQuest"){
            CornBool = true;
            QuestText.text = "Merci beaucoup, le champ est juste à coté!";
            DisplayButtons(false);
            Invoke("EraseQuestText", 2);
            CanSummit = true;
        }
        else if(cond == "DogQuest")
        {
            QuestText.text = "Dieu soit loué, retrouve le vite.";
            DisplayButtons(false);
            Invoke("EraseQuestText", 2);
            Dog.SetActive(true);
            CanSummit = true;
        }
        else if(cond == "PPCQuest")
        {
            CanSummit = true;
            DisplayButtons(false);
            StartCoroutine(LaunchPPC());
        }
        else if (cond == "FPSQuest")
        {
            CanSummit = true;
            DisplayButtons(false);
            StartCoroutine(LaunchFPS());
        }
        else
        {
            QuestText.text = "Dommage. Reviens me voir plus tard.";
            DisplayButtons(false);
            Invoke("EraseQuestText", 2);
            CanSummit = true;
        }
    }

    public void EraseQuestText()
    {
        QuestText.text = "";
    }

    public void QuestComplet()
    {
        QuestCompletText.text = Parameters.QuestAchieved + "/" + NumberOfQuests;
        if(Parameters.QuestAchieved == NumberOfQuests)
        {
            QuestText.text = "Félicitation, vous avez réussi toutes les quêtes!";
            Invoke("EraseQuestText", 2);
            CompletSong.Play();
        }
    }

    public void OnPointerEnter(GameObject obj)
    {
        GazeAt = true;
        GazeAtName = obj.name;
        
    }

    public void OnPointerExit()
    {
        GazeAt = false;
        GazeAtName = "";
    }

    public void RandomQuotesFunc()
    {
        System.Random rnd = new System.Random();
        int num = rnd.Next(6);
        QuestText.text = RandomQuotes[num];
        Invoke("EraseQuestText", 2);
    }


    void Awake()
    {
        QuestComplet();
    }

    void Update()
    {

        if (!CanSummit && Input.GetButtonDown("Button_X"))
        {
            Respond(Quest);
        }

        if(!CanSummit && Input.GetButtonDown("Button_Circle"))
        {
            Quest = "Else";
            Respond(Quest);
        }

        if (GazeAt && Input.GetButtonDown("Button_X"))
        {
            if (GazeAtName.Contains("ChildrenHide"))
            {
                HideDestroy(GameObject.Find(GazeAtName));
            }
            else if (GazeAtName.Contains("SheafOfHay") && CornBool)
            {
                CornDestroy(GameObject.Find(GazeAtName));
            }
            else if(GazeAtName == "Dog")
            {
                DogDestroy();
            }
            else if (GazeAtName == "Others")
            {
                RandomQuotesFunc();
            }

            else
            {
                LauncherQuest();
            }
        }


    }
}
