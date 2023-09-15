using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    // Distância a partir da qual o jogador pode interagir com a porta
    public float interactionDistance;

    // Os nomes das animações de abrir e fechar a porta
    public string doorOpenAnimName, doorCloseAnimName;

    // O método Update() é onde as coisas acontecem a cada quadro (frame)
    void Update()
    {
        // Um raio é criado que será disparado para a frente a partir da câmera do jogador
        Ray ray = new Ray(transform.position, transform.forward);

        // Variável RaycastHit, que é usada para obter informações sobre o que o raio atinge
        RaycastHit hit;

        // Se o raio atingir algo
        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            // Se o objeto atingido pelo raio estiver marcado como "door" (porta)
            if (hit.collider.gameObject.tag == "door")
            {
                // Uma variável GameObject é criada para o objeto pai principal da porta
                GameObject doorParent = hit.collider.transform.root.gameObject;

                // Uma variável Animator é criada para o componente Animator do doorParent
                Animator doorAnim = doorParent.GetComponent<Animator>();

                // Se a tecla E for pressionada
                if (Input.GetKeyDown(KeyCode.E))
                {
                    // Se o estado atual do Animator da porta estiver definido para a animação de abertura
                    if (doorAnim.GetCurrentAnimatorStateInfo(0).IsName(doorOpenAnimName))
                    {
                        // O gatilho de animação de abrir a porta é resetado
                        doorAnim.ResetTrigger("open");

                        // O gatilho de animação de fechar a porta é definido (ele é executado)
                        doorAnim.SetTrigger("close");
                    }
                    // Se o estado atual do Animator da porta estiver definido para a animação de fechamento
                    if (doorAnim.GetCurrentAnimatorStateInfo(0).IsName(doorCloseAnimName))
                    {
                        // O gatilho de animação de fechar a porta é resetado
                        doorAnim.ResetTrigger("close");

                        // O gatilho de animação de abrir a porta é definido (ele é executado)
                        doorAnim.SetTrigger("open");
                    }
                }
            }
        }
    }
}
