using UnityEngine;

public class MobileControls : MonoBehaviour
{
    [SerializeField] GameObject mobileControlsObject;
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
        
    }

    public void OnMovementKeyPress(MovementKey movementKey)
    {
        switch (movementKey)
        {
            
        }
    }
}

public enum MovementKey
{
    Left,
    Right,
    Jump
}