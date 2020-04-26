using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private GameObject gun;
    private GameObject spawnPoint;
    private bool isShooting;

    void Start()
    {
        gun = gameObject.transform.GetChild(0).gameObject;
        spawnPoint = gun.transform.GetChild(2).gameObject;

        isShooting = false;
    }


    IEnumerator Shoot()
    {
        isShooting = true;
        GameObject bullet = Instantiate(Resources.Load("Prefabs/bullet", typeof(GameObject))) as GameObject;
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        bullet.transform.rotation = spawnPoint.transform.rotation;
        bullet.transform.position = spawnPoint.transform.position;
        rb.AddForce(spawnPoint.transform.forward * 500f);
        GetComponent<AudioSource>().Play();
        gun.GetComponent<Animation>().Play();
        Destroy(bullet, 1);
        yield return new WaitForSeconds(.5f);
        isShooting = false;
    }

    void Update()
    {
        Debug.DrawRay(spawnPoint.transform.position, spawnPoint.transform.forward, Color.green);
        if (Input.GetButtonDown("Button_X") && !isShooting)
        {
            StartCoroutine("Shoot");
        }
        

        

    }
}
