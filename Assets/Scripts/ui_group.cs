using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ui_group : MonoBehaviour
{
    private Sprite[] items;

    private Image doorkeyOff; // ui doorkey
    private Sprite doorkeyOn;

    private Image battery2Off; // ui battery2
    private Sprite battery2On;

    private Image battery1Off; // ui battery1
    private Sprite battery1On;

    private AudioSource getItem;

    void Start()
    {
        items = Resources.LoadAll<Sprite>("UIs/ui_item");

        doorkeyOff = GameObject.Find("doorkey").GetComponent<Image>();
        doorkeyOn = items[5];

        battery1Off = GameObject.Find("battery1").GetComponent<Image>();
        battery1On = items[2];

        battery2Off = GameObject.Find("battery2").GetComponent<Image>();
        battery2On = items[2];

        getItem = GetComponent<AudioSource>();
    }

    public void changeDoorkey()
    {
        getItem.Play();
        doorkeyOff.sprite = doorkeyOn;
    }

    public void changeBattery1()
    {
        getItem.Play();
        battery1Off.sprite = battery1On;
    }

    public void changeBattery2()
    {
        getItem.Play();
        battery2Off.sprite = battery2On;
    }

    void Update()
    {
        
    }
}
