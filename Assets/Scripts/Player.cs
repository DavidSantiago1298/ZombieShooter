using System;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Health health;

    private UIcontroller uicontroller;

    private bool isPlaying = true;

    private void Start()
    {
        health = GetComponent<Health>();
        uicontroller = GetComponent<UIcontroller>();
    }
    private void OnCollisionEnter (Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            health.TakeDamage(1);
            Vector3 pushDirection = (transform.position - collision.transform.position).normalized;
            transform.position += pushDirection * 0.5f;
        }
        else if (collision.gameObject.CompareTag("Key"));
        {
            isPlaying = false;
            uicontroller.ShowWinUI(true);
        }
    }

    public void Die()
    {
        uicontroller.ShowGameOverUI(true);
    }
}
