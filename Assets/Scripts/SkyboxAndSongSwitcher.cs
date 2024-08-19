using UnityEngine;

public class SkyboxAndSongSwitcher : MonoBehaviour
{
    private Transform playerTransform;
    [SerializeField] private float magicSkyboxLimit;
    [SerializeField] private Material magicSkybox;
    [SerializeField] private AudioSource magicAudioSource;

    [SerializeField] private float pirateSkyboxLimit;
    [SerializeField] private Material pirateSkybox;
    [SerializeField] private AudioSource pirateAudioSource;

    [SerializeField] private Material spaceSkybox;
    [SerializeField] private AudioSource spaceAudioSource;
 
    private void Start()
    {
        playerTransform = FindObjectOfType<PlayerMovement>().transform;
        magicAudioSource.Play();
    }

    private void Update()
    {
        if(playerTransform.position.y < magicSkyboxLimit &&
           RenderSettings.skybox != magicSkybox)
        {
            RenderSettings.skybox = magicSkybox;
            magicAudioSource.Play();
            pirateAudioSource.Stop();
            spaceAudioSource.Stop();
        }
        else if(playerTransform.position.y >= magicSkyboxLimit &&
                playerTransform.position.y < pirateSkyboxLimit &&
                RenderSettings.skybox != pirateSkybox)
        {
            RenderSettings.skybox = pirateSkybox;
            magicAudioSource.Stop();
            pirateAudioSource.Play();
            spaceAudioSource.Stop();
        }
        else if(playerTransform.position.y >= pirateSkyboxLimit && RenderSettings.skybox != spaceSkybox)
        {
            RenderSettings.skybox = spaceSkybox;
            magicAudioSource.Stop();
            pirateAudioSource.Stop();
            spaceAudioSource.Play();
        }
    }
}