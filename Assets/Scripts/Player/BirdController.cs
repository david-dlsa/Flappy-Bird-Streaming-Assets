using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    public float speed = 1f; // Velocidade de subida do pássaro
    private Rigidbody2D rigidBody2D; // Referência ao componente Rigidbody2D

    public GameObject gameOverPanel; // Painel de Game Over a ser ativado quando o pássaro colidir

    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>(); // Obtém a referência ao componente Rigidbody2D do objeto
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            rigidBody2D.velocity = Vector2.up * speed; // Aplica uma velocidade vertical positiva para fazer o pássaro subir
        }
    }

    // Função chamada quando ocorre uma colisão 2D
    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameOverPanel.SetActive(true); // Ativa o painel de Game Over
        Time.timeScale = 0f; // Pausa o tempo do jogo
    }
}
