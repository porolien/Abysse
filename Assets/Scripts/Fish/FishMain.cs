using UnityEngine;

public class FishMain : MonoBehaviour
{
    public StateMachine stateMachine;
    public FishDetection detection;
    public FishMovement movement;
    public PatrolPath patrol;

    private void Awake()
    {
        SendMessage("Init", this);
    }
}
