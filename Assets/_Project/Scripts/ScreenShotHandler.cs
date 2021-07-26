using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ImageToPainting_JayeMoore
{
    public class ScreenShotHandler : MonoBehaviour
    {
        private static ScreenShotHandler instance; //static instance to trigger SS from a static function

        private Camera myCamera; //camera script goes on

        private bool takeScreenShotOnNextFrame; //bool to take SS for post render
        
        void Awake()
        {
            instance = this; //ScreenShotHandler instance
            myCamera = gameObject.GetComponent<Camera>(); //get camera on awake and cache it
           
        }

       

        private void OnPostRender() //capture SS after current frame has been rendered //triggers every frame so needs a boolean
        {
            if (takeScreenShotOnNextFrame)
            {
                takeScreenShotOnNextFrame = false; // if true , take SS and set to false
                RenderTexture renderTexture = myCamera.targetTexture; //reference to render texture

                Texture2D renderResult = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.ARGB32, false); // create new tex 2d to hold data dame size as render tex
                Rect rect = new Rect(0, 0, renderTexture.width, renderTexture.height); // create rect
                renderResult.ReadPixels(rect, 0, 0); //read rect

                byte[] byteArray = renderResult.EncodeToPNG(); //save to png
                //System.IO.File.WriteAllBytes(Application.dataPath + "/_Project/ScreenShots/CameraScreenShot.png", byteArray); //save to folder in project
                System.IO.File.WriteAllBytes(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop) + "/CameraScreenShot.png", byteArray); //save to user desktop
                Debug.Log("Saved camera screenshot"); //SS log
                RenderTexture.ReleaseTemporary(renderTexture); //clean up and release render tex
                myCamera.targetTexture = null; //set target to null
                
            }
        
        }

        private void TakeScreenShot(int width, int height) //receive width and height for SS
        {
            myCamera.targetTexture = RenderTexture.GetTemporary(width, height, 16); // create render texture and apply to camera
            takeScreenShotOnNextFrame = true;
        }

        public static void TakeScreenShot_Static(int width, int height) //static function to take SS
        {
            instance.TakeScreenShot(width, height); //take SS of width and height
        }

       
    }
}

