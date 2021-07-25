using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace OilPaint_JayeMoore
{
    public class ScreenShotHandler : MonoBehaviour
    {
        private static ScreenShotHandler instance;

        private Camera myCamera;

        private bool takeScreenShotOnNextFrame;
        
        //[SerializeField] private Text saveMessage;
    
        
        void Awake()
        {
            instance = this;
            myCamera = gameObject.GetComponent<Camera>();
           // saveMessage = GetComponent<Text>();
        }

        void Start()
        {
           // saveMessage.enabled = false;
        }

        private void OnPostRender()
        {
            if (takeScreenShotOnNextFrame)
            {
                takeScreenShotOnNextFrame = false;
                RenderTexture renderTexture = myCamera.targetTexture;

                Texture2D renderResult = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.ARGB32, false);
                Rect rect = new Rect(0, 0, renderTexture.width, renderTexture.height);
                renderResult.ReadPixels(rect, 0, 0);

                byte[] byteArray = renderResult.EncodeToPNG();
                //System.IO.File.WriteAllBytes(Application.dataPath + "/_Project/ScreenShots/CameraScreenShot.png", byteArray);
                System.IO.File.WriteAllBytes(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop) + "/CameraScreenShot.png", byteArray);
                Debug.Log("Saved camera screenshot");
                RenderTexture.ReleaseTemporary(renderTexture);
                myCamera.targetTexture = null;
                //saveMessage.enabled = true;
            }
        
        }

        private void TakeScreenShot(int width, int height)
        {
            myCamera.targetTexture = RenderTexture.GetTemporary(width, height, 16);
            takeScreenShotOnNextFrame = true;
        }

        public static void TakeScreenShot_Static(int width, int height)
        {
            instance.TakeScreenShot(width, height);
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}

