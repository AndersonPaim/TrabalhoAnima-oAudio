using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeAudioSync : MonoBehaviour
{
    [SerializeField] private AudioPeer _audioPeer;
    [SerializeField] private int _band;
    [SerializeField] private float _startScale;
    [SerializeField] private float _scaleMultiplier;

    private void Start()
    {

    }

    private void Update()
    {
        UpdateCubeScale();
    }

    private void UpdateCubeScale()
    {
        transform.localScale = new Vector3(transform.localScale.x, (_audioPeer.Frequency[_band] * _scaleMultiplier) + _startScale, transform.localScale.z);
    }
}
