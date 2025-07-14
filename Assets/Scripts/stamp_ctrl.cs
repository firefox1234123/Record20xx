using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class stamp_ctrl : MonoBehaviour, IDragHandler, IEndDragHandler, IPointerClickHandler
{
    private enum stamp1Rotate
    {
        degree0, degree90, degree180, degree270
    }
    private enum stamp2Rotate
    {
        degree0, degree90, degree180, degree270
    }
    private enum stamp3Rotate
    {
        degree0, degree90, degree180, degree270
    }
    private enum stamp4Rotate
    {
        degree0, degree90, degree180, degree270
    }
    private enum stamp5Rotate
    {
        degree0, degree90, degree180, degree270
    }

    private enum isDragging
    {
        on, off
    }
    private enum isFirstPlay
    {
        yes, no
    }

    private stamp1Rotate stamp1rotate = stamp1Rotate.degree0;
    private stamp2Rotate stamp2rotate = stamp2Rotate.degree0;
    private stamp3Rotate stamp3rotate = stamp3Rotate.degree0;
    private stamp4Rotate stamp4rotate = stamp4Rotate.degree0;
    private stamp5Rotate stamp5rotate = stamp5Rotate.degree0;

    private isDragging isdragging = isDragging.off;
    private isFirstPlay isfirstplay = isFirstPlay.yes;

    private puzzleManager2 puzzle;
    private stamp_group stampGroup;

    private RectTransform rectTrans;
    private Canvas canvas;
    private AudioSource stampAudio;

    private Image stampImage;

    private GameObject stampPos1, stampPos2, stampPos3, stampPos4;
    private Vector3 originPos;
    private string objectName;

    private int snapOffset = 40;
    private int temp = 1;

    void Start()
    {
        puzzle = GameObject.Find("Canvas").GetComponent<puzzleManager2>();
        stampGroup = GameObject.Find("stamp_group").GetComponent<stamp_group>();

        rectTrans = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        stampAudio = GetComponent<AudioSource>();

        stampImage = gameObject.GetComponent<Image>();

        stampPos1 = GameObject.Find("stampPos1");
        stampPos2 = GameObject.Find("stampPos2");
        stampPos3 = GameObject.Find("stampPos3");
        stampPos4 = GameObject.Find("stampPos4");
        originPos = new Vector3(transform.position.x, transform.position.y, 0);

        objectName = gameObject.name;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (isdragging == isDragging.on)
        {
            return;
        }
        else
        {
            changeSprite();
        }
    }

    private void changeSprite()
    {
        stampAudio.clip = puzzle.getStampSound(1);
        stampAudio.Play();

        switch (temp)
        {
            case 1:

                if (objectName == "stamp1")
                {
                    rectTrans.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 52);
                    rectTrans.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 33);
                    stampImage.sprite = puzzle.getStampSprite(1);
                    stamp1rotate = stamp1Rotate.degree90;
                }
                else if (objectName == "stamp2")
                {
                    rectTrans.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 33);
                    rectTrans.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 52);
                    stampImage.sprite = puzzle.getStampSprite(2);
                    stamp2rotate = stamp2Rotate.degree180;
                }
                else if (objectName == "stamp3")
                {
                    rectTrans.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 52);
                    rectTrans.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 33);
                    stampImage.sprite = puzzle.getStampSprite(3);
                    stamp3rotate = stamp3Rotate.degree270;
                }
                else if (objectName == "stamp4")
                {
                    rectTrans.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 33);
                    rectTrans.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 52);
                    stampImage.sprite = puzzle.getStampSprite(0);
                    stamp4rotate = stamp4Rotate.degree0;
                }
                else if (objectName == "stamp5")
                {
                    rectTrans.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 52);
                    rectTrans.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 33);
                    stampImage.sprite = puzzle.getStampSprite(13);
                    stamp5rotate = stamp5Rotate.degree90;
                }
                else
                {
                    Debug.LogError("stamp sprite change error");
                }
                break;
            case 2:

                if (objectName == "stamp1")
                {
                    rectTrans.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 33);
                    rectTrans.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 52);
                    stampImage.sprite = puzzle.getStampSprite(2);
                    stamp1rotate = stamp1Rotate.degree180;
                }
                else if (objectName == "stamp2")
                {
                    rectTrans.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 52);
                    rectTrans.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 33);
                    stampImage.sprite = puzzle.getStampSprite(3);
                    stamp2rotate = stamp2Rotate.degree270;
                }
                else if (objectName == "stamp3")
                {
                    rectTrans.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 33);
                    rectTrans.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 52);
                    stampImage.sprite = puzzle.getStampSprite(0);
                    stamp3rotate = stamp3Rotate.degree0;
                }
                else if (objectName == "stamp4")
                {
                    rectTrans.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 52);
                    rectTrans.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 33);
                    stampImage.sprite = puzzle.getStampSprite(1);
                    stamp4rotate = stamp4Rotate.degree90;
                }
                else if (objectName == "stamp5")
                {
                    rectTrans.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 33);
                    rectTrans.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 52);
                    stampImage.sprite = puzzle.getStampSprite(14);
                    stamp5rotate = stamp5Rotate.degree180;
                }
                else
                {
                    Debug.LogError("stamp sprite change error");
                }
                break;
            case 3:

                if (objectName == "stamp1")
                {
                    rectTrans.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 52);
                    rectTrans.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 33);
                    stampImage.sprite = puzzle.getStampSprite(3);
                    stamp1rotate = stamp1Rotate.degree270;
                }
                else if (objectName == "stamp2")
                {
                    rectTrans.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 33);
                    rectTrans.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 52);
                    stampImage.sprite = puzzle.getStampSprite(0);
                    stamp2rotate = stamp2Rotate.degree0;
                }
                else if (objectName == "stamp3")
                {
                    rectTrans.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 52);
                    rectTrans.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 33);
                    stampImage.sprite = puzzle.getStampSprite(1);
                    stamp3rotate = stamp3Rotate.degree90;
                }
                else if (objectName == "stamp4")
                {
                    rectTrans.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 33);
                    rectTrans.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 52);
                    stampImage.sprite = puzzle.getStampSprite(2);
                    stamp4rotate = stamp4Rotate.degree180;
                }
                else if (objectName == "stamp5")
                {
                    rectTrans.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 52);
                    rectTrans.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 33);
                    stampImage.sprite = puzzle.getStampSprite(15);
                    stamp5rotate = stamp5Rotate.degree270;
                }
                else
                {
                    Debug.LogError("stamp sprite change error");
                }
                break;
            case 4:

                if (objectName == "stamp1")
                {
                    rectTrans.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 33);
                    rectTrans.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 52);
                    stampImage.sprite = puzzle.getStampSprite(0);
                    stamp1rotate = stamp1Rotate.degree0;
                }
                else if (objectName == "stamp2")
                {
                    rectTrans.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 52);
                    rectTrans.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 33);
                    stampImage.sprite = puzzle.getStampSprite(1);
                    stamp2rotate = stamp2Rotate.degree90;
                }
                else if (objectName == "stamp3")
                {
                    rectTrans.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 33);
                    rectTrans.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 52);
                    stampImage.sprite = puzzle.getStampSprite(2);
                    stamp3rotate = stamp3Rotate.degree180;
                }
                else if (objectName == "stamp4")
                {
                    rectTrans.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 52);
                    rectTrans.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 33);
                    stampImage.sprite = puzzle.getStampSprite(3);
                    stamp4rotate = stamp4Rotate.degree270;
                }
                else if (objectName == "stamp5")
                {
                    rectTrans.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 33);
                    rectTrans.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 52);
                    stampImage.sprite = puzzle.getStampSprite(12);
                    stamp5rotate = stamp5Rotate.degree0;
                }
                else
                {
                    Debug.LogError("stamp sprite change error");
                }
                break;
            default:
                break;
        }

        if (temp + 1 >= 5)
        {
            temp = 1;
        }
        else
        {
            temp += 1;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        isdragging = isDragging.on;
        rectTrans.anchoredPosition += eventData.delta / canvas.scaleFactor;
        if (isfirstplay == isFirstPlay.yes)
        {
            stampAudio.clip = puzzle.getStampSound(0);
            stampAudio.Play();
            isfirstplay = isFirstPlay.no;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isdragging = isDragging.off;
        stampAudio.clip = puzzle.getStampSound(1);
        stampAudio.Play();
        isfirstplay = isFirstPlay.yes;

        if (Vector3.Distance(stampPos1.transform.position, transform.position) < snapOffset
            && stampGroup.stamppos1 == stamp_group.stampPos1.off)
        {
            transform.position = stampPos1.transform.position;
            // 1번 자리는 1~4 다 ok
            if ((objectName == "stamp1" && stamp1rotate == stamp1Rotate.degree0)
                || (objectName == "stamp2" && stamp2rotate == stamp2Rotate.degree0)
                || (objectName == "stamp3" && stamp3rotate == stamp3Rotate.degree0)
                || (objectName == "stamp4" && stamp4rotate == stamp4Rotate.degree0))
            {
                stampGroup.stampstate1 = stamp_group.stampState1.yes;
            }
            else
            {
                stampGroup.stampstate1 = stamp_group.stampState1.no;
            }
        }
        else if (Vector3.Distance(stampPos2.transform.position, transform.position) < snapOffset
            && stampGroup.stamppos2 == stamp_group.stampPos2.off)
        {
            transform.position = stampPos2.transform.position;
            // 2번 자리도 1~4 다 ok
            if ((objectName == "stamp1" && stamp1rotate == stamp1Rotate.degree0)
                || (objectName == "stamp2" && stamp2rotate == stamp2Rotate.degree0)
                || (objectName == "stamp3" && stamp3rotate == stamp3Rotate.degree0)
                || (objectName == "stamp4" && stamp4rotate == stamp4Rotate.degree0))
            {
                stampGroup.stampstate2 = stamp_group.stampState2.yes;
            }
            else
            {
                stampGroup.stampstate2 = stamp_group.stampState2.no;
            }
        }
        else if (Vector3.Distance(stampPos3.transform.position, transform.position) < snapOffset
            && stampGroup.stamppos3 == stamp_group.stampPos3.off)
        {
            transform.position = stampPos3.transform.position;
            // 3번 자리도 1~4 다 ok
            if ((objectName == "stamp1" && stamp1rotate == stamp1Rotate.degree0)
                || (objectName == "stamp2" && stamp2rotate == stamp2Rotate.degree0)
                || (objectName == "stamp3" && stamp3rotate == stamp3Rotate.degree0)
                || (objectName == "stamp4" && stamp4rotate == stamp4Rotate.degree0))
            {
                stampGroup.stampstate3 = stamp_group.stampState3.yes;
            }
            else
            {
                stampGroup.stampstate3 = stamp_group.stampState3.no;
            }
        }
        else if (Vector3.Distance(stampPos4.transform.position, transform.position) < snapOffset
            && stampGroup.stamppos4 == stamp_group.stampPos4.off)
        {
            transform.position = stampPos4.transform.position;
            // 4번 자리는 5만 ok
            if (objectName == "stamp5" && stamp5rotate == stamp5Rotate.degree180)
            {
                stampGroup.stampstate4 = stamp_group.stampState4.yes;
            }
            else
            {
                stampGroup.stampstate4 = stamp_group.stampState4.no;
            }
        }
        else
        {
            // 아무데나 붙어도 ok
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "stampPos1")
        {
            stampGroup.stamppos1 = stamp_group.stampPos1.on;
        }
        else if (other.tag == "stampPos2")
        {
            stampGroup.stamppos2 = stamp_group.stampPos2.on;
        }
        else if (other.tag == "stampPos3")
        {
            stampGroup.stamppos3 = stamp_group.stampPos3.on;
        }
        else if (other.tag == "stampPos4")
        {
            stampGroup.stamppos4 = stamp_group.stampPos4.on;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "stampPos1")
        {
            stampGroup.stamppos1 = stamp_group.stampPos1.off;
        }
        else if (other.tag == "stampPos2")
        {
            stampGroup.stamppos2 = stamp_group.stampPos2.off;
        }
        else if (other.tag == "stampPos3")
        {
            stampGroup.stamppos3 = stamp_group.stampPos3.off;
        }
        else if (other.tag == "stampPos4")
        {
            stampGroup.stamppos4 = stamp_group.stampPos4.off;
        }
    }

    public void resetStamp()
    {
        // stamp position reset
        transform.position = originPos;

        // stamp rotation reset
        if (objectName == "stamp1")
        {
            rectTrans.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 33);
            rectTrans.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 52);
            stampImage.sprite = puzzle.getStampSprite(0);
            stamp1rotate = stamp1Rotate.degree0;
        }
        else if (objectName == "stamp2")
        {
            rectTrans.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 52);
            rectTrans.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 33);
            stampImage.sprite = puzzle.getStampSprite(0);
            stamp2rotate = stamp2Rotate.degree90;
        }
        else if (objectName == "stamp3")
        {
            rectTrans.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 33);
            rectTrans.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 52);
            stampImage.sprite = puzzle.getStampSprite(0);
            stamp3rotate = stamp3Rotate.degree180;
        }
        else if (objectName == "stamp4")
        {
            rectTrans.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 52);
            rectTrans.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 33);
            stampImage.sprite = puzzle.getStampSprite(0);
            stamp4rotate = stamp4Rotate.degree270;
        }
        else if (objectName == "stamp5")
        {
            rectTrans.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 33);
            rectTrans.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 52);
            stampImage.sprite = puzzle.getStampSprite(12);
            stamp5rotate = stamp5Rotate.degree0;
        }

        // temp reset
        temp = 1;

        // stampState reset
        stampGroup.stampstate1 = stamp_group.stampState1.no;
        stampGroup.stampstate2 = stamp_group.stampState2.no;
        stampGroup.stampstate3 = stamp_group.stampState3.no;
        stampGroup.stampstate4 = stamp_group.stampState4.no;

        // stampPos reset
        stampGroup.stamppos1 = stamp_group.stampPos1.off;
        stampGroup.stamppos2 = stamp_group.stampPos2.off;
        stampGroup.stamppos3 = stamp_group.stampPos3.off;
        stampGroup.stamppos4 = stamp_group.stampPos4.off;
    }
}
