using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class arrow_group : MonoBehaviour
{
    public enum arrow1Onoff
    {
        on, off
    }
    public enum arrow2Onoff
    {
        on, off
    }
    public enum arrow3Onoff
    {
        on, off
    }
    public enum arrow4Onoff
    {
        on, off
    }
    public enum arrow5Onoff
    {
        on, off
    }
    public enum arrow6Onoff
    {
        on, off
    }
    public enum arrow7Onoff
    {
        on, off
    }
    public enum arrow8Onoff
    {
        on, off
    }
    public enum arrow9Onoff
    {
        on, off
    }
    public enum arrow10Onoff
    {
        on, off
    }
    public enum arrow11Onoff
    {
        on, off
    }
    public enum arrow12Onoff
    {
        on, off
    }
    public enum arrow13Onoff
    {
        on, off
    }
    public enum arrow14Onoff
    {
        on, off
    }
    public enum arrow15Onoff
    {
        on, off
    }
    public enum arrow16Onoff
    {
        on, off
    }
    public enum arrow17Onoff
    {
        on, off
    }
    public enum arrow18Onoff
    {
        on, off
    }
    public enum arrow19Onoff
    {
        on, off
    }
    public enum arrow20Onoff
    {
        on, off
    }
    public enum arrow21Onoff
    {
        on, off
    }
    public enum arrow22Onoff
    {
        on, off
    }
    public enum arrow23Onoff
    {
        on, off
    }
    public enum arrow24Onoff
    {
        on, off
    }
    public enum arrow25Onoff
    {
        on, off
    }

    private puzzleManager2 puzzle;

    private AudioSource arrowAudio;

    private StringBuilder sb = new StringBuilder();
    private int temp;

    private Button arrowReset;

    private Button arrow1, arrow2, arrow3, arrow4, arrow5, arrow6, arrow7, arrow8, arrow9, arrow10;
    private Button arrow11, arrow12, arrow13, arrow14, arrow15, arrow16, arrow17, arrow18, arrow19, arrow20;
    private Button arrow21, arrow22, arrow23, arrow24, arrow25;

    private Image arrow1Image, arrow2Image, arrow3Image, arrow4Image, arrow5Image, arrow6Image, arrow7Image, arrow8Image, arrow9Image, arrow10Image;
    private Image arrow11Image, arrow12Image, arrow13Image, arrow14Image, arrow15Image, arrow16Image, arrow17Image, arrow18Image, arrow19Image, arrow20Image;
    private Image arrow21Image, arrow22Image, arrow23Image, arrow24Image, arrow25Image;

    private Sprite arrowUpOn;
    private Sprite arrowUpOff;
    private Sprite arrowDownOn;
    private Sprite arrowDownOff;
    private Sprite arrowLeftOn;
    private Sprite arrowLeftOff;
    private Sprite arrowRightOn;
    private Sprite arrowRightOff;

    // 코드 개선 필요
    public arrow1Onoff arrow1onoff = arrow1Onoff.off;
    public arrow2Onoff arrow2onoff = arrow2Onoff.off;
    public arrow3Onoff arrow3onoff = arrow3Onoff.off;
    public arrow4Onoff arrow4onoff = arrow4Onoff.off;
    public arrow5Onoff arrow5onoff = arrow5Onoff.off;
    public arrow6Onoff arrow6onoff = arrow6Onoff.off;
    public arrow7Onoff arrow7onoff = arrow7Onoff.off;
    public arrow8Onoff arrow8onoff = arrow8Onoff.off;
    public arrow9Onoff arrow9onoff = arrow9Onoff.off;
    public arrow10Onoff arrow10onoff = arrow10Onoff.off;

    public arrow11Onoff arrow11onoff = arrow11Onoff.off;
    public arrow12Onoff arrow12onoff = arrow12Onoff.off;
    public arrow13Onoff arrow13onoff = arrow13Onoff.off;
    public arrow14Onoff arrow14onoff = arrow14Onoff.off;
    public arrow15Onoff arrow15onoff = arrow15Onoff.off;
    public arrow16Onoff arrow16onoff = arrow16Onoff.off;
    public arrow17Onoff arrow17onoff = arrow17Onoff.off;
    public arrow18Onoff arrow18onoff = arrow18Onoff.off;
    public arrow19Onoff arrow19onoff = arrow19Onoff.off;
    public arrow20Onoff arrow20onoff = arrow20Onoff.off;

    public arrow21Onoff arrow21onoff = arrow21Onoff.off;
    public arrow22Onoff arrow22onoff = arrow22Onoff.off;
    public arrow23Onoff arrow23onoff = arrow23Onoff.off;
    public arrow24Onoff arrow24onoff = arrow24Onoff.off;
    public arrow25Onoff arrow25onoff = arrow25Onoff.off;

    void Start()
    {
        puzzle = GameObject.Find("Canvas").GetComponent<puzzleManager2>();

        arrowAudio = GetComponent<AudioSource>();

        arrowReset = GameObject.Find("arrow_reset").GetComponent<Button>();
        arrowReset.onClick.AddListener(() => resetArrow());

        // 모든 버튼 연결
        arrow1 = GameObject.Find("arrow1").GetComponent<Button>();
        arrow1.onClick.AddListener(() => clickArrow(arrow1Image, 1));
        arrow2 = GameObject.Find("arrow2").GetComponent<Button>();
        arrow2.onClick.AddListener(() => clickArrow(arrow2Image, 2));
        arrow3 = GameObject.Find("arrow3").GetComponent<Button>();
        arrow3.onClick.AddListener(() => clickArrow(arrow3Image, 3));
        arrow4 = GameObject.Find("arrow4").GetComponent<Button>();
        arrow4.onClick.AddListener(() => clickArrow(arrow4Image, 4));
        arrow5 = GameObject.Find("arrow5").GetComponent<Button>();
        arrow5.onClick.AddListener(() => clickArrow(arrow5Image, 5));
        arrow6 = GameObject.Find("arrow6").GetComponent<Button>();
        arrow6.onClick.AddListener(() => clickArrow(arrow6Image, 6));
        arrow7 = GameObject.Find("arrow7").GetComponent<Button>();
        arrow7.onClick.AddListener(() => clickArrow(arrow7Image, 7));
        arrow8 = GameObject.Find("arrow8").GetComponent<Button>();
        arrow8.onClick.AddListener(() => clickArrow(arrow8Image, 8));
        arrow9 = GameObject.Find("arrow9").GetComponent<Button>();
        arrow9.onClick.AddListener(() => clickArrow(arrow9Image, 9));
        arrow10 = GameObject.Find("arrow10").GetComponent<Button>();
        arrow10.onClick.AddListener(() => clickArrow(arrow10Image, 10));

        arrow11 = GameObject.Find("arrow11").GetComponent<Button>();
        arrow11.onClick.AddListener(() => clickArrow(arrow11Image, 11));
        arrow12 = GameObject.Find("arrow12").GetComponent<Button>();
        arrow12.onClick.AddListener(() => clickArrow(arrow12Image, 12));
        arrow13 = GameObject.Find("arrow13").GetComponent<Button>();
        arrow13.onClick.AddListener(() => clickArrow(arrow13Image, 13));
        arrow14 = GameObject.Find("arrow14").GetComponent<Button>();
        arrow14.onClick.AddListener(() => clickArrow(arrow14Image, 14));
        arrow15 = GameObject.Find("arrow15").GetComponent<Button>();
        arrow15.onClick.AddListener(() => clickArrow(arrow15Image, 15));
        arrow16 = GameObject.Find("arrow16").GetComponent<Button>();
        arrow16.onClick.AddListener(() => clickArrow(arrow16Image, 16));
        arrow17 = GameObject.Find("arrow17").GetComponent<Button>();
        arrow17.onClick.AddListener(() => clickArrow(arrow17Image, 17));
        arrow18 = GameObject.Find("arrow18").GetComponent<Button>();
        arrow18.onClick.AddListener(() => clickArrow(arrow18Image, 18));
        arrow19 = GameObject.Find("arrow19").GetComponent<Button>();
        arrow19.onClick.AddListener(() => clickArrow(arrow19Image, 19));
        arrow20 = GameObject.Find("arrow20").GetComponent<Button>();
        arrow20.onClick.AddListener(() => clickArrow(arrow20Image, 20));

        arrow21 = GameObject.Find("arrow21").GetComponent<Button>();
        arrow21.onClick.AddListener(() => clickArrow(arrow21Image, 21));
        arrow22 = GameObject.Find("arrow22").GetComponent<Button>();
        arrow22.onClick.AddListener(() => clickArrow(arrow22Image, 22));
        arrow23 = GameObject.Find("arrow23").GetComponent<Button>();
        arrow23.onClick.AddListener(() => clickArrow(arrow23Image, 23));
        arrow24 = GameObject.Find("arrow24").GetComponent<Button>();
        arrow24.onClick.AddListener(() => clickArrow(arrow24Image, 24));
        arrow25 = GameObject.Find("arrow25").GetComponent<Button>();
        arrow25.onClick.AddListener(() => clickArrow(arrow25Image, 25));

        // 모든 버튼 이미지 연결
        arrow1Image = GameObject.Find("arrow1").GetComponent<Image>();
        arrow2Image = GameObject.Find("arrow2").GetComponent<Image>();
        arrow3Image = GameObject.Find("arrow3").GetComponent<Image>();
        arrow4Image = GameObject.Find("arrow4").GetComponent<Image>();
        arrow5Image = GameObject.Find("arrow5").GetComponent<Image>();
        arrow6Image = GameObject.Find("arrow6").GetComponent<Image>();
        arrow7Image = GameObject.Find("arrow7").GetComponent<Image>();
        arrow8Image = GameObject.Find("arrow8").GetComponent<Image>();
        arrow9Image = GameObject.Find("arrow9").GetComponent<Image>();
        arrow10Image = GameObject.Find("arrow10").GetComponent<Image>();

        arrow11Image = GameObject.Find("arrow11").GetComponent<Image>();
        arrow12Image = GameObject.Find("arrow12").GetComponent<Image>();
        arrow13Image = GameObject.Find("arrow13").GetComponent<Image>();
        arrow14Image = GameObject.Find("arrow14").GetComponent<Image>();
        arrow15Image = GameObject.Find("arrow15").GetComponent<Image>();
        arrow16Image = GameObject.Find("arrow16").GetComponent<Image>();
        arrow17Image = GameObject.Find("arrow17").GetComponent<Image>();
        arrow18Image = GameObject.Find("arrow18").GetComponent<Image>();
        arrow19Image = GameObject.Find("arrow19").GetComponent<Image>();
        arrow20Image = GameObject.Find("arrow20").GetComponent<Image>();

        arrow21Image = GameObject.Find("arrow21").GetComponent<Image>();
        arrow22Image = GameObject.Find("arrow22").GetComponent<Image>();
        arrow23Image = GameObject.Find("arrow23").GetComponent<Image>();
        arrow24Image = GameObject.Find("arrow24").GetComponent<Image>();
        arrow25Image = GameObject.Find("arrow25").GetComponent<Image>();
    }

    // 정답 확인 수시로
    void Update()
    {
        if (puzzle.gardenonoff == puzzleManager2.gardenOnoff.on)
        {
            arrowUpOn = puzzle.getGardenButtonSprite(9);
            arrowUpOff = puzzle.getGardenButtonSprite(8);
            arrowDownOn = puzzle.getGardenButtonSprite(5);
            arrowDownOff = puzzle.getGardenButtonSprite(4);
            arrowLeftOn = puzzle.getGardenButtonSprite(13);
            arrowLeftOff = puzzle.getGardenButtonSprite(12);
            arrowRightOn = puzzle.getGardenButtonSprite(1);
            arrowRightOff = puzzle.getGardenButtonSprite(0);
        }
        if (sb.ToString() == "2524231817222116111276123813141920151094")
        {
            puzzle.gardenStateOpen();
        }
    }

    // 클릭된 숫자 입력
    private void clickArrow(Image arrow, int num)
    {
        arrowAudio.Play();
        if (arrow.sprite == arrowUpOn)
        {
            arrow.sprite = arrowUpOff;
            enterNum(num);
        }
        else if (arrow.sprite == arrowDownOn)
        {
            arrow.sprite = arrowDownOff;
            enterNum(num);
        }
        else if (arrow.sprite == arrowLeftOn)
        {
            arrow.sprite = arrowLeftOff;
            enterNum(num);
        }
        else if (arrow.sprite == arrowRightOn)
        {
            arrow.sprite = arrowRightOff;
            enterNum(num);
        }
    }

    private void enterNum(int num)
    {
        if (temp != 0)
        {
            sb.Append(temp);
            temp = num;
        } else {
            temp = num;
        }
    }

    private void resetArrow()
    {
        sb.Clear();
        if (arrow1Image.sprite == arrowRightOff)
        {
            arrow1Image.sprite = arrowRightOn;
        }
        else if (arrow2Image.sprite == arrowRightOff)
        {
            arrow2Image.sprite = arrowRightOn;
        }
        else if (arrow3Image.sprite == arrowDownOff)
        {
            arrow3Image.sprite = arrowDownOn;
        }
        else if (arrow4Image.sprite == arrowRightOff)
        {
            arrow4Image.sprite = arrowRightOn;
        }
        else if (arrow5Image.sprite == arrowUpOff)
        {
            arrow5Image.sprite = arrowUpOn;
        }
        else if (arrow6Image.sprite == arrowUpOff)
        {
            arrow6Image.sprite = arrowUpOn;
        }
        else if (arrow7Image.sprite == arrowLeftOff)
        {
            arrow7Image.sprite = arrowLeftOn;
        }
        else if (arrow8Image.sprite == arrowDownOff)
        {
            arrow8Image.sprite = arrowDownOn;
        }
        else if (arrow9Image.sprite == arrowUpOff)
        {
            arrow9Image.sprite = arrowUpOn;
        }
        else if (arrow10Image.sprite == arrowLeftOff)
        {
            arrow10Image.sprite = arrowLeftOn;
        }

        else if (arrow11Image.sprite == arrowRightOff)
        {
            arrow11Image.sprite = arrowRightOn;
        }
        else if (arrow12Image.sprite == arrowUpOff)
        {
            arrow12Image.sprite = arrowUpOn;
        }
        else if (arrow13Image.sprite == arrowRightOff)
        {
            arrow13Image.sprite = arrowRightOn;
        }
        else if (arrow14Image.sprite == arrowDownOff)
        {
            arrow14Image.sprite = arrowDownOn;
        }
        else if (arrow15Image.sprite == arrowUpOff)
        {
            arrow15Image.sprite = arrowUpOn;
        }
        else if (arrow16Image.sprite == arrowUpOff)
        {
            arrow16Image.sprite = arrowUpOn;
        }
        else if (arrow17Image.sprite == arrowDownOff)
        {
            arrow17Image.sprite = arrowDownOn;
        }
        else if (arrow18Image.sprite == arrowLeftOff)
        {
            arrow18Image.sprite = arrowLeftOn;
        }
        else if (arrow19Image.sprite == arrowRightOff)
        {
            arrow19Image.sprite = arrowRightOn;
        }
        else if (arrow20Image.sprite == arrowUpOff)
        {
            arrow20Image.sprite = arrowUpOn;
        }

        else if (arrow21Image.sprite == arrowUpOff)
        {
            arrow21Image.sprite = arrowUpOn;
        }
        else if (arrow22Image.sprite == arrowLeftOff)
        {
            arrow22Image.sprite = arrowLeftOn;
        }
        else if (arrow23Image.sprite == arrowUpOff)
        {
            arrow23Image.sprite = arrowUpOn;
        }
        else if (arrow24Image.sprite == arrowLeftOff)
        {
            arrow24Image.sprite = arrowLeftOn;
        }
        else if (arrow25Image.sprite == arrowLeftOff)
        {
            arrow25Image.sprite = arrowLeftOn;
        }
    }
}