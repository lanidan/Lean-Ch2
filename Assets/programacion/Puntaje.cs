using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //hay que agregar este modulo
using TMPro;

public class Puntaje : MonoBehaviour
{
    // Start is called before the first frame update
    
    public static int puntos; //declaramos la variable Puntos
    public TMP_Text textoPuntos; //declaramos la variable Texto

    // Update is called once per frame
    void Start()
    {
        puntos = 0; //Asignamos 3 vidas por nivel
        
    }
    void Update()
    {
        textoPuntos.text = "" + puntos.ToString(); //Agregamos al texto elegido "Puntaje: " + lo que tenga en la variable puntos

        if(puntos < 0){ //Si puntos es menor a 0 entonces...
            puntos = 0; //Los puntos como minimo quedaran a cero
        }
    }

   }

