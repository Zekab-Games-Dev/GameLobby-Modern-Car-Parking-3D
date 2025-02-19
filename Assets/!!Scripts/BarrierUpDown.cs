using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierUpDown : MonoBehaviour {
    public static BarrierUpDown instance;
    public float z;
    public bool up,down;
	// Use this for initialization
	void Start () {
        instance = this;
        z = 0;
        up = true;
        down = false;
        //StartCoroutine(Example());
    }
	
	// Update is called once per frame
	void Update () {
        
        if (z == 90)
        {
            
            StartCoroutine(Example());
        }
        if (z == 0)
        {
            StartCoroutine(Example1());
            
        }
        if(z!=90 && up)
        {
            this.gameObject.transform.rotation = Quaternion.Euler(0, 0, z = z + 1f);
            
        }
        if (z != 0 && down)
        {
            this.gameObject.transform.rotation = Quaternion.Euler(0, 0, z = z - 1f);
        }


    }

    IEnumerator Example()
    {
        
        yield return new WaitForSeconds(3);
        down = true;
        up = false;
    }
    IEnumerator Example1()
    {

        yield return new WaitForSeconds(3f);
        down = false;
        up = true;
    }
}
