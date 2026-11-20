using System.Collections;
using UnityEngine;
public class EnemeyMovment : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private Animator animator;
    [SerializeField] private string hitTrigger = "Hit";  
    [SerializeField] private float destroyDelay = 0.8f;
    private int waypointIndex = 0;
    private bool reachedEnd = false;
    private void Start()
    {
        transform.position = waypoints[waypointIndex].position;

        if (animator == null)
            animator = GetComponentInChildren<Animator>();
    }
    private void Update()
    {
        if (!reachedEnd) Move();
    }
    private void Move()
    {
        transform.position = Vector3.MoveTowards(
            transform.position,
            waypoints[waypointIndex].position,
            moveSpeed * Time.deltaTime);
        if (transform.position == waypoints[waypointIndex].position)
        {
            waypointIndex++;
            if (waypointIndex >= waypoints.Length)
            {
                reachedEnd = true;
                StartCoroutine(HitAndDie());
            }
        }
    }
    private IEnumerator HitAndDie()
    {
        if (animator != null)
            animator.SetTrigger(hitTrigger);
        yield return new WaitForSeconds(destroyDelay);
        Destroy(gameObject);
    }
}