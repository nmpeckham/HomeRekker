using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TogglePhysics : MonoBehaviour
{
    private Toggle thisToggle;
    // Start is called before the first frame update
    void Start()
    {
        thisToggle = GetComponentInChildren<Toggle>();
        thisToggle.onValueChanged.AddListener(ToggleSwitched);
        Physics2D.autoSimulation = false;
    }

    void ToggleSwitched(bool arg)
    {
        Physics2D.autoSimulation = arg;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
