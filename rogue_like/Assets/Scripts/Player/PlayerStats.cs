using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    public static int MaxHealth = 20;
    public static int CurrentHealth;
    public static int Damage = 5;
    public static int MovementSpeed = 5; 

    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = MaxHealth;
    }

    
}
