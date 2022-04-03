using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportToShop : MonoBehaviour
{

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
        GameObject.FindWithTag("Player").transform.position = new Vector3(49, 4.0f, 0);
        GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().enabled = true;
    }
}