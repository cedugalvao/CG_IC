using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porta : MonoBehaviour
{
    // Dist�ncia a partir da qual o jogador pode interagir com a porta
    public float distanciaInteracao;

    // Nomes das anima��es de abrir e fechar a porta
    public string nomeAnimacaoAbrirPorta, nomeAnimacaoFecharPorta;

    // O m�todo Update() � onde as a��es ocorrem a cada quadro
    void Update()
    {
        // Cria um raio que ser� disparado para a frente a partir da c�mera do jogador
        Ray raio = new Ray(transform.position, transform.forward);

        // Vari�vel RaycastHit, que � usada para obter informa��es do que o raio atinge
        RaycastHit colisao;

        // Se o raio atingir algo
        if (Physics.Raycast(raio, out colisao, distanciaInteracao))
        {
            // Se o objeto atingido pelo raio tiver a tag "door" (porta)
            if (colisao.collider.gameObject.tag == "door")
            {
                // Cria uma vari�vel GameObject para o objeto pai principal da porta
                GameObject portaPai = colisao.collider.transform.root.gameObject;

                // Cria uma vari�vel Animator para o componente Animator da portaPai
                Animator animacaoPorta = portaPai.GetComponent<Animator>();

                // Se a tecla E for pressionada
                if (Input.GetKeyDown(KeyCode.E))
                {
                    // Se o estado atual da anima��o da porta for a anima��o de abrir
                    if (animacaoPorta.GetCurrentAnimatorStateInfo(0).IsName(nomeAnimacaoAbrirPorta))
                    {
                        // Reseta o gatilho da anima��o de abrir da porta
                        animacaoPorta.ResetTrigger("open");

                        // Aciona o gatilho da anima��o de fechar (ela � reproduzida)
                        animacaoPorta.SetTrigger("close");
                    }
                    // Se o estado atual da anima��o da porta for a anima��o de fechar
                    if (animacaoPorta.GetCurrentAnimatorStateInfo(0).IsName(nomeAnimacaoFecharPorta))
                    {
                        // Reseta o gatilho da anima��o de fechar da porta
                        animacaoPorta.ResetTrigger("close");

                        // Aciona o gatilho da anima��o de abrir (ela � reproduzida)
                        animacaoPorta.SetTrigger("open");
                    }
                }
            }
        }
    }
}
