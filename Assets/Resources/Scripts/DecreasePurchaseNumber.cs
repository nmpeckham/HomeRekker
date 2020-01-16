using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class DecreasePurchaseNumber : MonoBehaviour
{
    public string type;
    private Button thisButton;
    private TMP_Text numberText;
    private int number = 0;
    // Start is called before the first frame update
    void Start()
    {
        thisButton = GetComponent<Button>();
        thisButton.onClick.AddListener(IncreaseNumber);
        numberText = transform.parent.Find("QuantityToBuy").GetComponent<TMP_Text>();
    }

    void IncreaseNumber()
    {
        number = Convert.ToInt32(numberText.text);
        if(number > 0)
        {
            number--;
            numberText.text = number.ToString();
        }
    }

}
