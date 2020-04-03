using UnityEngine;

public class atack : MonoBehaviour
{
    public Animator enemyAnim;
    //public Animator ShakeAnim;
    public Animator AtackAnim;
    private float timBtwAtack;
    public float StartTimeBtwAtack;

    public LayerMask whatIsEnemy;

    public Transform AtackPos;
    public float atackRange;
    private void Start()
    {

       
    }
    private void Update()
    {
        
        // if (timBtwAtack <= 0)
        //  {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            
            //ShakeAnim.SetBool("shake",true);
            AtackAnim.SetBool("atack", true);
            Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(AtackPos.position, atackRange, whatIsEnemy);
            for (int i = 0; i < enemiesToDamage.Length; i++)
            {
                enemiesToDamage[i].GetComponent<enemyAi>().Hit();
            }
        }
      
         
        
        //timBtwAtack = StartTimeBtwAtack;
        // }
        else
        {
        
            // ShakeAnim.SetBool("shake", false);
            //timBtwAtack -= Time.deltaTime;
            AtackAnim.SetBool("atack", false);
        }

    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(AtackPos.position, atackRange);
    }




}
