using System.Collections;
using System.Collections.Generic;
using OilPaint_JayeMoore;
using UnityEngine;

namespace OilPaint_JayeMoore
{
    public class TakeScreenShot : MonoBehaviour
    {
        public void takeShot()
        {
            ScreenShotHandler.TakeScreenShot_Static(2048, 2048);
        }
    }
}

