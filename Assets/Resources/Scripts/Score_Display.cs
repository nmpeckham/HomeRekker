using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Score_Display : MonoBehaviour
{
    public TMP_Text scoretext;
    public int score;
    public int temp = 0;

    public GameObject scorePanel;

    private GameObject Figures;
    // Start is called before the first frame update
    void Start()
    {
        Figures = GameObject.FindWithTag("People");
    }

    public void UpdateScore()
    {
        
        foreach (Figure x in Figures.GetComponentsInChildren<Figure>())
        {
            if (!x._touched)
            {
                score += 100;
            }

        }
        foreach (KeyValuePair<string,int> kvp in PlayerController.inventory)
        {
            if (kvp.Value > 0)
            {
                string key = kvp.Key;
                int cost = GameData.itemPrices[key];
                score += kvp.Value * cost;
            }
        }

        //Debug.Log("Funds: " + GameData.playerFunds);
        score += GameData.playerFunds;

        scorePanel.SetActive(true);
        scoretext.text = "Score: " + score + "\n Press R to Restart \n Press L for Level Select";
    }
}
