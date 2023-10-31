using System.IO;
using UnityEngine;
using UnityEngine.Video;

public class AssetLoader : MonoBehaviour
{
    // Para carregar texturas
    public Texture2D LoadTexture(string fileName)
    {
        string filePath = Application.streamingAssetsPath + "/" + fileName;
        Texture2D texture = new Texture2D(2, 2); // Você pode ajustar os valores conforme necessário
        byte[] fileData = System.IO.File.ReadAllBytes(filePath);
        texture.LoadImage(fileData); // Carrega a imagem do arquivo

        return texture;
    }


    // Para carregar vídeos
    public VideoPlayer LoadVideo(string fileName)
    {
        string videoUrl = Application.streamingAssetsPath + "/" + fileName;
        VideoPlayer videoPlayer = gameObject.AddComponent<VideoPlayer>();
        videoPlayer.url = videoUrl;

        return videoPlayer;
    }

    public Sprite LoadSprite(string spriteName)
    {
        string path = Path.Combine(Application.streamingAssetsPath, spriteName);
        Sprite sprite = Resources.Load<Sprite>(path);
        if (sprite == null)
        {
            Debug.LogError("Sprite not found: " + spriteName);
        }
        return sprite;
    }

}
