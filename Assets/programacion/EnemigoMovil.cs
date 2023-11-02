using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoMovil : MonoBehaviour{


	public Transform target; //Esta variable sera la encargada tomar el objeto target
    public float velocidad; //Esta variable sera la encargada de tomar la velocidad en la que se movera la plataforma
    private Vector3 inicio, final; //Declaramos dos variables que seran las encargadas de cambiar informacion para intercambiar el target con la posicion inicial de la plataforma movil
		public SpriteRenderer spriteEnemy;   	

    void Start()
    {
        if(target != null){ //Verificamos si target es distinto de vacio
            target.parent =null; //Desvinculamos la jerarquia del target con la plataforma movil
            inicio = transform.position; //guardamos la primera posicion de la plataforma
            final = target.position; // guardamos la primera posicion del target

        }
      
      	spriteEnemy = GetComponent<SpriteRenderer>();
      
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
       			spriteEnemy.flipX = !spriteEnemy.flipX ;
        }
      
        
    }
  void OnTriggerEnter2D(Collider2D col){  //llamamos a la funcion cuando trigger entra al collider 2D
        if (col.gameObject.tag == "Player"){ //Se lee como "Si la colision se produce con un tag jugador"
            
           float yResta = 0.7f; //Esto lo usamos como ajuste. Si no está este ajuste, cuando el jugador lo toca de frente se eliminaria
           if(transform.position.y + yResta < col.transform.position.y){ // Se lee como "Si la posicion del enemigo es menor a la posicion del jugador entonces..."
                col.SendMessage("SaltarEnemigo"); //Hacemos un llamado a saltar Enemigo a Controles cuando lo pisamos 
                Destroy(gameObject); //Esta linea es la encargada de desruir el objeto
           } else { //Sino
                   Canvavidas.vida -=2;
               col.SendMessage("RetrocesoEnemigo", transform.position.x);// Enviamos un mensaje a Controles con Retroceso enemigo y enviamos como argumento la posicion en x del enemigo
           }
        }
    }
}
