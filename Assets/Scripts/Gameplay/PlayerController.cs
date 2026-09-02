using Fusion;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : NetworkBehaviour, IBeforeUpdate
{
    [SerializeField] private float moveSpeed = 6f;

    private float horizontal;
    private Rigidbody2D rigidbody;

    public override void Spawned()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    public void BeforeUpdate()
    {
        if (!Object.HasInputAuthority)
            return;

        horizontal = 0f;

        if (Keyboard.current.aKey.isPressed)
            horizontal -= 1f;

        if (Keyboard.current.dKey.isPressed)
            horizontal += 1f;
    }

    public override void FixedUpdateNetwork()
    {
        if (Runner.TryGetInputForPlayer<PlayerData>(Object.InputAuthority,out PlayerData input))
        {
            rigidbody.linearVelocity = new Vector2(input.horizontalInput * moveSpeed, rigidbody.linearVelocityY);
        }
    }

    public PlayerData GetPlayerNetworkInput()
    {
        return new PlayerData{horizontalInput = horizontal};
    }
}
