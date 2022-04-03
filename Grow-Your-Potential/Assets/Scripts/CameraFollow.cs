using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public bool isFrozen = false;
    private void Update()
    {
        // transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);
        if (!isFrozen){
            transform.position = new Vector3(0, player.transform.position.y, -10);
        }
    }
}
