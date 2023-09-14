using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porta : MonoBehaviour
{
    // Distância a partir da qual o jogador pode interagir com a porta
    public float distanciaInteracao;

    // Nomes das animações de abrir e fechar a porta
    public string nomeAnimacaoAbrirPorta, nomeAnimacaoFecharPorta;

    // O método Update() é onde as ações ocorrem a cada quadro
    void Update()
    {
        // Cria um raio que será disparado para a frente a partir da câmera do jogador
        Ray raio = new Ray(transform.position, transform.forward);

        // Variável RaycastHit, que é usada para obter informações do que o raio atinge
        RaycastHit colisao;

        // Se o raio atingir algo
        if (Physics.Raycast(raio, out colisao, distanciaInteracao))
        {
            // Se o objeto atingido pelo raio tiver a tag "door" (porta)
            if (colisao.collider.gameObject.tag == "door")
            {
                // Cria uma variável GameObject para o objeto pai principal da porta
                GameObject portaPai = colisao.collider.transform.root.gameObject;

                // Cria uma variável Animator para o componente Animator da portaPai
                Animator animacaoPorta = portaPai.GetComponent<Animator>();

                // Se a tecla E for pressionada
                if (Input.GetKeyDown(KeyCode.E))
                {
                    // Se o estado atual da animação da porta for a animação de abrir
                    if (animacaoPorta.GetCurrentAnimatorStateInfo(0).IsName(nomeAnimacaoAbrirPorta))
                    {
                        // Reseta o gatilho da animação de abrir da porta
                        animacaoPorta.ResetTrigger("open");

                        // Aciona o gatilho da animação de fechar (ela é reproduzida)
                        animacaoPorta.SetTrigger("close");
                    }
                    // Se o estado atual da animação da porta for a animação de fechar
                    if (animacaoPorta.GetCurrentAnimatorStateInfo(0).IsName(nomeAnimacaoFecharPorta))
                    {
                        // Reseta o gatilho da animação de fechar da porta
                        animacaoPorta.ResetTrigger("close");

                        // Aciona o gatilho da animação de abrir (ela é reproduzida)
                        animacaoPorta.SetTrigger("open");
                    }
                }
            }
        }
    }
}
