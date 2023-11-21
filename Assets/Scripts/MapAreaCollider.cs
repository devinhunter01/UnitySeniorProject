using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapAreaCollider : MonoBehaviour
{
    private List<PlayerMapAreas> playerMapAreasList = new List<PlayerMapAreas>();
    public void OnTriggerEnter(Collider collider) 
    {
        if (collider.TryGetComponent<PlayerMapAreas>(out PlayerMapAreas playerMapAreas)) 
        {
            playerMapAreasList.Add(playerMapAreas);
        }
    }

    public void OnTriggerExit(Collider collider) 
    {
        if (collider.TryGetComponent<PlayerMapAreas>(out PlayerMapAreas playerMapAreas)) 
        {
            playerMapAreasList.Remove(playerMapAreas);
        }
    }

    public List<PlayerMapAreas> GetPlayerMapAreasList()
    {
        return playerMapAreasList;
    }
}
