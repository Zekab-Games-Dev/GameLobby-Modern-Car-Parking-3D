using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class soundcontrol : MonoBehaviour {
    public AudioSource src;
    public Slider slider;
    void Start()
    {
        try
        {
            if (!PlayerPrefs.HasKey("CurVol"))
            {
                PlayerPrefs.SetFloat("CurVol", 1);
            }

            src.volume = PlayerPrefs.GetFloat("CurVol");
            slider.value = src.volume;
            slider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
        }
        catch { }
    }

    // Update is called once per frame
    void Update()
    {
        try {  
            PlayerPrefs.SetFloat("CurVol", src.volume); 

            PlayerPrefs.Save();
        }
        catch { }
    }
    public void ValueChangeCheck()
    {
        try { 
        src.volume = slider.value;
        }
        catch { }
    }
}
