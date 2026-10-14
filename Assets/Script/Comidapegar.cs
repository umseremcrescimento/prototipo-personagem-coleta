using UnityEngine;
using JetBrains.Annotations;

public class Comidapegar : MonoBehaviour
{
    public int valor = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Movimento.instancia.AdicionarPontos(valor);
            Destroy(gameObject);
        }
    }
}