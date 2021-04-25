using UnityEngine;

public class BulletController : MonoBehaviour
{
    private void Update()
    {
        Vector3 pos = transform.position;
        pos.x += 6f * Time.deltaTime;
        transform.position = pos;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Barrier"))
        {
            gameObject.SetActive(false);
        }
    }
}
