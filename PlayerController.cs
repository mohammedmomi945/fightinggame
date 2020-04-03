using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    public int health = 100;
    public float movmentSpeed = 5f;


    public Rigidbody2D rb;
    Vector2 movment;
    public Animator Animator;
    public Slider healthbar;
    private void Start()
    {
        
    }
    private void Update()
    {
        healthbar.maxValue = health;
        healthbar.value = health;
        die();
        flip();
        anim();
       
        movment.x = Input.GetAxis("Horizontal");
        movment.y = Input.GetAxis("Vertical");
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movment * movmentSpeed * Time.fixedDeltaTime);
    }
    private void anim()
    {
        Animator.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));
        Animator.SetFloat("SpeedUp", Mathf.Abs(Input.GetAxis("Vertical")));
    }
    void flip()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
    }
    void die()
    {
        if (health <= 0)
        {
            Time.timeScale = 0;
        }
    }
}
