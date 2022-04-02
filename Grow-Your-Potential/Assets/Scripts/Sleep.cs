using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sleep : MonoBehaviour
{
    public GameManager gm;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("sleep");
            gm.removeAllEnemies();
            gm.increaseDayNumber();
        }
    }
}
