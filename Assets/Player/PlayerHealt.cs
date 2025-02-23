using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHealt : MonoBehaviour
{
    [SerializeField] int playerMaxHP = 100;
    [SerializeField] int playerCurrentHP;
    [SerializeField] TextMeshProUGUI healtText;
    DisplayDamage displayDamage;
    public int GetplayerCurrentHP{get{return playerCurrentHP;}}
    

    void Start()
    {
        playerCurrentHP = playerMaxHP;
        displayDamage = GetComponent<DisplayDamage>();
    }

    public void PlayerTakeDamage(int damage)
    {
        playerCurrentHP -= damage;
        DisplayHP();
        displayDamage.ShowImpactCanvas();
        if(playerCurrentHP <= 0)
        {
            DeathHandlerer deathHandlerer = GetComponent<DeathHandlerer>();
            deathHandlerer.HandleDeath();
            Debug.Log("Game over... bruh...");
        }
    }

    private void DisplayHP()
    {
        healtText.text = $"HP: {playerCurrentHP}";
    }
}
