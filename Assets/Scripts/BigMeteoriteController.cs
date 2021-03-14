using UnityEngine;

public class BigMeteoriteController : MonoBehaviour
{
    private ObjectSpawnManager _objectSpawnManager = null;

    private void Start()
    {
        _objectSpawnManager = FindObjectOfType<ObjectSpawnManager>();
    }

    private void Update()
    {
        Vector3 pos = transform.position;
        pos.x -= _objectSpawnManager.cubeSpeed * Time.deltaTime;
        transform.position = pos;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //_objectSpawnManager.ScoreTouch();
            Debug.Log("Touch1");
            //Destroy(gameObject);
        }
        //else if (other.CompareTag("Boundary"))
        //{
        //    _objectSpawnManager.SpawnCube();
        //    Debug.Log("Touch2");
        //    Destroy(gameObject);
        //}
    }
}
