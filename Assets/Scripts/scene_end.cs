using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class scene_end : MonoBehaviour
{
    private GameObject popupGroup;

    private GameObject restart;
    private GameObject exit;

    private Button okButton;
    private Button restartButton;
    private Button exitButton;

    private GameObject ok;
    private GameObject yes;
    private GameObject no;
    private Button yesButton;
    private Button noButton;
    private TextMeshProUGUI popupText;

    void Start()
    {
        popupGroup = GameObject.Find("popup_group");

        restart = GameObject.Find("restart_button");
        exit = GameObject.Find("exit_button");

        restartButton = restart.GetComponent<Button>();
        restartButton.onClick.AddListener(() => openPopup(0));
        exitButton = exit.GetComponent<Button>();
        exitButton.onClick.AddListener(() => openPopup(1));

        ok = GameObject.Find("popup_button_ok");
        yes = GameObject.Find("popup_button_yes");
        no = GameObject.Find("popup_button_no");
        okButton = ok.GetComponent<Button>();
        okButton.onClick.AddListener(() => goMainScene());
        yesButton = yes.GetComponent<Button>();
        yesButton.onClick.AddListener(() => endGame());
        noButton = no.GetComponent<Button>();
        noButton.onClick.AddListener(() => closePopup());

        popupText = GameObject.Find("popup_text").GetComponent<TextMeshProUGUI>();

        popupGroup.SetActive(false);
    }

    private void openPopup(int n)
    {
        popupGroup.SetActive(true);
        switch (n)
        {
            case 0: // restartButton을 눌렀을 때
                ok.SetActive(true);
                yes.SetActive(false);
                no.SetActive(false);
                popupText.text = "메인 화면으로 이동합니다";
                break;
            case 1: // exitButton을 눌렀을 때
                ok.SetActive(false);
                yes.SetActive(true);
                no.SetActive(true);
                popupText.text = "정말 종료할까요?";
                break;
            default:
                break;
        }
    }

    private void goMainScene()
    {
        SceneManager.LoadScene("0)MainScene");
    }

    private void closePopup()
    {
        popupGroup.SetActive(false);
    }

    private void endGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
}
