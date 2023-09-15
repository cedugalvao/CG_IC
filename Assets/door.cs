using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    // Dist�ncia a partir da qual o jogador pode interagir com a porta
    public float interactionDistance;

    // Os nomes das anima��es de abrir e fechar a porta
    public string doorOpenAnimName, doorCloseAnimName;

    // O m�todo Update() � onde as coisas acontecem a cada quadro (frame)
    void Update()
    {
        // Um raio � criado que ser� disparado para a frente a partir da c�mera do jogador
        Ray ray = new Ray(transform.position, transform.forward);

        // Vari�vel RaycastHit, que � usada para obter informa��es sobre o que o raio atinge
        RaycastHit hit;

        // Se o raio atingir algo
        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            // Se o objeto atingido pelo raio estiver marcado como "door" (porta)
            if (hit.collider.gameObject.tag == "door")
            {
                // Uma vari�vel GameObject � criada para o objeto pai principal da porta
                GameObject doorParent = hit.collider.transform.root.gameObject;

                // Uma vari�vel Animator � criada para o componente Animator do doorParent
                Animator doorAnim = doorParent.GetComponent<Animator>();

                // Se a tecla E for pressionada
                if (Input.GetKeyDown(KeyCode.E))
                {
                    // Se o estado atual do Animator da porta estiver definido para a anima��o de abertura
                    if (doorAnim.GetCurrentAnimatorStateInfo(0).IsName(doorOpenAnimName))
                    {
                        // O gatilho de anima��o de abrir a porta � resetado
                        doorAnim.ResetTrigger("open");

                        // O gatilho de anima��o de fechar a porta � definido (ele � executado)
                        doorAnim.SetTrigger("close");
                    }
                    // Se o estado atual do Animator da porta estiver definido para a anima��o de fechamento
                    if (doorAnim.GetCurrentAnimatorStateInfo(0).IsName(doorCloseAnimName))
                    {
                        // O gatilho de anima��o de fechar a porta � resetado
                        doorAnim.ResetTrigger("close");

                        // O gatilho de anima��o de abrir a porta � definido (ele � executado)
                        doorAnim.SetTrigger("open");
                    }
                }
            }
        }
    }
}
