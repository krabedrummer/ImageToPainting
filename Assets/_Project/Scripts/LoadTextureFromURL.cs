using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace OilPaint_JayeMoore
{
    public class LoadTextureFromURL : MonoBehaviour
    {
        
        float value; //slider value
        // float prevValue;
        public Renderer meshRenderer;
        public Material sharedMaterial;
        public GameObject shadedObject;
        public InputField imageURL;
        
        public Slider paintSlider;
        
        private string TextureURL;
        void Start()
        {
            //meshRenderer = shadedObject.GetComponent<MeshRenderer>();
            //sharedMaterial = meshRenderer.sharedMaterial;
           // sharedMaterial.shader = Shader.Find("Custom/OilPaint");
            //value = sharedMaterial.GetFloat("_Radius");
           // paintSlider.value = value;
           //value = paintSlider.value;
        }
        
        void Update()
        {
            TextureURL = imageURL.text;
           
            shadedObject.GetComponent<MeshRenderer>().sharedMaterial.SetFloat("_Radius", value);
            value = paintSlider.value;
        }
        
        void  OnGUI() {
            //value = GUI.HorizontalSlider(new Rect(50, 675, 180, 50), value, 0.0F, 10.0F);
            

        }

       /*public void SetValue(float value)
       {
           value = paintSlider.value;
           this.value = value;
           Debug.Log(value);
           if (meshRenderer != null)
           {
               sharedMaterial.shader = Shader.Find("Custom/OilPaint");
               sharedMaterial.SetFloat("_Radius", this.value);
               
           }
       }*/

        public void LoadImage()
        {
            StartCoroutine(DownloadImage(TextureURL)); 
        }
        
        IEnumerator DownloadImage(string TextureURL)
        {
            UnityWebRequest request = UnityWebRequestTexture.GetTexture(TextureURL);
            yield return request.SendWebRequest();
            
            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(request.error);
            }
            else
                this.gameObject.GetComponent<Renderer>().material.mainTexture = ((DownloadHandlerTexture)request.downloadHandler).texture;
        }
    } 
}
