using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UI;


public class main_ctrl : MonoBehaviour
{
    private main_group mainGroup;
    private puzzleManager puzzle;

    private AudioSource mainAudio;

    private Button main;
    private Image mainImage;

    private string objectName;
    private int temp = 1;

    void Start()
    {
        mainGroup = GameObject.Find("main_group").GetComponent<main_group>();
        puzzle = GameObject.Find("Canvas").GetComponent<puzzleManager>();

        mainAudio = GetComponent<AudioSource>();

        main = GetComponent<Button>();
        main.onClick.AddListener(() => changeSprite());

        mainImage = GetComponent<Image>();

        objectName = gameObject.name;
    }

    private void changeSprite()
    {
        mainAudio.Play();
        switch (temp)
        {
            case 1:
                // dot -> ractangle
                mainImage.sprite = puzzle.getMainButtonSprite(2);
                break;
            case 2:
                // ractangle -> triangle
                mainImage.sprite = puzzle.getMainButtonSprite(3);
                break;
            case 3:
                // triangle -> circle
                mainImage.sprite = puzzle.getMainButtonSprite(0);
                break;
            case 4:
                // circle -> dot
                mainImage.sprite = puzzle.getMainButtonSprite(1);
                break;
            default:
                break;
        }
        mainState(mainImage.sprite.name);

        // 4가지의 도형을 반복해서 띄우도록
        if (temp+1 >= 5)
        {
            // 횟수에 맞게 temp = 1 or temp += 1
            temp = 1;
        }
        else
        {
            temp += 1;
        }
    }

    private void mainState(string sprite)
    {
        switch(objectName)
        {
            case "main1":
                if (sprite == "puzzle_mainKeyPad_dot")
                {
                    mainGroup.main1is = main_group.main1Is.dot;
                } else if (sprite == "puzzle_mainKeyPad_ractangle")
                {
                    mainGroup.main1is = main_group.main1Is.ractangle;
                } else if (sprite == "puzzle_mainKeyPad_triangle")
                {
                    mainGroup.main1is = main_group.main1Is.triangle;
                } else if (sprite == "puzzle_mainKeyPad_circle")
                {
                    mainGroup.main1is = main_group.main1Is.circle;
                }
                break;
            case "main2":
                if (sprite == "puzzle_mainKeyPad_dot")
                {
                    mainGroup.main2is = main_group.main2Is.dot;
                }
                else if (sprite == "puzzle_mainKeyPad_ractangle")
                {
                    mainGroup.main2is = main_group.main2Is.ractangle;
                }
                else if (sprite == "puzzle_mainKeyPad_triangle")
                {
                    mainGroup.main2is = main_group.main2Is.triangle;
                }
                else if (sprite == "puzzle_mainKeyPad_circle")
                {
                    mainGroup.main2is = main_group.main2Is.circle;
                }
                break;
            case "main3":
                if (sprite == "puzzle_mainKeyPad_dot")
                {
                    mainGroup.main3is = main_group.main3Is.dot;
                }
                else if (sprite == "puzzle_mainKeyPad_ractangle")
                {
                    mainGroup.main3is = main_group.main3Is.ractangle;
                }
                else if (sprite == "puzzle_mainKeyPad_triangle")
                {
                    mainGroup.main3is = main_group.main3Is.triangle;
                }
                else if (sprite == "puzzle_mainKeyPad_circle")
                {
                    mainGroup.main3is = main_group.main3Is.circle;
                }
                break;
            case "main4":
                if (sprite == "puzzle_mainKeyPad_dot")
                {
                    mainGroup.main4is = main_group.main4Is.dot;
                }
                else if (sprite == "puzzle_mainKeyPad_ractangle")
                {
                    mainGroup.main4is = main_group.main4Is.ractangle;
                }
                else if (sprite == "puzzle_mainKeyPad_triangle")
                {
                    mainGroup.main4is = main_group.main4Is.triangle;
                }
                else if (sprite == "puzzle_mainKeyPad_circle")
                {
                    mainGroup.main4is = main_group.main4Is.circle;
                }
                break;
            case "main5":
                if (sprite == "puzzle_mainKeyPad_dot")
                {
                    mainGroup.main5is = main_group.main5Is.dot;
                }
                else if (sprite == "puzzle_mainKeyPad_ractangle")
                {
                    mainGroup.main5is = main_group.main5Is.ractangle;
                }
                else if (sprite == "puzzle_mainKeyPad_triangle")
                {
                    mainGroup.main5is = main_group.main5Is.triangle;
                }
                else if (sprite == "puzzle_mainKeyPad_circle")
                {
                    mainGroup.main5is = main_group.main5Is.circle;
                }
                break;
            case "main6":
                if (sprite == "puzzle_mainKeyPad_dot")
                {
                    mainGroup.main6is = main_group.main6Is.dot;
                }
                else if (sprite == "puzzle_mainKeyPad_ractangle")
                {
                    mainGroup.main6is = main_group.main6Is.ractangle;
                }
                else if (sprite == "puzzle_mainKeyPad_triangle")
                {
                    mainGroup.main6is = main_group.main6Is.triangle;
                }
                else if (sprite == "puzzle_mainKeyPad_circle")
                {
                    mainGroup.main6is = main_group.main6Is.circle;
                }
                break;
            case "main7":
                if (sprite == "puzzle_mainKeyPad_dot")
                {
                    mainGroup.main7is = main_group.main7Is.dot;
                }
                else if (sprite == "puzzle_mainKeyPad_ractangle")
                {
                    mainGroup.main7is = main_group.main7Is.ractangle;
                }
                else if (sprite == "puzzle_mainKeyPad_triangle")
                {
                    mainGroup.main7is = main_group.main7Is.triangle;
                }
                else if (sprite == "puzzle_mainKeyPad_circle")
                {
                    mainGroup.main7is = main_group.main7Is.circle;
                }
                break;
            case "main8":
                if (sprite == "puzzle_mainKeyPad_dot")
                {
                    mainGroup.main8is = main_group.main8Is.dot;
                }
                else if (sprite == "puzzle_mainKeyPad_ractangle")
                {
                    mainGroup.main8is = main_group.main8Is.ractangle;
                }
                else if (sprite == "puzzle_mainKeyPad_triangle")
                {
                    mainGroup.main8is = main_group.main8Is.triangle;
                }
                else if (sprite == "puzzle_mainKeyPad_circle")
                {
                    mainGroup.main8is = main_group.main8Is.circle;
                }
                break;
            case "main9":
                if (sprite == "puzzle_mainKeyPad_dot")
                {
                    mainGroup.main9is = main_group.main9Is.dot;
                }
                else if (sprite == "puzzle_mainKeyPad_ractangle")
                {
                    mainGroup.main9is = main_group.main9Is.ractangle;
                }
                else if (sprite == "puzzle_mainKeyPad_triangle")
                {
                    mainGroup.main9is = main_group.main9Is.triangle;
                }
                else if (sprite == "puzzle_mainKeyPad_circle")
                {
                    mainGroup.main9is = main_group.main9Is.circle;
                }
                break;
            default:
                break;
        }
    }

    // 퍼즐 리셋
    public void resetMain()
    {
        // temp reset
        temp = 1;

        // sprite reset
        mainImage.sprite = puzzle.getMainButtonSprite(1);
        mainState(mainImage.sprite.name);
    }
}
