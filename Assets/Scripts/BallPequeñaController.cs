using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class BallPequeñaController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float velocityx = 10f;
    
    private PlayerController playerController;
    public GameObject rightBullet;
    
   

  //  private int score = 4;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerController = FindObjectOfType<PlayerController>();
        
        Destroy(gameObject,3);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = Vector2.right * velocityx;
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            
            Destroy(gameObject);
            playerController.DisminuirPuntajeEn1();
            //Destroy(rightBullet.gameObject);
           
            if (playerController.score == 0)
            {
                Destroy(other.gameObject);
                Destroy(this.gameObject);
            }
           
           // playerController.IncrementarPuntajeEn10();
        }
    }
    
   

}
