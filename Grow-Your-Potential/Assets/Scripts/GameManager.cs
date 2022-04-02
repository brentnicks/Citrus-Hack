using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int dayNumber = 1;
    public GameObject dayCounter;

    public void removeAllEnemies()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }
    }

    public void increaseDayNumber()
    {
        ++dayNumber;
        dayCounter.GetComponent<Text>().text = "Day: " + dayCounter;
    }
}