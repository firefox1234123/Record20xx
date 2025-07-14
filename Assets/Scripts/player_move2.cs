using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_move2 : MonoBehaviour
{
    private Rigidbody2D playerRb;
    private Animator playerAnim;
    private AudioSource scanningAudio;
    private Vector2 playerVector;

    private float speed = 5f;
    private float minScale = 1f;
    private float maxScale = 1.5f;
    private float minY = -3.6f;
    private float maxY = -0.9f;
    private float scaleChangeSpeed = 5f;

    private puzzleManager2 puzzle;
    private dialogue_group dialogue;

    private bool isColliding = false;
    private string objectName; // 현재 충돌한 사물을 전달하기 위함

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
        scanningAudio = GetComponent<AudioSource>();

        puzzle = GameObject.Find("Canvas").GetComponent<puzzleManager2>();
        dialogue = GameObject.Find("dialogue_group").GetComponent<dialogue_group>();
    }

    void Update()
    {
        playerVector.x = Input.GetAxisRaw("Horizontal");
        playerVector.y = Input.GetAxisRaw("Vertical");

        playerRb.velocity = playerVector * speed;

        Vector3 playerPos = transform.position;
        playerPos.x = Mathf.Clamp(playerPos.x, -15.3f, 5.6f);
        playerPos.y = Mathf.Clamp(playerPos.y, minY, maxY);
        transform.position = playerPos;

        playerAnim.SetFloat("MoveX", playerRb.velocity.x);
        playerAnim.SetFloat("MoveY", playerRb.velocity.y);

        changeScale();

        // 스캔 모션 & 퍼즐화면 띄우기
        if (isColliding && Input.GetKeyDown(KeyCode.E))
        {
            playerAnim.SetTrigger("isScanning");
            scanningAudio.Play();
            StartCoroutine(loadPuzzle());
        }
    }

    // 플레이어 y좌표에 따른 크기 변경
    private void changeScale()
    {
        float t = Mathf.InverseLerp(minY, maxY, transform.position.y);
        float targetScale = Mathf.Lerp(maxScale, minScale, t);

        Vector3 currentScale = transform.localScale;
        float newScale = Mathf.Lerp(currentScale.x, targetScale, Time.deltaTime * scaleChangeSpeed);

        newScale = Mathf.Clamp(newScale, minScale, maxScale);

        transform.localScale = new Vector3(newScale, newScale, 1);
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        //playerState = PlayerState.Stop;

        isColliding = true;
        objectName = other.collider.name;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        isColliding = false;
    }

    // mainDoor, subDoor에서만 작동
    private void OnTriggerStay2D(Collider2D other)
    {
        isColliding = true;
        objectName = other.name;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        isColliding = false;
    }

    IEnumerator loadPuzzle()
    {
        yield return new WaitForSeconds(1.1f);
        puzzle.blindonoff = puzzleManager2.blindOnoff.on;
        puzzle.hintonoff = puzzleManager2.hintOnoff.on;
        switch (objectName)
        {
            case "object_pipe":
                puzzle.pipeonoff = puzzleManager2.pipeOnoff.on;
                break;
            case "object_mainDoor":
                puzzle.mainDooronoff = puzzleManager2.mainDoorOnoff.on;
                break;
            case "object_garden":
                puzzle.gardenonoff = puzzleManager2.gardenOnoff.on;
                break;
            case "object_subDoor":
                puzzle.subDooronoff = puzzleManager2.subDoorOnoff.on;
                break;
            case "object_jangttokttae":
                puzzle.jangttokttaeonoff = puzzleManager2.jangttokttaeOnoff.on;
                break;
            default:
                puzzle.blindOff();
                dialogue.thereIsNothing();
                break;
        }
    }
}
