using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[Serializable]
public class GameObjectSpriteMapping
{
    public SpriteRenderer spriteRenderer;
    public string spriteName;
}

public class SpriteManager : MonoBehaviour
{
    public List<GameObjectSpriteMapping> spriteRenderersToUpdate = new List<GameObjectSpriteMapping>();

    private void Start()
    {
        LoadSprites();
    }

    public void LoadSprites()
    {
        foreach (var mapping in spriteRenderersToUpdate)
        {
            string spriteName = mapping.spriteName;

            // Carrega o sprite da pasta local
            Texture2D texture = LoadTexture(spriteName);

            if (texture != null)
            {
                Sprite newSprite = Sprite.Create(
                    texture,
                    new Rect(0, 0, texture.width, texture.height),
                    new Vector2(0.5f, 0.5f)
                );

                // Atualiza o SpriteRenderer com o novo sprite
                mapping.spriteRenderer.sprite = newSprite;
            }
        }
    }

    private Texture2D LoadTexture(string spriteName)
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, "Sprites", spriteName);
        byte[] fileData = System.IO.File.ReadAllBytes(filePath);
        Texture2D texture = new Texture2D(2, 2);

        if (texture.LoadImage(fileData))
        {
            return texture;
        }

        return null;
    }
}
