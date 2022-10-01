using Cinemachine;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _camera;
    [SerializeField] private AudioPeer _audioPeer;
    [SerializeField] private float _shakeMultiplier;
    [SerializeField] private Volume _volume;
    private ChromaticAberration _chromaticAberration;

    private CinemachineBasicMultiChannelPerlin _cameraNoise;

    private void Start()
    {
        Initialize();
    }

    private void Update()
    {
        UpdateCameraShake();
    }

    private void Initialize()
    {
        _cameraNoise = _camera.GetCinemachineComponent<Cinemachine.CinemachineBasicMultiChannelPerlin>();
        _volume.profile.TryGet(out _chromaticAberration);
    }

    private void UpdateCameraShake()
    {
        float audioAmp = _audioPeer.ClipLoudness;

        _chromaticAberration.intensity.Override(audioAmp * 3);

        _cameraNoise.m_AmplitudeGain = audioAmp * _shakeMultiplier;
        _cameraNoise.m_FrequencyGain = audioAmp * _shakeMultiplier;
    }
}
