using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform shotSpawn = null;
    private ObjectSpawnManager objectSpawnManager = null;
    private ObjectPooler objectPooler = null;
    private Vector3 movement = Vector3.zero;

    private void Awake()
    {
        objectSpawnManager = FindObjectOfType<ObjectSpawnManager>();
        objectPooler = FindObjectOfType<ObjectPooler>();
    }

    private void Start()
    {
        transform.position = new Vector3(-8f, 0f, 0f);
        InvokeRepeating(nameof(Shot), 1f, 2f);
    }

    private void Update()
    {
        if (objectSpawnManager.isGameOver == false)
        {
            movement.x = -Input.acceleration.y;
            movement.z = Input.acceleration.x;
            if (movement.sqrMagnitude > 1)
            {
                movement.Normalize();
            }
            movement *= Time.deltaTime;
            transform.Translate(movement * 12.0f);
        }
    }

    private void Shot()
    {
        GameObject enemy = objectPooler.GetPooledBulletObject();
        if (enemy != null)
        {
            enemy.transform.position = shotSpawn.position;
            enemy.SetActive(true);
        }
    }

    public void StopShot()
    {
        CancelInvoke();
    }
}
