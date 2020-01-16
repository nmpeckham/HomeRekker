using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public Button startButton;
    public Button creditsButton;
    public Button loreButton;
    // Start is called before the first frame update
    void Start()
    {
        startButton.onClick.AddListener(StartGame);
        creditsButton.onClick.AddListener(LoadCredits);
        loreButton.onClick.AddListener(LoadLore);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit(0);
        }
    }

    void LoadLore()
    {
        SceneManager.LoadScene("Lore");
    }

    void StartGame()
    {
        SceneManager.LoadScene("levelSelect");
    }

    void LoadCredits()
    {
        SceneManager.LoadScene("Credits");
    }

}
