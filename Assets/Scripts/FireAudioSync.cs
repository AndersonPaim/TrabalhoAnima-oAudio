using UnityEngine;

public class FireAudioSync : MonoBehaviour
{
    [SerializeField] private AudioPeer _audioPeer;
    [SerializeField] private ParticleSystem _particle;


    private void Update()
    {
        UpdateFireHeight();
    }

    private void UpdateFireHeight()
    {
        float audioAmp = _audioPeer.ClipLoudness;
        //_particle = audioAmp * 600;
        _particle.startLifetime = audioAmp * 30;
    }
}
