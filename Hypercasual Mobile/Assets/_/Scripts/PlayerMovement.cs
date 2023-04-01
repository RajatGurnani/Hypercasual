using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
    public ParticleSystem gameOverParticleSystem;
    public bool isMoving = false;
    public float moveSpeed;
    public int moveDir = 0; // will be either -1 or 1
    public Rigidbody2D rb2D;

    [Header("OnGameOver")]
    public float shrinkTime;
    public Vector3 shrinkScale = Vector3.zero;

    [Header("OnGameStarted")]
    public float growTime;
    public Vector3 growScale = Vector3.one;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Tags.Wall))
        {
            ChangeDirection();
        }

        if (collision.CompareTag(Tags.Enemy))
        {
            GameManager.GameOver?.Invoke();
        }
    }

    public void Start()
    {
        SelectRandomDirection();
    }

    public void SelectRandomDirection()
    {
        moveDir = Random.Range(0, 2) == 0 ? -1 : 1;
        rb2D.velocity = moveDir * moveSpeed * Vector2.right;
    }

    public void ChangeDirection()
    {
        moveDir *= -1;
        rb2D.velocity = moveDir * moveSpeed * Vector2.right;
    }
    private void Update()
    {
        ReadInputs();
    }

    public void ReadInputs()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ChangeDirection();
        }
    }

    public void GameOver()
    {
        transform.DOScale(shrinkScale, shrinkTime);
        // Shrink the player and after that play the particle system
        isMoving = false;
    }

    public void GameStarted()
    {
        transform.DOScale(growScale, growTime);
        // Grow the player to normal size and start moving
        isMoving = true;
    }

    private void OnEnable()
    {
        GameManager.GameOver += GameOver;
        GameManager.GameStarted += GameStarted;
    }

    private void OnDisable()
    {
        GameManager.GameOver += GameOver;
        GameManager.GameStarted -= GameStarted;
    }
}
