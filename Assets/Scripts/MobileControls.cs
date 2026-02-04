using UnityEngine;

public class MobileControls : MonoBehaviour
{
    [SerializeField] GameObject mobileControlsObject;
    [SerializeField] PlayerMove playerMove;
    bool isHeldLeft;
    bool isHeldRight;
    bool isHeldJump;
    [SerializeField] int speed;
    [SerializeField] int jumpHeight;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        #if UNITY_IOS || UNITY_ANDROID || UNITY_WEBGL
            mobileControlsObject.SetActive(true);
        #else
            mobileControlsObject.SetActive(false);
        #endif
    }

    // Update is called once per frame
    void Update()
    {
        if (isHeldLeft)
        {
            playerMove.SetPlayerMoveMobile(-1, 0);
        }
        else if (isHeldRight)
        {
            playerMove.SetPlayerMoveMobile(1, 0);
        }
        else if (isHeldJump)
        {
            playerMove.SetPlayerMoveMobile(0, 1);
        }
        else
        {
            playerMove.ResetPlayerMoveMobile();
        }
    }

    public void OnMovementKeyDown(MovementKey movementKey)
    {
        switch (movementKey)
        {
            case MovementKey.Left:
                isHeldLeft = true;
                break;
            case MovementKey.Right:
                isHeldRight = true;
                break;
            case MovementKey.Jump:
                isHeldJump = true;
                break;
        }
    }

    public void OnMovementKeyUp(MovementKey movementKey)
    {
        switch (movementKey)
        {
            case MovementKey.Left:
                isHeldLeft = false;
                break;
            case MovementKey.Right:
                isHeldRight = false;
                break;
            case MovementKey.Jump:
                isHeldJump = false;
                break;
        }
    }
}

public enum MovementKey
{
    Left,
    Right,
    Jump
}