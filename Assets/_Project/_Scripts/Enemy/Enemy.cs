using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private const string PepeTag = "Pepe";
    private const string SmileyTag = "Smiley";
    private const string WomanTag = "Woman";

   [SerializeField] private int _hp = 0;

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag(PepeTag))
        {
            --_hp;
        }

        if(other.collider.CompareTag(SmileyTag))
        {
            _hp-=2;
        }

        if(other.collider.CompareTag(WomanTag))
        {
            // Nothing...
        }

        if (_hp <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}