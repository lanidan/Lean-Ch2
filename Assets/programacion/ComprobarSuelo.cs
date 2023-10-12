using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComprobarSuelo : MonoBehaviour
{

   private Controles control;

   private Rigidbody2D rb2d; //creamos una variable para el rigidBody2D


    // Start is called before the first frame update
    void Start()
    {
      control =GetComponentInParent<Controles>();
      rb2d =GetComponentInParent<Rigidbody2D>();
     
    }

    void FixedUpdate(){

    }
  
    void OnCollisionEnter2D(Collision2D col){ //Un llamado que sucede cuando una colisión se produce la primera vez
        if(col.gameObject.tag == "Plataforma"){ // Si el objeto donde se produce una colision tiene el tag Plataforma, entonces...
         rb2d.velocity =new Vector3(0f, 0f, 0f); //Le damos un valor de velocidad a 0 al personaje, esto se hace para que no se produzca un bug con las animaciones
         control.transform.parent = col.transform; // Transformamos al personaje en hijo del suelo
         
         control.suelo =true; // Ponemos en verdadero que está tocando el suelo
        }
    }
    
    void OnCollisionStay2D(Collision2D col){
        control.suelo =true;
    }

    void OnCollisionExit2D(Collision2D col){
        control.suelo =false;
        if(col.gameObject.tag == "Plataforma"){ // Si el objeto donde se produce una colision tiene el tag Plataforma, entonces...
         control.transform.parent = null;// Sacamos al personaje de ser hijo del suelo
        }
    }

}
