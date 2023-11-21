using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapArea : MonoBehaviour
{
    public enum State //maybe here add "capturedblue/capturedred" or something like that
    {
        Neutral,
        Captured,
    }
    private List<MapAreaCollider> mapAreaColliderList;
    private State state;
    private float progress;

    private void Awake()
    {
        mapAreaColliderList = new List<MapAreaCollider>();

        foreach (Transform child in transform)
        {
            MapAreaCollider mapAreaCollider = child.GetComponent<MapAreaCollider>();
            if (mapAreaCollider != null)
            {
                mapAreaColliderList.Add(mapAreaCollider);
            }
        }

        state = State.Neutral;
    }

    private void Update()
    {
        switch (state)
        {
            case State.Neutral:
                List<PlayerMapAreas> playerMapAreasInsideList = new List<PlayerMapAreas>();
                foreach (MapAreaCollider mapAreaCollider in mapAreaColliderList)
                {
                    foreach (PlayerMapAreas playerMapAreas in mapAreaCollider.GetPlayerMapAreasList())
                    {
                        if (!playerMapAreasInsideList.Contains(playerMapAreas))
                        {
                            playerMapAreasInsideList.Add(playerMapAreas);
                        }
                    }
                }

                float progressSpeed = 1f;
                progress += playerMapAreasInsideList.Count * progressSpeed * Time.deltaTime;

                Debug.Log("playerCountInsideMapArea: " + playerMapAreasInsideList.Count + "; " + progress);

                if (progress >= 1f)
                {
                    state = State.Captured;
                    Debug.Log("Captured Point");
                }
                break;
            case State.Captured:
                break;
        }

    }
}
