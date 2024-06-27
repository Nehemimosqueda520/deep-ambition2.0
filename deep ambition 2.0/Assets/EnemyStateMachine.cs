using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    public Transform player;
    public float chaseDistance = 5f;
    public Renderer enemyRenderer;
    

    private IEnemyState currentState;

    private void Start()
    {
        enemyRenderer = GetComponent<Renderer>();
        ChangeState(new IdleState());
    }

    private void Update()
    {
        currentState.Execute(this);
    }

    public void ChangeState(IEnemyState newState)
    {
        if (currentState != null)
        {
            currentState.Exit(this);
        }
        currentState = newState;
        currentState.Enter(this);
    }

    public void ChangeColor(Color newColor)
    {
        if (enemyRenderer != null)
        {
            enemyRenderer.material.color = newColor;
        }
    }
}

public interface IEnemyState
{
    void Enter(EnemyStateMachine enemy);
    void Execute(EnemyStateMachine enemy);
    void Exit(EnemyStateMachine enemy);
}