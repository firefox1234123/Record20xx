using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class block_group : MonoBehaviour
{
    // 해당 위치에 오브젝트가 있는가를 담아두는 enum
    public enum block4Pos
    {
        on, off
    }
    public enum block13Pos
    {
        on, off
    }
    public enum block14Pos
    {
        on, off
    }
    public enum block22Pos
    {
        on, off
    }

    // 해당 블럭이 옳은 위치에 있는가를 담아두는 enum
    public enum block4State
    {
        no, yes
    }
    public enum block13State
    {
        no, yes
    }
    public enum block14State
    {
        no, yes
    }
    public enum block22State
    {
        no, yes
    }

    private puzzleManager puzzle;

    public block4Pos block4pos = block4Pos.off;
    public block13Pos block13pos = block13Pos.off;
    public block14Pos block14pos = block14Pos.off;
    public block22Pos block22pos = block22Pos.off;

    public block4State block4state = block4State.no;
    public block13State block13state = block13State.no;
    public block14State block14state = block14State.no;
    public block22State block22state = block22State.no;

    private block_ctrl block4, block13, block14, block22;

    private Button blockReset;

    void Start()
    {
        puzzle = GameObject.Find("Canvas").GetComponent<puzzleManager>();

        block4 = GameObject.Find("block4").GetComponent<block_ctrl>();
        block13 = GameObject.Find("block13").GetComponent<block_ctrl>();
        block14 = GameObject.Find("block14").GetComponent<block_ctrl>();
        block22 = GameObject.Find("block22").GetComponent<block_ctrl>();

        blockReset = GameObject.Find("block_reset").GetComponent<Button>();
        blockReset.onClick.AddListener(() => resetBlock());
    }

    void Update()
    {
        if (block4state == block4State.yes
            && block13state == block13State.yes
            && block14state == block14State.yes
            && block22state == block22State.yes)
        {
            puzzle.livRackStateOpen();
        }
    }

    private void resetBlock()
    {
        block4.resetBlock();
        block13.resetBlock();
        block14.resetBlock();
        block22.resetBlock();
    }
}
