using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int MaxHitpoints=5;
    [Tooltip("Adds chosen amount to increase difficulty")]
    [SerializeField] int DifficultyRamp;
    int CurrentHitpoint;
    Enemy enemy;
    void Start()
    {
        enemy = FindObjectOfType<Enemy>();   
    }
    void OnEnable()
    {
        CurrentHitpoint = MaxHitpoints;
    }
    void OnParticleCollision(GameObject other)
    {
        CurrentHitpoint--;
        Debug.Log("Iam shot");
        if (CurrentHitpoint <= 0) { gameObject.SetActive(false);enemy.RewardGold();MaxHitpoints += DifficultyRamp; }
    }
    // Update is called once per frame
}
