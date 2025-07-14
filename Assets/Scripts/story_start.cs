using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class story_start : MonoBehaviour, IPointerClickHandler
{
    private TextMeshProUGUI content;
    private TextMeshProUGUI info;

    IEnumerator corutine;
    private int temp = 0;

    void Start()
    {
        content = GameObject.Find("dialogue_content").GetComponent<TextMeshProUGUI>();
        info = GameObject.Find("dialogue_info").GetComponent<TextMeshProUGUI>();

        firstDialogue();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        temp++;
        if (temp == 1)
        {
            secondDialogue();
        } else if (temp == 2)
        {
            info.text = "게임 시작 >>";
            thirdDialogue();
        }
        else if (temp >= 3)
        {
            closeCorutine();
            SceneManager.LoadScene("2)first_home");
        }
    }

    private void firstDialogue()
    {
        resetCorutine(10f);
        content.text = "아아, 잘 들리지? 미안하다\n일이 많아서 혼자 보냈는데, 잘 할 수 있지?.";
    }

    private void secondDialogue()
    {
        resetCorutine(10f);
        content.text = "일단은...도착하면 주변을 한번 둘러봐\n여기 일 끝나면 바로 갈게";
    }

    private void thirdDialogue()
    {
        resetCorutine(5f);
        content.text = "스캔해서 문제를 풀면 기록은 자동으로 될 거야\n그럼 잘 해봐";
    }

    private void resetCorutine(float time)
    {
        if (corutine != null)
        {
            StopCoroutine(corutine);
        }
        corutine = OpenAndClose(time);
        StartCoroutine(corutine);
    }

    public void closeCorutine()
    {
        if (corutine != null)
        {
            StopCoroutine(corutine);
        }
    }

    IEnumerator OpenAndClose(float time)
    {
        yield return new WaitForSeconds(time);
    }
}
