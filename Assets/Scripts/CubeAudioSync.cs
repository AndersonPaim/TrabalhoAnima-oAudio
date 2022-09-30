using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeAudioSync : MonoBehaviour
{
    [System.Serializable]
    public class CubeColor
    {
        public float minValue;
        public float maxValue;
        public Material mat;
    }

    [SerializeField] private AudioPeer _audioPeer;
    [SerializeField] private int _band;
    [SerializeField] private float _startScale;
    [SerializeField] private float _scaleMultiplier;
    [SerializeField] private List<CubeColor> _cubeColorList = new List<CubeColor>();

    private MeshRenderer _mesh;

    private void Start()
    {
        _mesh = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        UpdateCubeScale();
        UpdateCubeColor();
    }

    private void UpdateCubeScale()
    {
        transform.localScale = new Vector3(transform.localScale.x, (_audioPeer.Frequency[_band] * _scaleMultiplier) + _startScale, transform.localScale.z);
    }

    private void UpdateCubeColor()
    {
        foreach(CubeColor cubeColor in _cubeColorList)
        {
            if(_audioPeer.Frequency[_band] >= cubeColor.minValue && _audioPeer.Frequency[_band] < cubeColor.maxValue)
            {
                _mesh.material = cubeColor.mat;
            }
        }
    }
}
