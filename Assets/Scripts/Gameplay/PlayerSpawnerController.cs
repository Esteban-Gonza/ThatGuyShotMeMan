using Fusion;
using UnityEngine;

public class PlayerSpawnerController : NetworkBehaviour, IPlayerJoined, IPlayerLeft
{
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private NetworkPrefabRef playerNetworkPrefab = NetworkPrefabRef.Empty;

    public override void Spawned()
    {
        if (Runner.IsServer)
        {
            foreach(PlayerRef item in Runner.ActivePlayers)
            {
                SpawnPlayer(item);
            }
        }
    }

    private void SpawnPlayer(PlayerRef playerRef)
    {
        if (Runner.IsServer)
        {
            int index = playerRef.PlayerId % spawnPoints.Length;
            Vector3 spawnPoint = spawnPoints[index].position;
            NetworkObject playerObject = Runner.Spawn(playerNetworkPrefab, Vector3.zero, Quaternion.identity, playerRef);


            Runner.SetPlayerObject(playerRef, playerObject);
        }
    }

    private void DespawnPlayer(PlayerRef playerRef)
    {
        if (Runner.IsServer)
        {
            if(Runner.TryGetPlayerObject(playerRef, out NetworkObject playerNetworkObject))
            {
                Runner.Despawn(playerNetworkObject);
            }
        }

        // Reset player object
        Runner.SetPlayerObject(playerRef, null);
    }

    public void PlayerJoined(PlayerRef player)
    {
        SpawnPlayer(player);
    }

    public void PlayerLeft(PlayerRef player)
    {
        DespawnPlayer(player);
    }
}
