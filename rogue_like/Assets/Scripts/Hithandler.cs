using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hithandler : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.tag == "Bullet")
        {
            GetComponentInParent<EnemyBehaviour>().OnHitEffect(trig.GetComponentInParent<BulletHandler>().getDmg());
        }
    }
}
