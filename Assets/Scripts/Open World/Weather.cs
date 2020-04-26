using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weather : MonoBehaviour
{
    public GameObject Sun;
    private Light SunLight;

    public float RotationSunSpeed = 1f;

    // Start is called before the first frame update
    void Awake()
    {
        SunLight = Sun.GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        SunLight.transform.Rotate(Vector3.right * RotationSunSpeed * Time.deltaTime);

    }
}
