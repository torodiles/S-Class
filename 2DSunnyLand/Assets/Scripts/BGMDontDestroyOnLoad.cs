using Unity.VisualScripting;
using UnityEngine;

public class BGMDontDestroyOnLoad : MonoBehaviour
{
    public BGMDontDestroyOnLoad Instance;
    // SINGLETON
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        Instance = this;
        DontDestroyOnLoad(Instance);

    }
}
