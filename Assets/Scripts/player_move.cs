using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_move : MonoBehaviour
{

    // player 관련
    private Rigidbody2D playerRb;
    private Animator playerAnim;
    private AudioSource scanningAudio;
    private Vector2 playerVector;

    //private PlayerState playerState;
    private float speed = 5f;
    private float minScale = 1f;
    private float maxScale = 1.5f;
    private float minY = -3.6f;
    private float maxY = -0.9f;
    private float minX = -2f;
    private float maxX = 1.2f;
    private float scaleChangeSpeed = 5f;

    private puzzleManager puzzle;
    private dialogue_group dialogue;

    private GameObject tv;
    private float transAlpha = 0.6f; // 투명도
    private float originAlpha = 1.0f;
    private SpriteRenderer tvSpriterenderer;
    private Color tvColor;

    private bool isColliding = false;
    private string objectName; // 현재 충돌한 사물을 전달하기 위함

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
        scanningAudio = GetComponent<AudioSource>();

        puzzle = GameObject.Find("Canvas").GetComponent<puzzleManager>();

        tv = GameObject.Find("object_home_tv");
        tvSpriterenderer = tv.GetComponent<SpriteRenderer>();
        if (tvSpriterenderer != null)
        {
            tvColor = tvSpriterenderer.color;
        } else
        {
            Debug.Log("tv sprite error");
        }

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

        if (tvSpriterenderer != null)
        {
            float playerX = transform.position.x;

            if (playerX >= minX && playerX <= maxX)
            {
                setTransparency(transAlpha);
            } else
            {
                setTransparency(originAlpha);
            }
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

    // 플레이어가 tv와 겹치면 tv투명하게
    private void setTransparency(float alpha)
    {
        if (tvSpriterenderer != null)
        {
            Color color = tvSpriterenderer.color;
            color.a = alpha;
            tvSpriterenderer.color = color;
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        //playerState = PlayerState.Stop;
        if (other.collider.tag == "background")
        {
            // nothing
        } else
        {
            isColliding = true;
            objectName = other.collider.name;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        isColliding = false;
    }

    // mainDoor, mat에서만 작동
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
        puzzle.blindonoff = puzzleManager.blindOnoff.on;
        puzzle.hintonoff = puzzleManager.hintOnoff.on;
        switch (objectName)
        {
            case "object_home_tv":
                puzzle.tvonoff = puzzleManager.tvOnoff.on;
                break;
            case "object_home_livRack":
                puzzle.livRackonoff = puzzleManager.livRackOnoff.on;
                break;
            case "object_home_sofa":
                puzzle.sofaonoff = puzzleManager.sofaOnoff.on;
                break;
            case "object_home_mat":
                puzzle.matonoff = puzzleManager.matOnoff.on;
                break;
            case "object_home_mainDoor":
                puzzle.mainDoorStateOpen();
                puzzle.mainDooronoff = puzzleManager.mainDoorOnoff.on;
                break;
            case "object_home_displayRack":
                puzzle.displayRackonoff = puzzleManager.displayRackOnoff.on;
                break;
            case "object_home_refrigerator":
                puzzle.refrigeratoronoff = puzzleManager.refrigeratorOnoff.on;
                break;
            case "object_home_table":
                puzzle.tableonoff = puzzleManager.tableOnoff.on;
                break;
            default:
                puzzle.blindOff();
                dialogue.thereIsNothing();
                break;
        }
    }
}