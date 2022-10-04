using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPeer : MonoBehaviour
{
    private AudioSource _audioSource;
    private float[] _frequency = new float[8];
    private float _clipLoudness;

    public float[] Frequency => _frequency;
    public float ClipLoudness => _clipLoudness;
    public static float[] _samples = new float[512];

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        GetAudioSpectrum();
        GetFrequency();
        GetLoudness();
    }

    private void GetLoudness()
    {
        _audioSource.clip.GetData(_samples, _audioSource.timeSamples);
        _clipLoudness = 0f;

        foreach (var sample in _samples)
        {
            _clipLoudness += Mathf.Abs(sample);
        }

        _clipLoudness /= 512;
        _clipLoudness *= _audioSource.volume;

        if(!_audioSource.isPlaying)
        {
            _clipLoudness = 0;
        }
    }

    private void GetFrequency()
    {
        _audioSource.GetSpectrumData(_samples, 0, FFTWindow.Blackman);

        int count = 0;

        for(int i = 0; i < 8; i++)
        {
            float average = 0;
            int sampleCount = (int)Mathf.Pow (2, i) * 2;

            if(i == 7)
            {
                sampleCount += 2;
            }

            for(int j = 0; j < sampleCount; j++)
            {
                average += _samples[count] * (count + 1);
                count++;
            }

            average /= count;

            _frequency[i] = average * 10;
        }
    }

    private void GetAudioSpectrum()
    {
        _audioSource.GetSpectrumData(_samples, 0, FFTWindow.Blackman);
    }
}
