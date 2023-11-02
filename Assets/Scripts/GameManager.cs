using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI scoreText;

    private void Start()
    {
        // Libera tempo do jogo
        Time.timeScale = 1f;
    }

    public void RestartGame()
    {
        //Carrega a cena do jogo
        SceneManager.LoadScene(0);
    }
}
