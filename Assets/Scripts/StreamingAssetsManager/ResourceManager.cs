using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager instance; // Isso permite que outros scripts acessem facilmente esta instância

    [System.Serializable]
    public class ResourceData
    {
        public string resourceName;
        public string resourcePath;
    }

    public List<ResourceData> resources = new List<ResourceData>
    {
        new ResourceData { resourceName = "World Night BackGround", resourcePath = "StreamingAssets/Sprites/World_Night_BackGround.png" }
    };


    private Dictionary<string, string> resourceDictionary = new Dictionary<string, string>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject); // Garante que só haja uma instância desse script
        }

        InitializeResourceDictionary();
    }

    private void InitializeResourceDictionary()
    {
        // Preencha o dicionário de recursos com base na lista de recursos
        foreach (ResourceData resource in resources)
        {
            resourceDictionary[resource.resourceName] = resource.resourcePath;
        }
    }

    public string GetResourcePath(string resourceName)
    {
        // Retorna o caminho do recurso com base no nome do recurso
        if (resourceDictionary.ContainsKey(resourceName))
        {
            return resourceDictionary[resourceName];
        }
        else
        {
            Debug.LogError("Resource not found: " + resourceName);
            return null;
        }
    }
}
