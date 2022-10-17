using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMove : MonoBehaviour
{
    public float MotorForce, SteerForce, BrakeForce;
    public WheelCollider WheelFL, WheelFR, WheelBL, WheelBR;


    // Update is called once per frame
    void Update()
    {
        float v = Input.GetAxis("Vertical") * MotorForce;
        float h = Input.GetAxis("Horizontal") * SteerForce;

        WheelBL.motorTorque= v; 
        WheelBR.motorTorque = v;

        WheelFL.steerAngle =h;
        WheelFR.steerAngle =h;

        if(Input.GetKey(KeyCode.Space)){
            WheelBL.brakeTorque= BrakeForce; 
            WheelBR.brakeTorque = BrakeForce;
        }

        if(Input.GetKeyDown(KeyCode.Space)){
            WheelBL.brakeTorque= 0; 
            WheelBR.brakeTorque = 0;
        }

        if(Input.GetAxis("Vertical")==0){
            WheelBL.brakeTorque= BrakeForce; 
            WheelBR.brakeTorque = BrakeForce;
        }else{
            WheelBL.brakeTorque= 0; 
            WheelBR.brakeTorque = 0;
        }
    }
}
