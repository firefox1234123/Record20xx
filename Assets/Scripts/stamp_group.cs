using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stamp_group : MonoBehaviour
{
    // 해당 위치에 오브젝트가 있는가를 담아두는 enum
    public enum stampPos1
    {
        on, off
    }
    public enum stampPos2
    {
        on, off
    }
    public enum stampPos3
    {
        on, off
    }
    public enum stampPos4
    {
        on, off
    }

    // 해당 위치에 옳은 블럭이 있는가를 담아두는 enum
    public enum stampState1
    {
        yes, no
    }
    public enum stampState2
    {
        yes, no
    }
    public enum stampState3
    {
        yes, no
    }
    public enum stampState4
    {
        yes, no
    }

    private puzzleManager2 puzzle;

    public stampPos1 stamppos1 = stampPos1.off;
    public stampPos2 stamppos2 = stampPos2.off;
    public stampPos3 stamppos3 = stampPos3.off;
    public stampPos4 stamppos4 = stampPos4.off;

    public stampState1 stampstate1 = stampState1.no;
    public stampState2 stampstate2 = stampState2.no;
    public stampState3 stampstate3 = stampState3.no;
    public stampState4 stampstate4 = stampState4.no;

    private stamp_ctrl stamp1, stamp2, stamp3, stamp4, stamp5;

    private Button stampReset;

    void Start()
    {
        puzzle = GameObject.Find("Canvas").GetComponent<puzzleManager2>();

        stamp1 = GameObject.Find("stamp1").GetComponent<stamp_ctrl>();
        stamp2 = GameObject.Find("stamp2").GetComponent<stamp_ctrl>();
        stamp3 = GameObject.Find("stamp3").GetComponent<stamp_ctrl>();
        stamp4 = GameObject.Find("stamp4").GetComponent<stamp_ctrl>();
        stamp5 = GameObject.Find("stamp5").GetComponent<stamp_ctrl>();

        stampReset = GameObject.Find("stamp_reset").GetComponent<Button>();
        stampReset.onClick.AddListener(() => resetStamp());
    }

    void Update()
    {
        // 모든 자리에 스탬프가 존재하고, 옳은 자리에 있다면 ok
        if (stamppos1 == stampPos1.on
            && stamppos2 == stampPos2.on
            && stamppos3 == stampPos3.on
            && stamppos4 == stampPos4.on
            && stampstate1 == stampState1.yes
            && stampstate2 == stampState2.yes
            && stampstate3 == stampState3.yes
            && stampstate4 == stampState4.yes)
        {
            puzzle.jangttokttaeStateOpen();
        }
    }

    private void resetStamp()
    {
        stamp1.resetStamp();
        stamp2.resetStamp();
        stamp3.resetStamp();
        stamp4.resetStamp();
        stamp5.resetStamp();
    }
}
