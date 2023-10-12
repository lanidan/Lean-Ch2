using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seguir : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject seguir; // creamos una variable llamada seguir
    public Vector2 minCamPos, maxCamPos; //Definimos un máximo y un minimo para limitar el movimiento de la camara

    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float posX= seguir.transform.position.x;
        float posY= seguir.transform.position.y;
//transform.position=new Vector3(posX,posY, transform.position.z);
        transform.position=new Vector3(
            Mathf.Clamp(posX, minCamPos.x, maxCamPos.x),   //Limitamos el eje X
            Mathf.Clamp(posY,minCamPos.y, maxCamPos.y),    //Limitamos el eje Y
          transform.position.z);
    }
}
