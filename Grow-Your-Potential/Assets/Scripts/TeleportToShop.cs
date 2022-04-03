using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportToShop : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.position = new Vector3(49, 5.5f, 0);
        }
    }
}
