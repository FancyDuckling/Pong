using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Ball : MonoBehaviour
{
    //reset ball
    //public float startX = 0f;
    //public float startY = 4f;
    
    public ParticleSystem collisionParticle;
    public GameManager gameManager; //skapar en referens till gamemanager för score
   

    public float speed = 30;
    float hitFactor(Vector2 ballPos, Vector2 racketPos,
                float racketHeight)
    {
        // ascii art:
        // ||  1 <- at the top of the racket
        // ||
        // ||  0 <- at the middle of the racket
        // ||
        // || -1 <- at the bottom of the racket
        return (ballPos.y - racketPos.y) / racketHeight;
    }

    // Start : Initial Velocity
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
    }
    void EmitParticle(int amount)
    {
        collisionParticle.Emit(amount);
      
    }
    //Reset Ball
    /*void ResetBall()
    {
        float posY = Random.Range(-maxStartY, maxStartY);
        Vector2 position = new Vector2(startX, posY);
    }*/



    void OnCollisionEnter2D(Collision2D col)
    {

       

        // Note: 'col' holds the collision information. If the
        // Ball collided with a racket, then:
        //   col.gameObject is the racket
        //   col.transform.position is the racket's position
        //   col.collider is the racket's collider


        //Make BOOM when hit wall
        if (col.gameObject.name == "WallTop")
        {
            EmitParticle(70);
            
        }

        if (col.gameObject.name == "WallBottom")
        {
            EmitParticle(70);
        }

        if (col.gameObject.name == "WallLeft")
        {
            EmitParticle(70);
           
        }

        if (col.gameObject.name == "WallRight")
        {
            EmitParticle(70);
        }

        // Hit the left Racket?
        if (col.gameObject.name == "RacketLeft")

        {
   

            // Calculate hit Factor
            float y = hitFactor(transform.position,
                                col.transform.position,
                                col.collider.bounds.size.y);
        

            // Calculate direction, make length=1 via .normalized
            Vector2 dir = new Vector2(1, y).normalized;

            // Set Velocity with dir * speed
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }

        // Hit the right Racket?
        if (col.gameObject.name == "RacketRight")
        {
            // Calculate hit Factor
            float y = hitFactor(transform.position,
                                col.transform.position,
                                col.collider.bounds.size.y);
            

            // Calculate direction, make length=1 via .normalized
            Vector2 dir = new Vector2(-1, y).normalized;

            // Set Velocity with dir * speed
            GetComponent<Rigidbody2D>().velocity = dir * speed;


        }

         
         

    }
    //ScoreZone
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ScoreZone scoreZone = collision.GetComponent<ScoreZone>();
        if (scoreZone)
        {
            gameManager.OnScoreZoneReached(scoreZone.id);
        }
    }



}
