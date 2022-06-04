using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class DetectObjectCollision : MonoBehaviour
{
    public static event Action SectionPassed = delegate {  };
    
    [SerializeField] private TextMeshProUGUI countText;
    [SerializeField] private SectionData sectionData;
    [SerializeField] private Transform leftBarrier, rightBarrier;

    private MeshRenderer _meshRenderer;
    public int numberOfDetectedObjects;
    private bool _objectLimitReached = false;

    private void Start()
    {
        ComponentInitialization();
    }

    private void Update()
    {
        MovePlatformAfterObjectLimitIsReached();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Object"))
        {
            //get text 
            numberOfDetectedObjects++;
            countText.text = numberOfDetectedObjects + " / " + sectionData.objectLimit;
        }
    }

    void MovePlatformAfterObjectLimitIsReached()
    {
        if (numberOfDetectedObjects >= sectionData.objectLimit && !_objectLimitReached)
        {
            _objectLimitReached = true;
            StartCoroutine("MovePlatform");
        }
    }

    IEnumerator MovePlatform()
    {
        yield return new WaitForSeconds(2f);
        gameObject.transform.DOMoveY(0f, 0.5f);
        //Vector3 pos = gameObject.transform.position;
        //gameObject.transform.position = new Vector3(pos.x, 0f, pos.z);
        _meshRenderer.material = sectionData.sectionMaterial;
        StartCoroutine("OpenBarrier");
    }

    IEnumerator OpenBarrier()
    {
        leftBarrier.DORotate(new Vector3(0, 0, 90), 1, RotateMode.LocalAxisAdd);
        rightBarrier.DORotate(new Vector3(0, 0, -90), 1, RotateMode.LocalAxisAdd);
        yield return new WaitForSeconds(1f);
        //Move Player Again
        Player.MagnetPlayer.isPlayerStopped = false;
        // Notify UI 
        SectionPassed.Invoke();
    }

    void ComponentInitialization()
    {
        _meshRenderer = gameObject.GetComponent<MeshRenderer>();
        countText.text = "0 / " + sectionData.objectLimit;
    }
}
