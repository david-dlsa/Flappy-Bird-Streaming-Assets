using UnityEngine;

public class SpawnPipes : MonoBehaviour
{
    public GameObject pipe;
    public float height;
    public float delayBetweenPipes = 1f;
    public SpriteManager spriteManager;

    private float timer = 0f;

    void Start()
    {
        CreateAndSetPipeSprite();
    }

    void Update()
    {
        if (timer > delayBetweenPipes)
        {
            CreateAndSetPipeSprite();
            timer = 0;
        }
        timer += Time.deltaTime;
    }

    void CreateAndSetPipeSprite()
    {
        GameObject newPipe = Instantiate(pipe);
        newPipe.transform.position = transform.position + new Vector3(0, Random.Range(-height, height), 0);


        // Acesse o SpriteManager e defina os sprites para Pipe Up e Pipe Down
        spriteManager.ChangeSprite(newPipe, "Pipe.png");
        spriteManager.ChangeSprite(newPipe, "Pipe.png");
    }
}
