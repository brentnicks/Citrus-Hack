using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Vector3 teleportLocation;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Invoke("teleportPlayer", 0.25f);
            collision.gameObject.GetComponent<PlayerMovement>().enabled = false;
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }
    }

    private void teleportPlayer()
    {
        GameObject.FindWithTag("Player").transform.position = teleportLocation;
        GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().enabled = true;
        GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");
        camera.transform.position = new Vector3(teleportLocation.x, teleportLocation.y, -10);
        CameraFollow cf = camera.GetComponent<CameraFollow>();
        cf.isFrozen = !cf.isFrozen;
        Debug.Log(cf.isFrozen);
    }
}