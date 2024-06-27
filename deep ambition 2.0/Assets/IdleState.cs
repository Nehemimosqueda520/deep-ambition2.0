using UnityEngine;

public class IdleState : IEnemyState
{
    public void Enter(EnemyStateMachine enemy) 
    {
        enemy.ChangeColor(Color.green); // Cambia el color a verde en el estado Idle
    }

    public void Execute(EnemyStateMachine enemy)
    {
        if (Vector3.Distance(enemy.transform.position, enemy.player.position) <= enemy.chaseDistance)
        {
            enemy.ChangeState(new ChaseState());
        }
    }

    public void Exit(EnemyStateMachine enemy) 
    {
        // Código para limpiar el estado Idle
    }
}