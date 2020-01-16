using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ShopItemController : MonoBehaviour
{
    public string type;
    private Button plusButton;
    private Button minusButton;
    private TMP_Text quantityText;
    private TMP_Text priceText;

    private int price;

    private int number = 0;
    // Start is called before the first frame update
    void Start()
    {
        plusButton = transform.Find("Buttons").Find("PlusButton").GetComponent<Button>();
        minusButton = transform.Find("Buttons").Find("MinusButton").GetComponent<Button>();

        plusButton.onClick.AddListener(IncreaseQuantity);
        minusButton.onClick.AddListener(DecreaseQuantity);

        quantityText = transform.Find("Buttons").Find("QuantityToBuy").GetComponent<TMP_Text>();

        priceText = transform.Find(type).Find("Image").Find("PriceLabel").Find("Quantity").GetComponent<TMP_Text>();
        price = GameData.itemPrices[type];

        priceText.text = "$" + price.ToString();

    }

    void IncreaseQuantity()
    {
        if(GameData.playerFunds - price >= 0)
        {
            number++;
            GameData.playerFunds -= price;
            quantityText.text = number.ToString();

            ShopController.UpdateFunds();

            if (PlayerController.inventory.ContainsKey(type))    PlayerController.inventory[type]++;
            else    PlayerController.inventory.Add(type, 1);
        }

    }

    void DecreaseQuantity()
    {
        if (number > 0)
        {
            number--;
            GameData.playerFunds += price;
            PlayerController.inventory.Remove(type);
        }
        quantityText.text = number.ToString();

        
        ShopController.UpdateFunds();
    }
}
