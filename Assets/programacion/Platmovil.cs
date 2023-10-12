using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platmovil : MonoBehaviour
{
    public Transform target; //Esta variable sera la encargada tomar el objeto target
    public float velocidad; //Esta variable sera la encargada de tomar la velocidad en la que se movera la plataforma


    private Vector3 inicio, final; //Declaramos dos variables que seran las encargadas de cambiar informacion para intercambiar el target con la posicion inicial de la plataforma movil


    // Start is called before the first frame update
    void Start()
    {
        if(target != null){ //Verificamos si target es distinto de vacio
            target.parent =null; //Desvinculamos la jerarquia del target con la plataforma movil
            inicio = transform.position; //guardamos la primera posicion de la plataforma
            final = target.position; // guardamos la primera posicion del target

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate(){
        if (target != null){// Si el target no está vacio, hace lo que esta entre las llaves
            transform.position = Vector3.MoveTowards(transform.position,target.position, velocidad * Time.deltaTime); //Esta linea es la encargada de mover nuestra plataforma, para ello le enviamos un vector3 que contiene (la posicion de la plataforma movil, la posicion del target, la velocidad multiplicada por un time delta )
        }
        if (transform.position == target.position){ //Verificamos que la plataforma movil llegó a la posicion del target
             target.position = (target.position == inicio) ? final : inicio; // El ? es un operador ternario. Esto nos dice que: Si la posicion del target es igual al inicio entonces cambia la posicion del target al final, lo cambia con el valor inicio.
        }
      
        
    }
}
