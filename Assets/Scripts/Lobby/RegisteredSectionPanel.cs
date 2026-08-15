using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Fusion;

public class RegisteredSectionPanel : LobbyPanelBase
{
    [Space(5f)]
    [Header("Local Variables")]
    [SerializeField] private Button joinRandomRoomBtn;
    [SerializeField] private Button joinRoomByArgBtn;
    [SerializeField] private Button createRoomBtn;

    [SerializeField] private TMP_InputField joinRoomByArgInputField;
    [SerializeField] private TMP_InputField createRoomInputField;

    public override void InitPanel(LobbyUIManager uiManager)
    {
        base.InitPanel(uiManager);

        joinRandomRoomBtn.onClick.AddListener(JoinRandomRoom);
        joinRoomByArgBtn.onClick.AddListener(() => CreateRoom(GameMode.Client, joinRoomByArgInputField.text));
        createRoomBtn.onClick.AddListener(() => CreateRoom(GameMode.Host, createRoomInputField.text));
    }

    private void CreateRoom(GameMode mode, string field)
    {
        if (field.Length >= 2)
        {
            GlobalManagers.Instance.networkRunnerController.StartGame(mode, field);
        }
    }

    private void JoinRandomRoom()
    {
        GlobalManagers.Instance.networkRunnerController.StartGame(GameMode.AutoHostOrClient, string.Empty);
    }
}
