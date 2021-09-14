using System;
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
    public int maxHealth = 20;
    public int health;
    public GameObject body;
    public Animator animator;
    public GameObject coinPrefab;
    #endregion

    #region Protected Variables
    protected RaycastHit2D hit;
    protected Transform target;
    protected float distance;
    protected bool attackMode;
    protected bool inRange;
    #endregion

    protected virtual void Awake()
    {
        health = maxHealth;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<BoxCollider2D>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("isWalking", (inRange && !attackMode));
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

    protected virtual void EnemyLogic()
    {
        
        distance = Vector2.Distance(transform.position, target.position);
        Move();
        attackMode = false;
        if (distance < attackDistance)
        {
            attackMode = true;
        }
    }

    internal void GetBlastDamage()
    {
        Destroy(gameObject);
    }

    protected void Move()
    {
        Flip();
        Vector2 targetPosition = new Vector2(target.position.x, target.position.y);
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }


    void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.tag == "Player")
        {
            inRange = true;
        }
    }
    
    public void OnHitEffect(int dmg)
    {
        inRange = true;
        health -= dmg;
        if (health <= 0)
        {
            Defeat();
        }
    }

    public virtual void Defeat()
    {
        Destroy(gameObject);
        GameObject coin = Instantiate(coinPrefab, transform.position, Quaternion.Euler(0, 0, 1));
    }

    protected void Flip()
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

