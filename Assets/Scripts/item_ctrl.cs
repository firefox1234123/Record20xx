using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class item_ctrl : MonoBehaviour, IPointerClickHandler
{
    private puzzleManager puzzle;
    private ui_group uiGroup;

    private string objectName;

    void Start()
    {
        puzzle = GameObject.Find("Canvas").GetComponent<puzzleManager>();
        uiGroup = GameObject.Find("UI").GetComponent<ui_group>();

        objectName = gameObject.name;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (objectName == "item_doorkey")
        {
            puzzle.getdoorkey = puzzleManager.getDoorkey.yes;
            uiGroup.changeDoorkey();
        }
        else if (objectName == "item_battery1")
        {
            puzzle.getbattery1 = puzzleManager.getBattery1.yes;
            puzzle.displayRackPuzzleOpen();
            uiGroup.changeBattery1();
        } else if (objectName == "item_battery2")
        {
            puzzle.getbattery2 = puzzleManager.getBattery2.yes;
            puzzle.displayRackPuzzleOpen();
            uiGroup.changeBattery2();
        }
    }

    void Update()
    {
        
    }
}
