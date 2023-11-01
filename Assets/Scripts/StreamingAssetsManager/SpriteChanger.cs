using System.IO;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class SpriteChanger : MonoBehaviour
{
    public SpriteRenderer spriteRenderer; // O componente SpriteRenderer que você deseja alterar

    public string spriteFileName; // Variável para o nome do arquivo

    void Start()
    {
        ChangeSprite(spriteFileName);
    }

    public void ChangeSprite(string spriteName)
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, "Sprites", spriteName);


        Texture2D texture = LoadTexture(filePath);

        if (texture != null)
        {
            spriteRenderer.sprite = Sprite.Create(
                texture,
                new Rect(0, 0, texture.width, texture.height),
                new Vector2(0.5f, 0.5f)
            );
        }
    }

    private Texture2D LoadTexture(string filePath)
    {
        byte[] fileData = System.IO.File.ReadAllBytes(filePath);
        Texture2D texture = new Texture2D(2, 2);

        if (texture.LoadImage(fileData))
        {
            return texture;
        }

        return null;
    }
}
