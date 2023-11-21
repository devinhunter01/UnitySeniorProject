using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapAreasCapturingUI : MonoBehaviour
{
    [SerializeField] private List<MapArea> mapAreaList;
    private Image progressImage;

    private void Awake() 
    {
        progressImage = transform.Find("ProgressImage").GetComponent<Image>();
        //This needs to be worked on later. Prefab can't reference scene, so need to find another way to display.
    }
    
}
