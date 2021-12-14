using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GruntScript : MonoBehaviour
{
    private Animator Animator;
    public GameObject BulletEnemyPrefab;
    public GameObject John;
    private float LastShoot;
    private int Health = 5;

    void Start()
    {
        Animator = GetComponent<Animator>();
    }

    public void Update()
    {
        if (John == null) return;
        Vector3 direction = John.transform.position - transform.position;
        if (direction.x >= 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        else transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);

        float distance = Mathf.Abs(John.transform.position.x - transform.position.x);
        if (distance < 1.0f && Time.time > LastShoot + 0.25f)
        {
            Shoot();
            LastShoot = Time.time;
        }
    }
    private void Shoot(){

        AudioManager.instance.PlayAudio(AudioManager.instance.rifle);
        
        Vector3 direction;
       if (transform.localScale.x == 1.0f) direction = Vector3.right;
       else direction = Vector3.left;

       GameObject bullet = Instantiate(BulletEnemyPrefab, transform.position + direction * 0.1f, Quaternion.identity);
       bullet.GetComponent<BulletEnemyScript>().SetDirection(direction);
   }    
   public void Hit() {
       Health = Health -1;
       if (Health == 0){
           Animator.SetBool("dead", Health == 0);
       }
   }

    public void Destroygrunt (){
        Destroy(gameObject);
    } 
}