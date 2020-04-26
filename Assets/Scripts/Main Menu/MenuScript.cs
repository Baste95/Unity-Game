using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameObject CreditsText;
    private bool ShowCredits = false;

    public GameObject SliderGO;
    public Slider LoadingSlider;
    AsyncOperation async;


    public void OnClickPlayButton()
    {
        StartCoroutine(LoadingScene());
    }

    public void OnCLickCreditsButton()
    {
        if (ShowCredits)
        {
            ShowCredits = false;
            CreditsText.SetActive(false);
        }
        else
        {
            ShowCredits = true;
            CreditsText.SetActive(true);
        }
    }

    public void OnClickQuitButton()
    {
        Application.Quit();
        //Debug.Log("Quit");
    }

    IEnumerator LoadingScene()
    {
        SliderGO.SetActive(true);
        async = SceneManager.LoadSceneAsync("OpenWorld");
        async.allowSceneActivation = false;

        while(async.isDone == false)
        {
            LoadingSlider.value = async.progress;
            if(async.progress == 0.9f)
            {
                LoadingSlider.value = 1f;
                async.allowSceneActivation = true;

            }
            yield return null;
        }
    }
}
