using UnityEngine;
using UnityEngine.SceneManagement;

public class AttackState : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Asegúrate de que el objeto que colisiona es el jugador
        if (other.CompareTag("Player"))
        {
            // Reinicia la escena actual
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}