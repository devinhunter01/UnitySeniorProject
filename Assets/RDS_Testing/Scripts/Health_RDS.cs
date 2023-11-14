using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using TMPro;
using UnityEngine;

public class Health_RDS : MonoBehaviour
{
    public int health;
    public bool isLocalPlayer;
    
    [Header("UI")]
    public TextMeshProUGUI healthText;
    
     [PunRPC]
     public void TakeDamage(int _damage)
     {
        health -= _damage;

        healthText.text = health.ToString();

        if (health <= _damage)
        {
            if(isLocalPlayer)
                RoomManager_RDS.instance.SpawnPlayer();
            
         Destroy(gameObject); 
        }
     }
}
