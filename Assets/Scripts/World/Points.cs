using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
    public GameManager gameManager;

    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>(); // Obtém a referência ao objeto com componente GameManager
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        gameManager.score++; // Incrementa a pontuação ao triggar colisão
        gameManager.scoreText.text = gameManager.score.ToString(); // Atribui ao objeto de texto a pontuação numérica convertida em texto
    }
}
