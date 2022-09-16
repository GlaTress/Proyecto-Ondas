using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class OnTrigger : MonoBehaviour
{
    public GameObject UICHAT;
    public GameObject _Video_A_Reproducir_Canvas;
    public VideoPlayer Video;
    public bool InRange = false;
    // Start is called before the first frame update
    void Awake()
    {
        Video.Prepare();
    }

    // Update is called once per frame
    void Update()
    {
        if(InRange){
            if(Input.GetKeyDown(KeyCode.E)){
            _Video_A_Reproducir_Canvas.SetActive(true);
            
            }
            if(Video.isPlaying == false || Input.GetKeyDown(KeyCode.Return)){
                _Video_A_Reproducir_Canvas.SetActive(false);
            }
        }
        //Debug.Log(Video.isPlaying);
        
    }
    private void OnTriggerStay(Collider other) {
        InRange = true;
        UICHAT.SetActive(true);
        
    }
    private void OnTriggerExit(Collider other) {
        InRange = false;
        UICHAT.SetActive(false);
    }
}
