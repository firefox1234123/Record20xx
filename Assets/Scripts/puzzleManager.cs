using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class puzzleManager : MonoBehaviour
{
    // 각 캔버스의 활성화 유무를 담은 enum
    public enum blindOnoff
    {
        on, off
    }
    public enum hintOnoff
    {
        on, off
    }
    public enum tvOnoff
    {
        on, off
    }
    public enum livRackOnoff
    {
        on, off
    }
    public enum matOnoff
    {
        on, off
    }
    public enum sofaOnoff
    {
        on, off
    }
    public enum mainDoorOnoff
    {
        on, off
    }
    public enum displayRackOnoff
    {
        on, off
    }
    public enum refrigeratorOnoff
    {
        on, off
    }
    public enum tableOnoff
    {
        on, off
    }

    // 해결 유무를 담아두는 enum (sofa는 필요X)
    private enum tvSolved
    {
        no, yes
    }
    private enum livRackSolved
    {
        no, yes
    }
    private enum matSolved
    {
        no, yes
    }
    private enum mainDoorKeyGet
    {
        no, yes
    }
    private enum mainDoorSolved
    {
        no, yes
    }
    private enum displayRackSolved
    {
        no, yes
    }
    private enum refrigeratorSolved
    {
        no, yes
    }
    private enum tableSolved
    {
        no, yes
    }

    // 퍼즐 설명 대사 출력 유무 확인(삭제 가능성O)
    private enum tvisFirst
    {
        no, yes
    }
    private enum livRackisFirst
    {
        no, yes
    }
    private enum matisFirst
    {
        no, yes
    }
    private enum sofaisFirst
    {
        no, yes
    }
    private enum mainDoorisFirst
    {
        no, yes
    }
    private enum displayRackisFirst
    {
        no, yes
    }
    private enum displayRackBatteryisFirst
    {
        no, yes
    }
    private enum refrigeratorisFirst
    {
        no, yes
    }
    private enum tableisFirst
    {
        no, yes
    }

    // 아이템 소지 유무 확인
    public enum getDoorkey
    {
        no, yes
    }
    public enum getBattery1
    {
        no, yes
    }
    public enum getBattery2
    {
        no, yes
    }

    private input_ctrl input;
    private dialogue_group dialogueGroup;

    public tvOnoff tvonoff;
    public livRackOnoff livRackonoff;
    public matOnoff matonoff;
    public sofaOnoff sofaonoff;
    public mainDoorOnoff mainDooronoff;
    public displayRackOnoff displayRackonoff;
    public refrigeratorOnoff refrigeratoronoff;
    public tableOnoff tableonoff;

    private tvSolved tvsolved = tvSolved.no;
    private livRackSolved livRacksolved = livRackSolved.no;
    private matSolved matsolved = matSolved.no;
    private mainDoorSolved mainDoorsolved = mainDoorSolved.no;
    private mainDoorKeyGet mainDoorKeyget = mainDoorKeyGet.no;
    private displayRackSolved displayRacksolved = displayRackSolved.no;
    private refrigeratorSolved refrigeratorsolved = refrigeratorSolved.no;
    private tableSolved tablesolved = tableSolved.no;

    private tvisFirst tvisfirst = tvisFirst.yes;
    private livRackisFirst livRackisfirst = livRackisFirst.yes;
    private matisFirst matisfirst = matisFirst.yes;
    private sofaisFirst sofaisfirst = sofaisFirst.yes;
    private mainDoorisFirst maindoorisfirst = mainDoorisFirst.yes;
    private displayRackisFirst displayRackisfirst = displayRackisFirst.yes;
    private displayRackBatteryisFirst displayRackBatteryisfirst = displayRackBatteryisFirst.yes;
    private refrigeratorisFirst refrigeratorisfirst = refrigeratorisFirst.yes;
    private tableisFirst tableisfirst = tableisFirst.yes;

    public getBattery1 getbattery1 = getBattery1.no;
    public getBattery2 getbattery2 = getBattery2.no;
    public getDoorkey getdoorkey = getDoorkey.no;

    public blindOnoff blindonoff;
    private GameObject blind;
    private Button blindButton;

    public hintOnoff hintonoff;
    private GameObject hintGroup;

    private GameObject inputGroup;
    private RectTransform inputGroupPos;

    private GameObject blockGroup;
    private GameObject mainGroup;
    private GameObject magnetGroup;

    private GameObject tv;
    private Image tvImage;
    private Sprite tvOpen;
    private GameObject doorkey;
    private AudioSource tvAudio;

    private GameObject livRack;
    private Image livRackImage;
    private Sprite livRackOpen;
    private AudioSource livRackAudio;
    private AudioClip blockAttach;
    private AudioClip blockDetach;

    private GameObject mat;
    private Image matImage;
    private Sprite matOpen;
    private GameObject battery2;
    private AudioSource matAudio;

    private GameObject sofa;

    private GameObject mainDoor;
    private Image mainDoorImage;
    private Sprite mainDoorOpen;
    private Sprite[] mainDoorButtons;

    private GameObject popupGroup;
    private Button okButton;

    private GameObject displayRack;
    private Image displayRackImage;
    private Sprite displayRackBattery1;
    private Sprite displayRackClose;
    private Sprite displayRackOpen;
    private AudioSource displayRackAudio;

    private GameObject refrigerator;
    private Image refrigeratorImage;
    private Sprite refrigeratorOpen;
    private Sprite[] magnetImages;
    private GameObject battery1;
    private AudioSource refrigeratorAudio;
    private AudioClip magnetAttach;
    private AudioClip magnetDetach;

    private GameObject table;
    private Image tableImage;
    private Sprite tableOpen;

    void Start()
    {
        dialogueGroup = GameObject.Find("dialogue_group").GetComponent<dialogue_group>();

        blind = GameObject.Find("blind");
        blindButton = blind.GetComponent<Button>();
        blindButton.onClick.AddListener(() => turnOff());
        blindonoff = blindOnoff.off;

        hintGroup = GameObject.Find("hint_group");
        hintonoff = hintOnoff.off;

        input = GameObject.Find("input").GetComponent<input_ctrl>();
        inputGroup = GameObject.Find("input_group");
        inputGroup.SetActive(false);

        blockGroup = GameObject.Find("block_group");
        blockGroup.SetActive(false);

        mainGroup = GameObject.Find("main_group");
        mainGroup.SetActive(false);

        magnetGroup = GameObject.Find("magnet_group");
        magnetGroup.SetActive(false);

        inputGroupPos = inputGroup.GetComponent<RectTransform>();

        tv = GameObject.Find("tv");
        tvImage = tv.GetComponent<Image>();
        tvOpen = Resources.Load<Sprite>("Puzzles/Puzzle_home_tv_open");
        tvAudio = tv.GetComponent<AudioSource>();
        tvonoff = tvOnoff.off;
        doorkey = GameObject.Find("item_doorkey");
        doorkey.SetActive(false);

        livRack = GameObject.Find("livRack");
        livRackImage = livRack.GetComponent<Image>();
        livRackOpen = Resources.Load<Sprite>("Puzzles/Puzzle_home_livRack_open");
        livRackAudio = livRack.GetComponent<AudioSource>();
        blockAttach = Resources.Load<AudioClip>("Sounds/Sound_magnet_attach");
        blockDetach = Resources.Load<AudioClip>("Sounds/Sound_magnet_detach");
        livRackonoff = livRackOnoff.off;

        mat = GameObject.Find("mat");
        matImage = mat.GetComponent<Image>();
        matOpen = Resources.Load<Sprite>("Puzzles/Puzzle_home_mat_open");
        matAudio = mat.GetComponent<AudioSource>();
        matonoff = matOnoff.off;
        battery1 = GameObject.Find("item_battery1");
        battery1.SetActive(false);

        sofa = GameObject.Find("sofa");
        sofaonoff = sofaOnoff.off;

        mainDoor = GameObject.Find("mainDoor");
        mainDoorImage = mainDoor.GetComponent<Image>();
        mainDoorOpen = Resources.Load<Sprite>("Puzzles/Puzzle_home_mainDoor_open");
        mainDoorButtons = Resources.LoadAll<Sprite>("Puzzles/Puzzle_mainKeyPad");
        mainDooronoff = mainDoorOnoff.off;

        popupGroup = GameObject.Find("popup_group");
        okButton = GameObject.Find("popup_button_ok").GetComponent<Button>();
        okButton.onClick.AddListener(() => loadScene());
        popupGroup.SetActive(false);

        displayRack = GameObject.Find("displayRack");
        displayRackImage = displayRack.GetComponent<Image>();
        displayRackBattery1 = Resources.Load<Sprite>("Puzzles/Puzzle_home_displayRack_battery1");
        displayRackClose = Resources.Load<Sprite>("Puzzles/Puzzle_home_displayRack_close");
        displayRackOpen = Resources.Load<Sprite>("Puzzles/Puzzle_home_displayRack_open");
        displayRackAudio = displayRack.GetComponent<AudioSource>();
        displayRackonoff = displayRackOnoff.off;

        refrigerator = GameObject.Find("refrigerator");
        refrigeratorImage = refrigerator.GetComponent<Image>();
        refrigeratorOpen = Resources.Load<Sprite>("Puzzles/Puzzle_home_refrigerator_open");
        magnetImages = Resources.LoadAll<Sprite>("Puzzles/Puzzle_home_refrigerator_magnet");
        refrigeratorAudio = refrigerator.GetComponent<AudioSource>();
        magnetAttach = Resources.Load<AudioClip>("Sounds/Sound_magnet_attach");
        magnetDetach = Resources.Load<AudioClip>("Sounds/Sound_magnet_detach");
        refrigeratoronoff = refrigeratorOnoff.off;
        battery2 = GameObject.Find("item_battery2");
        battery2.SetActive(false);

        table = GameObject.Find("table");
        tableImage = table.GetComponent<Image>();
        tableOpen = Resources.Load<Sprite>("Puzzles/Puzzle_home_table_open");
        tableonoff = tableOnoff.off;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            hintMessage();
        }

        // blind onoff
        if (blindonoff == blindOnoff.on)
        {
            blind.SetActive(true);
        } else if (blindonoff == blindOnoff.off)
        {
            blind.SetActive(false);
        }

        // hint(UI) onoff
        if (hintonoff == hintOnoff.on)
        {
            hintGroup.SetActive(true);
        }
        else if (hintonoff == hintOnoff.off)
        {
            hintGroup.SetActive(false);
        }

        // tv onoff
        if (tvonoff == tvOnoff.on)
        {
            if (tvisfirst == tvisFirst.yes)
            {
                dialogueGroup.tvPuzzleDialogue();
                tvisfirst = tvisFirst.no;
            }

            tv.SetActive(true);
            inputGroup.SetActive(true);
            inputGroupPos.offsetMin = new Vector2(-20, -117);
            inputGroupPos.offsetMax = new Vector2(-20, -117);
            if (tvsolved == tvSolved.yes)
            {
                inputGroup.SetActive(false);
                if (getdoorkey == getDoorkey.no)
                {
                    doorkey.SetActive(true);
                } else
                {
                    doorkey.SetActive(false);
                }
            }
        } else if (tvonoff == tvOnoff.off)
        {
            tv.SetActive(false);
        }

        // livRack onoff
        if (livRackonoff == livRackOnoff.on)
        {
            if (livRackisfirst == livRackisFirst.yes)
            {
                dialogueGroup.livRackPuzzleDialogue();
                livRackisfirst = livRackisFirst.no;
            }

            livRack.SetActive(true);
            blockGroup.SetActive(true);
            if (livRacksolved == livRackSolved.yes)
            {
                blockGroup.SetActive(false);
            }
        } else if (livRackonoff == livRackOnoff.off)
        {
            livRack.SetActive(false);
        }

        // mat onoff
        if (matonoff == matOnoff.on)
        {
            if (matisfirst == matisFirst.yes)
            {
                dialogueGroup.matPuzzleDialogue();
                matisfirst = matisFirst.no;
            }

            mat.SetActive(true);
            inputGroup.SetActive(true);
            inputGroupPos.offsetMin = new Vector2(52, 30);
            inputGroupPos.offsetMax = new Vector2(52, 30);

            if (matsolved == matSolved.yes)
            {
                inputGroup.SetActive(false);
                if (getbattery1 == getBattery1.no)
                {
                    battery1.SetActive(true);
                } else
                {
                    battery1.SetActive(false);
                }
            }
        } else if (matonoff == matOnoff.off)
        {
            mat.SetActive(false);
        }

        // sofa onoff
        if (sofaonoff == sofaOnoff.on)
        {
            if (sofaisfirst == sofaisFirst.yes)
            {
                dialogueGroup.sofaPuzzleDialogue();
                sofaisfirst = sofaisFirst.no;
            }

            sofa.SetActive(true);
        } else if (sofaonoff == sofaOnoff.off)
        {
            sofa.SetActive(false);
        }

        // mainDoor onoff
        if (mainDooronoff == mainDoorOnoff.on)
        {
            if (maindoorisfirst == mainDoorisFirst.yes)
            {
                dialogueGroup.mainDoorPuzzleDialogue();
                maindoorisfirst = mainDoorisFirst.no;
            }

            mainDoor.SetActive(true);
            mainGroup.SetActive(true);
            if (mainDoorsolved == mainDoorSolved.yes)
            {
                mainGroup.SetActive(false);
            }
        } else if (mainDooronoff == mainDoorOnoff.off)
        {
            mainDoor.SetActive(false);
        }

        // displayRack onoff
        if (displayRackonoff == displayRackOnoff.on)
        {
            // 배터리를 둘 다 획득했다면
            if (getbattery1 == getBattery1.yes && getbattery2 == getBattery2.yes && displayRackisfirst == displayRackisFirst.yes)
            {
                dialogueGroup.displayRackPuzzleDialogue();
                displayRackisfirst = displayRackisFirst.no;
            } else if (displayRackBatteryisfirst == displayRackBatteryisFirst.yes)
            {
                dialogueGroup.displayRackBatteryDialogue();
                displayRackBatteryisfirst = displayRackBatteryisFirst.no;
            }

            displayRack.SetActive(true);
            inputGroup.SetActive(true);
            inputGroupPos.offsetMin = new Vector2(0, 0);
            inputGroupPos.offsetMax = new Vector2(0, 0);
            if (displayRacksolved == displayRackSolved.yes || !(getbattery1 == getBattery1.yes && getbattery2 == getBattery2.yes))
            {
                inputGroup.SetActive(false);
            }
        } else if (displayRackonoff == displayRackOnoff.off)
        {
            displayRack.SetActive(false);
        }

        // refrigerator onoff
        if (refrigeratoronoff == refrigeratorOnoff.on)
        {
            if (refrigeratorisfirst == refrigeratorisFirst.yes)
            {
                dialogueGroup.refrigeratorPuzzleDialogue();
                refrigeratorisfirst = refrigeratorisFirst.no;
            }

            refrigerator.SetActive(true);
            magnetGroup.SetActive(true);
            if (refrigeratorsolved == refrigeratorSolved.yes)
            {
                magnetGroup.SetActive(false);
                if (getbattery2 == getBattery2.no)
                {
                    battery2.SetActive(true);
                } else
                {
                    battery2.SetActive(false);
                }
            }
        } else if (refrigeratoronoff == refrigeratorOnoff.off)
        {
            refrigerator.SetActive(false);
        }

        // table onoff
        if (tableonoff == tableOnoff.on)
        {
            if (tableisfirst == tableisFirst.yes)
            {
                dialogueGroup.tablePuzzleDialogue();
                tableisfirst = tableisFirst.no;
            }

            table.SetActive(true);
            inputGroup.SetActive(true);
            inputGroupPos.offsetMin = new Vector2(50, 2);
            inputGroupPos.offsetMax = new Vector2(50, 2);
            if (tablesolved == tableSolved.yes)
            {
                inputGroup.SetActive(false);
            }
        } else if (tableonoff == tableOnoff.off)
        {
            table.SetActive(false);
        }
    }

    private void hintMessage()
    {
        if (tvonoff == tvOnoff.on && tvsolved == tvSolved.no)
        {
            dialogueGroup.tvPuzzleHint();
        }
        else if (livRackonoff == livRackOnoff.on && livRacksolved == livRackSolved.no)
        {
            dialogueGroup.livRackPuzzleHint();
        }
        else if (matonoff == matOnoff.on && matsolved == matSolved.no)
        {
            dialogueGroup.matPuzzleHint();
        }
        else if (sofaonoff == sofaOnoff.on)
        {
            dialogueGroup.sofaPuzzleHint();
        }
        else if (mainDooronoff == mainDoorOnoff.on && mainDoorsolved == mainDoorSolved.no)
        {
            dialogueGroup.mainDoorPuzzleHint();
        }
        else if (displayRackonoff == displayRackOnoff.on && displayRacksolved == displayRackSolved.no)
        {
            dialogueGroup.displayRackPuzzleHint();
        }
        else if (refrigeratoronoff == refrigeratorOnoff.on && refrigeratorsolved == refrigeratorSolved.no)
        {
            dialogueGroup.refrigeratorPuzzleHint();
        }
        else if (tableonoff == tableOnoff.on && tablesolved == tableSolved.no)
        {
            dialogueGroup.tablePuzzleHint();
        }
        else
        {
            Debug.LogError("hint error");
        }
    }

    // blind가 눌렸을 때 창이 닫히도록
    private void turnOff()
    {
        blindonoff = blindOnoff.off;
        hintonoff = hintOnoff.off;
        inputGroup.SetActive(false);
        blockGroup.SetActive(false);
        mainGroup.SetActive(false);
        magnetGroup.SetActive(false);
        doorkey.SetActive(false);
        battery1.SetActive(false);
        battery2.SetActive(false);
        input.clear();
        dialogueGroup.closeCorutine();

        if (tvonoff == tvOnoff.on)
        {
            tvonoff = tvOnoff.off;
        }
        if (livRackonoff == livRackOnoff.on)
        {
            livRackonoff = livRackOnoff.off;
        }
        if (matonoff == matOnoff.on)
        {
            matonoff = matOnoff.off;
        }
        if (sofaonoff == sofaOnoff.on)
        {
            sofaonoff = sofaOnoff.off;
        }
        if (mainDooronoff == mainDoorOnoff.on)
        {
            mainDooronoff = mainDoorOnoff.off;
        }
        if (displayRackonoff == displayRackOnoff.on)
        {
            displayRackonoff = displayRackOnoff.off;
        }
        if (refrigeratoronoff == refrigeratorOnoff.on)
        {
            refrigeratoronoff = refrigeratorOnoff.off;
        }
        if (tableonoff == tableOnoff.on)
        {
            tableonoff = tableOnoff.off;
        }
    }

    // 아무것도 없는 곳 스캔했을 때
    public void blindOff()
    {
        blindonoff = blindOnoff.off;
        hintonoff = hintOnoff.off;
    }

    // tv sprite change
    public void tvStateOpen()
    {
        tvImage.sprite = tvOpen;
        tvsolved = tvSolved.yes;
        inputGroup.SetActive(false);
        doorkey.SetActive(true);
        tvAudio.Play();
        dialogueGroup.tvOpenDialogue();
    }

    // livRack sprite change
    public void livRackStateOpen()
    {
        livRackImage.sprite = livRackOpen;
        livRacksolved = livRackSolved.yes;
        blockGroup.SetActive(false);
        livRackAudio.Play();
        dialogueGroup.livRackOpenDialogue();
    }

    public AudioClip getBlockSound(int index)
    {
        if (index == 0)
        {
            return magnetAttach;
        }
        else
        {
            return magnetDetach;
        }
    }

    // mat sprite change
    public void matStateOpen()
    {
        matImage.sprite = matOpen;
        matsolved = matSolved.yes;
        inputGroup.SetActive(false);
        battery1.SetActive(true);
        matAudio.Play();
        dialogueGroup.matOpenDialogue();
    }

    // mainDoorHandle sprite change
    public void mainDoorHandleOpen()
    {
        mainDoorImage.sprite = mainDoorOpen;
        mainDoorKeyget = mainDoorKeyGet.yes;
    }

    // mainDoorHandle sprite send
    public Sprite getMainButtonSprite(int index)
    {
        return mainDoorButtons[index];
    }

    // mainDoor puzzle clear
    public void mainDoorPuzzleOpen()
    {
        mainDoorsolved = mainDoorSolved.yes;
        mainDoorStateOpen();
    }

    // popup open
    public void mainDoorStateOpen()
    {
        if (mainDoorKeyget == mainDoorKeyGet.yes
            && mainDoorsolved == mainDoorSolved.yes)
        {
            popupGroup.SetActive(true);
        }
    }

    // scene change
    private void loadScene()
    {
        SceneManager.LoadScene("3)second_yard");
    }

    // displayRack sprite change - battery
    public void displayRackPuzzleOpen()
    {
        if ((getbattery1 == getBattery1.yes && getbattery2 == getBattery2.no)
            || (getbattery1 == getBattery1.no && getbattery2 == getBattery2.yes))
        {
            displayRackImage.sprite = displayRackBattery1;
        } else if (getbattery1 == getBattery1.yes && getbattery2 == getBattery2.yes)
        {
            displayRackImage.sprite = displayRackClose;
            dialogueGroup.displayRackPuzzleDialogue();
        }
    }

    // displayRack sprite change - open
    public void displayRackStateOpen()
    {
        displayRackImage.sprite = displayRackOpen;
        displayRacksolved = displayRackSolved.yes;
        inputGroup.SetActive(false);
        displayRackAudio.Play();
        dialogueGroup.displayRackOpenDialogue();
    }

    // refrigerator sprite change
    public void refrigeratorStateOpen()
    {
        refrigeratorImage.sprite = refrigeratorOpen;
        refrigeratorsolved = refrigeratorSolved.yes;
        magnetGroup.SetActive(false);
        battery2.SetActive(true);
        refrigeratorAudio.Play();
        dialogueGroup.refrigeratorOpenDialogue();
    }

    // magnet sprite send
    public Sprite getMagnetSprite(int index)
    {
        return magnetImages[index];
    }

    // magnet sound send
    public AudioClip getMagnetSound(int index)
    {
        if (index == 0)
        {
            return magnetAttach;
        } else
        {
            return magnetDetach;
        }
    }

    public void tableStateOpen()
    {
        tableImage.sprite = tableOpen;
        tablesolved = tableSolved.yes;
        inputGroup.SetActive(false);
        dialogueGroup.tableOpenDialogue();
    }
}
