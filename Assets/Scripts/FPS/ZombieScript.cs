using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieScript : MonoBehaviour
{
    private Transform goal;
    private NavMeshAgent agent;
    private bool change = true;
    private GameObject Script;
    private Game GameScript;

    void Start()
    {
        Script = GameObject.Find("Scripts");
        GameScript = Script.GetComponent<Game>();
        goal = Camera.main.transform;
        agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position;
        GetComponent<Animation>().Play("zombie_walk_forward");
    }


    void OnTriggerEnter(Collider col)
    {
        
        GetComponent<CapsuleCollider>().enabled = false;
        Destroy(col.gameObject);
        GetComponent<AudioSource>().Play();
        agent.destination = gameObject.transform.position;
        GetComponent<Animation>().Stop();
        GetComponent<Animation>().Play("zombie_death_standing");
        Destroy(gameObject, 3);
        GameScript.Remains--;
        //Game.RefreshText();
        GameObject zombie = Instantiate(Resources.Load("Prefabs/zombie", typeof(GameObject))) as GameObject;

        float randomX = UnityEngine.Random.Range(-12f, 12f);
        float constantY = .01f;
        float randomZ = UnityEngine.Random.Range(-13f, 13f);
        zombie.transform.position = new Vector3(randomX, constantY, randomZ);

        while (Vector3.Distance(zombie.transform.position, Camera.main.transform.position) <= 3)
        {
            randomX = UnityEngine.Random.Range(-13f, -13f);
            if (change)
            {
                randomZ = UnityEngine.Random.Range(14f, 26f);
            }
            else
            {
                randomZ = UnityEngine.Random.Range(-20f, -14f);
            }
            change = !change;

            zombie.transform.position = new Vector3(randomX, constantY, randomZ);
        }

    }

}

