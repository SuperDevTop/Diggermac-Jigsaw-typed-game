using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public float delay = 0.1f;
    public string currentText = "";
    public string fullText = "";
    public GameObject tapPrompt;
    public Sprite[] sprites;
    public Image image;    
    private float promptTimer;

    int pageCount = 0;
    List<string> diaglogTemp = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        diaglogTemp.Add("BIGGY: Hi, my name is Mr.Biglot and everyone calls me Biggy." + "\n" + "I am so hungry now..." + "\n" + "Could you please give me some bread?");
        diaglogTemp.Add("BIGGY: It's very dielicious." + "\n" + "Would you mind I have some drink?");
        diaglogTemp.Add("SHILLABEER: When I was a child, I had a great time with a long journey." + "\n" + "It was very dangerous and risky." + "\n" + "I really had a great time.");
        diaglogTemp.Add("SHILLABEER: Really sorry." + "\n" + "It's all my fault.");
        diaglogTemp.Add("ALL: Oh, no! The ghost will be angry!");
        diaglogTemp.Add("BIGGY: I'm ok and you are all nice guys." + "\n" + "I'd like to reward something for your favour." + "\n" + "Please give this bag." + "\n" + "But remember! It's very dangerous to open. Remember!");
        writeDialogue(diaglogTemp[pageCount]);
    }

    // Update is called once per frame
    void Update()
    {
        promptTimer += Time.deltaTime * 2;
        tapPrompt.GetComponent<CanvasGroup>().alpha = (1 + Mathf.Sin(promptTimer)) / 2;
    }

    public void NextPageClick()
    {
        pageCount++;
        if (pageCount == 7)
        {
            Application.LoadLevel("Game1");
        }
        else if(pageCount < 7)
        {
            image.sprite = sprites[pageCount];
            writeDialogue(diaglogTemp[pageCount]);            
        }       
    }

    public void SkipButtonClick()
    {
        Application.LoadLevel("Game1");
    }

    public void writeDialogue(string text)
    {
        //List<string> levelDialogue = dialogueMap [currentLevel-1];
        //fullText = levelDialogue [0];
        fullText = text;
        currentText = "";
        StopCoroutine("ShowText");
        StartCoroutine("ShowText");
    }

    public void skipTyping()
    {
        print("skipping typing");
        StopCoroutine("ShowText");
        currentText = fullText;
        this.GetComponent<Text>().text = fullText;
    }

    IEnumerator ShowText()
    {
        for (int i = 0; i <= fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            this.GetComponent<Text>().text = currentText;           
            yield return new WaitForSeconds(delay);
        }
    }
}
