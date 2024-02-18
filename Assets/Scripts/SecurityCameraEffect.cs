using UnityEngine;

public class SecurityCameraEffect : MonoBehaviour
{
    public Material securityCameraMaterial; // Asigna el material con el shader SecurityCameraEffect

    void Start()
    {
        Camera.main.depthTextureMode = DepthTextureMode.Depth;
    }

    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, securityCameraMaterial);
    }
}