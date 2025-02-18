using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]

    private string enemyToLook = "Player";
    [SerializeField]
    private float speed = 1f;
    private Transform objective;

    private Health health;
    private void Start()
    {
        objective = GameObject.FindGameObjectWithTag(enemyToLook).transform;
        health = GetComponent<Health>();
    }

    private void Update()
    {
        FollowObjective();
    }

    private void FollowObjective()
    {
        Vector3 direction = (objective.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
        transform.rotation = Quaternion.LookRotation(direction);
    }

    private void OnCollisionEnter(Collision collison)
    {
        if (collison.gameObject.CompareTag("Bullet"))
        {
            health.TakeDamage(1);
            Destroy(collison.gameObject);
            SoundManager.instance.Play("Damage");
        }    
        
    }

    public void Die()
    {
        Destroy(gameObject);
        SoundManager.instance.Play("Mdeath");
    }
}
