using UnityEngine;

public class ActivateObjectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject objectSpawner;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            objectSpawner.SetActive(true);
        }
    }
}
