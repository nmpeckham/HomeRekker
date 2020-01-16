using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectItemButtonController : MonoBehaviour
{
    private Button thisButton;
    public int itemShape;
    public int itemMaterial;
    // Start is called before the first frame update
    void Start()
    {
        thisButton = GetComponent<Button>();
        thisButton.onClick.AddListener(ItemSelected);       //Test
    }

    void ItemSelected()
    {
        if(itemShape >= 0) PlayerController.addItemShape = itemShape;
        else PlayerController.addItemMaterial = itemMaterial;
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
