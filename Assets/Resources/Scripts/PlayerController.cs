using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public GameObject cubeObj;
    public Transform placedObjectParent;
    internal static int addItemMaterial = 0;   //0 = wood, 1 = steel, 2 = brick
    internal static int addItemShape = 0;
    internal static int selectedItemMaterial = 0;
    internal static int selectedItemShape = 0;
    internal static Dictionary<string, int> inventory;
    public GameObject inventoryPanel;
    public GameObject sidebar;
    public bool selected;

    private GameObject heldObject;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(GameData.playerFunds);
        inventory = new Dictionary<string, int>
        {
            {"Cube-Hay", 0 },
            {"Cube-Wood", 0 },
            {"Cube-Metal", 0 },
            {"Rectangle-Hay", 0 },
            {"Rectangle-Wood", 0 },
            {"Rectangle-Metal",  0 },
            {"L-Hay", 0 },
            {"L-Wood", 0 },
            {"L-Metal", 0 },
            {"Hut-Hay", 0 },
            {"Hut-Wood", 0 },
            {"Hut-Metal", 0 },
            {"Triangle-Hay", 0 },
            {"Triangle-Wood", 0 },
            {"Triangle-Metal", 0 },
            {"Sphere-Hay", 0 },
            {"Sphere-Wood", 0 },
            {"Sphere-Metal", 0 }
        };
        //item = Instantiate();
        DrawInventory();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0)) {
            //Debug.Log(selectedItemShape);
            //Debug.Log(GameData.objectMaterials[selectedItemMaterial]);
            //Debug.Log("mouseOnPlayArea: " + GameData.mouseOnPlayArea);
            //Debug.Log("items: " + (inventory[GameData.objectShapes[selectedItemShape] + "-" + GameData.objectMaterials[selectedItemMaterial]]));
            if (GameData.mouseOnPlayArea && inventory[GameData.objectShapes[selectedItemShape] + "-" + GameData.objectMaterials[selectedItemMaterial]] > 0 && heldObject != null)
            {
                GameObject item = Instantiate(GameData.primitives[GameData.objectShapes[selectedItemShape] + "-" + GameData.objectMaterials[selectedItemMaterial]], Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10)), heldObject.transform.rotation, placedObjectParent);
                item.transform.SetPositionAndRotation(new Vector3(item.transform.position.x, item.transform.position.y, -1), item.transform.rotation);
                item.transform.localScale = heldObject.transform.localScale;
                inventory[GameData.objectShapes[selectedItemShape] + "-" + GameData.objectMaterials[selectedItemMaterial]]--;
                DrawInventory();
            }
        }
        if (Input.mouseScrollDelta.y != 0 && heldObject != null)
        {
            heldObject.transform.Rotate(new Vector3(0, 0, Input.mouseScrollDelta.y * 10));
        }

        if(Input.GetKey(KeyCode.Q) && heldObject != null)
        {
            heldObject.transform.Rotate(new Vector3(0, 0, 1));
        }

        if (Input.GetKey(KeyCode.E) && heldObject != null)
        {
            heldObject.transform.Rotate(new Vector3(0, 0, -1));
        }

        if (Input.GetKeyDown(KeyCode.X) && heldObject != null)
        {
            heldObject.transform.localScale = new Vector3(heldObject.transform.localScale.x * -1, heldObject.transform.localScale.y, heldObject.transform.localScale.z);
        }

        if (Input.GetKeyDown(KeyCode.Y) && heldObject != null)
        {
            heldObject.transform.localScale = new Vector3(heldObject.transform.localScale.x, heldObject.transform.localScale.y * -1, heldObject.transform.localScale.z);
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            sidebar.SetActive(!sidebar.activeInHierarchy);
            if (!sidebar.activeInHierarchy)
                GameData.mouseOnPlayArea = true;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Destroy(heldObject);
            heldObject = null;

            GameData.playerFunds = 100;
            inventory.Clear();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            SceneManager.LoadScene("levelSelect");
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit(0);
        }
    }

    public void DrawInventory()
    {
        foreach(Transform t in inventoryPanel.GetComponentInChildren<Transform>())
        {
            Destroy(t.gameObject);
        }
        foreach(KeyValuePair<string, int> item in inventory)
        {
            //Debug.Log(item.Key + " " + item.Value);
            //Debug.Log("Prefabs/Item-" + GameData.objectMap[item.type]);
            if (item.Value > 0)
            {
                //print(item.Key + item.Value);
                GameObject gO = Instantiate(Resources.Load<GameObject>("Prefabs/inventoryImages/" + item.Key), inventoryPanel.transform);
                gO.GetComponentInChildren<TMP_Text>().text = "x" + item.Value.ToString("N0");
            }
        }
    }

    public void InventoryItemSelected()
    {
        //Debug.Log("Hello");

        //Debug.Log(GameData.objectShapes[selectedItemShape] + "-" + GameData.objectMaterials[selectedItemMaterial]);
        if(inventory[GameData.objectShapes[selectedItemShape] + "-" + GameData.objectMaterials[selectedItemMaterial]] > 0)
        {
            if (heldObject != null)
            {
                Destroy(heldObject);
                heldObject = Instantiate(GameData.primitives[GameData.objectShapes[selectedItemShape] + "-" + GameData.objectMaterials[selectedItemMaterial]], Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10)), Quaternion.identity, placedObjectParent);
                StartCoroutine("UpdateHeldObjectPos");
            }
            else
            {
                heldObject = Instantiate(GameData.primitives[GameData.objectShapes[selectedItemShape] + "-" + GameData.objectMaterials[selectedItemMaterial]], Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10)), Quaternion.identity, placedObjectParent);
                StartCoroutine("UpdateHeldObjectPos");
            }
        }
    }

    IEnumerator UpdateHeldObjectPos()
    {
        while(true)
        {
            bool error = false;
            try
            {
                if (inventory[heldObject.name.Replace("(Clone)", "")] <= 0)
                {
                    Destroy(heldObject);
                }
                heldObject.transform.SetPositionAndRotation(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10)), heldObject.transform.rotation);
            }
            catch (MissingReferenceException)
            {
                error = true;
            }
            catch(NullReferenceException)
            {
                error = true;
            }
            if (error) yield return null;
            else yield return new WaitForFixedUpdate();
        }
    }

    public void AddInventoryItem()
    {
        //Debug.Log(inventory[GameData.objectShapes[selectedItemShape] + "-" + GameData.objectMaterials[selectedItemMaterial]]);
        inventory[GameData.objectShapes[addItemShape] + "-" + GameData.objectMaterials[addItemMaterial]]++;
        DrawInventory();
    }


}
