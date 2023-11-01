using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[Serializable]
public class ObjectSpriteMapping
{
    public string tag;
    public string spriteName;
}

public class SpriteManager : MonoBehaviour
{
    public List<ObjectSpriteMapping> objectSpriteMappings = new List<ObjectSpriteMapping>();

    private void Start()
    {
        // Encontre e atualize os sprites para objetos com as tags especificadas na configuração
        foreach (var mapping in objectSpriteMappings)
        {
            GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag(mapping.tag);
            foreach (var obj in objectsWithTag)
            {
                ChangeSprite(obj, mapping.spriteName);
            }
        }
    }

    public void ChangeSprite(GameObject obj, string spriteName)
    {
        // Carrega o sprite da pasta local
        Texture2D texture = LoadTexture(spriteName);

        if (texture != null)
        {
            Sprite newSprite = Sprite.Create(
                texture,
                new Rect(0, 0, texture.width, texture.height),
                new Vector2(0.5f, 0.5f)
            );

            // Atualiza o sprite no objeto
            SetObjectSprite(obj, newSprite);
        }
    }

    private void SetObjectSprite(GameObject obj, Sprite newSprite)
    {
        List<SpriteRenderer> spriteRenderers = FindSpriteRenderersRecursively(obj);

        foreach (var spriteRenderer in spriteRenderers)
        {
            spriteRenderer.sprite = newSprite;
        }
    }

    private List<SpriteRenderer> FindSpriteRenderersRecursively(GameObject obj)
    {
        List<SpriteRenderer> spriteRenderers = new List<SpriteRenderer>();
        FindSpriteRenderersRecursively(obj.transform, spriteRenderers);
        return spriteRenderers;
    }

    private void FindSpriteRenderersRecursively(Transform obj, List<SpriteRenderer> spriteRenderers)
    {
        var spriteRenderer = obj.GetComponent<SpriteRenderer>();

        if (spriteRenderer != null)
        {
            spriteRenderers.Add(spriteRenderer);
        }

        foreach (Transform child in obj)
        {
            FindSpriteRenderersRecursively(child, spriteRenderers);
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
