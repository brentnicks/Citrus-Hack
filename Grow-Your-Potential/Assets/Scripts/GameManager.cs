using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int dayNumber = 1;
    public GameObject dayCounter;
    public int currentSeed = 1;
    public GameObject border1, border2, border3, coinCounter;
    public int coins = 5;
    public int seed1 = 0, seed2 = 0, seed3 = 0;
    public Text textSeed1, textSeed2, textSeed3;
    public Planter[] planters;

    private void Start()
    {
        updateCoins();
        updateSeedText();
    }
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
        dayCounter.GetComponent<Text>().text = "Day: " + dayNumber;
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

    public void updateCoins()
    {
        coinCounter.GetComponent<Text>().text = "Coins: " + coins;
    }

    public void updateSeedText()
    {
        textSeed1.text = seed1.ToString();
        textSeed2.text = seed2.ToString();
        textSeed3.text = seed3.ToString();
    }



    public void hatchSeeds()
    {
        foreach (Planter plant in planters)
        {
            plant.hatchEnemy();
        }
    }
}