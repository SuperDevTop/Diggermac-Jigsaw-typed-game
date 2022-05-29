using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayButtonClick()
    {
        Application.LoadLevel("LevelSelect");
    }

    public void CreditButtonClick()
    {
        Application.LoadLevel("Credit");
    }

    public void SettingsButtonClick()
    {
        Application.LoadLevel("Settings");
    }

    public void ExitButtonClick()
    {
        Application.Quit();
    }
}
