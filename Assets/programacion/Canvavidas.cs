
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Canvavidas : MonoBehaviour
{

    static public int vida; //Variable que contiene las vidas. Dice static al inicio para que otros scripts puedan acceder a esta variable
    public Animator animvida; //Variable que toma el Animator


    // Start is called before the first frame update
    void Start()
    {
        animvida = GetComponent<Animator>(); //tomamos el animator y lo guardamos en la variable animvida
        vida=4;
    }
       void Update()
    {
        animvida.SetInteger("vidas", vida); //Vinculamos el script con el parametro de la animacion
    }
}