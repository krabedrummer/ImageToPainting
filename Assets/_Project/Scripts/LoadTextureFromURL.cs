using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace ImageToPainting_JayeMoore
{
    public class LoadTextureFromURL : MonoBehaviour
    {
        
        float value; //slider value
        
        [SerializeField] private Renderer meshRenderer; //mesh we want to change material on
        [SerializeField] private Material sharedMaterial; // material on gameObject to be manipulated
        [SerializeField] private GameObject texturedObject; // Quad is used for an image plain
        [SerializeField] private InputField imageURL; // input field for URL of img
        [SerializeField] private Slider paintSlider; //slider used to control number of paint strokes
        
        private string TextureURL; //string of img URL
    
        
        void Update()
        {
            TextureURL = imageURL.text; // get URL from text in input field
           
            texturedObject.GetComponent<Renderer>().sharedMaterial.SetFloat("_Radius", value);// get the renderer of the Quad and get the material and its _Radius property value
            value = paintSlider.value; // set value to slider value
           // Debug.Log(value);
        }
        
        //Start coroutine to download img from TextureURL string
        public void LoadImage()
        {
            StartCoroutine(DownloadImage(TextureURL));
            TextureURL = null;
            Debug.Log("Image Loaded");
        }
        
        public void Reset()
        {
            gameObject.GetComponent<Renderer>().material.mainTexture = null; // clear image
            Debug.Log("Image Reset");
        }
        IEnumerator DownloadImage(string TextureURL)
        {
            UnityWebRequest request = UnityWebRequestTexture.GetTexture(TextureURL);  // web request for URL
            yield return request.SendWebRequest();
            
            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(request.error);
            }
            else
                this.gameObject.GetComponent<Renderer>().material.mainTexture = ((DownloadHandlerTexture)request.downloadHandler).texture; //download requested imaged
        }
    } 
}
