using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class NewCamera : MonoBehaviour {


    public float orbitXSpeed = 7.5f;
    public float orbitYSpeed = 5f;

    private Quaternion orbitRotation = Quaternion.identity;
    public float minOrbitY = -20f;
    public float maxOrbitY = 80f;

    internal float orbitX = 0f;
    internal float orbitY = 0f;

    public Transform car;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void LateUpdate()
    {
        this.GetComponentInChildren<Transform>().LookAt(car.transform);
        transform.rotation = orbitRotation;
        Orbit();

        //
    }

    public void OnDrag(PointerEventData pointerData)
    {

        // Receiving drag input from UI.
        orbitX += pointerData.delta.x * orbitXSpeed * .02f;
        orbitY -= pointerData.delta.y * orbitYSpeed * .02f;

        

    }

    void Orbit()
    {
        orbitY = Mathf.Clamp(orbitY, minOrbitY, maxOrbitY);
        orbitRotation = Quaternion.Euler(orbitY, orbitX, 0f);
    }
}
