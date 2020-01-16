using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddItemButtonController : MonoBehaviour
{
    Button thisButton;

    public int shape;
    public int material; 

    // Start is called before the first frame update
    void Start()
    {
        thisButton = GetComponent<Button>();
        thisButton.onClick.AddListener(AddItem);
    }

    void AddItem()
    {
        PlayerController.selectedItemMaterial = material;
        PlayerController.selectedItemShape = shape;
        GameObject.Find("Player").GetComponent<PlayerController>().InventoryItemSelected();
    }

}
