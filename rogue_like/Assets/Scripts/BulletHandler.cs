using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHandler : MonoBehaviour
{

    public GameObject hitEffect;
    private int dmg = 1;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Obstacle")
        {
            hitEffectPlay();
            Destroy(gameObject);
        }
    }


    void OnTriggerExit2D(Collider2D collider)
    {
         if(collider.tag == "Obstacle")
        {
            Destroy(gameObject);
        }
    }


    void OnTriggerStay2D(Collider2D collider)
    {
         if(collider.tag == "Obstacle")
        {
            Destroy(gameObject);
        }
    }


    void hitEffectPlay()
    {
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        effect.GetComponent<ParticleSystem>().Play();
        Destroy(effect, 5f);
    }

    public int getDmg()
    {
        return dmg;
    }

    public void setDmg ( int dmg)
    {
        this.dmg = dmg;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
