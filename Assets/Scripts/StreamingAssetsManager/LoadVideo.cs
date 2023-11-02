using UnityEngine;
using UnityEngine.Video;

public class LoadVideo : MonoBehaviour
{
    public VideoPlayer myVideoPlayer;  // Refer�ncia ao componente VideoPlayer

    void Start()
    {
        // Define a URL do v�deo que sera reproduzido
        string videoUrl = Application.streamingAssetsPath + "/" + "Videos" + "/" + "video_streamingAssets" + ".mp4";

        // Atribui a URL ao componente VideoPlayer para carregar o video
        myVideoPlayer.url = videoUrl;
    }
}
