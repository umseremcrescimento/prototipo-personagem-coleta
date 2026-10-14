using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Movimento2 : MonoBehaviour
{
    [Header("Movimento")]
    public float velocidade = 5f;
    public float velocidadeGiro = 720f;

    [Header("Pulo e Gravidade")]
    public float alturaPulo = 5f;
    public float gravidade = -20f;

    private CharacterController controller;
    private float velocidadeY;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Entrada
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 direcao = new Vector3(h, 0, v);

        if (direcao.magnitude > 1f)
        {
            direcao.Normalize();
        }

        // Giro
        if (direcao != Vector3.zero)
        {
            Quaternion rotacaoAlvo = Quaternion.LookRotation(direcao);

            transform.rotation = Quaternion.RotateTowards(
                transform.rotation,
                rotacaoAlvo,
                velocidadeGiro * Time.deltaTime
            );
        }

        // Gravidade e pulo
        if (controller.isGrounded)
        {
            if (velocidadeY < 0)
            {
                velocidadeY = -2f;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                velocidadeY = Mathf.Sqrt(alturaPulo * -2f * gravidade);
            }
        }

        velocidadeY += gravidade * Time.deltaTime;

        // Movimento completo
        Vector3 movimento = direcao * velocidade;
        movimento.y = velocidadeY;

        controller.Move(movimento * Time.deltaTime);
    }
}