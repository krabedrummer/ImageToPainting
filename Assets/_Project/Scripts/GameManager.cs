using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OilPaint_JayeMoore
{
    public class GameManager : MonoBehaviour
    {
    

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKey("escape"))
            {
                Application.Quit();
                Debug.Log("Application Quit");
            }
        }

        public void QuitApplication()
        {
            Application.Quit();
            Debug.Log("Application Quit");
        }

        
    }
}