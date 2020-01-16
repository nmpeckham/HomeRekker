using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    public Button rainforestButton;
    public Button desertButton;
    public Button northPoleButton;
    public Button cityButton;
    public Button mainMenuButton;
    // Start is called before the first frame update
    void Start()
    {
        mainMenuButton.onClick.AddListener(LoadMainMenu);
        rainforestButton.onClick.AddListener(LoadRainforest);
        desertButton.onClick.AddListener(LoadDesert);
        northPoleButton.onClick.AddListener(LoadNorthPole);
        cityButton.onClick.AddListener(LoadCity);
    }

    void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    void LoadRainforest()
    {
        SceneManager.LoadScene("Rainforest Level 1");
    }

    void LoadDesert()
    {
        SceneManager.LoadScene("Desert Level 1");
    }

    void LoadNorthPole()
    {
        SceneManager.LoadScene("North Pole Level 1");
    }

    void LoadCity()
    {
        SceneManager.LoadScene("Urban Level 1");
    }
}
