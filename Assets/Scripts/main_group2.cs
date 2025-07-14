using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class main_group2 : MonoBehaviour
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

    private puzzleManager2 puzzle;

    public main1Is main1is;
    public main2Is main2is;
    public main3Is main3is;
    public main4Is main4is;
    public main5Is main5is;
    public main6Is main6is;
    public main7Is main7is;
    public main8Is main8is;
    public main9Is main9is;

    private main_ctrl2 main1, main2, main3, main4, main5, main6, main7, main8, main9;

    private Button mainReset;

    private bool isExcuted;

    void Start()
    {
        puzzle = GameObject.Find("Canvas").GetComponent<puzzleManager2>();

        main1 = GameObject.Find("main1").GetComponent<main_ctrl2>();
        main2 = GameObject.Find("main2").GetComponent<main_ctrl2>();
        main3 = GameObject.Find("main3").GetComponent<main_ctrl2>();
        main4 = GameObject.Find("main4").GetComponent<main_ctrl2>();
        main5 = GameObject.Find("main5").GetComponent<main_ctrl2>();
        main6 = GameObject.Find("main6").GetComponent<main_ctrl2>();
        main7 = GameObject.Find("main7").GetComponent<main_ctrl2>();
        main8 = GameObject.Find("main8").GetComponent<main_ctrl2>();
        main9 = GameObject.Find("main9").GetComponent<main_ctrl2>();

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
        if (main1is == main1Is.circle
            && main2is == main2Is.triangle
            && main3is == main3Is.ractangle
            && main4is == main4Is.ractangle
            && main5is == main5Is.circle
            && main6is == main6Is.triangle
            && main7is == main7Is.ractangle
            && main8is == main8Is.triangle
            && main9is == main9Is.circle
            && isExcuted)
        {
            // puzzleManager에게 mainDoor 퍼즐 부분 완료라고 전하기(한 번만)
            isExcuted = false;
            puzzle.mainDoorStateOpen();
        }
    }

}

