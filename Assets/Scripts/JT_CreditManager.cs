using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JT_CreditManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("WaitToEnd", 300); //300 seconds
    }

    // Change this to go to whatever the mainmenu scene is
    void Update()
   {
       if (Input.anyKey)
       {
           SceneManager.LoadScene("DH_MainMenu");
       }
   }

    public void WaitToEnd()
    {
        SceneManager.LoadScene("DH_MainMenu");
    }
}
