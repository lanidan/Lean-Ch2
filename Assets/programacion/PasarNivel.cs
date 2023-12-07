using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PasarNivel : MonoBehaviour

    // Start is called before the first frame update
    {
        
    

    
   private void OnTriggerEnter2D(Collider2D other){ //Llamado a que un objeto entre en colision
         if(other.tag == "Player"){ 
    SceneManager.LoadScene(2);
   }
   }
}
