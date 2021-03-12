using UnityEngine;

public abstract class SingletonManager<T> : MonoBehaviour where T : SingletonManager<T>
{
    private static T _instance;

    public static T Instance
    {
        get
        {
            return _instance;
        }
    }

    protected virtual void Awake()
    {
        if (Instance == null)
        {
            _instance = this as T;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }
}
