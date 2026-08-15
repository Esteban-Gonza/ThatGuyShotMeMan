using UnityEngine;

public class GlobalManagers : MonoBehaviour
{
    public static GlobalManagers Instance { get; private set; }

    [field: SerializeField] public NetworkRunnerController networkRunnerController { get; private set; }

    [Space(5)][Header("DDOL")]
    [SerializeField] private GameObject parentOBJ;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(parentOBJ);
        }
    }
}
