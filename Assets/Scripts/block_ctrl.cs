using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class block_ctrl : MonoBehaviour, IDragHandler, IEndDragHandler
{
    private enum isFirstPlay
    {
        no, yes
    }
    
    private isFirstPlay isfirstplay = isFirstPlay.yes;

    private puzzleManager puzzle;
    private block_group blockGroup;

    private RectTransform rectTransform;
    private Canvas canvas;
    private AudioSource blockAudio;

    private int snapOffset = 40;

    private GameObject block4Pos;
    private GameObject block13Pos;
    private GameObject block14Pos;
    private GameObject block22Pos;
    private Vector3 originPos;

    private string objectName;

    void Start()
    {
        puzzle = GameObject.Find("Canvas").GetComponent<puzzleManager>();
        blockGroup = GameObject.Find("block_group").GetComponent<block_group>();

        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        blockAudio = GetComponent<AudioSource>();

        block4Pos = GameObject.Find("block4Pos");
        block13Pos = GameObject.Find("block13Pos");
        block14Pos = GameObject.Find("block14Pos");
        block22Pos = GameObject.Find("block22Pos");
        originPos = new Vector3(transform.position.x, transform.position.y, 0);

        objectName = gameObject.name;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        if (isfirstplay == isFirstPlay.yes)
        {
            blockAudio.clip = puzzle.getMagnetSound(0);
            blockAudio.Play();
            isfirstplay = isFirstPlay.no;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        blockAudio.clip = puzzle.getMagnetSound(1);
        blockAudio.Play();
        isfirstplay = isFirstPlay.yes;

        if (Vector3.Distance(block4Pos.transform.position, transform.position) < snapOffset
            && blockGroup.block4pos == block_group.block4Pos.off)
        {
            transform.position = block4Pos.transform.position;
            if (objectName == "block4")
            {
                blockGroup.block4state = block_group.block4State.yes;
            }
            else
            {
                blockGroup.block4state = block_group.block4State.no;
            }

        }
        else if (Vector3.Distance(block13Pos.transform.position, transform.position) < snapOffset
            && blockGroup.block13pos == block_group.block13Pos.off)
        {
            transform.position = block13Pos.transform.position;
            if (objectName == "block13")
            {
                blockGroup.block13state = block_group.block13State.yes;
            }
            else
            {
                blockGroup.block13state = block_group.block13State.no;
            }
        }
        else if (Vector3.Distance(block14Pos.transform.position, transform.position) < snapOffset
            && blockGroup.block14pos == block_group.block14Pos.off)
        {
            transform.position = block14Pos.transform.position;
            if (objectName == "block14")
            {
                blockGroup.block14state = block_group.block14State.yes;
            }
            else
            {
                blockGroup.block14state = block_group.block14State.no;
            }
        }
        else if (Vector3.Distance(block22Pos.transform.position, transform.position) < snapOffset
            && blockGroup.block22pos == block_group.block22Pos.off)
        {
            transform.position = block22Pos.transform.position;
            if (objectName == "block22")
            {
                blockGroup.block22state = block_group.block22State.yes;
            }
            else
            {
                blockGroup.block22state = block_group.block22State.no;
            }
        }
        else
        {
            transform.position = originPos;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "block4Pos")
        {
            blockGroup.block4pos = block_group.block4Pos.on;
        }
        if (other.tag == "block13Pos")
        {
            blockGroup.block13pos = block_group.block13Pos.on;
        }
        if (other.tag == "block14Pos")
        {
            blockGroup.block14pos = block_group.block14Pos.on;
        }
        if (other.tag == "block22Pos")
        {
            blockGroup.block22pos = block_group.block22Pos.on;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "block4Pos")
        {
            blockGroup.block4pos = block_group.block4Pos.off;
        }
        if (other.tag == "block13Pos")
        {
            blockGroup.block13pos = block_group.block13Pos.off;
        }
        if (other.tag == "block14Pos")
        {
            blockGroup.block14pos = block_group.block14Pos.off;
        }
        if (other.tag == "block22Pos")
        {
            blockGroup.block22pos = block_group.block22Pos.off;
        }
    }

    public void resetBlock()
    {
        // block transform reset
        transform.position = originPos;

        // blockState reset
        blockGroup.block4state = block_group.block4State.no;
        blockGroup.block13state = block_group.block13State.no;
        blockGroup.block14state = block_group.block14State.no;
        blockGroup.block22state = block_group.block22State.no;

        // blockPos reset
        blockGroup.block4pos = block_group.block4Pos.off;
        blockGroup.block13pos = block_group.block13Pos.off;
        blockGroup.block14pos = block_group.block14Pos.off;
        blockGroup.block22pos = block_group.block22Pos.off;
    }
}