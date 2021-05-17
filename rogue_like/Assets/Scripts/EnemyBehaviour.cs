using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    #region Public Variables
    public Transform rayCast;
    public LayerMask raycastMask;
    public float rayCastLength;
    public float attackDistance;
    public float moveSpeed;
    public float timer;
    public int maxHealth = 20;
    public int health;
    public GameObject body;
    public Animator animator;
    #endregion

    #region Private Variables
    private RaycastHit2D hit;
    private Transform target;
    private float distance;
    private bool attackMode;
    private bool inRange;
    private bool cooling;
    private float intTimer;
    #endregion

    void Awake()
    {
        intTimer = timer;
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange)
        {
            hit = Physics2D.Raycast(rayCast.position, Vector2.left * rayCastLength, raycastMask);
            RaycastDebugger();
        }
        if(hit.collider!=null)
        {
            EnemyLogic();
        }
        else
        {
            inRange = false;
        }

    }

    void EnemyLogic()
    {
        distance = Vector2.Distance(transform.position, target.position);
        if (distance > attackDistance)
        {

            Move();
            StopAttack();
        }
        else if (distance < attackDistance)
        {
            Attack();
        }

        if(cooling)
        {
            Cooldown();
            //animator.SetBool("isAttacking", false);
        }
    }

    void Move()
    {
        Flip();
        Vector2 targetPosition = new Vector2(target.position.x, target.position.y);
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }

    void Attack()
    {
        animator.SetBool("isAttacking", true);
        attackMode = true;
    }

    void Cooldown()
    {
        timer -= Time.deltaTime;
        if(timer<= 0 && cooling && attackMode)
        {
            cooling = false;
            timer = intTimer;
        }
    }

    void StopAttack()
    {
        animator.SetBool("isAttacking", false);
        cooling = false;
        attackMode = false;
    }


    void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.tag == "Player")
        {
            target = trig.transform;
            inRange = true;
            
        }
    }
    
    public void OnHitEffect(int dmg)
    {
        
        health -= dmg;
        if (health <= 0)
            Destroy(gameObject);
    }

    private void Flip()
    {
        Vector3 rotation = transform.eulerAngles;
        if(transform.position.x < target.position.x)
        {
            rotation.y = 180f;
        }
        else
        {
            rotation.y = 0f;
        }

        transform.eulerAngles = rotation;
    }

    public void TriggerCooldown()
    {
        cooling = true;
    }

    void RaycastDebugger()
    {
        if (distance > attackDistance)
        {
            Debug.DrawRay(rayCast.position, Vector2.left * rayCastLength, Color.red);
        }
        else if (distance < attackDistance)
        {
            Debug.DrawRay(rayCast.position, Vector2.left * rayCastLength, Color.green);
        }
    }

}

