using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    [SerializeField] private ObjectSpawnManager objectSpawnManager = null;
    public float bgMoveSpeed = 1f;
    private float speed = 1f;

    private void Update()
    {
        if (objectSpawnManager.isGameOver == false)
        {
            speed += bgMoveSpeed * Time.deltaTime;
            RenderSettings.skybox.SetFloat("_Rotation", speed);
        }
    }
}
