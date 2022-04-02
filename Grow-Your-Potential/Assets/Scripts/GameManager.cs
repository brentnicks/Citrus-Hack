using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int dayNumber = 1;
    public GameObject dayCounter;
    public int currentSeed = 1;
    public GameObject border1, border2, border3;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            changeSeed();
        }
    }
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

    public void changeSeed()
    {
        ++currentSeed;
        if (currentSeed > 3) currentSeed = 1;

        if (currentSeed == 1)
        {
            setWhite(border1);
            setGray(border2);
            setGray(border3);
        }
        else if (currentSeed == 2)
        {
            setGray(border1);
            setWhite(border2);
            setGray(border3);
        }
        else if (currentSeed == 3)
        {
            setGray(border1);
            setGray(border2);
            setWhite(border3);
        }
    }

    void setGray(GameObject border)
    {
        border.GetComponent<Image>().color = Color.gray;
        border.GetComponent<Outline>().enabled = false;
    }

    void setWhite(GameObject border)
    {
        border.GetComponent<Image>().color = Color.white;
        border.GetComponent<Outline>().enabled = true;
    }
}