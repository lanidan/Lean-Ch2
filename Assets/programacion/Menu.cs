using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//esto
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Iniciar()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
 Application.Quit();
    }

            
}
