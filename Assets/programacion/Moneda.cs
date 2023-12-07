using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class Moneda : MonoBehaviour
{

  public AudioClip clip; //Variable que contiene el audiosource
   
   private void OnTriggerEnter2D(Collider2D other){ //Llamado a que un objeto entre en colision
         if(other.tag == "Player"){ //Si el objeto con el que se colisiona es del tipo jugador
             AudioSource.PlayClipAtPoint(clip, new Vector3(5, 1, 2)); // Hace sonar el clip en un punto especifico
             Puntaje.puntos += 1; //Recambio    Sumamos diez puntos al puntaje 
             Destroy(gameObject); //Destruimos el objeto
         }
   }
}
