using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMove2 : MonoBehaviour
{

    public float MotorForce, SteerForce, BrakeForce, DashForce, DashLimit, ContraDashTime, ContraDashForce, TurboLimite, Downdraft;
    private bool MotorFlag, SteerFlag, TurboFlag, LeftDashFlag, RightDashFlag;
    private Rigidbody CarRigidbody;
    public float MotorTime, SteerTime, TurboTime, DashTime;
    public WheelCollider WheelFL, WheelFR, WheelBL, WheelBR;

    // Start is called before the first frame update
    void Start()
    {
        CarRigidbody=GetComponent<Rigidbody>();
        MotorFlag=false;
        SteerFlag=false;
            
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        DefaultController();
        DashController();
        TurboController();
        MotorController();
        SteerController();
        BrakeController();
    }

    void DefaultController(){
        WheelHit hit = new WheelHit();
        if(!((WheelFL.GetGroundHit(out hit)) && (WheelFR.GetGroundHit(out hit)) && (WheelBL.GetGroundHit(out hit)) && (WheelBR.GetGroundHit(out hit))))
        //CarRigidbody.velocity = CarRigidbody.velocity+(-transform.up * Downdraft);
        CarRigidbody.AddForce(-transform.up * Downdraft);

    }
    void DashController(){
        if(DashTime==0){

            if(Input.GetKey(KeyCode.Q)){
                DashTime=DashLimit;
                LeftDashFlag=true;
                CarRigidbody.velocity = CarRigidbody.velocity+(-transform.right * DashForce);
            }else if(Input.GetKey(KeyCode.E)){
                DashTime=DashLimit;
                RightDashFlag=true;
                CarRigidbody.velocity = CarRigidbody.velocity+(transform.right * DashForce);
                }else {
                    if(DashTime>0){
                        DashTime--;
            }}
        }else {
            if(DashTime>0){
                DashTime--;
            }
            if(DashTime<ContraDashTime&&(LeftDashFlag||RightDashFlag)){
                if(LeftDashFlag){
                    LeftDashFlag=false;
                    CarRigidbody.velocity = CarRigidbody.velocity+(transform.right * ContraDashForce);
                }else if(RightDashFlag){
                    RightDashFlag=false;
                    CarRigidbody.velocity = CarRigidbody.velocity+(-transform.right * ContraDashForce);
                }
            }

        }
    }


    void TurboController(){

        if(TurboTime<TurboLimite){

            if(Input.GetKey(KeyCode.LeftShift)){
                TurboTime++;
                TurboFlag=true;
            }else {
                if(TurboTime>0){
                    TurboTime--;
            }
                TurboFlag=false;
            }
        }else {
        if(TurboTime>0){
            TurboTime--;
            }
        TurboFlag=false;
        }

    }

    void MotorController(){
        float v = Input.GetAxis("Vertical") * MotorForce;

        if(MotorFlag && MotorTime<150){
            MotorTime++;
        }else if(MotorFlag && MotorTime==150){

        }else if(MotorTime >0){
            MotorTime--;
        }

        if(v > 0){
            MotorFlag=true;
        }else{
            MotorFlag=false;
        }
        if(TurboFlag){
            v = v*MotorTime*10;
        }else{
            v=v*MotorTime;
        }
        if(RightDashFlag||LeftDashFlag){
            
        }
        
        WheelBL.motorTorque = v; 
        WheelBR.motorTorque = v;
        
    }

    void SteerController(){
        

        
        //float SteerTemp = SteerForce + SteerTime;
        

        float h = Input.GetAxis("Horizontal") * SteerForce;

        if(h != 0){
        SteerFlag=true;
        }else{
            SteerFlag=false;
        }
        
        WheelFL.steerAngle =h;
        WheelFR.steerAngle =h;

        //SteerTimer();
    }
// não usado (ainda) & incompleto & bugado
    void SteerTimer(){
        
        if(SteerFlag && SteerTime<30){
            SteerTime++;
        }else if(SteerFlag && SteerTime==30){

        }else if(SteerTime >0){
            SteerTime--;
        }
        
    }
    
    void BrakeController(){
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


