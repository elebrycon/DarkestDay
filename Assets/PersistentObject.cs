using UnityEngine;

public class PersistentObject : MonoBehaviour
{
    void Awake()
    {
        // Prevent this object from being destroyed when loading a new scene
        DontDestroyOnLoad(gameObject);
    }
}
