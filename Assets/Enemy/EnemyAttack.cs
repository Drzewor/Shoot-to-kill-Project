using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    PlayerHealt target;
    [SerializeField] int damage = 10;
    void Start()
    {
        target = FindObjectOfType<PlayerHealt>();   
    }

    public void AttackHitEvent()
    {
        if(target == null) return;
        target.PlayerTakeDamage(damage);
    }
}
