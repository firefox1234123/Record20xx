using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class magnet_group : MonoBehaviour
{
    // 해당 위치에 오브젝트가 있는가를 담아두는 enum
    public enum magnetPos1
    {
        on, off
    }
    public enum magnetPos2
    {
        on, off
    }
    public enum magnetPos3
    {
        on, off
    }
    public enum magnetPos4
    {
        on, off
    }
    public enum magnetPos5
    {
        on, off
    }
    public enum magnetPos6
    {
        on, off
    }
    public enum magnetPos7
    {
        on, off
    }

    // 해당 위치에 옳은 오브젝트들이 있는가를 담아두는 enum
    public enum magnetPos1State
    {
        no, yes
    }
    public enum magnetPos2State
    {
        no, yes
    }
    public enum magnetPos3State
    {
        no, yes
    }
    public enum magnetPos4State
    {
        no, yes
    }
    public enum magnetPos5State
    {
        no, yes
    }
    public enum magnetPos6State
    {
        no, yes
    }
    public enum magnetPos7State
    {
        no, yes
    }

    private puzzleManager puzzle;

    public magnetPos1 magnetpos1 = magnetPos1.off;
    public magnetPos2 magnetpos2 = magnetPos2.off;
    public magnetPos3 magnetpos3 = magnetPos3.off;
    public magnetPos4 magnetpos4 = magnetPos4.off;
    public magnetPos5 magnetpos5 = magnetPos5.off;
    public magnetPos6 magnetpos6 = magnetPos6.off;
    public magnetPos7 magnetpos7 = magnetPos7.off;

    public magnetPos1State magnetPos1state = magnetPos1State.no;
    public magnetPos2State magnetPos2state = magnetPos2State.no;
    public magnetPos3State magnetPos3state = magnetPos3State.no;
    public magnetPos4State magnetPos4state = magnetPos4State.no;
    public magnetPos5State magnetPos5state = magnetPos5State.no;
    public magnetPos6State magnetPos6state = magnetPos6State.no;
    public magnetPos7State magnetPos7state = magnetPos7State.no;

    private magnet_ctrl magnet3, magnetPlus, magnet4, magnetMinus, magnet2, magnetEqual, magnet5;

    private Button magnetReset;

    void Start()
    {
        puzzle = GameObject.Find("Canvas").GetComponent<puzzleManager>();

        magnet3 = GameObject.Find("magnet3").GetComponent<magnet_ctrl>();
        magnetPlus = GameObject.Find("magnetPlus").GetComponent<magnet_ctrl>();
        magnet4 = GameObject.Find("magnet4").GetComponent<magnet_ctrl>();
        magnetMinus = GameObject.Find("magnetMinus").GetComponent<magnet_ctrl>();
        magnet2 = GameObject.Find("magnet2").GetComponent<magnet_ctrl>();
        magnetEqual = GameObject.Find("magnetEqual").GetComponent<magnet_ctrl>();
        magnet5 = GameObject.Find("magnet5").GetComponent<magnet_ctrl>();

        magnetReset = GameObject.Find("magnet_reset").GetComponent<Button>();
        magnetReset.onClick.AddListener(() => resetMagnet());
    }

    void Update()
    {
        // 모든 자리에 자석이 붙어있고, 옳은 자리에 있다면 ok
        if (magnetpos1 == magnetPos1.on
            && magnetpos2 == magnetPos2.on
            && magnetpos3 == magnetPos3.on
            && magnetpos4 == magnetPos4.on
            && magnetpos5 == magnetPos5.on
            && magnetpos6 == magnetPos6.on
            && magnetpos7 == magnetPos7.on
            && magnetPos1state == magnetPos1State.yes
            && magnetPos2state == magnetPos2State.yes
            && magnetPos3state == magnetPos3State.yes
            && magnetPos4state == magnetPos4State.yes
            && magnetPos5state == magnetPos5State.yes
            && magnetPos6state == magnetPos6State.yes
            && magnetPos7state == magnetPos7State.yes)
        {
            puzzle.refrigeratorStateOpen();
        }
    }

    private void resetMagnet()
    {
        magnet3.resetMagnet();
        magnetPlus.resetMagnet();
        magnet4.resetMagnet();
        magnetMinus.resetMagnet();
        magnet2.resetMagnet();
        magnetEqual.resetMagnet();
        magnet5.resetMagnet();
    }
}
