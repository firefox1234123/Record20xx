using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class handle_ctrl : MonoBehaviour
{
    private puzzleManager2 puzzle;

    private Button handle;
    private Button handleReset;
    private Image handleImage;
    private AudioSource handleAudio;

    private RectTransform rectTrans;
    private int temp;
    private int count;

    void Start()
    {
        puzzle = GameObject.Find("Canvas").GetComponent<puzzleManager2>();

        handle = GameObject.Find("handle").GetComponent<Button>();
        handle.onClick.AddListener(() => changeImage());

        handleReset = GameObject.Find("handle_reset").GetComponent<Button>();
        handleReset.onClick.AddListener(() => resetHandle());

        handleImage = GameObject.Find("handle").GetComponent<Image>();

        handleAudio = GameObject.Find("handle").GetComponent<AudioSource>();

        rectTrans = GameObject.Find("handle").GetComponent<RectTransform>();
    }

    void Update()
    {
        if (count == 8)
        {
            puzzle.pipeStateOpen();
        }
    }

    // handle image change
    private void changeImage()
    {
        handleAudio.Play();

        if (temp == 0) // 기본 상태라면 반 돌리기
        {
            rectTrans.offsetMin = new Vector2(550, 150);
            rectTrans.offsetMax = new Vector2(-550, -250);

            handleImage.sprite = puzzle.getPipeHandleSprite(0);
            temp = 1;
        }
        else if (temp == 1) // 돌아간 상태라면 기본 상태로
        {
            rectTrans.offsetMin = new Vector2(400, 190);
            rectTrans.offsetMax = new Vector2(-400, -300);

            handleImage.sprite = puzzle.getPipeHandleSprite(1);
            temp = 0;
        }
        count++;
    }

    // reset handle count
    private void resetHandle()
    {
        count = 0;
    }
}
