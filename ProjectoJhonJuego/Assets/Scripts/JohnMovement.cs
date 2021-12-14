using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JohnMovement : MonoBehaviour
{
    public GameObject BulletPrefab;
    public float Speed;
    public float JumpForce;
    private Rigidbody2D Rigidbody2D;
    private Animator Animator;
    private float Horizontal;
    private bool Grounded;
    private float LastShoot;
    private int Health = 5;
    private int sube = 0;

    public bool isDead;
    public GameObject gameOverImg;


    void Start()
    {
        gameOverImg.SetActive(false);
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();

        if (!isDead){
            gameOverImg.GetComponent<CanvasGroup>().alpha = 0.0f;
        }
    }
    void Update()
    {
        
        Horizontal = Input.GetAxisRaw("Horizontal");

        if (Horizontal < 0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (Horizontal > 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        
        if(Input.GetKey(KeyCode.S)){
             sube = 1;
        } else sube = 0;

        Animator.SetBool("running", Horizontal != 0.0f);
        Animator.SetBool("down", sube == 1);

        //Debug.DrawLine(transform.position, Vector3.up * 0.2f, Color.red);
        if (Physics2D.Raycast(transform.position, Vector3.down, 0.2f))
        {
            Grounded = true;
        }
        else Grounded = false;
        if (Input.GetKeyDown(KeyCode.W)&& Grounded)
        {
          Jump();
        }
        if (Input.GetKey(KeyCode.Space) && Time.time > LastShoot + 0.25f){
        Shoot();
        LastShoot = Time.time;
        }
    }
   

    private void Jump()
   {
       AudioManager.instance.PlayAudio(AudioManager.instance.jmp);
        Rigidbody2D.AddForce(Vector2.up * JumpForce);
   }
   private void Shoot(){

       AudioManager.instance.PlayAudio(AudioManager.instance.rifle);

       Vector3 direction;
       if (transform.localScale.x == 1.0f) direction = Vector3.right;
       else direction = Vector3.left;

       GameObject bullet = Instantiate(BulletPrefab, transform.position + direction * 0.1f, Quaternion.identity);
       bullet.GetComponent<BulletScript>().SetDirection(direction);
   }
  
    private void FixedUpdate()
   {
        Rigidbody2D.velocity = new Vector2(Horizontal, Rigidbody2D.velocity.y);
   }

   public void Hit() {

       AudioManager.instance.PlayAudio(AudioManager.instance.hurt);

       Health = Health -1;
       if (Health == 0){
           Animator.SetBool("dead", Health == 0);
           isDead = true;
       }
}

public void IsDead(){
    if (isDead){
        gameOverImg.SetActive(true);
    }if (gameOverImg.GetComponent<CanvasGroup>().alpha < 1f){
        gameOverImg.GetComponent<CanvasGroup>().alpha += 0.005f;
    }
       }

public void Destroyjhon (){
        Destroy(gameObject);
    }

} 

