using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    void Start() 
    {
        AudioManager.instance.PlayAudio(AudioManager.instance.main);
    }
    
    public GameObject John;
    
    void Update()
    {
        if (John != null){
        Vector3 position = transform.position;
        position.x = John.transform.position.x;
        transform.position = position;
        }
    }
}
