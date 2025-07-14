using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class main_group : MonoBehaviour
{
    public enum main1Is
    {
        dot,
        ractangle,
        triangle,
        circle
    }
    public enum main2Is
    {
        dot,
        ractangle,
        triangle,
        circle
    }
    public enum main3Is
    {
        dot,
        ractangle,
        triangle,
        circle
    }
    public enum main4Is
    {
        dot,
        ractangle,
        triangle,
        circle
    }
    public enum main5Is
    {
        dot,
        ractangle,
        triangle,
        circle
    }
    public enum main6Is
    {
        dot,
        ractangle,
        triangle,
        circle
    }
    public enum main7Is
    {
        dot,
        ractangle,
        triangle,
        circle
    }
    public enum main8Is
    {
        dot,
        ractangle,
        triangle,
        circle
    }
    public enum main9Is
    {
        dot,
        ractangle,
        triangle,
        circle
    }

    private puzzleManager puzzle;

    public main1Is main1is;
    public main2Is main2is;
    public main3Is main3is;
    public main4Is main4is;
    public main5Is main5is;
    public main6Is main6is;
    public main7Is main7is;
    public main8Is main8is;
    public main9Is main9is;

    private main_ctrl main1, main2, main3, main4, main5, main6, main7, main8, main9;

    private Button mainReset;

    private bool isExcuted;

    void Start()
    {
        puzzle = GameObject.Find("Canvas").GetComponent<puzzleManager>();

        main1 = GameObject.Find("main1").GetComponent<main_ctrl>();
        main2 = GameObject.Find("main2").GetComponent<main_ctrl>();
        main3 = GameObject.Find("main3").GetComponent<main_ctrl>();
        main4 = GameObject.Find("main4").GetComponent<main_ctrl>();
        main5 = GameObject.Find("main5").GetComponent<main_ctrl>();
        main6 = GameObject.Find("main6").GetComponent<main_ctrl>();
        main7 = GameObject.Find("main7").GetComponent<main_ctrl>();
        main8 = GameObject.Find("main8").GetComponent<main_ctrl>();
        main9 = GameObject.Find("main9").GetComponent<main_ctrl>();

        mainReset = GameObject.Find("main_reset").GetComponent<Button>();
        mainReset.onClick.AddListener(() => resetAllMain());

        isExcuted = true;
    }

    private void resetAllMain()
    {
        main1.resetMain();
        main2.resetMain();
        main3.resetMain();
        main4.resetMain();
        main5.resetMain();
        main6.resetMain();
        main7.resetMain();
        main8.resetMain();
        main9.resetMain();
    }

    void Update()
    {
        if (main1is == main1Is.triangle
            && main2is == main2Is.circle
            && main3is == main3Is.triangle
            && main4is == main4Is.circle
            && main5is == main5Is.ractangle
            && main6is == main6Is.ractangle
            && main7is == main7Is.triangle
            && main8is == main8Is.ractangle
            && main9is == main9Is.circle
            && isExcuted)
        {
            // puzzleManager에게 mainDoor 퍼즐 부분 완료라고 전하기(한 번만)
            isExcuted = false;
            puzzle.mainDoorPuzzleOpen();
        }
    }

}
