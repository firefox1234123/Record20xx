using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class magnet_ctrl : MonoBehaviour, IDragHandler, IEndDragHandler ,IPointerClickHandler
{
    private enum magnet3Rotate
    {
        degree0, degree90, degree180, degree270
    }
    private enum magnet4Rotate
    {
        degree0, degree90, degree180, degree270
    }
    private enum magnetMinusRotate
    {
        degree0, degree90, degree180, degree270
    }
    private enum magnet2Rotate
    {
        degree0, degree90, degree180, degree270
    }
    private enum magnetEqualRotate
    {
        degree0, degree90, degree180, degree270
    }
    private enum magnet5Rotate
    {
        degree0, degree90, degree180, degree270
    }

    private enum isDragging
    {
        on, off
    }
    private enum isFirstPlay
    {
        no, yes
    }

    private magnet_group magnetGroup;
    private puzzleManager puzzle;

    private Canvas canvas;
    private AudioSource magnetAudio;

    private magnet3Rotate magnet3rotate = magnet3Rotate.degree0;
    private magnet4Rotate magnet4rotate = magnet4Rotate.degree0;
    private magnetMinusRotate magnetMinusrotate = magnetMinusRotate.degree0;
    private magnet2Rotate magnet2rotate = magnet2Rotate.degree0;
    private magnetEqualRotate magnetEqualrotate = magnetEqualRotate.degree0;
    private magnet5Rotate magnet5rotate = magnet5Rotate.degree0;

    private isDragging isdragging = isDragging.off;
    private isFirstPlay isfirstplay = isFirstPlay.yes;

    private Image magnetImage;

    private GameObject magnetPos1;
    private GameObject magnetPos2; 
    private GameObject magnetPos3; 
    private GameObject magnetPos4; 
    private GameObject magnetPos5;
    private GameObject magnetPos6; 
    private GameObject magnetPos7; 

    private string objectName;
    private RectTransform rectTrans;
    private Vector3 originPos;

    private int snapOffset = 30;
    private int temp = 1; // 스프라이트 반복 변경을 위한 변수

    void Start()
    {
        magnetGroup = GameObject.Find("magnet_group").GetComponent<magnet_group>();
        puzzle = GameObject.Find("Canvas").GetComponent<puzzleManager>();

        //rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        magnetAudio = GetComponent<AudioSource>();

        magnetImage = gameObject.GetComponent<Image>();

        magnetPos1 = GameObject.Find("magnetPos1");
        magnetPos2 = GameObject.Find("magnetPos2");
        magnetPos3 = GameObject.Find("magnetPos3");
        magnetPos4 = GameObject.Find("magnetPos4");
        magnetPos5 = GameObject.Find("magnetPos5");
        magnetPos6 = GameObject.Find("magnetPos6");
        magnetPos7 = GameObject.Find("magnetPos7");

        originPos = new Vector3(transform.position.x, transform.position.y, 0);

        objectName = gameObject.name;
        rectTrans = gameObject.GetComponent<RectTransform>();
    }

    // 자석 클릭 이벤트
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

    // 자석 스프라이트 변경
    private void changeSprite()
    {
        magnetAudio.clip = puzzle.getMagnetSound(1);
        magnetAudio.Play();
        switch (temp)
        {
            case 1:
                // 오브젝트 크기 변경하고
                rectTrans.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 100);
                rectTrans.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 80);
                // 0도 -> 90도 이미지로
                if (objectName == "magnet3")
                {
                    magnetImage.sprite = puzzle.getMagnetSprite(5);
                    magnet3rotate = magnet3Rotate.degree90;
                }
                else if (objectName == "magnetPlus")
                {
                    rectTrans.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 80);
                    magnetImage.sprite = puzzle.getMagnetSprite(29);
                }
                else if (objectName == "magnet4")
                {
                    magnetImage.sprite = puzzle.getMagnetSprite(9);
                    magnet4rotate = magnet4Rotate.degree90;
                }
                else if (objectName == "magnetMinus")
                {
                    rectTrans.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 80);
                    rectTrans.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 20);
                    magnetImage.sprite = puzzle.getMagnetSprite(25);
                    magnetMinusrotate = magnetMinusRotate.degree90;
                }
                else if (objectName == "magnet2")
                {
                    magnetImage.sprite = puzzle.getMagnetSprite(1);
                    magnet2rotate = magnet2Rotate.degree90;
                }
                else if (objectName == "magnetEqual")
                {
                    rectTrans.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 60);
                    rectTrans.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 70);
                    magnetImage.sprite = puzzle.getMagnetSprite(21);
                    magnetEqualrotate = magnetEqualRotate.degree90;
                }
                else if (objectName == "magnet5")
                {
                    magnetImage.sprite = puzzle.getMagnetSprite(13);
                    magnet5rotate = magnet5Rotate.degree90;
                }
                else
                {
                    Debug.Log("magnet sprite change error;");
                }
                break;
            case 2:
                // 오브젝트 크기 변경하고
                rectTrans.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 80);
                rectTrans.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 100);
                // 90도 -> 180도 이미지로
                if (objectName == "magnet3")
                {
                    magnetImage.sprite = puzzle.getMagnetSprite(6);
                    magnet3rotate = magnet3Rotate.degree180;
                }
                else if (objectName == "magnetPlus")
                {
                    rectTrans.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 80);
                    magnetImage.sprite = puzzle.getMagnetSprite(30);
                }
                else if (objectName == "magnet4")
                {
                    magnetImage.sprite = puzzle.getMagnetSprite(10);
                    magnet4rotate = magnet4Rotate.degree180;
                }
                else if (objectName == "magnetMinus")
                {
                    rectTrans.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 20);
                    rectTrans.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 80);
                    magnetImage.sprite = puzzle.getMagnetSprite(26);
                    magnetMinusrotate = magnetMinusRotate.degree180;
                }
                else if (objectName == "magnet2")
                {
                    magnetImage.sprite = puzzle.getMagnetSprite(2);
                    magnet2rotate = magnet2Rotate.degree180;
                }
                else if (objectName == "magnetEqual")
                {
                    rectTrans.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 70);
                    rectTrans.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 60);
                    magnetImage.sprite = puzzle.getMagnetSprite(22);
                    magnetEqualrotate = magnetEqualRotate.degree180;
                }
                else if (objectName == "magnet5")
                {
                    magnetImage.sprite = puzzle.getMagnetSprite(14);
                    magnet5rotate = magnet5Rotate.degree180;
                }
                else
                {
                    Debug.Log("magnet sprite change error;");
                }
                break;
            case 3:
                // 오브젝트 크기 변경하고
                rectTrans.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 100);
                rectTrans.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 80);
                // 180도 -> 270도 이미지로
                if (objectName == "magnet3")
                {
                    magnetImage.sprite = puzzle.getMagnetSprite(7);
                    magnet3rotate = magnet3Rotate.degree270;
                }
                else if (objectName == "magnetPlus")
                {
                    rectTrans.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 80);
                    magnetImage.sprite = puzzle.getMagnetSprite(31);
                }
                else if (objectName == "magnet4")
                {
                    magnetImage.sprite = puzzle.getMagnetSprite(11);
                    magnet4rotate = magnet4Rotate.degree270;
                }
                else if (objectName == "magnetMinus")
                {
                    rectTrans.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 80);
                    rectTrans.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 20);
                    magnetImage.sprite = puzzle.getMagnetSprite(27);
                    magnetMinusrotate = magnetMinusRotate.degree270;
                }
                else if (objectName == "magnet2")
                {
                    magnetImage.sprite = puzzle.getMagnetSprite(3);
                    magnet2rotate = magnet2Rotate.degree270;
                }
                else if (objectName == "magnetEqual")
                {
                    rectTrans.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 60);
                    rectTrans.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 70);
                    magnetImage.sprite = puzzle.getMagnetSprite(23);
                    magnetEqualrotate = magnetEqualRotate.degree270;
                }
                else if (objectName == "magnet5")
                {
                    magnetImage.sprite = puzzle.getMagnetSprite(15);
                    magnet5rotate = magnet5Rotate.degree270;
                }
                else
                {
                    Debug.Log("magnet sprite change error;");
                }
                break;
            case 4:
                // 오브젝트 크기 변경하고
                rectTrans.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 80);
                rectTrans.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 100);
                // 270도 -> 0도 이미지로
                if (objectName == "magnet3")
                {
                    magnetImage.sprite = puzzle.getMagnetSprite(4);
                    magnet3rotate = magnet3Rotate.degree0;
                }
                else if (objectName == "magnetPlus")
                {
                    rectTrans.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 80);
                    magnetImage.sprite = puzzle.getMagnetSprite(28);
                }
                else if (objectName == "magnet4")
                {
                    magnetImage.sprite = puzzle.getMagnetSprite(8);
                    magnet4rotate = magnet4Rotate.degree0;
                }
                else if (objectName == "magnetMinus")
                {
                    rectTrans.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 20);
                    rectTrans.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 80);
                    magnetImage.sprite = puzzle.getMagnetSprite(24);
                    magnetMinusrotate = magnetMinusRotate.degree0;
                }
                else if (objectName == "magnet2")
                {
                    magnetImage.sprite = puzzle.getMagnetSprite(0);
                    magnet2rotate = magnet2Rotate.degree0;
                }
                else if (objectName == "magnetEqual")
                {
                    rectTrans.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 70);
                    rectTrans.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 60);
                    magnetImage.sprite = puzzle.getMagnetSprite(20);
                    magnetEqualrotate = magnetEqualRotate.degree0;
                }
                else if (objectName == "magnet5")
                {
                    magnetImage.sprite = puzzle.getMagnetSprite(12);
                    magnet5rotate = magnet5Rotate.degree0;
                }
                else
                {
                    Debug.Log("magnet sprite change error;");
                }
                break;
            default:
                break;
        }

        // 4가지의 도형을 반복해서 띄우도록
        if (temp + 1 >= 5)
        {
            // 횟수에 맞게 temp = 1 or temp += 1
            temp = 1;
        }
        else
        {
            temp += 1;
        }
    }

    //오브젝트 드래그 중
    public void OnDrag(PointerEventData eventData)
    {
        isdragging = isDragging.on;
        rectTrans.anchoredPosition += eventData.delta / canvas.scaleFactor;
        if (isfirstplay == isFirstPlay.yes)
        {
            magnetAudio.clip = puzzle.getMagnetSound(0);
            magnetAudio.Play();
            isfirstplay = isFirstPlay.no;
        }
    }

    // 오브젝트 드래그 끝
    public void OnEndDrag(PointerEventData eventData)
    {
        isdragging = isDragging.off;
        magnetAudio.clip = puzzle.getMagnetSound(1);
        magnetAudio.Play();
        isfirstplay = isFirstPlay.yes;

        if (Vector3.Distance(magnetPos1.transform.position, transform.position) < snapOffset
            && magnetGroup.magnetpos1 == magnet_group.magnetPos1.off)
        {
            transform.position = magnetPos1.transform.position;
            // 1번 자리는 3이나 4가 붙어있으면 ok 
            if ((objectName == "magnet3" && magnet3rotate == magnet3Rotate.degree0)
                || (objectName == "magnet4" && magnet4rotate == magnet4Rotate.degree0))
            {
                magnetGroup.magnetPos1state = magnet_group.magnetPos1State.yes;
            } 
            else
            {
                magnetGroup.magnetPos1state = magnet_group.magnetPos1State.no;
            }
        }
        else if (Vector3.Distance(magnetPos2.transform.position, transform.position) < snapOffset
            && magnetGroup.magnetpos2 == magnet_group.magnetPos2.off)
        {
            transform.position = magnetPos2.transform.position;
            // 2번 자리에는 +나 -가 붙어있으면 ok
            if (objectName == "magnetPlus"
                || (objectName == "magnetMinus" && (magnetMinusrotate == magnetMinusRotate.degree90 || magnetMinusrotate == magnetMinusRotate.degree270)))
            {
                magnetGroup.magnetPos2state = magnet_group.magnetPos2State.yes;
            }
            else
            {
                magnetGroup.magnetPos2state = magnet_group.magnetPos2State.no;
            }
        }
        else if (Vector3.Distance(magnetPos3.transform.position, transform.position) < snapOffset
            && magnetGroup.magnetpos3 == magnet_group.magnetPos3.off)
        {
            transform.position = magnetPos3.transform.position;
            // 3번 자리는 2나 3, 4가 붙어있으면 ok
            if ((objectName == "magnet2" && magnet2rotate == magnet2Rotate.degree0)
                || (objectName == "magnet3" && magnet3rotate == magnet3Rotate.degree0)
                || (objectName == "magnet4" && magnet4rotate == magnet4Rotate.degree0))
            {
                magnetGroup.magnetPos3state = magnet_group.magnetPos3State.yes;
            }
            else
            {
                magnetGroup.magnetPos3state = magnet_group.magnetPos3State.no;
            }
        }
        else if (Vector3.Distance(magnetPos4.transform.position, transform.position) < snapOffset
            && magnetGroup.magnetpos4 == magnet_group.magnetPos4.off)
        {
            transform.position = magnetPos4.transform.position;
            // 4번 자리는 +나 -가 붙어있으면 ok
            if (objectName == "magnetPlus"
                || (objectName == "magnetMinus" && (magnetMinusrotate == magnetMinusRotate.degree90 || magnetMinusrotate == magnetMinusRotate.degree270)))
            {
                magnetGroup.magnetPos4state = magnet_group.magnetPos4State.yes;
            }
            else
            {
                magnetGroup.magnetPos4state = magnet_group.magnetPos4State.no;
            }
        }
        else if (Vector3.Distance(magnetPos5.transform.position, transform.position) < snapOffset
        && magnetGroup.magnetpos5 == magnet_group.magnetPos5.off)
        {
            transform.position = magnetPos5.transform.position;
            // 5번 자리는 2나 3, 4가 붙어있으면 ok
            if ((objectName == "magnet2" && magnet2rotate == magnet2Rotate.degree0)
                || (objectName == "magnet3" && magnet3rotate == magnet3Rotate.degree0)
                || (objectName == "magnet4" && magnet4rotate == magnet4Rotate.degree0))
            {
                magnetGroup.magnetPos5state = magnet_group.magnetPos5State.yes;
            }
            else
            {
                magnetGroup.magnetPos5state = magnet_group.magnetPos5State.no;
            }
        }
        else if (Vector3.Distance(magnetPos6.transform.position, transform.position) < snapOffset
                && magnetGroup.magnetpos6 == magnet_group.magnetPos6.off)
        {
            transform.position = magnetPos6.transform.position;
            // 6번 자리는 무조건 =가 붙어있어야 ok
            if (objectName == "magnetEqual" && (magnetEqualrotate == magnetEqualRotate.degree0 || magnetEqualrotate == magnetEqualRotate.degree270))
            {
                magnetGroup.magnetPos6state = magnet_group.magnetPos6State.yes;
            }
            else
            {
                magnetGroup.magnetPos6state = magnet_group.magnetPos6State.no;
            }
        }
        else if (Vector3.Distance(magnetPos7.transform.position, transform.position) < snapOffset
        && magnetGroup.magnetpos7 == magnet_group.magnetPos7.off)
        {
            transform.position = magnetPos7.transform.position;
            // 7번 자리도 무조건 5가 붙어있어야 ok
            if (objectName == "magnet5" && magnet5rotate == magnet5Rotate.degree0)
            {
                magnetGroup.magnetPos7state = magnet_group.magnetPos7State.yes;
            }
            else
            {
                magnetGroup.magnetPos7state = magnet_group.magnetPos7State.no;
            }
        }
        else
        {
            // 자석이라 아무곳이나 붙어도 ok
        }
    }

    // 해당 위치에 자석이 붙어있음을 전달
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "magnetPos1")
        {
            magnetGroup.magnetpos1 = magnet_group.magnetPos1.on;
        }
        if (other.tag == "magnetPos2")
        {
            magnetGroup.magnetpos2 = magnet_group.magnetPos2.on;
        }
        if (other.tag == "magnetPos3")
        {
            magnetGroup.magnetpos3 = magnet_group.magnetPos3.on;
        }
        if (other.tag == "magnetPos4")
        {
            magnetGroup.magnetpos4 = magnet_group.magnetPos4.on;
        }
        if (other.tag == "magnetPos5")
        {
            magnetGroup.magnetpos5 = magnet_group.magnetPos5.on;
        }
        if (other.tag == "magnetPos6")
        {
            magnetGroup.magnetpos6 = magnet_group.magnetPos6.on;
        }
        if (other.tag == "magnetPos7")
        {
            magnetGroup.magnetpos7 = magnet_group.magnetPos7.on;
        }
    }

    // 해당 위치에서 자석이 떨어졌음을 전달
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "magnetPos1")
        {
            magnetGroup.magnetpos1 = magnet_group.magnetPos1.off;
        }
        if (other.tag == "magnetPos2")
        {
            magnetGroup.magnetpos2 = magnet_group.magnetPos2.off;
        }
        if (other.tag == "magnetPos3")
        {
            magnetGroup.magnetpos3 = magnet_group.magnetPos3.off;
        }
        if (other.tag == "magnetPos4")
        {
            magnetGroup.magnetpos4 = magnet_group.magnetPos4.off;
        }
        if (other.tag == "magnetPos5")
        {
            magnetGroup.magnetpos5 = magnet_group.magnetPos5.off;
        }
        if (other.tag == "magnetPos6")
        {
            magnetGroup.magnetpos6 = magnet_group.magnetPos6.off;
        }
        if (other.tag == "magnetPos7")
        {
            magnetGroup.magnetpos7 = magnet_group.magnetPos7.off;
        }
    }


    // reset magnet
    public void resetMagnet()
    {
        // magnet position reset
        transform.position = originPos;

        // magnet rotation reset
        rectTrans.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 80);
        rectTrans.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 100);
        if (objectName == "magnet3")
        {
            magnetImage.sprite = puzzle.getMagnetSprite(4);
            magnet3rotate = magnet3Rotate.degree0;
        }
        else if (objectName == "magnetPlus")
        {
            rectTrans.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 80);
            magnetImage.sprite = puzzle.getMagnetSprite(28);
        }
        else if (objectName == "magnet4")
        {
            magnetImage.sprite = puzzle.getMagnetSprite(8);
            magnet4rotate = magnet4Rotate.degree0;
        }
        else if (objectName == "magnetMinus")
        {
            rectTrans.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 20);
            rectTrans.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 80);
            magnetImage.sprite = puzzle.getMagnetSprite(24);
            magnetMinusrotate = magnetMinusRotate.degree0;
        }
        else if (objectName == "magnet2")
        {
            magnetImage.sprite = puzzle.getMagnetSprite(0);
            magnet2rotate = magnet2Rotate.degree0;
        }
        else if (objectName == "magnetEqual")
        {
            rectTrans.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 70);
            rectTrans.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 60);
            magnetImage.sprite = puzzle.getMagnetSprite(20);
            magnetEqualrotate = magnetEqualRotate.degree0;
        }
        else if (objectName == "magnet5")
        {
            magnetImage.sprite = puzzle.getMagnetSprite(12);
            magnet5rotate = magnet5Rotate.degree0;
        }

        // temp reset
        temp = 1;

        // magnetState reset
        magnetGroup.magnetPos1state = magnet_group.magnetPos1State.no;
        magnetGroup.magnetPos2state = magnet_group.magnetPos2State.no;
        magnetGroup.magnetPos3state = magnet_group.magnetPos3State.no;
        magnetGroup.magnetPos4state = magnet_group.magnetPos4State.no;
        magnetGroup.magnetPos5state = magnet_group.magnetPos5State.no;
        magnetGroup.magnetPos6state = magnet_group.magnetPos6State.no;
        magnetGroup.magnetPos7state = magnet_group.magnetPos7State.no;

        // magnetPos reset
        magnetGroup.magnetpos1 = magnet_group.magnetPos1.off;
        magnetGroup.magnetpos2 = magnet_group.magnetPos2.off;
        magnetGroup.magnetpos3 = magnet_group.magnetPos3.off;
        magnetGroup.magnetpos4 = magnet_group.magnetPos4.off;
        magnetGroup.magnetpos5 = magnet_group.magnetPos5.off;
        magnetGroup.magnetpos6 = magnet_group.magnetPos6.off;
        magnetGroup.magnetpos7 = magnet_group.magnetPos7.off;
    }
}
