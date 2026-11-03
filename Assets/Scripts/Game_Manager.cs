using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    string marcador;
    public int p1 = 0;
    public int p2 = 0;
    public AudioClip PointScoredSound;
    public TextMeshProUGUI marcadorTXT;
    AudioSource _audiosource;
    private void Start()
    {
        marcador = "0|0";
        Debug.Log(p1 + "|" + p2);
    }
    public void UpdatePointsText()
    {
        marcadorTXT.text = marcador;
        marcador = (p1 + "|" + p2);
        _audiosource.Play();
    }
    //private void OnCollisionEnter2D (Collision2D collision)
    //{
    //    if (collision.gameObject.name == "Wall_D")
    //    {
    //        p1 ++;
    //        Debug.Log("PuntoP1");
    //    }
    //}
}