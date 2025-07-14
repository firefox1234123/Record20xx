using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class puzzleManager2 : MonoBehaviour
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
    public enum pipeOnoff
    {
        on, off
    }
    public enum mainDoorOnoff
    {
        on, off
    }
    public enum gardenOnoff
    {
        on, off
    }
    public enum subDoorOnoff
    {
        on, off
    }
    public enum jangttokttaeOnoff
    {
        on, off
    }

    // 해결 유무를 담아두는 enum (subDoor는 필요X)
    private enum pipeSolved
    {
        no, yes
    }
    private enum mainDoorSolved
    {
        no, yes
    }
    private enum gardenSolved
    {
        no, yes
    }
    private enum jangttokttaeSolved
    {
        no, yes
    }

    // 퍼즐 설명 대사 출력 유무 확인(삭제 가능성O)
    private enum pipeisFirst
    {
        no, yes
    }
    private enum mainDoorisFirst
    {
        no, yes
    }
    private enum gardenisFirst
    {
        no, yes
    }
    private enum subDoorisFirst
    {
        no, yes
    }
    private enum jangttokttaeisFirst
    {
        no, yes
    }
    
    private dialogue_group dialogueGroup;

    public pipeOnoff pipeonoff;
    public mainDoorOnoff mainDooronoff;
    public gardenOnoff gardenonoff;
    public subDoorOnoff subDooronoff;
    public jangttokttaeOnoff jangttokttaeonoff;

    private pipeSolved pipesolved = pipeSolved.no;
    private mainDoorSolved mainDoorsolved = mainDoorSolved.no;
    private gardenSolved gardensolved = gardenSolved.no;
    private jangttokttaeSolved jangttokttaesolved = jangttokttaeSolved.no;

    private pipeisFirst pipeisfirst = pipeisFirst.yes;
    private mainDoorisFirst mainDoorisfirst = mainDoorisFirst.yes;
    private gardenisFirst gardenisfirst = gardenisFirst.yes;
    private subDoorisFirst subDoorisfirst = subDoorisFirst.yes;
    private jangttokttaeisFirst jangttokttaeisfirst = jangttokttaeisFirst.yes;

    public blindOnoff blindonoff;
    private GameObject blind;
    private Button blindButton;

    public hintOnoff hintonoff;
    private GameObject hintGroup;

    private GameObject arrowGroup;
    private GameObject stampGroup;
    private GameObject mainGroup;
    private GameObject handleGroup;

    private GameObject pipe;
    private Image pipeImage;
    private Sprite pipeOpen;
    private Sprite handleOpen;
    private Sprite handleClose;

    private GameObject mainDoor;
    private Sprite[] mainDoorButtons;

    private GameObject popupGroup;
    private Button okButton;

    private GameObject garden;
    private Image gardenImage;
    private Sprite gardenOpen;
    private Sprite[] gardenButtons;
    private AudioSource gardenAudio;

    private GameObject subDoor;

    private GameObject jangttokttae;
    private Image jangttokttaeImage;
    private Sprite jangttokttaeOpen;
    private Sprite[] jangttokttaeButtons;
    private AudioSource jangttokttaeAudio;
    private AudioClip stampAttach;
    private AudioClip stampDetach;

    void Start()
    {
        dialogueGroup = GameObject.Find("dialogue_group").GetComponent<dialogue_group>();

        blind = GameObject.Find("blind");
        blindButton = blind.GetComponent<Button>();
        blindButton.onClick.AddListener(() => turnOff());
        blindonoff = blindOnoff.off;

        hintGroup = GameObject.Find("hint_group");
        hintonoff = hintOnoff.off;

        arrowGroup = GameObject.Find("arrow_group");
        arrowGroup.SetActive(false);

        stampGroup = GameObject.Find("stamp_group");
        stampGroup.SetActive(false);

        mainGroup = GameObject.Find("main_group");
        mainGroup.SetActive(false);

        handleGroup = GameObject.Find("handle_group");
        handleGroup.SetActive(false);

        pipe = GameObject.Find("pipe");
        pipeImage = pipe.GetComponent<Image>();
        pipeOpen = Resources.Load<Sprite>("Puzzles/Puzzle_yard_pipe_side");
        handleOpen = Resources.Load<Sprite>("Puzzles/Puzzle_yard_pipe_open");
        handleClose = Resources.Load<Sprite>("Puzzles/Puzzle_yard_pipe_close");
        pipeonoff = pipeOnoff.off;

        mainDoor = GameObject.Find("mainDoor");
        mainDoorButtons = Resources.LoadAll<Sprite>("Puzzles/Puzzle_mainKeyPad");
        mainDooronoff = mainDoorOnoff.off;

        popupGroup = GameObject.Find("popup_group");
        okButton = GameObject.Find("popup_button_ok").GetComponent<Button>();
        okButton.onClick.AddListener(() => loadScene());
        popupGroup.SetActive(false);

        garden = GameObject.Find("garden");
        gardenImage = garden.GetComponent<Image>();
        gardenOpen = Resources.Load<Sprite>("Puzzles/Puzzle_yard_garden_open");
        gardenAudio = garden.GetComponent<AudioSource>();
        gardenButtons = Resources.LoadAll<Sprite>("Puzzles/Puzzle_yard_garden_key");
        gardenonoff = gardenOnoff.off;

        subDoor = GameObject.Find("subDoor");
        subDooronoff = subDoorOnoff.off;

        jangttokttae = GameObject.Find("jangttokttae");
        jangttokttaeImage = jangttokttae.GetComponent<Image>();
        jangttokttaeOpen = Resources.Load<Sprite>("Puzzles/Puzzle_yard_jangttokttae_open");
        jangttokttaeAudio = jangttokttae.GetComponent<AudioSource>();
        jangttokttaeButtons = Resources.LoadAll<Sprite>("Puzzles/Puzzle_yard_jangttokttae_num");
        stampAttach = Resources.Load<AudioClip>("Sounds/Sound_stamp_attach");
        stampDetach = Resources.Load<AudioClip>("Sounds/Sound_stamp_detach");
        jangttokttaeonoff = jangttokttaeOnoff.off;
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
        }
        else if (blindonoff == blindOnoff.off)
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

        // pipe onoff
        if (pipeonoff == pipeOnoff.on)
        {
            if (pipeisfirst == pipeisFirst.yes)
            {
                dialogueGroup.pipePuzzleDialogue();
                pipeisfirst = pipeisFirst.no;
            }

            pipe.SetActive(true);
            handleGroup.SetActive(true);
            if (pipesolved == pipeSolved.yes)
            {
                handleGroup.SetActive(false);
            }
        }
        else if (pipeonoff == pipeOnoff.off)
        {
            pipe.SetActive(false);
        }

        // mainDoor onoff
        if (mainDooronoff == mainDoorOnoff.on)
        {
            if (mainDoorisfirst == mainDoorisFirst.yes)
            {
                dialogueGroup.mainDoorPuzzleDialogue2();
                mainDoorisfirst = mainDoorisFirst.no;
            }

            mainDoor.SetActive(true);
            mainGroup.SetActive(true);
            if (mainDoorsolved == mainDoorSolved.yes)
            {
                mainGroup.SetActive(false);
            }
        }
        else if (mainDooronoff == mainDoorOnoff.off)
        {
            mainDoor.SetActive(false);
        }

        // garden onoff
        if (gardenonoff == gardenOnoff.on)
        {
            if (gardenisfirst == gardenisFirst.yes)
            {
                dialogueGroup.gardenPuzzleDialogue();
                gardenisfirst = gardenisFirst.no;
            }

            garden.SetActive(true);
            arrowGroup.SetActive(true);
            if (gardensolved == gardenSolved.yes)
            {
                arrowGroup.SetActive(false);
            }
        }
        else if (gardenonoff == gardenOnoff.off)
        {
            garden.SetActive(false);
        }

        // subDoor onoff
        if (subDooronoff == subDoorOnoff.on)
        {
            if (subDoorisfirst == subDoorisFirst.yes)
            {
                dialogueGroup.subDoorPuzzleDialogue();
                subDoorisfirst = subDoorisFirst.no;
            }

            subDoor.SetActive(true);
        }
        else if (subDooronoff == subDoorOnoff.off)
        {
            subDoor.SetActive(false);
        }

        // jangttokttae onoff
        if (jangttokttaeonoff == jangttokttaeOnoff.on)
        {
            if (jangttokttaeisfirst == jangttokttaeisFirst.yes)
            {
                dialogueGroup.jangttokttaePuzzleDialogue();
                jangttokttaeisfirst = jangttokttaeisFirst.no;
            }
            jangttokttae.SetActive(true);
            stampGroup.SetActive(true);
            if (jangttokttaesolved == jangttokttaeSolved.yes)
            {
                stampGroup.SetActive(false);
            }
        }
        else if (jangttokttaeonoff == jangttokttaeOnoff.off)
        {
            jangttokttae.SetActive(false);
        }
    }

    private void hintMessage()
    {
        if (pipeonoff == pipeOnoff.on && pipesolved == pipeSolved.no)
        {
            dialogueGroup.pipePuzzleHint();
        }
        else if (mainDooronoff == mainDoorOnoff.on && mainDoorsolved == mainDoorSolved.no)
        {
            dialogueGroup.mainDoorPuzzleHint2();
        }
        else if (gardenonoff == gardenOnoff.on && gardensolved == gardenSolved.no)
        {
            dialogueGroup.gardenPuzzleHint();
        }
        else if (subDooronoff == subDoorOnoff.on)
        {
            dialogueGroup.subDoorPuzzleHint();
        }
        else if (jangttokttaeonoff == jangttokttaeOnoff.on && jangttokttaesolved == jangttokttaeSolved.no)
        {
            dialogueGroup.jangttokttaePuzzleHint();
        }
        else
        {
            Debug.LogError("hint error");
        }
    }

    // blind 눌렸을 때 창 닫히도록
    private void turnOff()
    {
        blindonoff = blindOnoff.off;
        hintonoff = hintOnoff.off;
        arrowGroup.SetActive(false);
        stampGroup.SetActive(false);
        mainGroup.SetActive(false);
        handleGroup.SetActive(false);
        dialogueGroup.closeCorutine();

        if (pipeonoff == pipeOnoff.on)
        {
            pipeonoff = pipeOnoff.off;
        }
        if (mainDooronoff == mainDoorOnoff.on)
        {
            mainDooronoff = mainDoorOnoff.off;
        }
        if (gardenonoff == gardenOnoff.on)
        {
            gardenonoff = gardenOnoff.off;
        }
        if (subDooronoff == subDoorOnoff.on)
        {
            subDooronoff = subDoorOnoff.off;
        }
        if (jangttokttaeonoff == jangttokttaeOnoff.on)
        {
            jangttokttaeonoff = jangttokttaeOnoff.off;
        }
    }

    // 아무것도 없는 곳 스캔했을 때
    public void blindOff()
    {
        blindonoff = blindOnoff.off;
        hintonoff = hintOnoff.off;
    }

    public Sprite getPipeHandleSprite(int index)
    {
        if (index == 0)
        {
            return handleOpen;
        } else
        {
            return handleClose;
        }
    }

    public void pipeStateOpen()
    {
        pipeImage.sprite = pipeOpen;
        pipesolved = pipeSolved.yes;
        handleGroup.SetActive(false);
        dialogueGroup.pipeOpenDialogue();
    }

    public Sprite getMainButtonSprite(int index)
    {
        return mainDoorButtons[index];
    }

    public void mainDoorStateOpen()
    {
        mainDoorsolved = mainDoorSolved.yes;
        popupGroup.SetActive(true);
    }

    private void loadScene()
    {
        SceneManager.LoadScene("4)story_end");
    }

    public Sprite getGardenButtonSprite(int index)
    {
        return gardenButtons[index];
    }

    public void gardenStateOpen()
    {
        gardenImage.sprite = gardenOpen;
        gardensolved = gardenSolved.yes;
        arrowGroup.SetActive(false);
        gardenAudio.Play();
        dialogueGroup.gardenOpenDialogue();
    }

    public Sprite getStampSprite(int index)
    {
        return jangttokttaeButtons[index];
    }

    public AudioClip getStampSound(int index)
    {
        if (index == 0)
        {
            return stampAttach;
        } else
        {
            return stampDetach;
        }
    }

    public void jangttokttaeStateOpen()
    {
        jangttokttaeImage.sprite = jangttokttaeOpen;
        jangttokttaesolved = jangttokttaeSolved.yes;
        stampGroup.SetActive(false);
        jangttokttaeAudio.Play();
        dialogueGroup.jangttokttaeOpenDialogue();
    }
}
