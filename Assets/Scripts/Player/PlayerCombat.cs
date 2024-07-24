using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour, ITakeDamage
{
    [SerializeField] private float maxHealth;
    [SerializeField] private float damageTakenPerHit;
    [SerializeField] private float invulnerabilityDuration;
    [SerializeField] private GameObject invulnerabilityBubble;
    private bool invPowerUp;
    private float currentHealth;
    private bool canTakeDamage;

    // Healths publicas para set inicial de slider de hp
    public float MaxHealth { get => maxHealth; set => maxHealth = value; }
    public float CurrentHealth { get => currentHealth; set => currentHealth = value; }
    public bool CanTakeDamage { get => canTakeDamage; set => canTakeDamage = value; } // Para pwpup invulnerabilidad
    public bool InvPowerUp { get => invPowerUp; set => invPowerUp = value; }

    public GameObject InvulnerabilityBubble { get => invulnerabilityBubble; }

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
        currentHealth -= damageToTake;

        OnHurt?.Invoke(currentHealth);

        if (currentHealth <= 0f)
        {
            GameManager.Instance.GameOver();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!canTakeDamage || !collision.gameObject.CompareTag("Enemy")) return;

        TakeDamage(damageTakenPerHit);
        StartCoroutine(InvulerabilityTime());
    }

    private IEnumerator InvulerabilityTime()
    {
        canTakeDamage = false;
        invulnerabilityBubble.SetActive(true);

        yield return new WaitForSeconds(invulnerabilityDuration);

        if (!invPowerUp)
        {
            invulnerabilityBubble.SetActive(false);
            canTakeDamage = true;
        }
    }
}
