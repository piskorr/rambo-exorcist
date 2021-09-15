using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    [SerializeField]
    public static int MaxHealth = 50;
    [SerializeField]
    public static int CurrentHealth;
    [SerializeField]
    public static int Damage = 5;
    [SerializeField]
    public static int MovementSpeed = 5;

    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = MaxHealth;
    }


}
