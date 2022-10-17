/*using System.Reflection.Metadata;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PilarController : MonoBehaviour
{


    public Transform cubo;
    public int tempoEntrada ;
    public int velocidade;

    // Start is called before the first frame update
    void Start()
    {
        cubo=gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        tempo--;
        if(tempo<0){
            drop();
        }
    }

    void drop(){
        cubo.Translate(0, 0, (Time.deltaTime-tempoEntrada)*velocidade);
    }
}*/