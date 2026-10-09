using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private Renderer checkpointRenderer;

    private void Start()
    {
        checkpointRenderer = GetComponent<Renderer>();
    }
    private void OnTriggerEnter(Collider other)
    {
        playerController player = other.GetComponent<playerController>();
        if (player != null)
        {
            player.SetSpawnPoint(transform);
            Debug.Log("Checkpoint recolectado!");
            if (checkpointRenderer != null)
            {
                checkpointRenderer.material.color = Color.yellow; // Cambia el color del checkpoint a verde
            }
        }
    }
}