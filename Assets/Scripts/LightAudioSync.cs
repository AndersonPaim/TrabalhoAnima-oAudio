using UnityEngine;

public class LightAudioSync : MonoBehaviour
{
    [SerializeField] private AudioPeer _audioPeer;
    [SerializeField] private Light _light;
    [SerializeField] private Animator _anim;

    private void Update()
    {
        UpdateLightIntensity();
    }

    private void UpdateLightIntensity()
    {
        float audioAmp = _audioPeer.ClipLoudness;
        _light.intensity = audioAmp * 1000000;
        _anim.SetFloat("Speed", audioAmp * 6);
    }
}
