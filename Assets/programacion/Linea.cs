using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Linea : MonoBehaviour
{
    public Transform desde; //Creamos la variable encargada del inicio del dibujo
    public Transform hasta; //Creamos la variable encargada del final del dibujo
    // Start is called before the first frame update
    
    void OnDrawGizmosSelected(){
        if (desde != null && hasta != null){ //Nos aseguramos que el inicio y el final no esten vacios
            Gizmos.color =Color.blue; //Definimos un color de la linea
            Gizmos.DrawLine(desde.position,hasta.position); // Dibujamos la linea en la posicion "desde" a la posicion de "hasta"
            Gizmos.DrawSphere(desde.position, 0.15f); //Dibujamos una esfera en la posición desde 
            Gizmos.DrawSphere(hasta.position, 0.15f); //Dibujamos una esfera en la posicion hasta
        }
    }
}
