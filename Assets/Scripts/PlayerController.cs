using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Velocidad = 50f;//Velocidad bola
    public float topheight = 3;//Altura limite
    public float botheight = -3;
    public bool UseArrowKeys = false;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MovePaddle();
    }
    void MovePaddle()
    {
        this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, ConstrainPaddle(), transform.position.z);
    }
    float ConstrainPaddle()
    {
        float nuevaY = this.gameObject.transform.position.y + (PaddleDirection() * Velocidad * Time.deltaTime);
        if (nuevaY > topheight)
        {
            nuevaY = topheight;
        }
        
        if (nuevaY < botheight)
        {
            nuevaY = botheight;
        }
        return nuevaY;
    }

    float PaddleDirection ()
    {
        float Direccion = 0f;

        if (UseArrowKeys == true)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                Debug.Log("Pulsando FlechaArriba ");
                Direccion = 1f;
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                Debug.Log("Pulsando FlechaAbajo ");
                Direccion = -1f;
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.W))
            {
                Debug.Log("Pulsando W ");
                Direccion = 1f;
            }

            if (Input.GetKey(KeyCode.S))
            {
                Debug.Log("Pulsando S ");
                Direccion = -1f;
            }
        }
        return Direccion;
    }
}
