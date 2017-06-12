using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent (typeof(AudioSource))]
public class AudioSRC : MonoBehaviour {

    AudioSource _audioSource;
    float[] _smpls = new float[512];
    public static float[] cs = new float[8];
    public static float[] csBuff = new float[8];
    float[] decrease = new float[8];
    AudioSource AS;
    public int sM;

    public AudioClip HeartBeat, Dark, Relief, Fall;

	// Use this for initialization
	void Start () {
        AS = gameObject.GetComponent<AudioSource>();
        _audioSource = GetComponent<AudioSource>();
		
	}
	
	// Update is called once per frame
	void Update () {
        GetSpectrumAudioSource();
        GetFreqBands();
        bandBuf();
        Track();
	}

    void GetSpectrumAudioSource()
    {
        _audioSource.GetSpectrumData(_smpls, 0, FFTWindow.Blackman);
    }

    void bandBuf()
    {
        for (int i = 0; i < 8; i++)
        {
            if (csBuff[i] < cs[i] && cs[i]<.075f)
            {
                csBuff[i] = cs[i];
                decrease[i] = 0.005f;
            }

            if (csBuff[i] > cs[i])
            {
                csBuff[i] -= decrease[i];
                decrease[i] *= 1.2f;
            }
        }
    }

    void GetFreqBands()
    {
        int k = 0;

        for (int i = 0; i < 8; i++)
        {
            float avg = 0;
            int sampCount = (int)Mathf.Pow(2, i) * 2;

            if (i == 7)
            {
                sampCount += 2;
            }

            for(int j=0;j<sampCount; j++)
            {
                avg += _smpls[k] * (k + 1);
                k++;
            }
            avg /= k;

            cs[i] = avg;
        }
    }
    
    void Track()
    {
        if (Manager._switchMusic != sM)
        {
            sM=  Manager._switchMusic;

            switch (Manager._switchMusic)
            {
                case 1:
                    
                    AS.Stop();
                    AS.clip = HeartBeat;
                    AS.Play();

                    break;

                case 2:
                    
                    AS.Stop();
                    AS.clip = Relief;
                    AS.Play();
                    break;

                case 3:


                    AS.Stop();
                    AS.clip = Fall;
                    AS.Play();
                    break;

                case 4:

                    AS.Stop();
                    AS.clip = Dark;
                    AS.Play();
                    break;

                case 0:
                    AS.Stop();
                    break;

            }

        }

    }
}
