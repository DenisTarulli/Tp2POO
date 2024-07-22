using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour, ITakeDamage
{
    [SerializeField] private float maxHealth;
    private float currentHealth;
    private bool canTakeDamage;

    // Healths publicas para set inicial de slider de hp
    public float MaxHealth { get => maxHealth; set => maxHealth = value; }
    public float CurrentHealth { get => currentHealth; set => currentHealth = value; }
    public bool CanTakeDamage { get => canTakeDamage; set => canTakeDamage = value; } // Para pwpup invulnerabilidad

    public static event Action<float> OnHurt;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    private void Start()
    {
        canTakeDamage = true;
    }

    private void Update()
    {

    }

    public void TakeDamage(float damageToTake)
    {
        OnHurt?.Invoke(damageToTake);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
