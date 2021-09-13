using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickupHandler : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag.Equals("Player"))
        {
            ScoreTextScript.coinCount++;
            var colider = GetComponent<Collider2D>();
            if (colider != null)
            {
                colider.enabled = false;
            }
            Destroy(gameObject);
        }
    }
}
