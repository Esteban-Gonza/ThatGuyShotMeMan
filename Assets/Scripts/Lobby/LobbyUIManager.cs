using UnityEngine;

public class LobbyUIManager : MonoBehaviour
{
    [SerializeField] private LobbyPanelBase[] lobbyPanles;

    private void Start()
    {
        foreach(LobbyPanelBase lobby in lobbyPanles)
        {
            lobby.InitPanel(this);
        }
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
