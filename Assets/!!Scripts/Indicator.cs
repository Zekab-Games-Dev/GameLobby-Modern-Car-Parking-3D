using UnityEngine;
using System.Collections;

public class Indicator : MonoBehaviour {
    Renderer rend;
    float offset;
    public bool left;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
    void Update()
    { 
        if(left)
            offset = offset + 0.0025f;
        else
            offset=offset - 0.0045f;
        rend=this.GetComponent<Renderer>();
        rend.material.mainTextureOffset = new Vector2(offset, 0);
    }
}
