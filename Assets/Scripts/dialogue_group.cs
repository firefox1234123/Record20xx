using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class dialogue_group : MonoBehaviour, IPointerClickHandler
{
    private GameObject dialogue;
    private TextMeshProUGUI title;
    private TextMeshProUGUI content;

    IEnumerator corutine;

    void Start()
    {
        dialogue = GameObject.Find("dialogue");
        title = GameObject.Find("dialogue_title").GetComponent<TextMeshProUGUI>();
        content = GameObject.Find("dialogue_content").GetComponent<TextMeshProUGUI>();

        title.text = "나";

        InfoDialogue();
    }

    void Update()
    {

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        closeCorutine();
    }

    // stage1 : home
    private void InfoDialogue()
    {
        resetCorutine(10f);
        content.text = "사물에 가까이 간 뒤, 'E'를 눌러 스캔할 수 있어.";
    }

    public void tvPuzzleDialogue()
    {
        resetCorutine(10f);
        content.text = "같은 문자끼리는 같은 숫자겠지?\n(* 4자리 숫자를 입력해주세요.)";
    }
    public void tvPuzzleHint()
    {
        resetCorutine(10f);
        content.text = "AA를 11, 22 식으로 대입해서 BBCC가\n나오는 숫자를 구해보자.";
    }
    public void tvOpenDialogue()
    {
        resetCorutine(5f);
        content.text = "열렸다! 이 막대기는 어디에 쓰는거지?";
    }

    public void livRackPuzzleDialogue()
    {
        resetCorutine(10f);
        content.text = "숫자블럭으로 4개의 숫자를 만들 수 있을까?\n(* 숫자를 움직일 수 있습니다)";
    }
    public void livRackPuzzleHint()
    {
        resetCorutine(10f);
        content.text = "양쪽의 숫자를 더하고 빼면 가운데 숫자가 나와.\n예를 들면 14 + 22 = 36이라거나...";
    }
    public void livRackOpenDialogue()
    {
        resetCorutine(5f);
        content.text = "열렸어!\n이상한 쪽지는... 일단 기억해두자.";
    }

    public void matPuzzleDialogue()
    {
        resetCorutine(10f);
        content.text = "여기는 문제가 없어. 문제만 있는 곳이 있나?\n(* 4자리 숫자를 입력해주세요)";
    }
    public void matPuzzleHint()
    {
        resetCorutine(10f);
        content.text = "미로에서 봤던 숫자를 입력해줘.\n만약 세 자리라면 0123을 입력해야 해.";
    }
    public void matOpenDialogue()
    {
        resetCorutine(5f);
        content.text = "이건 어디에 쓰는 걸까?";
    }

    public void sofaPuzzleDialogue()
    {
        resetCorutine(10f);
        content.text = "미로를 따라가볼까?\n그런데 답을 입력할만한 곳은 없네.";
    }
    public void sofaPuzzleHint()
    {
        resetCorutine(10f);
        content.text = "미로 속 길을 칠하면 숫자가 보여.\n희미하게... 2...6인 것 같아.";
    }

    public void mainDoorPuzzleDialogue()
    {
        resetCorutine(10f);
        content.text = "여기는 꽤 복잡하네.\n많은 힌트와 도구가 필요할 것 같아.";
    }
    public void mainDoorPuzzleHint()
    {
        resetCorutine(10f);
        content.text = "열쇠 하나와... 문양이 적힌 걸 찾아야 해.\n입력할 때 모서리의 무늬에 주의해!";
    }

    public void displayRackBatteryDialogue()
    {
        resetCorutine(10f);
        content.text = "무언가가 빠져있어. 전원을 공급할 수 있는\n무언가를 찾아야 해.";
    }
    public void displayRackPuzzleDialogue()
    {
        resetCorutine(5f);
        content.text = "좋아! 이제 키패드가 작동할거야.";
    }
    public void displayRackPuzzleHint()
    {
        resetCorutine(10f);
        content.text = "A에 1, 2, 3순으로 대입해봐.\n일단 A는 2인 것 같아.";
    }
    public void displayRackOpenDialogue()
    {
        resetCorutine(5f);
        content.text = "열렸어!\n이 쪽지는... 언제 필요하지?";
    }

    public void refrigeratorPuzzleDialogue()
    {
        resetCorutine(10f);
        content.text = "이 금속은 어떻게 붙어있는거지?\n(* 클릭하여 돌릴 수 있습니다)";
    }
    public void refrigeratorPuzzleHint()
    {
        resetCorutine(10f);
        content.text = "돌아가는 자석으로 수식을 만들면 돼.\n1처럼 생긴 거... 돌리면 -일지도?";
    }
    public void refrigeratorOpenDialogue()
    {
        resetCorutine(5f);
        content.text = "이건 어디에 쓰는 걸까?";
    }

    public void tablePuzzleDialogue()
    {
        resetCorutine(10f);
        content.text = "큰 그림에 작은 도형이 몇 개 있는가...?\n(* 4자리 숫자를 입력해주세요)";
    }
    public void tablePuzzleHint()
    {
        resetCorutine(10f);
        content.text = "도형을 조합해서 오각형의 개수를 새면 돼.\n3종류의 오각형이...4개씩 있는 것 같아.";
    }
    public void tableOpenDialogue()
    {
        resetCorutine(5f);
        content.text = "됐어!\n이 쪽지는... 어느 문제의 힌트인가?";
    }


    // stage2 : yard
    public void pipePuzzleDialogue()
    {
        resetCorutine(5f);
        content.text = "수도꼭지를 돌릴 수 있어.";
    }
    public void pipePuzzleHint()
    {
        resetCorutine(10f);
        content.text = "옆집 문에 붙어있던 문제의 답을 입력하자.";
    }
    public void pipeOpenDialogue()
    {
        resetCorutine(5f);
        content.text = "뒤에 쪽지가 붙어있었어!";
    }

    public void mainDoorPuzzleDialogue2()
    {
        resetCorutine(5f);
        content.text = "아까와 같은 형식이야. 쪽지를 찾아보자.";
    }
    public void mainDoorPuzzleHint2()
    {
        resetCorutine(10f);
        content.text = "여기는 열쇠가 없어. 쪽지만 찾으면 돼.\n입력할 때 모서리 무늬에 유의해.";
    }

    public void gardenPuzzleDialogue()
    {
        resetCorutine(5f);
        content.text = "화살표를 따라... 전부 눌러야 할 것 같아.";
    }
    public void gardenPuzzleHint()
    {
        resetCorutine(10f);
        content.text = "가장 오른쪽 아래에서 시작해서...\n오른쪽 위까지 화살표를 따라가보자!";
    }
    public void gardenOpenDialogue()
    {
        resetCorutine(5f);
        content.text = "좋아! 아래에 쪽지가 있었어!";
    }

    public void subDoorPuzzleDialogue()
    {
        resetCorutine(5f);
        content.text = "이 문제 역시 답을 입력할 곳이 없어.";
    }
    public void subDoorPuzzleHint()
    {
        resetCorutine(10f);
        content.text = "1234=0, 5678=3...\n원이 몇 개 있는지가 중요해보여.";
    }

    public void jangttokttaePuzzleDialogue()
    {
        resetCorutine(5f);
        content.text = "이건 뭐지...? 물음표를 채워보라고?\n(* 숫자를 움직일 수 있습니다)";
    }
    public void jangttokttaePuzzleHint()
    {
        resetCorutine(10f);
        content.text = "숫자 3개를 더해서 하나의 숫자가 되려면\n...3과 9이려나?";
    }
    public void jangttokttaeOpenDialogue()
    {
        resetCorutine(5f);
        content.text = "됐다! 열렸어! 안에 작은 쪽지가 있네.";
    }

    // extra
    public void thereIsNothing()
    {
        resetCorutine(5f);
        content.text = "이곳엔 아무것도 없어.\n다른 곳을 스캔해보자.";
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
            dialogue.SetActive(false);
        }
    }

    IEnumerator OpenAndClose(float time)
    {
        dialogue.SetActive(true);
        yield return new WaitForSeconds(time);
        dialogue.SetActive(false);
    }
}