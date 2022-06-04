using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DetectObjectCollision : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI countText;
    [SerializeField] private SectionData sectionData;
    public int numberOfDetectedObjects;
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Object"))
        {
            //get text 
            numberOfDetectedObjects++;
            countText.text = numberOfDetectedObjects + " / " + sectionData.objectLimit;
        }
    }
}
