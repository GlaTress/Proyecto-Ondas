using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoIntro : MonoBehaviour
{
    public GameObject CanvasGrande;
    public VideoPlayer VideoPrinc;
    public GameObject CanvasVideo;
    private bool Preparado = true;
    private void Awake() {
        VideoPrinc.Prepare();
        
    } 
       
    

    // Update is called once per frame
    void Update()
    {
        //while(!(VideoPrinc.isPrepared)){
        //    continue;
        //}
        //VideoPrinc.Play();
        Debug.Log(VideoPrinc.isPrepared);
        if(Preparado == false && VideoPrinc.isPlaying){
            Preparado = true;
        }
        if(Preparado == true && VideoPrinc.isPlaying == false || Input.GetKeyDown(KeyCode.Return)){
            CanvasGrande.SetActive(true);
            CanvasVideo.SetActive(false);
        }
        

    }
}
