using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ImageToPainting_JayeMoore
{
    public class GameManager : MonoBehaviour
    {
    

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKey("escape")) //Quit app from Escape
            {
                Application.Quit();
                Debug.Log("Application Quit");
            }
        }

        public void QuitApplication()
        {
            Application.Quit(); // Quit app from UI BTN
            Debug.Log("Application Quit");
        }

        
    }
}
