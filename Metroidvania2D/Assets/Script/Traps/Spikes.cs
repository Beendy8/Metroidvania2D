using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private AudioClip hit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SoundManager.instance.PlaySound(hit);
            collision.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
    }
}
