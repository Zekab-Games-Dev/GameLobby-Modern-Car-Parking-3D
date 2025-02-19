using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelButton : MonoBehaviour

{
    public Sprite Locked, Simple, Selected;
    public GameObject AnimGameObject, SimpleSprite;
    public bool LockedBool, SelectedBool;
    public static LevelButton Instance;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        ButtonUnlocking();
    }

    public void ButtonUnlocking()
    {
        if (LockedBool)
        {

            SimpleSprite.GetComponent<Image>().sprite = Locked;
            this.GetComponent<Button>().interactable = false;
        }
        else
        {
            SimpleSprite.GetComponent<Image>().sprite = Simple;
            this.GetComponent<Button>().interactable = true;
            if (SelectedBool)
            {
                print("Selected");
                SimpleSprite.GetComponent<Image>().sprite = Selected;
                AnimGameObject.SetActive(true);
            }
            else
            {
                AnimGameObject.SetActive(false);
            }
        }
    }
}
