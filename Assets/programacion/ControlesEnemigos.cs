using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlesEnemigos : MonoBehaviour
{
    public float velocidadmax = 1f; // Representa la fuerza maxima que le podemos aplicar al momento de controlarlo
    public float velocidad = 1f; // Representa la fuerza que le vamos a aplicar a nuestro personaje de manera horizontal
    //public GameObject Controlador;
    //private GameObject Controlador;  //Variable que contiene el objeto Controlador del juego
    private Rigidbody2D rb2d; //Creamos una variable del tipo RigidBody para poder utilizarlo dentro del script

    void Start()
    {
    rb2d = GetComponent<Rigidbody2D>(); //Tomamos el RigidBody de unity y lo colocamos en rb2d
    //Controlador = GetComponent<Puntaje>()
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb2d.AddForce(Vector2.right * velocidad ); //Le agregamos una nueva fuerza a nuestro RigidBody, que va a ser el resultado de la multiplicacion de un vector que apunta a la derecha (Vector2.right), la velocidad
        float velocidadlimit = Mathf.Clamp(rb2d.velocity.x, -velocidadmax, velocidadmax); //Con clamp fijamos un valor entre un maximo y un minimo. Solo establecemos los limites
        rb2d.velocity =new Vector2(velocidadlimit,rb2d.velocity.y); //Con este vector le damos la velocidad maxima o minima con "velocidadlimit" en el eje x, y en el rb2d.velocity.y toma la velocidad actual en el eje y
    
    if(rb2d.velocity.x > -0.01f && rb2d.velocity.x < 0.01f){ //comprobamos si choca contra un objeto, se da vuelta
        velocidad=-velocidad; //esta linea es el cambio de direccion
        rb2d.velocity = new Vector2(velocidad, rb2d.velocity.y); // le indicamos al rb2d la nueva velocidad
    }
     if (velocidad > 0f){  //Lo que dice esta linea es que la velocidad es positivo (Es decir, va hacia la derecha) pasará lo que esté entre los {}
            transform.localScale = new Vector3(1f, 1f, 1f); //Lo que queremos modificar es un valor del componente "Transform" de Unity, especificamente el de Scale, para ello le enviamos un vector con los valores que nosotros deseamos (1,1,1) es decir, que mire hacia la derecha
        }
        else if (velocidad < 0f){ //Lo que dice esta linea es que la velocidad es negativo (Es decir, va hacia la izquierda) pasará lo que esté entre los {}
            transform.localScale = new Vector3(-1f, 1f, 1f); //Lo que queremos modificar es un valor del componente "Transform" de Unity, especificamente el de Scale, para ello le enviamos un vector con los valores que nosotros deseamos (-1,1,1) es decir, que mira hacia la izquierda
        }
    }

    //Programación de eliminar al personaje

    void OnTriggerEnter2D(Collider2D col){  //llamamos a la funcion cuando trigger entra al collider 2D
        if (col.gameObject.tag == "jugador"){ //Se lee como "Si la colision se produce con un tag jugador"
            
           float yResta = 0.7f; //Esto lo usamos como ajuste. Si no está este ajuste, cuando el jugador lo toca de frente se eliminaria
           if(transform.position.y + yResta < col.transform.position.y){ // Se lee como "Si la posicion del enemigo es menor a la posicion del jugador entonces..."
                //Controlador.GetComponent<Puntaje>().puntos += 20; //Sumamos diez puntos al puntaje
                col.SendMessage("SaltarEnemigo"); //Hacemos un llamado a saltar Enemigo a Controles cuando lo pisamos 
                Destroy(gameObject); //Esta linea es la encargada de desruir el objeto
           } else { //Sino
              // Controlador.GetComponent<Puntaje>().puntos -= 20; //Sumamos diez puntos al puntaje
               col.SendMessage("RetrocesoEnemigo", transform.position.x);// Enviamos un mensaje a Controles con Retroceso enemigo y enviamos como argumento la posicion en x del enemigo
           }
        }
    }
}
