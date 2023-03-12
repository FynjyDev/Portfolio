using UnityEngine;

public class SingletonController : MonoBehaviour
{
    public static SingletonController singletonController;

    public Config config;
    public UIController UIController;


    private void Awake()
    {
        if (singletonController) { Destroy(gameObject); return; }
        else singletonController = this;
    }
}