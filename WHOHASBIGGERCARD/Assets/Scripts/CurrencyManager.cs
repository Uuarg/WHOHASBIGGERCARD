using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyManager : MonoBehaviour
{
    public static CurrencyManager Instance;
    public int coins;
    public TMP_Text coinsText;
    public float coinRate = 0.05f;
    public int rateIncrRate = 5;
    private void Awake()
    {
        Instance = this;
        if (PlayerPrefs.HasKey("Coins"))
        {
            coins = PlayerPrefs.GetInt("Coins");
        }
        else
        {
            coins = 100000;
            PlayerPrefs.SetInt("Coins", coins);
        }
        coinsText.text = coins.ToString("N0");

        // packs State


    }

    public void PackInit()
    {
        if (PlayerPrefs.HasKey("pack1"))
        {
            if (PlayerPrefs.GetInt("pack1") == 1)
            {
                DisablePack(GameObject.Find("CardPack1").GetComponent<Button>());
            }
            else
            {
                GameObject.Find("CardPack1").GetComponent<Button>().interactable = true;
            }
        }
        else
        {
            PlayerPrefs.SetInt("pack1", 0);
        }
        // similary for pack2 and pack3
        if (PlayerPrefs.HasKey("pack2"))
        {
            if (PlayerPrefs.GetInt("pack2") == 1)
            {
                DisablePack(GameObject.Find("CardPack2").GetComponent<Button>());
            }
            else
            {
                GameObject.Find("CardPack2").GetComponent<Button>().interactable = true;
            }
        }
        else
        {
            PlayerPrefs.SetInt("pack2", 0);
        }
        if (PlayerPrefs.HasKey("pack3"))
        {
            if (PlayerPrefs.GetInt("pack3") == 1)
            {
                DisablePack(GameObject.Find("CardPack3").GetComponent<Button>());
            }
            else
            {
                GameObject.Find("CardPack3").GetComponent<Button>().interactable = true;
            }
        }
        else
        {
            PlayerPrefs.SetInt("pack3", 0);
        }
    }
    public void UpdateCoins(int newCoins)
    {
        // start the coroutine UpdateCoinsRoutine with the newCoins
        StartCoroutine(UpdateCoinsRoutine(newCoins));
    }
    private IEnumerator UpdateCoinsRoutine(int newCoins)
    {
        // increase the coins by the newCoins with rate coinRate using a while loop
        int oldCoins = coins;
        while (coins < oldCoins + newCoins + rateIncrRate)
        {
            coins += rateIncrRate;
            coinsText.text = coins.ToString("N0");
            // wait for coinRate seconds
            yield return new WaitForSeconds(coinRate);
        }
        coins = oldCoins + newCoins;
        coinsText.text = coins.ToString("N0");
        PlayerPrefs.SetInt("Coins", coins);
    }

    public void BuyCardPack(int packValue)
    {
        if (packValue > coins)
        {
            Debug.Log("Not enough coins");
            return;
        }
        UpdateCoins(-packValue);
    }

    public void DisablePack(Button button)
    {
        button.interactable = false;
        button.transform.GetChild(0).GetComponent<TMP_Text>().text = "Purchased";
        if (button.name == "CardPack1")
        {
            PlayerPrefs.SetInt("pack1", 1);
        }
        else if (button.name == "CardPack2")
        {
            PlayerPrefs.SetInt("pack2", 1);
        }
        else if (button.name == "CardPack3")
        {
            PlayerPrefs.SetInt("pack3", 1);
        }
    }
}
