using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WalkSounds : MonoBehaviour
{
    public AudioClip WalkSand1;
    public AudioClip WalkSand2;

    public AudioClip WalkGrass1;
    public AudioClip WalkGrass2;

    public AudioClip Other1;
    public AudioClip Other2;

    private FirstPersonController controller;

    private string ActualGameObject = "";


    private void Start()
    {
        controller = GetComponent<FirstPersonController>();
    }


    void OnControllerColliderHit(ControllerColliderHit hit)
    {

        if (hit.gameObject.transform.parent.name != ActualGameObject)
        {

            if (hit.gameObject.transform.parent.name == "Sand")
            {
                ActualGameObject = hit.gameObject.transform.parent.name;
                controller.m_FootstepSounds[0] = WalkSand1;
                controller.m_FootstepSounds[1] = WalkSand2;

            }

            else if (hit.gameObject.name.Contains("sand"))
            {
                ActualGameObject = hit.gameObject.transform.parent.name;
                controller.m_FootstepSounds[0] = WalkSand1;
                controller.m_FootstepSounds[1] = WalkSand2;
            }


            else if (hit.gameObject.transform.parent.name == "Environement")
            {
                ActualGameObject = hit.gameObject.transform.parent.name;
                controller.m_FootstepSounds[0] = WalkGrass1;
                controller.m_FootstepSounds[1] = WalkGrass2;

            }

            else
            {
                ActualGameObject = hit.gameObject.transform.parent.name;
                controller.m_FootstepSounds[0] = Other1;
                controller.m_FootstepSounds[1] = Other2;
            }


        }
    }
}
