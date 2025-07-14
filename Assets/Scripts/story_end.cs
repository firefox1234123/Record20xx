using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class story_end : MonoBehaviour, IPointerClickHandler
{
    private TextMeshProUGUI content;

    private AudioSource scanning;

    IEnumerator corutine;
    private int temp = 0;

    void Start()
    {
        content = GameObject.Find("dialogue_content").GetComponent<TextMeshProUGUI>();
        scanning = GetComponent<AudioSource>();

        firstDialogue();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        temp++;
        if (temp == 1)
        {
            scanning.Play();
            secondDialogue();
        }
        else if (temp >= 2)
        {
            closeCorutine();
            SceneManager.LoadScene("5)EndScene");
        }
    }

    private void firstDialogue()
    {
        resetCorutine(10f);
        content.text = "온 세상에 초록빛이 가득해.";
    }

    private void secondDialogue()
    {
        resetCorutine(10f);
        content.text = "스캔해보니 저 식물은 칡이라는데,\n다른 곳들도 이럴까?";
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
