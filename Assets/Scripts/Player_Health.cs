using Unity.VisualScripting;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth ;
    public int damagePerSecond;
    public int healingPerSecond;
    public float healingSpeed;
    public float damageSpeed; 
    public Health_Bar healthBar;

    [SerializeField] int currentHealth;
    private float timeSinceDamage;
    private float timeSinceHealing;
    private bool isDead;
    private bool isTakingDamage;
    private bool isHealingDamage;

    private const int sceneNumber = 0;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);
    }

    private void Update()
    {
        if (isDead)
            return;

        if (currentHealth <= 0 && !isDead)
        {
            isDead = true;
            // gameManager.SceneSwitch(sceneNumber);
        }

        if (isTakingDamage)
        {
            timeSinceDamage += Time.deltaTime;
            if (timeSinceDamage >= damageSpeed)
            {
                ApplyDamage(damagePerSecond);
                timeSinceDamage = 0f;
            }
        }

        if (isHealingDamage)
        {
            timeSinceHealing += Time.deltaTime;
            if (timeSinceHealing >= healingSpeed)
            {
                HealDamage(healingPerSecond);
                timeSinceHealing = 0f;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Gray_Zone"))
        {
            isTakingDamage = true;
            isHealingDamage = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Gray_Zone"))
        {
            isTakingDamage = false;
            isHealingDamage = true;
        }
    }

    private void ApplyDamage(int damage)
    {
        currentHealth = Mathf.Max(currentHealth - damage, 0);
        healthBar.SetHealth(currentHealth);
    }

    private void HealDamage(int heal)
    {
        currentHealth = Mathf.Min(currentHealth + heal, maxHealth);
        healthBar.SetHealth(currentHealth);
    }
}
