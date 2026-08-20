using UnityEngine;

public class LobbyUIManager : MonoBehaviour
{
    [SerializeField] private LoadingCanvasController loadingCanvasController;
    [SerializeField] private LobbyPanelBase[] lobbyPanles;

    private void Start()
    {
        foreach(LobbyPanelBase lobby in lobbyPanles)
        {
            lobby.InitPanel(this);
        }

        Instantiate(loadingCanvasController);
    }

    public void ShowPanel(LobbyPanelBase.LobbyPanelType type)
    {
        foreach (LobbyPanelBase lobby in lobbyPanles)
        {
            if(lobby.PanelType == type)
            {
                lobby.ShowPanel();
            }
        }
    }
}
