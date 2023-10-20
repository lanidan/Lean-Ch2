using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapsaw : MonoBehaviour
{
 void OnTriggerEnter2D(Collider2D col)
 {

    if(col.gameObject.tag == "Player")
    {
        col.SendMessage("RetrocesoEnemigo", transform.position.x);
        Canvavidas.vida -=1;
    } 


 }

 

   
}
