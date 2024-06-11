using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth;
    public int damagePerSecond;
    public int healingPerSecond;
    public float healingSpeed;
    public float damageSpeed; 
    public Health_Bar healthBar;
    public Transform respawnPoint; // Assign this in the Inspector

    [SerializeField] int currentHealth;
    private float timeSinceDamage;
    private float timeSinceHealing;
    private bool isDead;
    private bool isTakingDamage;
    private bool isHealingDamage;
    
    private Rigidbody RB;

    private const int sceneNumber = 0;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);
        RB = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (isDead)
            return;

        if (currentHealth <= 0 && !isDead)
        {
            isDead = true;
            Respawn();
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
            timeSinceDamage = 0f; // Reset timeSinceDamage
        }

    }


    private void OnTriggerExit(Collider other)

    {

        if (other.CompareTag("Gray_Zone"))

        {

            isTakingDamage = false;

            isHealingDamage = true;

            timeSinceHealing = 0f; // Reset timeSinceHealing

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

    private void Respawn()
    {
        transform.position = respawnPoint.position;
        currentHealth = maxHealth;
        healthBar.SetHealth(currentHealth);
        isDead = false;
    }
}