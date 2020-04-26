using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSShow : MonoBehaviour
{
    void OnGUI()
    {
        GUI.Label(new Rect(0, 0, 100, 50), "FPS: " + (int)(1.0f / Time.smoothDeltaTime));
    }
}
