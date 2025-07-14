using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scene_main : MonoBehaviour
{
    private Button startButton;
    private Button exitButton;

    private GameObject popupGroup;
    private Button yesButton;
    private Button noButton;

    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        startButton = GameObject.Find("start_button").GetComponent<Button>();
        startButton.onClick.AddListener(() => startGame());
        exitButton = GameObject.Find("exit_button").GetComponent<Button>();
        exitButton.onClick.AddListener(() => openPopup());

        popupGroup = GameObject.Find("popup_group");

        yesButton = GameObject.Find("popup_button_yes").GetComponent<Button>();
        yesButton.onClick.AddListener(() => endGame());
        noButton = GameObject.Find("popup_button_no").GetComponent<Button>();
        noButton.onClick.AddListener(() => closePopup());

        popupGroup.SetActive(false);
    }

    private void startGame()
    {
        SceneManager.LoadScene("1)story_start");
    }

    private void openPopup()
    {
        popupGroup.SetActive(true);
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
