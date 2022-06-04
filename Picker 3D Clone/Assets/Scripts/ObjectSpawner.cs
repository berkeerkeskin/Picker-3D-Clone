using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private Transform propeller, spawnPoint;
    [SerializeField] private GameObject pyramid;
    [SerializeField] private List<Transform> spawnPoints;

    private Vector3 _position;
    private bool _isSpawned;
    private void Awake()
    {
        ComponentInitialization();
    }
    
    void Update()
    {
        RotatePropeller();
        SpawnPyramids();
    }

    void SpawnPyramids()
    {
        if (!_isSpawned)
        {
            StartCoroutine("Spawn");
            _isSpawned = true;
        }
        
    }

    IEnumerator Spawn()
    {
        MoveSpawner();
        for (int i = 0; i < 50; i++)
        {
            yield return new WaitForSeconds(0.08f);
            Instantiate(pyramid, spawnPoint.position, Quaternion.Euler(-90, 0, 0));
        }
        Destroy(gameObject);
    }

    void RotatePropeller()
    {
        //Rotate propeller
        propeller.DOLocalRotate(new Vector3(0, 360, 0), 5, RotateMode.LocalAxisAdd).SetLoops(-1);
    }

    void MoveSpawner()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(gameObject.transform.DOMoveX(spawnPoints[0].position.x, 0.1f));
        sequence.Append(gameObject.transform.DOMoveZ(_position.z + 20, 1f));
        sequence.Append(gameObject.transform.DOMoveX(spawnPoints[2].position.x, 0.1f));
        sequence.Append(gameObject.transform.DOMoveZ(_position.z + 40, 1f));
        sequence.Append(gameObject.transform.DOMoveX(spawnPoints[1].position.x, 0.1f));
        sequence.Append(gameObject.transform.DOMoveZ(_position.z + 60, 1f));
        sequence.Append(gameObject.transform.DOMoveX(spawnPoints[0].position.x, 0.1f));
        sequence.Append(gameObject.transform.DOMoveZ(_position.z + 80, 1f));
    }

    void ComponentInitialization()
    {
        gameObject.SetActive(false);
        _position = gameObject.transform.position;
    }
}
