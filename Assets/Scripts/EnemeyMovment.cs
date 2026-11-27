using System.Collections;
using UnityEngine;
public class EnemeyMovment : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float distanceToReach = 0.1f;

    [Header("Animation")]
    [SerializeField] private Animator animator;
    [SerializeField] private string hitTrigger = "Hit";
    [SerializeField] private float destroyDelay = 0.8f;

    [Header("Health")]
    [SerializeField] private float startHealth = 100f;
    [SerializeField] private float damagePerHit = 10f;

    [Header("Hit Detection")]
    [SerializeField] private string damageTag = "Unit";
    [SerializeField] private GameObject hitEffect;
    [SerializeField] private GameObject deathEffect;
    [SerializeField] private float effectLifetime = 2f;
    [SerializeField] private int damageToPlayer = 1;

    private Transform[] waypoints;
    private float health;
    private float speed;
    private int waypointIndex = 0;
    private bool reachedEnd = false;
    private bool isDead = false;
    
    public void Init(Transform[] path)
    {
        waypoints = path;
    }

    private void Start()
    {
        health = startHealth * Waves.HealthMultiplier;
        speed = moveSpeed * Waves.SpeedMultiplier;
        transform.position = waypoints[waypointIndex].position;

        if (animator == null)
            animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if (Time.timeScale == 0f) return;
        if (!reachedEnd && !isDead) Move();
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(
            transform.position, waypoints[waypointIndex].position, speed * 0.15f);

        if (Vector3.Distance(transform.position, waypoints[waypointIndex].position) <= distanceToReach)
        {
            waypointIndex++;
            if (waypointIndex >= waypoints.Length)
            {
                reachedEnd = true;
                StartCoroutine(HitAndDie());
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(damageTag)) TakeDamage(damagePerHit);
    }

    public void TakeDamage(float amount)
    {
        if (isDead || reachedEnd) return;

        health -= amount;
        SpawnEffect(hitEffect);

        if (health <= 0f)
            Die();
    }

    private void Die()
    {
        isDead = true;
        SpawnEffect(deathEffect);
        ScoreSystem.instance.Add(10);
        Waves.EnemiesAlive--;
        Destroy(gameObject);
    }

    private void SpawnEffect(GameObject effectPrefab)
    {
        if (effectPrefab == null) return;
        GameObject fx = Instantiate(effectPrefab, transform.position, Quaternion.identity);
        Destroy(fx, effectLifetime);
    }

    private IEnumerator HitAndDie()
    {
        if (animator != null)
            animator.SetTrigger(hitTrigger);

        yield return new WaitForSeconds(destroyDelay);
        Health.instance.TakeDamage(damageToPlayer);
        Waves.EnemiesAlive--;
        Destroy(gameObject);
    }
}