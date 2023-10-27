using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemitriger : MonoBehaviour
{
       void OnTriggerEnter2D(Collider2D col){  //llamamos a la funcion cuando trigger entra al collider 2D
        if (col.gameObject.tag == "Player"){ //Se lee como "Si la colision se produce con un tag jugador"
            
           float yResta = 0.7f; //Esto lo usamos como ajuste. Si no está este ajuste, cuando el jugador lo toca de frente se eliminaria
           if(transform.position.y + yResta < col.transform.position.y){ // Se lee como "Si la posicion del enemigo es menor a la posicion del jugador entonces..."
                //Controlador.GetComponent<Puntaje>().puntos += 20; //Sumamos diez puntos al puntaje
                col.SendMessage("SaltarEnemigo"); //Hacemos un llamado a saltar Enemigo a Controles cuando lo pisamos 
                Destroy(gameObject); //Esta linea es la encargada de desruir el objeto
           } else { //Sino
              // Controlador.GetComponent<Puntaje>().puntos -= 20; //Sumamos diez puntos al puntaje
                   Canvavidas.vida -=2;
               col.SendMessage("RetrocesoEnemigo", transform.position.x);// Enviamos un mensaje a Controles con Retroceso enemigo y enviamos como argumento la posicion en x del enemigo
           }
        }
}
}