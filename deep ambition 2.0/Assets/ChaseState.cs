using UnityEngine;
using UnityEngine.AI;

public class ChaseState : IEnemyState
{
    private NavMeshAgent agent;

    public void Enter(EnemyStateMachine enemy)
    {
        enemy.ChangeColor(Color.red); // Cambia el color a rojo en el estado Chase
        agent = enemy.GetComponent<NavMeshAgent>();

        if (!agent.isOnNavMesh)
        {
            Debug.LogError("NavMeshAgent is not on the NavMesh at the start of ChaseState.");
            return;
        }

        agent.isStopped = false;
    }

    public void Execute(EnemyStateMachine enemy)
    {
        if (agent.isOnNavMesh)
        {
            agent.SetDestination(enemy.player.position);

            if (Vector3.Distance(enemy.transform.position, enemy.player.position) > enemy.chaseDistance)
            {
                enemy.ChangeState(new IdleState());
            }
        }
        else
        {
            Debug.LogWarning("NavMeshAgent is not on the NavMesh.");
        }
    }

    public void Exit(EnemyStateMachine enemy)
    {
        agent.isStopped = true;
    }
}
