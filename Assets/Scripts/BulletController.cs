using UnityEngine;

public class BulletController : MonoBehaviour
{
    private ObjectSpawnManager objectSpawnManager = null;

    private void Start()
    {
        objectSpawnManager = FindObjectOfType<ObjectSpawnManager>();
    }

    private void Update()
    {
        if (objectSpawnManager.isGameOver == false)
        {
            Vector3 pos = transform.position;
            pos.x += 6f * Time.deltaTime;
            transform.position = pos;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Barrier"))
        {
            gameObject.SetActive(false);
        }
    }
}
