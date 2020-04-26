using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Quit : MonoBehaviour
{
    IEnumerator LoadYourAsyncScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("MainMenu");
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
    void Update()
    {
        if (Input.GetButtonDown("Button_Option")){
            StartCoroutine(LoadYourAsyncScene());
        }
    }
}
