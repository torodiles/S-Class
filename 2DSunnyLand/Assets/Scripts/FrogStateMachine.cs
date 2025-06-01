using UnityEngine;

public class FrogStateMachine : MonoBehaviour
{
    public enum FrogState
    {
        Idle,
        Jumping,
        Dead
    }

    public FrogState currentState = FrogState.Idle;
    private Enemy enemyComponent;
    private FrogMovement movementComponent;

    private float jumpTimer;
    public float jumpInterval = 2f;

    void Start()
    {
        enemyComponent = GetComponent<Enemy>();
        movementComponent = GetComponent<FrogMovement>();

        jumpTimer = jumpInterval;
    }

    void Update()
    {
        switch (currentState)
        {
            case FrogState.Idle:
                HandleIdleState();
                break;
            case FrogState.Jumping:
                HandleJumpingState();
                break;
            case FrogState.Dead:
                HandleDeadState();
                break;
        }
    }

    void HandleIdleState()
    {
        jumpTimer -= Time.deltaTime;

        if (jumpTimer <= 0f)
        {
            TransitionToState(FrogState.Jumping);
        }

        if (enemyComponent.health <= 0)
        {
            TransitionToState(FrogState.Dead);
        }
    }

    void HandleJumpingState()
    {
        
        if (movementComponent.isGrounded() && GetComponent<Rigidbody2D>().linearVelocity.y <= 0.1f)
        {
            TransitionToState(FrogState.Idle);
        }

        if (enemyComponent.health <= 0)
        {
            TransitionToState(FrogState.Dead);
        }
    }

    void HandleDeadState()
    {
        movementComponent.enabled = false;
        GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        Destroy(gameObject, 0.5f);
    }

    void TransitionToState(FrogState newState)
    {
        currentState = newState;

        switch (newState)
        {
            case FrogState.Idle:
                jumpTimer = jumpInterval;
                break;
            case FrogState.Jumping:
                movementComponent.Jump();
                break;
            case FrogState.Dead:
                GetComponent<Collider2D>().enabled = false;
                break;
        }
    }
}
