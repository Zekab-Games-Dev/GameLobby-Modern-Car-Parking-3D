using UnityEngine;
using System.Collections;

public class StopOffset : MonoBehaviour {
    public Material atlas, red;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter(Collider collider)
    {
        //     Debug.Log("collider.gameObject.tag " + collider.gameObject.tag + " collider.transform.parent.tag : " + collider.transform.parent.tag + " collider.transform.root.tag : " + collider.transform.root.tag);
        if (collider.gameObject.tag == "Player" || collider.transform.root.tag == "Player")
        {

            this.gameObject.GetComponent<Indicator>().enabled = false;
            this.GetComponent<MeshRenderer>().material = red;
        }

    }
    void OnTriggerExit(Collider collider)
    {
        //      Debug.Log("collider.gameObject.tag " + collider.gameObject.tag + "collider.transform.root.tag : " + collider.transform.root.tag);
        if (collider.gameObject.tag == "Player" || collider.transform.root.tag == "Player")
        {

            this.gameObject.GetComponent<Indicator>().enabled = true;
            this.GetComponent<MeshRenderer>().material = atlas;
        }

    }
}
