using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddToInventoryButton : MonoBehaviour
{
    Button thisButton;
    // Start is called before the first frame update
    void Start()
    {
        thisButton = GetComponent<Button>();
        thisButton.onClick.AddListener(AddItem);
    }

    private void AddItem()
    {
        GameObject.Find("Player").GetComponent<PlayerController>().AddInventoryItem();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
