using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Movimento : MonoBehaviour
{
    public static Movimento instancia;

    public TextMeshProUGUI textoPontuacao;

    public int frutasNecessarias = 15;

    public GameObject TextodeVitoria;

    private int frutas = 0;

    void Awake()
    {
        instancia = this;
    }

    void Start()
    {
        AtualizarTexto();
        TextodeVitoria.SetActive(false);
    }

    public void AdicionarPontos(int pontos)
    {
        frutas += pontos;
        AtualizarTexto();

        // Verifica se ganhou
        if (frutas >= frutasNecessarias)
        {
            VencerJogo();
        }
    }

    void AtualizarTexto()
    {
        textoPontuacao.text = "Frutas: " + frutas + "/" + frutasNecessarias;
    }

    void VencerJogo()
    {
        Debug.Log("VOCÊ GANHOU!");
        TextodeVitoria.SetActive(true);
    }
}