using UnityEngine;

public class FishMain : MonoBehaviour
{
    public StateMachine stateMachine;
    public FishDetection detection;
    public FishMovement movement;
    public PatrolPath patrol;

    public bool afraidByLight;

    private void Awake()
    {
        SendMessage("Init", this);
    }
}
