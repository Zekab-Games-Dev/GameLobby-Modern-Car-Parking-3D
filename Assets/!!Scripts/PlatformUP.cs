using UnityEngine;
using System.Collections;

public class PlatformUP : MonoBehaviour {
    public GameObject up;
    bool inCollider;
    public bool down;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
    void Update()
    {
        Debug.Log("NEW TRANSFORM VALUE  " + up.transform.position.y);
        if (down)
        {
            if (inCollider && up.transform.position.y > (-3.3f))
            {
                up.transform.position = new Vector3(up.transform.position.x, (up.transform.position.y - 0.025f), up.transform.position.z);
            }
        }
        else
        { 
        
        if (inCollider && up.transform.position.y < (0.635433f))
        {
            up.transform.position = new Vector3(up.transform.position.x, (up.transform.position.y + 0.025f), up.transform.position.z);
        }
    }
    }
    void OnTriggerEnter(Collider collider)
    {
        //     Debug.Log("collider.gameObject.tag " + collider.gameObject.tag + " collider.transform.parent.tag : " + collider.transform.parent.tag + " collider.transform.root.tag : " + collider.transform.root.tag);
        if (collider.gameObject.tag == "Player" || collider.transform.root.tag == "Player")
        {
            inCollider = true;
        }

    }
    void OnTriggerExit(Collider collider)
    {
        //      Debug.Log("collider.gameObject.tag " + collider.gameObject.tag + "collider.transform.root.tag : " + collider.transform.root.tag);
        if (collider.gameObject.tag == "Player" || collider.transform.root.tag == "Player")
        {
            inCollider = false;
        }

    }
}
