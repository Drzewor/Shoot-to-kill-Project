using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealt : MonoBehaviour
{
    [SerializeField] int maxHP = 10;
    [SerializeField] int currentHP;
    private void Awake() 
    {
        currentHP = maxHP;
    }

    public void TakeDamage(int weaponDamage)
    {
        BroadcastMessage("OnDamageTaken");
        currentHP -= weaponDamage;
        if(currentHP <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        GetComponent<Animator>().SetTrigger("Death");
        gameObject.GetComponent<EnemyAI>().enabled = false;
        gameObject.GetComponent<BoxCollider>().enabled = false;
        gameObject.GetComponent<NavMeshAgent>().enabled = false;
    }
}
