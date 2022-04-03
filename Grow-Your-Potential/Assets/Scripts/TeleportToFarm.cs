using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportToFarm : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.position = new Vector3(7, 4, 0);
        }
    }
}
