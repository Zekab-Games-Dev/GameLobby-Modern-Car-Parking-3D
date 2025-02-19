using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnteringName : MonoBehaviour
{
    public static EnteringName instance=null;
    public InputField inputField;
    public InputField inputFieldAge;
    private string _userName;
    private int _userAge;
    public Button next;
    public Text wrongTextName;
    public Text wrongTextAge;
    public Toggle[] gender;
    public Toggle[] avatar;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
            instance = this;
        }
        inputField.onValidateInput += delegate (string input, int charIndex, char addedChar) { return SetToUpper(addedChar); };
    }

    public char SetToUpper(char c)
    {
        return char.ToUpper(c);
    }
   
    void Start()
    {
        try
        {
            LoadData();
        }
        catch { }

    }
    void LoadData() 
    {
        try { 
        if (PlayerPrefs.GetString("username") != "" && PlayerPrefs.GetInt("userage") != 0)
        {
            inputField.text = PlayerPrefs.GetString("username");
            inputFieldAge.text = PlayerPrefs.GetInt("userage").ToString();
        }
        gender[PlayerPrefs.GetInt("gender", 0)].isOn = true;
        avatar[PlayerPrefs.GetInt("avatar", 0)].isOn = true;
        }
        catch { }
    }
    void SaveUsername()
    {
        try { 
        PlayerPrefs.SetString("username", _userName);
        PlayerPrefs.SetInt("userage", _userAge);
        PlayerPrefs.SetInt("gender", PlayerPrefs.GetInt("gender",0));
        PlayerPrefs.SetInt("avatar", PlayerPrefs.GetInt("avatar",0));
        PlayerPrefs.SetInt("savedatafirsttime",1);
        }
        catch { }
    }
  public  void SaveHere()                                  // function where u want to save
    {
        try { 
        char[] charArray = inputField.text.ToCharArray();
        
            if (inputField.text.ToCharArray().Length > 0 && inputFieldAge.text.Length > 0 && inputFieldAge.text != "0")
            {
           
                next.interactable = true;
                _userName = inputField.text;
                _userAge = int.Parse(inputFieldAge.text);
                wrongTextAge.enabled = false;
                wrongTextName.enabled = false;
                SaveUsername();
            PlayerPrefs.SetInt("userInformation", 1);
            StartCoroutine(LoadScene());
            }
        else
        {
            if (inputField.text == "" && inputField.text == "")
            {
                wrongTextName.enabled = true;
                wrongTextAge.enabled = true;
            }
            else if (inputField.text == "")
            {
                wrongTextName.enabled = true;
                wrongTextAge.enabled = false;
            }
            else if (inputFieldAge.text == "")
            {
                wrongTextAge.enabled = true;
                wrongTextName.enabled = false;
            }

        }
        }
        catch { }
    }

    public void SelectGender(int value) 
    {
        try { 
        PlayerPrefs.SetInt("gender", value);
        }
        catch { }
    }
    public void SelectAvatar(int value)
    {
        try { 
        PlayerPrefs.SetInt("avatar", value);
        }
        catch { }
    }

    IEnumerator LoadScene() 
    {
        yield return new WaitForSecondsRealtime(0f);
        SceneManager.LoadScene("MainMenu");
    }

    public void SaveInMenu()                                  // function where u want to save
    {
        try { 
        char[] charArray = inputField.text.ToCharArray();

        if (inputField.text.ToCharArray().Length > 0 && inputFieldAge.text.Length > 0 && inputFieldAge.text != "0")
        {

            next.interactable = true;
            _userName = inputField.text;
            _userAge = int.Parse(inputFieldAge.text);
            wrongTextAge.enabled = false;
            wrongTextName.enabled = false;
            SaveUsername();
            MenuManger.Instance.LoadProfile();
            this.gameObject.SetActive(false);
            PlayerPrefs.SetInt("userInformation", 1);
        }
        else
        {
            if (inputField.text == "" && inputField.text == "")
            {
                wrongTextName.enabled = true;
                wrongTextAge.enabled = true;
            }
            else if (inputField.text == "")
            {
                wrongTextName.enabled = true;
                wrongTextAge.enabled = false;
            }
            else if (inputFieldAge.text == "")
            {
                wrongTextAge.enabled = true;
                wrongTextName.enabled = false;
            }

        }
        }
        catch { }
    }
    public void Skip()                                  // function where u want to save
    {
        try
        {
                PlayerPrefs.SetInt("userInformation", 1);
                StartCoroutine(LoadScene());       
        }
        catch { }
    }
}
