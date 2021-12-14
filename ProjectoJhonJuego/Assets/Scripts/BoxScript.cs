using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour
{
    private Animator Animator;

    private int Health = 1;

    void Start()
    {
        Animator = GetComponent<Animator>();
    }
    
    public void Hit() {
       Health = Health -1;
       if (Health == 0){
           Animator.SetBool("dead", Health == 0);
       }
   }
    public void DestroyBox (){
        Destroy(gameObject);
    } 
}
