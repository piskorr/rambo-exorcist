using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour
{

    public Animator animator;
    public Camera gameCamera;
    public float characterSpeed;
    public bool characterFacingRight = true;
    public static HealthBar healthBar;

    private SpriteRenderer sprite;
    private Rigidbody2D rigidbody2D;
    private Vector3 characterMovement;    
    private Vector2 mousePosition;
    private float lastDmgTime = 0;
    private float invincibility = 1;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        healthBar.SetMaxhealth(PlayerStats.MaxHealth);
    }


    void Update()
    {
        characterMovement = Vector3.zero;
        characterMovement.x = Input.GetAxisRaw("Horizontal");
        characterMovement.y = Input.GetAxisRaw("Vertical");

        mousePosition = gameCamera.ScreenToWorldPoint(Input.mousePosition);

        if(characterMovement.x == 0 && characterMovement.y == 0)
        {
            animator.SetBool("isPlayerRunning", false);
        }
        else
        {
            animator.SetBool("isPlayerRunning", true);
        }        
    }


    void FixedUpdate()
    {
        Move();
        UpdateDirection();       
    }


    void UpdateDirection()
    {
        Vector2 lookDirection = mousePosition - rigidbody2D.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        
        if((angle < 90 && angle > -90) && !characterFacingRight)
        {
            FlipCharacter();
        }
       else 
       if((angle > 90 || angle < -90) && characterFacingRight)
        {
            FlipCharacter();    
        }
    }


    void Move()
    {
        rigidbody2D.MovePosition(transform.position + characterMovement * PlayerStats.MovementSpeed * Time.deltaTime);
    }


    private void FlipCharacter()
	{
		characterFacingRight = !characterFacingRight;
        sprite.flipX = !sprite.flipX;
		
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Attack" && Time.time-lastDmgTime>invincibility)
        {
            lastDmgTime = Time.time;
            PlayerStats.CurrentHealth -= 10;
            healthBar.SetHealth(PlayerStats.CurrentHealth);
        }
    }
}
