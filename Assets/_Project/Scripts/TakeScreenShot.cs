using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ImageToPainting_JayeMoore
{
    public class TakeScreenShot : MonoBehaviour
    {
        public void takeShot()
        {
            ScreenShotHandler.TakeScreenShot_Static(2048, 2048); //take sc of 2048 x 2048
        }
    }
}

