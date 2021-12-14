using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DrugsScript : MonoBehaviour
{
    public float drug;
    public Text drugText;

    public static DrugsScript instance;
    
    private void Awake() {
        if(instance == null)
        {
            instance = this;
        }
    }

    private void Start() {
        drugText.text = "x " + drug.ToString();
    }

    public void Drug(float drugCollected)
    {
        drug += drugCollected;
        drugText.text = "x " + drug.ToString();
    }
    public void lvl(){
        if(drug == 13){
            SceneManager.LoadScene(3);
        }
    }
}
