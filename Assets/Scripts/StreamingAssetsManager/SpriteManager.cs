using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

[Serializable]
public class ObjectSpriteMapping
{
    public string tag;         // A tag do objeto
    public string spriteName;  // O nome do sprite na pasta StreamingAssets
}

[Serializable]
public class SpriteMapping
{
    public string tag;                // A tag do objeto
    public string currentSpriteName;  // O nome do sprite atual na pasta Sprites
    public string newSpriteName;      // O nome do novo sprite na pasta StreamingAssets
}

public class SpriteManager : MonoBehaviour
{
    public List<ObjectSpriteMapping> objectSpriteMappings = new List<ObjectSpriteMapping>();
    public List<SpriteMapping> spriteMappings = new List<SpriteMapping>();

    private void Start()
    {
        // Itera pelas configurações de mapeamento de objetos para trocar os sprites
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
        // Carrega a textura do sprite a partir do arquivo
        Texture2D texture = LoadTexture(spriteName);

        if (texture != null)
        {
            // Configura o filtro da textura para Point (Pipe é pixel art)
            // TODO Fazer mais flexivel, poder definir no ObjectSpriteMapping
            texture.filterMode = FilterMode.Point;

            // Cria um novo sprite com base na textura
            Sprite newSprite = Sprite.Create(
                texture,
                new Rect(0, 0, texture.width, texture.height),
                new Vector2(0.5f, 0.5f)
            );

            // Atualiza o sprite do objeto
            SetObjectSprite(obj, newSprite);
        }
    }

    private void SetObjectSprite(GameObject obj, Sprite newSprite)
    {
        // Encontra todos os renderizadores de sprite no objeto e seus filhos
        List<SpriteRenderer> spriteRenderers = FindSpriteRenderersRecursively(obj);

        foreach (var spriteRenderer in spriteRenderers)
        {
            // Atualiza o sprite renderizador com o novo sprite
            spriteRenderer.sprite = newSprite;
        }
    }

    private List<SpriteRenderer> FindSpriteRenderersRecursively(GameObject obj)
    {
        // Encontra todos os renderizadores de sprite recursivamente em objetos e filhos
        List<SpriteRenderer> spriteRenderers = new List<SpriteRenderer>();
        FindSpriteRenderersRecursively(obj.transform, spriteRenderers);
        return spriteRenderers;
    }

    private void FindSpriteRenderersRecursively(Transform obj, List<SpriteRenderer> spriteRenderers)
    {
        // Encontra o renderizador de sprite no objeto
        var spriteRenderer = obj.GetComponent<SpriteRenderer>();

        if (spriteRenderer != null)
        {
            spriteRenderers.Add(spriteRenderer);
        }

        // Continua a busca nos filhos do objeto
        foreach (Transform child in obj)
        {
            FindSpriteRenderersRecursively(child, spriteRenderers);
        }
    }

    private Texture2D LoadTexture(string spriteName)
    {
        // Carrega uma textura de um arquivo em StreamingAssets
        string filePath = Path.Combine(Application.streamingAssetsPath, "Sprites", spriteName);
        byte[] fileData = System.IO.File.ReadAllBytes(filePath);
        Texture2D texture = new Texture2D(2, 2);

        if (texture.LoadImage(fileData))
        {
            return texture;
        }

        // Retorna nulo se a textura não puder ser carregada
        return null;
    }
}
