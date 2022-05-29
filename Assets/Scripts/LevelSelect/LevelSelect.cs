using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LevelSelect : MonoBehaviour
{
    public static string levelInfo = Application.dataPath + "/levelinfo.txt";
    int levelNumber = 1;

    public Sprite[] activeMap;
    public Sprite[] unactiveMap;
    public Image[] mapImage;
    public Text textInfo;

    // Start is called before the first frame update
    void Start()
    {
        if (!File.Exists(levelInfo))
        {
            File.Create(levelInfo);
            File.WriteAllText(levelInfo, "1");
            levelNumber = 1;
        }
        else
        {
            levelNumber = Int32.Parse(File.ReadAllText(levelInfo));
        }

        switch (levelNumber)
        {
            case 1:
                {
                    mapImage[0].sprite = activeMap[0];
                    mapImage[1].sprite = unactiveMap[0];
                    mapImage[2].sprite = unactiveMap[1];
                    mapImage[3].sprite = unactiveMap[2];
                    break;
                }

            case 2:
                {
                    mapImage[0].sprite = activeMap[0];
                    mapImage[1].sprite = activeMap[1];
                    mapImage[2].sprite = unactiveMap[1];
                    mapImage[3].sprite = unactiveMap[2];
                    break;
                }

            case 3:
                {
                    mapImage[0].sprite = activeMap[0];
                    mapImage[1].sprite = activeMap[1];
                    mapImage[2].sprite = activeMap[2];
                    mapImage[3].sprite = unactiveMap[2];
                    break;
                }

            case 4:
                {
                    mapImage[0].sprite = activeMap[0];
                    mapImage[1].sprite = activeMap[1];
                    mapImage[2].sprite = activeMap[2];
                    mapImage[3].sprite = activeMap[3];
                    break;
                }
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 4; i++)
        {
            if (Vector2.Distance(Input.mousePosition, mapImage[i].gameObject.transform.position) < 74)
            {
                switch (levelNumber)
                {
                    case 1:
                        {
                            if (i == 0)
                            {
                                textInfo.text = "Level Difficulties: Easy" + "\n" + "Find Tom's letter.";
                            }
                            else if (i == 1)
                            {
                                textInfo.text = "Level Difficulties: Normal" + "\n" + "Locked.";
                            }
                            else if (i == 2)
                            {
                                textInfo.text = "Level Difficulties: Hard" + "\n" + "Locked.";
                            }
                            else if (i == 3)
                            {
                                textInfo.text = "Level Difficulties: Insane" + "\n" + "Locked.";
                            }
                            break;
                        }

                    case 2:
                        {
                            if (i == 0)
                            {
                                textInfo.text = "Level Difficulties: Easy" + "\n" + "Find Tom's letter.";
                            }
                            else if (i == 1)
                            {
                                textInfo.text = "Level Difficulties: Normal" + "\n" + "Find Tom's ship.";
                            }
                            else if (i == 2)
                            {
                                textInfo.text = "Level Difficulties: Hard" + "\n" + "Locked.";
                            }
                            else if (i == 3)
                            {
                                textInfo.text = "Level Difficulties: Insane" + "\n" + "Locked.";
                            }
                            break;
                        }

                    case 3:
                        {
                            if (i == 0)
                            {
                                textInfo.text = "Level Difficulties: Easy" + "\n" + "Find Tom's letter.";
                            }
                            else if (i == 1)
                            {
                                textInfo.text = "Level Difficulties: Normal" + "\n" + "Find Tom's ship.";
                            }
                            else if (i == 2)
                            {
                                textInfo.text = "Level Difficulties: Hard" + "\n" + "Find the clothes.";
                            }
                            else if (i == 3)
                            {
                                textInfo.text = "Level Difficulties: Insane" + "\n" + "Locked.";
                            }
                            break;
                        }

                    case 4:
                        {
                            if (i == 0)
                            {
                                textInfo.text = "Level Difficulties: Easy" + "\n" + "Find Tom's letter.";
                            }
                            else if (i == 1)
                            {
                                textInfo.text = "Level Difficulties: Normal" + "\n" + "Find Tom's ship.";
                            }
                            else if (i == 2)
                            {
                                textInfo.text = "Level Difficulties: Hard" + "\n" + "Find the clothes.";
                            }
                            else if (i == 3)
                            {
                                textInfo.text = "Level Difficulties: Insane" + "\n" + "Find the treasure.";
                            }
                            break;
                        }
                }               
            }
        }
    }

    public void PlayEasy()
    {
        Application.LoadLevel("Tutorial");
    }

    public void BackButtonClick()
    {
        Application.LoadLevel("MainMenu");
    }   
}
