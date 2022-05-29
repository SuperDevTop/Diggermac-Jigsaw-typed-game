using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using System.IO;

public class Game1 : MonoBehaviour, IPointerDownHandler, IPointerClickHandler,
    IPointerUpHandler, IPointerExitHandler, IPointerEnterHandler,
    IBeginDragHandler, IDragHandler, IEndDragHandler
{      
    public Image[] moveImages;
    public Image[] patternImages;
    public GameObject part1;
    public GameObject part2;    
    public GameObject part3;
    public GameObject part4;
    public GameObject part5;
    public GameObject part6;
    public GameObject[] page;
    public GameObject[] words;        
    public InputField[] inputFields;
    public Text lettersText;
    
    GameObject moveObject;

    bool isMove;
    bool isPlace;
    int count;
    int matchedCount;
    int wordCount;
    List<String> matchedWords = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        matchedWords.Add("SAY");
        matchedWords.Add("RED");
        matchedWords.Add("OPEN");
        matchedWords.Add("CASE");
        matchedWords.Add("TIMES");
        matchedWords.Add("YELLOW");
    }

    // Update is called once per frame
    void Update()
    {       
        if (isMove)
        {
            moveObject.transform.position = Input.mousePosition;
        }

        if (isPlace)
        {
            moveObject.transform.position = Input.mousePosition;
        }

        if (Input.GetKeyDown("escape"))
        {
            isMove = false;
            isPlace = false;
            moveObject.transform.position = Input.mousePosition;
        }

        if (count == 24)
        {           
            part2.SetActive(false);
            part3.gameObject.SetActive(true);
        }  
    }


    public void MatchButtonClick()
    {
        if (lettersText.text == matchedWords[matchedCount])
        {
            if (matchedCount == 5)
            {
                lettersText.text = "";
                page[matchedCount].SetActive(false);
                part4.SetActive(false);
                part5.SetActive(true);
            }
            else
            {
                lettersText.text = "";
                page[matchedCount].SetActive(false);
                page[matchedCount + 1].SetActive(true);
                matchedCount++;
            }

        }
        else
        {
            lettersText.text = "";
        }        
    }

    public void Part3NextButtonClick()
    {
        count = 0;
        part3.SetActive(false);
        part4.SetActive(true);
    }

    public void Part4NextButtonClick()
    {
        if (wordCount == 6)
        {
            part5.SetActive(false);
            this.GetComponent<Image>().enabled = false;
            part6.SetActive(true);
        }        
    }

    public void Part5NextButtonClick()
    {        
        File.WriteAllText(LevelSelect.levelInfo, "2");
        Application.LoadLevel("LevelSelect");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        
        
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (isMove)
        {
            for (int i = 0; i < patternImages.Length; i++)
            {
                if (Vector2.Distance(Input.mousePosition, patternImages[i].gameObject.transform.position) < 50f)
                {
                    if (patternImages[i].gameObject.name == moveObject.name)
                    {
                        isMove = false;
                        moveObject.SetActive(false);
                        patternImages[i].gameObject.SetActive(true);
                        count++;
                    }                   
                }
            }
        }
        else
        {
            for (int i = 0; i < moveImages.Length; i++)
            {
                if (moveImages[i].gameObject == eventData.pointerCurrentRaycast.gameObject)
                {
                    isMove = true;
                    moveObject = moveImages[i].gameObject;
                }
            }
        }

        if (isPlace)
        {
            for(int i = 0; i < words.Length;i++)
            {
                if (Vector2.Distance(Input.mousePosition, words[i].gameObject.transform.position) < 50f)
                {
                    if (moveObject.tag == words[i].tag)
                    {
                        moveObject.transform.position = new Vector2(-10000, -10000);
                        isPlace = false;
                        words[i].GetComponent<Image>().enabled = true;
                        wordCount++;
                    }
                }
            }
        }
        else
        {
            if (eventData.pointerCurrentRaycast.gameObject.name == "Word")
            {
                isPlace = true;
                moveObject = eventData.pointerCurrentRaycast.gameObject;
            }
        }                     
    }

    public void OnPointerExit(PointerEventData eventData)
    {
       
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        
    }

    public void OnDrag(PointerEventData eventData)
    {
       
    }

    public void OnEndDrag(PointerEventData eventData)
    {
       
    }
}
