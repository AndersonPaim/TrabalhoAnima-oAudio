using Cinemachine;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _camera;
    [SerializeField] private AudioPeer _audioPeer;
    [SerializeField] private float _shakeMultiplier;

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
    }

    private void UpdateCameraShake()
    {
        float audioAmp = _audioPeer.ClipLoudness;

        _cameraNoise.m_AmplitudeGain = audioAmp * _shakeMultiplier;
        _cameraNoise.m_FrequencyGain = audioAmp * _shakeMultiplier;
    }
}
