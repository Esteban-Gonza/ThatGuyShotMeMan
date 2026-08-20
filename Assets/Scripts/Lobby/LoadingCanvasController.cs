using UnityEngine;
using UnityEngine.UI;

public class LoadingCanvasController : MonoBehaviour
{
    [SerializeField] private Animator loadAnimator;
    [SerializeField] private Button cancelBtn;

    private NetworkRunnerController networkRunnerController;

    private void Start()
    {
        networkRunnerController = GlobalManagers.Instance.networkRunnerController;
        networkRunnerController.OnStartedRunnerConnection += OnStartedRunnerConnection;
        networkRunnerController.OnPlayerJoinedSuccesfully += OnPlayerJoinedSuccesfully;

        cancelBtn.onClick.AddListener(networkRunnerController.ShutDownRunner);

        gameObject.SetActive(false);
    }

    private void OnPlayerJoinedSuccesfully()
    {
        const string CLIP_NAME = "Out";
        StartCoroutine(Utils.PlayAnimationAndSetState(gameObject, loadAnimator, CLIP_NAME, false));
    }
    
    private void OnStartedRunnerConnection()
    {
        const string CLIP_NAME = "In";
        this.gameObject.SetActive(true);
        StartCoroutine(Utils.PlayAnimationAndSetState(gameObject, loadAnimator, CLIP_NAME));
    }

    private void OnDestroy()
    {
        networkRunnerController.OnStartedRunnerConnection -= OnStartedRunnerConnection;
        networkRunnerController.OnPlayerJoinedSuccesfully -= OnPlayerJoinedSuccesfully;
    }
}
