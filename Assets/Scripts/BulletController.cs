using UnityEngine;

public class BulletController : MonoBehaviour
{
    private ObjectSpawnManager objectSpawnManager = null;

    private void Awake()
    {
        objectSpawnManager = FindObjectOfType<ObjectSpawnManager>();
    }

    private void Update()
    {
        Vector3 pos = transform.position;
        pos.x += objectSpawnManager.objectSpeed * Time.deltaTime;
        transform.position = pos;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            gameObject.SetActive(false);
            other.gameObject.SetActive(false);
        }
        if (other.CompareTag("Barrier"))
        {
            gameObject.SetActive(false);
        }
    }
}
