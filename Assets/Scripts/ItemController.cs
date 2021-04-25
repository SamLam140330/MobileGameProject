using UnityEngine;

public class ItemController : MonoBehaviour
{
    private PlayerController playerController = null;
    private ObjectSpawnManager objectSpawnManager = null;

    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        objectSpawnManager = FindObjectOfType<ObjectSpawnManager>();
    }

    private void Update()
    {
        if (objectSpawnManager.isGameOver == false)
        {
            Vector3 pos = transform.position;
            pos.x -= 5f * Time.deltaTime;
            transform.position = pos;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerController.AddBullet();
            if (GameManager.Instance.isAudioOn == true)
            {
                GameManager.Instance.PlaySound(0);
            }
            gameObject.SetActive(false);
        }
        if (other.CompareTag("Barrier"))
        {
            gameObject.SetActive(false);
        }
    }
}
