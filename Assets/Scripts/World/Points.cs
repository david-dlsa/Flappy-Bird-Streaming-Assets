using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
    public GameManager gameManager;

    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>(); // Obt�m a refer�ncia ao objeto com componente GameManager
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        gameManager.score++; // Incrementa a pontua��o ao triggar colis�o
        gameManager.scoreText.text = gameManager.score.ToString(); // Atribui ao objeto de texto a pontua��o num�rica convertida em texto
    }
}
