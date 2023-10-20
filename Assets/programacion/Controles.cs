using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controles : MonoBehaviour
{
    public float velocidadmax = 10f; // Representa la fuerza maxima que le podemos aplicar al momento de controlarlo
    public float velocidad = 2f; // Representa la fuerza que le vamos a aplicar a nuestro personaje de manera horizontal
    private Rigidbody2D rb2d; //Creamos una variable del tipo RigidBody para poder utilizarlo dentro del script
    public bool suelo;
    public float saltofuerza = 6.7f; //Representa la fuerza el salto que le vamos a aplicar a nuestro personaje
    
    
   private Animator anim; //Creamos una variable del tipo Animator para poder utilizarlo en el Script
    private bool salto; //Esta variable es la encargada se saber si saltamos o no.
    
    private bool movimiento =true; // creamos una variable para activar o desactivar el movimiento

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>(); //Tomamos el RigidBody de unity y lo colocamos en rb2d
        anim = GetComponent<Animator>(); //Tomamos el Animator de unity y lo colocamos en anim
    
    }

    // Update is called once per frame
    void Update()
    { 
       if (Input.GetKeyDown(KeyCode.UpArrow) && suelo){ //Esto se lee como "Si apreto la flecha arriba y esta tocando el suelo pasa lo que está dentro de {}" El GetKeyDown nos dice que si presionamos una vez un boton, y el KeyCode.UpArrow nos dice que si apretamos el boton flecha arriba.
            salto = true; // Si se cumple lo anterior cambia el salto a true
        }
    
    }
    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal"); //La biblioteca de unity nos permite utilizar el GetAxis que nos servirá para detectar el eje horizontal cuando apretemos un boton de derecha o izq. De aqui tomamos la dirección
       
        if (!movimiento) h = 0; // Si el movimiento es falso, desactiva el movimiento   
        
        rb2d.AddForce(Vector2.right * velocidad * h); //Le agregamos una nueva fuerza a nuestro RigidBody, que va a ser el resultado de la multiplicacion de un vector que apunta a la derecha (Vector2.right), la velocidad y h
        float velocidadlimit = Mathf.Clamp(rb2d.velocity.x, -velocidadmax, velocidadmax); //Con clamp fijamos un valor entre un maximo y un minimo. Solo establecemos los limites
        rb2d.velocity =new Vector2(velocidadlimit,rb2d.velocity.y); //Con este vector le damos la velocidad maxima o minima con "velocidadlimit" en el eje x, y en el rb2d.velocity.y toma la velocidad actual en el eje y

        anim.SetFloat("velocidad",Mathf.Abs(rb2d.velocity.x)); // Le asignamos el valor absoluto de velocidad al parametro de velocidad del animator. 
        anim.SetBool("suelo", suelo); // Le asignamos el valor de suelo al parametro suelo del animator
        
        if (h > 0.1f){  // El "if" es un condicional que se lee como "Si". Lo que dice esta linea es que Si h es mayor 0.1 (Es decir, va hacia la derecha) pasará lo que esté entre los {}
            transform.localScale = new Vector3(2.89f, 2.15f, 1.05f); //Lo que queremos modificar es un valor del componente "Transform" de Unity, especificamente el de Scale, para ello le enviamos un vector con los valores que nosotros deseamos (1,1,1) es decir, que mire hacia la derecha
        }
        if (h < -0.1f){ //Lo que dice esta linea es que Si h es mayor 0.1 (Es decir, va hacia la izquierda) pasará lo que esté entre los {}
            transform.localScale = new Vector3(-2.89f, 2.15f, 1.05f); //Lo que queremos modificar es un valor del componente "Transform" de Unity, especificamente el de Scale, para ello le enviamos un vector con los valores que nosotros deseamos (-1,1,1) es decir, que mira hacia la izquierda
        }
        
        if (salto){ //Se lee como Si la variable salto esta activado hace lo que este entre los {}
            rb2d.velocity = new Vector2(rb2d.velocity.x,0); //Con esto solucionamos el error del super salto luego de saltar sobre una plataforma unidireccional.
            rb2d.AddForce(Vector2.up * saltofuerza, ForceMode2D.Impulse); //Como sabemos, Unity se maneja con fuerzas, por ello le aplicamos una fuerza que tendrá como direccion hacia arriba multiplicada por el saltofuerza. Además diremos que esta nueva fuerza es solo un impulso con el ForecemMode2D
            salto = false;
        }

        
    } 
   //Saltar cuando pisamos un enemigo
        
        public void SaltarEnemigo(){ //Creamos un llamado a Saltar enemigo
            salto = true;  //Ponemos Saltar como verdadero
        }

        public void RetrocesoEnemigo(float enemiPosX){ //Creamos un llamado a Retroceso enemigo y pedimos que nos manden la posicion en X del enemigo
            salto = true;  //Ponemos Saltar como verdadero
            float lado = Mathf.Sign(enemiPosX - transform.position.x); //Creamos la variable de lado, Mathf.Sign va aser la encargada de determinar el signo y así poder saber de que lado recibe el daño
            rb2d.AddForce(Vector2.left * lado * saltofuerza, ForceMode2D.Impulse); //agregamos una nueva fuerza donde lo nuevo que intervendrá es la variable lado.
           movimiento = false; //desactivamos el movimiento 
           Invoke("Habilitarmovimiento", 0.7f); // Reactiva el movimiento 
        }

        void Habilitarmovimiento(){ //creamos un llamado al movimiento
            movimiento= true; //Ponemos el movimiento como verdadero 
        }
}
