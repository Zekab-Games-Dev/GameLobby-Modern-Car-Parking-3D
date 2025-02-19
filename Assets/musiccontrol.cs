using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class musiccontrol : MonoBehaviour {
    public AudioSource src;
    public Slider sliderr;
    void Start()
    {
        try { 
        if (!PlayerPrefs.HasKey("musicVol"))
        {
            PlayerPrefs.SetFloat("musicVol", 1);
        }

        src.volume = PlayerPrefs.GetFloat("musicVol");
        sliderr.value = src.volume;
        sliderr.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
        }
        catch { }
    }

    void Update()
    {
        try { 
        PlayerPrefs.SetFloat("musicVol", src.volume);

        PlayerPrefs.Save();
        }
        catch { }
        // }
    }
    public void ValueChangeCheck()
    {
        try { 
        src.volume = sliderr.value;
		AudioListener.volume = PlayerPrefs.GetFloat ("musicVol");
        }
        catch { }
    }
    public void PlaySoundButton1()
    {
        try { 
        src.Play();
        }
        catch { }
    }
}
