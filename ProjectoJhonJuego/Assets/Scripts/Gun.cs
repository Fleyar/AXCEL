using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Gun : MonoBehaviour
{
    public float gun;
    public Text gunText;

    public static Gun instance;
    
    private void Awake() {
        if(instance == null)
        {
            instance = this;
        }
    }

    private void Start() {
        gunText.text = "x " + gun.ToString();
    }

    public void Drug(float gunCollected)
    {
        gun += gunCollected;
        gunText.text = "x " + gun.ToString();
    }
    public void lvl(){
        if(gun == 1){
            SceneManager.LoadScene(2);
        }
    }
}
