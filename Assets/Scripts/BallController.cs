using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float BallVelocity = 10f;
    public float TimeAlive = 0f;
    public float VelocityMulty = 1;
    public Game_Manager gameManager;

    AudioSource _audioSource;
    Rigidbody2D _rb;
    float _lastHorizontalDirection = 1f;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _audioSource = GetComponent<AudioSource>();
        LaunchBall(0);
    }
    private void Update()
    {
        if (TimeAlive > 2f && VelocityMulty < 2)
        {
            VelocityMulty += 0.25f;
            BallVelocity *= VelocityMulty;
            TimeAlive = 0f;
        }
        else
        {
            TimeAlive += Time.deltaTime;
        }
    }
    void FixedUpdate()
    {
        if (_rb.velocity.magnitude > BallVelocity)
        {
            _rb.velocity = _rb.velocity.normalized * BallVelocity;
        }

        if (Mathf.Abs(_rb.velocity.x) >= BallVelocity * 0.3f)
        {
            _lastHorizontalDirection = Mathf.Sign(_rb.velocity.x);
        }
        else
        {
            float yDirection = Mathf.Sign(_rb.velocity.y);

            if (yDirection == 0f)
            {
                yDirection = 1f;
            }

            float minX = 0.3f;
            float y = Mathf.Sqrt(1f - minX * minX);

            _rb.velocity = new Vector2(
                _lastHorizontalDirection * minX,
                yDirection * y
            ) * BallVelocity;
        }
        gameManager.UpdatePointsText();
    }

    void LaunchBall(int dir)
    {
        BallVelocity = 10;
        VelocityMulty = 1f;
        TimeAlive = 0f;
        this.transform.position = new Vector3(0, 0, 0);
        if (dir == 0)
        {
            _lastHorizontalDirection = Random.value > 0.5f ? 1f : -1f;
        }
        else
        {
            _lastHorizontalDirection = dir;
        }
        float yVelocity = Random.Range(-0.7f, 0.7f);

        _rb.velocity = new Vector2(_lastHorizontalDirection, yVelocity).normalized * BallVelocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall_D"))
        {
            gameManager.p1++;
            LaunchBall(-1);
        }
        if (collision.gameObject.CompareTag("Wall_I"))
        {
            gameManager.p2++;
            LaunchBall(1);
        }
        Debug.Log("Ball Hit");
        _audioSource.pitch = Random.Range(0.8f, 1.2f);
        _audioSource.Play();
    }


}
