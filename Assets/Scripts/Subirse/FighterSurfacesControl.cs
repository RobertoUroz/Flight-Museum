using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterSurfacesControl : MonoBehaviour
{
    public Transform rightElevator, leftElevator;
    public Transform rightFlap, leftFlap;
    public Transform rightRudder, leftRudder;
    public float MRx, MRy, MRz;
    public float maxAngle, flapMaxAngle, rudderMaxAngle;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        MRx = Mathf.Clamp(MRx + Input.GetAxis("Vertical") * 0.05f, -1f, 1f);
        MRz = Mathf.Clamp(MRz - Input.GetAxis("Horizontal") * 0.05f, -1f, 1f);
        MRy = Mathf.Clamp(MRy + Input.GetAxis("Yaw") * 0.05f, -1f, 1f);

        MRx = Input.GetAxis("Vertical") > -0.05 && Input.GetAxis("Vertical") < 0.05 ? MRx - MRx/(10000.0f * Time.deltaTime) : MRx;
        MRz = Input.GetAxis("Horizontal") > -0.05 && Input.GetAxis("Horizontal") < 0.05 ? MRz - MRz/(10000.0f * Time.deltaTime) : MRz;
        MRy = Input.GetAxis("Yaw") > -0.05 && Input.GetAxis("Yaw") < 0.05 ? MRy - MRy/(10000.0f * Time.deltaTime) : MRy;
        
        rightElevator.transform.localRotation = Quaternion.Euler(new Vector3((MRz + MRx) * maxAngle + 90, 0, 0));
        leftElevator.transform.localRotation = Quaternion.Euler(new Vector3((-MRz + MRx) * maxAngle - 90, 0, 0));
        
        rightRudder.transform.localRotation = Quaternion.Euler(new Vector3(-15.582f, -MRy * rudderMaxAngle + 90.0f, 180.0f));
        leftRudder.transform.localRotation = Quaternion.Euler(new Vector3(15.582f, -MRy * rudderMaxAngle + 90.0f, 0.0f));
        
        rightFlap.transform.localRotation = Quaternion.Euler(new Vector3(-84.0f + 180.0f + (MRz + MRx) * flapMaxAngle, 0.0f, -0.0f));
        leftFlap.transform.localRotation = Quaternion.Euler(new Vector3(-96.0f + (-MRz + MRx) * flapMaxAngle, 0.0f, -5.0f));

	}
}
