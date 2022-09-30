using UnityEngine;

public class LightAudioSync : MonoBehaviour
{
    [SerializeField] private AudioPeer _audioPeer;
    [SerializeField] private Light _light;


    private void Update()
    {
        UpdateLightIntensity();
    }

    private void UpdateLightIntensity()
    {
        float audioAmp = _audioPeer.ClipLoudness;
        _light.intensity = audioAmp * 400;
    }
}
