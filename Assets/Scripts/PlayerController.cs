using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 50;
    public float upSpeed = 100;
    private bool puedoSaltar = false;
    
    
    private SpriteRenderer sr;
    private Animator animator;
    private Rigidbody2D rb2d;

    private WaitForSecondsRealtime tiempo;
    
    public GameObject rightBullet;
    private WaitForSeconds segundos;

    public Text scoreEnemig;
    
    private float switchColorDelay = .1f;
    private float switchColorTime = 0f;
    
    private Color originalColor;

 public int score = 5;
    
    
   
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        originalColor = sr.color;
    }

    // Update is called once per frame
    void Update()
    {
        
        switchColorTime += Time.deltaTime;
       

        if (Input.GetKeyDown(KeyCode.X) )
        {
            
            
           
            if (!sr.flipX)
            {
                if (switchColorTime > switchColorDelay)
                {
                    SwitchColor();
                }

                var position = new Vector2(transform.position.x + 1.5f, transform.position.y - .5f);
                Instantiate(rightBullet, position, rightBullet.transform.rotation);
            }
            else
            {
                var position = new Vector2(transform.position.x  - 1.5f, transform.position.y - .5f);
               // Instantiate(leftBullet, position, rightBullet.transform.rotation);
            }
              
        }
        
        
        
        SetQuietoAnimation();
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
            sr.flipX = false;
            SetCorrerAnimation();
            
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            
            rb2d.velocity = new Vector2(-speed, rb2d.velocity.y);
            sr.flipX = true;
            SetCorrerAnimation();
        }
        else
        {
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        }
        
        if (Input.GetKeyDown(KeyCode.Space) && puedoSaltar)
        {
            rb2d.velocity = Vector2.up * upSpeed;
            puedoSaltar = false;
           
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == 6)
        {
            puedoSaltar = true;
        }
        
        
        
        
    }
    private void SetQuietoAnimation()
    {
        animator.SetInteger("Estado",0);
    }
    private void SetCorrerAnimation()
    {
        animator.SetInteger("Estado",1);
    }
    
    
    private void SetSaltarAnimation()
    {
        animator.SetInteger("Estado",2);
    }
    
    private void SetCorrerDisparandoAnimation()
    {
        animator.SetInteger("Estado",3);
    }

   public void DisminuirPuntajeEn1()
      {
          score -= 1;
      }
    
   
   
   private void SwitchColor()
   {
       if(sr.color == originalColor)
           sr.color = Color.green;
       else
           sr.color = originalColor;
       switchColorTime = 0;
        
   }    
}
