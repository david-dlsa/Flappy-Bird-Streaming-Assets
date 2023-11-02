using UnityEngine;

public class SpawnPipes : MonoBehaviour
{
    public GameObject pipe; // Prefab do cano
    public float height; // Altura máxima para a posição vertical dos canos
    public float delayBetweenPipes = 1f; // Atraso entre a criação de canos
    public SpriteManager spriteManager; // Referência ao SpriteManager

    private float timer = 0f; // Contador de tempo

    void Start()
    {
        CreateAndSetPipeSprite();
    }

    void Update()
    {
        // Verifica se o timer atingiu o atraso especificado para criar um novo cano
        if (timer > delayBetweenPipes)
        {
            CreateAndSetPipeSprite(); // Chama a função para criar um novo cano
            timer = 0; // Reinicia o timer
        }

        timer += Time.deltaTime; // Incrementa o timer com o tempo decorrido
    }

    // Função para criar um novo cano e definir seu sprite
    void CreateAndSetPipeSprite()
    {
        GameObject newPipe = Instantiate(pipe); // Instancia um novo cano a partir do prefab
        newPipe.transform.position = transform.position + new Vector3(0, Random.Range(-height, height), 0);

        // Acesse o SpriteManager e defina os sprites para Pipe Up e Pipe Down
        spriteManager.ChangeSprite(newPipe, "Pipe.png");
    }
}
