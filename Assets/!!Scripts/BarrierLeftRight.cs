using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierLeftRight : MonoBehaviour {
    public static BarrierLeftRight instance;
    public float z;
    public bool left, right;
    // Use this for initialization
    void Start () {
        instance = this;
        z = this.gameObject.transform.position.x;
        left = true;
        right = false;
	}

    // Update is called once per frame
    void Update()
    {

        if (z > 2.5)
        {
            left = false;
            StartCoroutine(Example());
        }
        if (z < -0.90)
        {
            StartCoroutine(Example1());

        }
        if (z != 2.5 && left)
        {
            Debug.Log("b "+ z);
            this.gameObject.transform.position = new Vector3(z=z+0.01f, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
            Debug.Log("a "+ z);
        }
        if (z != -0.90 && right)
        {
            this.gameObject.transform.position = new Vector3(z = z - 0.01f, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
        }


    }

    IEnumerator Example()
    {

        yield return new WaitForSeconds(3);
        right = true;
        left = false;
    }
    IEnumerator Example1()
    {

        yield return new WaitForSeconds(3f);
        right = false;
        left = true;
    }
}
