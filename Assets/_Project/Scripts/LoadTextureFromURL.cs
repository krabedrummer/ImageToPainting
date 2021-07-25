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
        [SerializeField] private Renderer meshRenderer;
        [SerializeField] private Material sharedMaterial;
        [SerializeField] private GameObject texturedObject;
        [SerializeField] private InputField imageURL;
        
        [SerializeField] private Slider paintSlider;
        
        private string TextureURL;
    
        
        void Update()
        {
            TextureURL = imageURL.text;
           
            texturedObject.GetComponent<Renderer>().sharedMaterial.SetFloat("_Radius", value);
            value = paintSlider.value;
            Debug.Log(value);
        }
        

        public void LoadImage()
        {
            StartCoroutine(DownloadImage(TextureURL));
            TextureURL = null;
            Debug.Log("Image Loaded");
        }
        
        public void Reset()
        {
            gameObject.GetComponent<Renderer>().material.mainTexture = null;
            Debug.Log("Image Reset");
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
