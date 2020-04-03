using System.Collections;
using UnityEngine;

public class enemyAi : MonoBehaviour
{
    float HitTimer;

    //
    //Variebals
    public Animator Shake;
    public GameObject Player;
    float Timer1;
    public PlayerController PlayerController;
    public int slimedamage = 5;
    public GameObject particales;
    public int damage = 5;
    public float Health;
    public Animator animator;
    public float speed;
    public float position_from_player;
    private Transform Target;
    float timer;
    public float MaxTimer;
    
    void Start()
    {
      
        Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        //Kills if health =0
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
        if (Target.position.x > transform.position.x)
        {
            //face right
            transform.localScale = new Vector3(5, 5, 1);
        }
        else if (Target.position.x < transform.position.x)
        {
            //face left
            transform.localScale = new Vector3(-5, 5, 1);
        }

        //Follow player
        if (Vector2.Distance(transform.position, Target.position) > position_from_player)
        {

            Player.GetComponent<Renderer>().material.color = Color.white;
            Timer1 = 0;
            transform.position = Vector2.MoveTowards(transform.position, Target.position, speed * Time.deltaTime);
            animator.SetBool("moving", true);
        }
       else if (Vector2.Distance(transform.position, Target.position) < position_from_player)
        {
               
            //Timer
            Timer1 += Time.deltaTime;
            if (Timer1 > 1)
            {
                
            }
          
        }
    }
    public void Hit()
    {
        
        Shake.SetTrigger("Shake");
        //Hit
        HitTimer += Time.deltaTime;
        if (HitTimer <= 0.2f)
        {
           
            animator.SetBool("Hit", true);
        }
        else
        {
            HitTimer = 0;
            Debug.Log("lol");
            animator.SetBool("Hit", false);
        }
        Health -= damage;
        Instantiate(particales, transform.position, Quaternion.identity);
       
    }
   
   
}
