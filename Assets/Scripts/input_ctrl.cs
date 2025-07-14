using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class input_ctrl : MonoBehaviour
{
    private puzzleManager puzzle;

    private AudioSource inputAudio;
    private AudioClip num1Clip;
    private AudioClip num2Clip;
    private AudioClip wrongClip;

    private StringBuilder sb = new StringBuilder();
    private int index = 0;

    private Button num1, num2, num3, num4, num5, num6, num7, num8, num9, num0, cancle, ok;

    void Start()
    {
        puzzle = GameObject.Find("Canvas").GetComponent<puzzleManager>();

        inputAudio = GetComponent<AudioSource>();
        num1Clip = Resources.Load<AudioClip>("Sounds/Sound_num1");
        num2Clip = Resources.Load<AudioClip>("Sounds/Sound_num2");
        wrongClip = Resources.Load<AudioClip>("Sounds/Sound_false");

        // 모든 버튼 연결
        num1 = GameObject.Find("num1").GetComponent<Button>();
        num1.onClick.AddListener(() => clickNum(1));
        num2 = GameObject.Find("num2").GetComponent<Button>();
        num2.onClick.AddListener(() => clickNum(2));
        num3 = GameObject.Find("num3").GetComponent<Button>();
        num3.onClick.AddListener(() => clickNum(3));
        num4 = GameObject.Find("num4").GetComponent<Button>();
        num4.onClick.AddListener(() => clickNum(4));
        num5 = GameObject.Find("num5").GetComponent<Button>();
        num5.onClick.AddListener(() => clickNum(5));
        num6 = GameObject.Find("num6").GetComponent<Button>();
        num6.onClick.AddListener(() => clickNum(6));
        num7 = GameObject.Find("num7").GetComponent<Button>();
        num7.onClick.AddListener(() => clickNum(7));
        num8 = GameObject.Find("num8").GetComponent<Button>();
        num8.onClick.AddListener(() => clickNum(8));
        num9 = GameObject.Find("num9").GetComponent<Button>();
        num9.onClick.AddListener(() => clickNum(9));
        num0 = GameObject.Find("num0").GetComponent<Button>();
        num0.onClick.AddListener(() => clickNum(0));
        cancle = GameObject.Find("cancle").GetComponent<Button>();
        cancle.onClick.AddListener(() => cancleNum());
        ok = GameObject.Find("ok").GetComponent<Button>();
        ok.onClick.AddListener(() => okNum());

    }

    // 클릭된 숫자 입력
    private void clickNum(int num)
    {
        inputAudio.clip = num1Clip;
        inputAudio.Play();
        if (sb.Length <= 3) // sb.Lenght <= 3일 때만 입력 받기
        {
            sb.Append(num);
            index++;
            print();
        }
    }

    // 숫자 지우기
    private void cancleNum()
    {
        inputAudio.clip = num2Clip;
        inputAudio.Play();
        if (index-1 >= 0) // temp-1 == 현재 숫자 인덱스
        {
            sb.Remove(--index, 1);
        }
        print();
    }

    // 정답 확인
    private void okNum()
    {
        string answer = sb.ToString();
        inputAudio.clip = wrongClip;

        if (puzzle.tvonoff == puzzleManager.tvOnoff.on && answer == "0874")
        {
            clear();
            puzzle.tvStateOpen();
            puzzle.mainDoorHandleOpen();
        }
        else if (puzzle.matonoff == puzzleManager.matOnoff.on && answer == "0026")
        {
            clear();
            puzzle.matStateOpen();
        }
        else if (puzzle.displayRackonoff == puzzleManager.displayRackOnoff.on && answer == "2368")
        {
            clear();
            puzzle.displayRackStateOpen();
        }
        else if (puzzle.tableonoff == puzzleManager.tableOnoff.on && answer == "0012")
        {
            clear();
            puzzle.tableStateOpen();
        }
        else
        {
            clear();
            inputAudio.Play();
        }
    }

    // 숫자 출력
    public void print()
    {
        GetComponent<TextMeshProUGUI>().text = sb.ToString();
    }

    public void clear()
    {
        index = 0;
        sb.Clear();
        GetComponent<TextMeshProUGUI>().text = "";
    }
}
