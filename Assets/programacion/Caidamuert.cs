using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caidamuert : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.tag == "Player"){ //Se lee como "Si la colision se produce con un tag jugador"
            
          col.SendMessage("Caida");
          
        }
    }
}
