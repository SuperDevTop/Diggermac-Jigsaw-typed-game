using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WoodButton : MonoBehaviour
{
    public Text letterText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void letterButtonClick()
    {
        letterText.text += this.name;
    }
}
