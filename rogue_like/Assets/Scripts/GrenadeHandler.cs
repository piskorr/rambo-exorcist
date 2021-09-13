using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeHandler : MonoBehaviour
{
    public GameObject explosionEffect;
    public float grenadeDelay = 5.0f;
    public float grenadeRadius = 10.0f;

    private float delayTimer = 0.0f;
    public Collider2D[] targets;
    private ContactFilter2D filter;

    void Start()
    {
        delayTimer = Time.time + grenadeDelay;
    }


    void Update()
    {
        if (Time.time > delayTimer)
        {
            hitEffectPlay();
        }
    }


    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Obstacle")
        {
            hitEffectPlay();
        }
    }


    private void hitEffectPlay()
    {
        GameObject effect = Instantiate(explosionEffect, transform.position, Quaternion.identity);
        effect.GetComponent<ParticleSystem>().Play();
        DamageTargets();
        Destroy(gameObject);
        Destroy(effect, 5f);
    }


    private void DamageTargets()
    {
        filter.SetLayerMask(LayerMask.GetMask("Enemy"));
        targets = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y), grenadeRadius, filter.layerMask);
        foreach (Collider2D target in targets)
        {

            target.GetComponentInParent<EnemyBehaviour>().GetBlastDamage();
            Debug.Log("hit");
        }
    }


    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
