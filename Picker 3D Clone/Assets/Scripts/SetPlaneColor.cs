using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlaneColor : MonoBehaviour
{
    [SerializeField] private SectionData sectionData;
    void Start()
    {
        gameObject.GetComponent<MeshRenderer>().material = sectionData.sectionMaterial;
    }
    
}
