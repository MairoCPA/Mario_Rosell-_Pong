using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCOntroller : MonoBehaviour
{
    public float velocidad = 10f;
    private Rigidbody2D _rb;

    void Start()
    {
        _rb = this.gameObject.GetComponent<Rigidbody2D>();
        Launchball();

        //_rb.velocity = new Vector3(Random.Range(0, 2), Random.Range(-0.5f, 9.5f)).normalized * velocidad;
    }

    void FixedUpdate()
    {
            _rb.velocity = _rb.velocity.normalized * velocidad;

    }
        void Launchball()
        {
            bool isRight = false;
            if (Random.value > 0.5f)
            {
                isRight = true;
            }
            float xVelocity = -1;
            if (isRight == true )
            {
                xVelocity = 1;
            }

            float yVelocity = Random.Range(-1f, 1f);
            _rb.velocity = new Vector2(xVelocity * velocidad, yVelocity * velocidad);

        }
}