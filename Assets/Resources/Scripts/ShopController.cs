using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopController : MonoBehaviour
{
    private static TMP_Text remainingFundsText;
    private static Button buyButton;

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Desert Level 1") GameData.playerFunds = 30;
        else if (SceneManager.GetActiveScene().name == "Rainforest Level 1") GameData.playerFunds = 70;
        else if (SceneManager.GetActiveScene().name == "North Pole Level 1") GameData.playerFunds = 60;
        else if (SceneManager.GetActiveScene().name == "Urban Level 1") GameData.playerFunds = 135;
        buyButton = transform.Find("BuyPanel").GetComponentInChildren<Button>();
        buyButton.interactable = false;
        buyButton.onClick.AddListener(BuyItems);
        remainingFundsText = transform.Find("Funds Remaining").GetComponentInChildren<TMP_Text>();
        remainingFundsText.text = "Funds Remaining: $" + GameData.playerFunds.ToString();
    }

    public static void UpdateFunds()
    {
        remainingFundsText.text = "Funds Remaining: $" + GameData.playerFunds;
        if (PlayerController.inventory.Count != 0)
        {
            buyButton.interactable = true;
        }
        else buyButton.interactable = false;
    }

    void BuyItems()
    {
        GameObject.Find("Player").GetComponent<PlayerController>().DrawInventory();
        transform.parent.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
