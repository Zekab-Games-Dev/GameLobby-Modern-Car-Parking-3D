using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carDrivebyOwn : MonoBehaviour
{
    public static carDrivebyOwn instance;

    public GameObject[] LeftRightBarriers;
    public GameObject[] UpDownBarriers;

    public Transform path;
    public float maxSteerAngle = 60;
    public float turnSpeed = 5f;
    public WheelCollider wheelFL;
    public WheelCollider wheelFR;
    public WheelCollider wheelRL;
    public WheelCollider wheelRR;

    public float maxMotorTorque = 80f;
    public float maxBrakeTorque = 200f;

    public float currentSpeed;
    public float maxSpeed = 100f;
    public Vector3 centerOfMass;

    public Material BrakeNormal;
    public Material BrakingPress;
    public Material ReverseActive;
    public Material NotReverse;
    public Renderer carRenderer;
    public Renderer ReverseRenderer;

    public bool isBraking = false;
    private bool DefaultBrakes;

    public bool isDriving = true;
    private bool DefaultDrive;

    public bool isReversing = false;
    public bool isRightReversing = false;
    public bool isLeftReversing = false;

    public GameObject ReverseTriggercube;
    public GameObject ReverseRightTriggercube;
    public GameObject ReverseRightTriggercubeAnother;
    public GameObject ReverseLeftTriggercube;

    public float Swait = 1f;
    public float Rwait = 1f;
    public float Lwait = 1f;
    public float StopWait = 1f;

    public float IncreaseTorque = 500;

    private List<Transform> nodes;
    private int currentNode = 0;
    private float targetSteerAngle = 0;

    private Vector3 startPosition;
    private Quaternion startRotation;

    private void Awake()
    {
        instance = this;
        startPosition = transform.position;
        startRotation = transform.rotation;
        DefaultBrakes = isBraking;
        DefaultDrive = isDriving;
    }

    public void Reset()
    {
        currentSpeed = 0;
        maxMotorTorque = 80;
        maxBrakeTorque = 200f;
        currentNode = 0;
        targetSteerAngle = 0;
        isBraking = DefaultBrakes;
        carRenderer.material = BrakeNormal;
        carRenderer.material = BrakingPress;
        ReverseRenderer.material = ReverseActive;
        ReverseRenderer.material = NotReverse;
        isDriving = DefaultDrive;
        isReversing = false;
        isRightReversing = false;
        isLeftReversing = false; 
        if (ReverseLeftTriggercube.gameObject != null)
        {
            ReverseLeftTriggercube.gameObject.SetActive(true);
        }
        if (ReverseRightTriggercube.gameObject != null)
        {
            ReverseRightTriggercube.gameObject.SetActive(true);
        }
        if (ReverseTriggercube.gameObject != null)
        {
            ReverseTriggercube.gameObject.SetActive(true);
        }
        if (ReverseRightTriggercubeAnother.gameObject != null)
        {
            ReverseRightTriggercubeAnother.gameObject.SetActive(true);
        }
        for (int i = 0; i < LeftRightBarriers.Length; i++)
        {
            LeftRightBarriers[i].GetComponent<Animator>().Play("BarrierLeftRight", -1, 0);
        }
        for (int i = 0; i < UpDownBarriers.Length; i++)
        {
            UpDownBarriers[i].GetComponent<Animator>().Play("BarrierUpDown", -1, 0);
        }
        transform.position = startPosition;
        transform.rotation = startRotation;
    }

    private void Start()
    {
        GetComponent<Rigidbody>().centerOfMass = centerOfMass;
        Transform[] pathTransforms = path.GetComponentsInChildren<Transform>();
        nodes = new List<Transform>();
        for (int i = 0; i < pathTransforms.Length; i++)
        {
            if (pathTransforms[i] != path.transform)
            {
                nodes.Add(pathTransforms[i]);
            }
        }
    }

    private void FixedUpdate()
    {
        if(gameObject.activeSelf)
        {
            ApplySteer();
            Drive();
            CheckWayPointDistance();
            Braking();
            LerpToSteerAngle();
            ReverseDrive();
            RightReverseDrive();
            LeftReverseDrive();
        }
    }

    public void Drive()
    {
        if (isDriving)
        {
            currentSpeed = 2 * Mathf.PI * wheelFL.radius * wheelFL.rpm * 60 / 1000;

            if (currentSpeed < maxSpeed && !isBraking)
            {
                wheelFL.motorTorque = maxMotorTorque;
                wheelFR.motorTorque = maxMotorTorque;
            }
        }
        else
        {
            wheelFL.motorTorque = 0;
            wheelFR.motorTorque = 0;
        }
    }

    public void ReverseDrive()
    {
        if (isReversing)
        {
            ReverseRenderer.material = ReverseActive;
            wheelFL.motorTorque = -maxMotorTorque;
            wheelFR.motorTorque = -maxMotorTorque;

            wheelFL.steerAngle = 1f;
            wheelFR.steerAngle = 1f;;
        }
        else
        {
            ReverseRenderer.material = NotReverse;
        
        }
    }
    
    public void RightReverseDrive()
    {
        if (isRightReversing)
        {
            ReverseRenderer.material = ReverseActive ;
            wheelFL.motorTorque = -maxMotorTorque;
            wheelFR.motorTorque = -maxMotorTorque;

            wheelFL.steerAngle = -55f;
            wheelFR.steerAngle = -55f;
        }
        else
        {
            ReverseRenderer.material = NotReverse;
        }
    }
    
    public void LeftReverseDrive()
    {
        if (isLeftReversing)
        {
            ReverseRenderer.material = ReverseActive;
            wheelFL.motorTorque = -maxMotorTorque;
            wheelFR.motorTorque = -maxMotorTorque;

            wheelFL.steerAngle = 55f;
            wheelFR.steerAngle = 55f;
        }
        else
        {
            ReverseRenderer.material= NotReverse;
        }
    }

    private void CheckWayPointDistance()
    {
        if (Vector3.Distance(transform.position, nodes[currentNode].position) < 1f)
        {
            if (currentNode == nodes.Count - 1)
            {
                currentNode = 0;
            }
            else
            {
                currentNode++;
            }
        }
    }
    private void Braking()
    {
        if (isBraking)
        {
            carRenderer.material = BrakingPress;
            wheelRL.brakeTorque = maxBrakeTorque;
            wheelRR.brakeTorque = maxBrakeTorque;
        }
        else
        {
            carRenderer.material = BrakeNormal;
            wheelRL.brakeTorque = 0;
            wheelRR.brakeTorque = 0;
        }
    }
    private void ApplySteer()
    {
        Vector3 relativeVector = transform.InverseTransformPoint(nodes[currentNode].position);
        float newSteer = (relativeVector.x / relativeVector.magnitude) * maxSteerAngle;
        targetSteerAngle = newSteer;
    }

    private void LerpToSteerAngle()
    {
        wheelFL.steerAngle = Mathf.Lerp(wheelFL.steerAngle, targetSteerAngle, Time.deltaTime * turnSpeed);
        wheelFR.steerAngle = Mathf.Lerp(wheelFR.steerAngle, targetSteerAngle, Time.deltaTime * turnSpeed);
    }

    // For Car Stopping At Finnishingpoint
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "FinishPointStop")
        {
            this.isBraking = true;
            this.isDriving = false;
        }
    }
  
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "SCube")
        {
           StartCoroutine(BrakingTest());
        }
        if (other.gameObject.tag == "StraightReverseCube")
        {

            StartCoroutine(TriggerCube(true, true,false ,false,false, Swait, ReverseTriggercube.gameObject, currentSpeed, false, false, false, false)); 
        }
        if (other.gameObject.tag == "RightReverseCube")
        {
            StartCoroutine(TriggerCube(false, false, false, false, false, Rwait, ReverseRightTriggercube.gameObject, currentSpeed, false, false, true, true));
        }
        if (other.gameObject.tag == "LefttReverseCube")
        {
            StartCoroutine(TriggerCube(false, false, false, false, false, Lwait, ReverseLeftTriggercube.gameObject, currentSpeed, true, true, false, false));
        }
        if (other.gameObject.tag == "RightReverseCubeAnother")
        {
            StartCoroutine(TriggerCube(false, false, false, false, false, 8, ReverseRightTriggercubeAnother.gameObject, currentSpeed, false, false, true, true));
        }
        if (other.gameObject.tag == "StopCar")
        {
            StartCoroutine(TriggerCube(false, true, true, true, false, StopWait, null, 0, false, false, false, false));
        }
        if (other.gameObject.tag == "StoppedCar")
        {
            StartCoroutine(TriggerCube(false, true, true, true, false, 6, null, 0, false, false, false, false));
        }
        if (other.gameObject.tag == "IncrTorq")
        {
            maxMotorTorque = 500f;
        }
        if (other.gameObject.tag == "IncreaseTorque")
        {
            maxMotorTorque = IncreaseTorque;
        }
        if (other.gameObject.tag == "DecrTorq")
        {
            maxMotorTorque = 80f;
        }
    }

    IEnumerator BrakingTest()
    {
        this.isBraking = true;
        yield return new WaitForSeconds(1);
        this.isBraking = false;
        this.isDriving = true;
    }

    IEnumerator TriggerCube(bool checkReversing, bool reverse, bool checkBraking , bool brakes, bool drive, float waitTime, GameObject TriggergameObject , float speed, bool checkleftReversing, bool lr, bool checkRightReversing, bool rr)
    {
        print("Waiting Time" + waitTime);
        if (checkReversing)
        {
            isReversing = reverse;
        }
        if (checkBraking)
        {
            isBraking = brakes;
        }
        if (checkleftReversing)
        {
            isReversing = false;
            isLeftReversing = lr;
        }
        if (checkRightReversing)
        {
            isReversing = false;
            isRightReversing = rr;
        }
        isDriving = drive;
        currentSpeed = speed;

        yield return new WaitForSeconds(waitTime);

        if (TriggergameObject != null)
        {
            TriggergameObject.SetActive(false);
        }
        if (checkleftReversing)
        {
            isLeftReversing = !lr;
        }
        if (checkRightReversing)
        {          
            isRightReversing = !rr;
        }
        if (checkReversing)
        {
            isReversing = !reverse;
        }
        if (checkBraking)
        {
            isBraking = !brakes;
        }
        isDriving = !drive;
    }
}





