using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPeer : MonoBehaviour
{
    private AudioSource _audioSource;
    public static float[] _samples = new float[512];
    private float[] _frequency = new float[8];

    public float[] Frequency => _frequency;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        GetAudioSpectrum();
        GetFrequency();
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
