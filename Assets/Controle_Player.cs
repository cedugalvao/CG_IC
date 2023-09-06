using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript1 : MonoBehaviour{
    [Header("References")]
    public Rigidbody rb;
    public Transform head;
    public Camera camera;

    [Header("Configurações")]

    public float velocidadeAndar;
    public float velocidadeCorrida;


    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        
    }
    private void FixedUpdate(){
        Vector3 novaVelocidade = Vector3.up * rb.velocity.y;
        float velocidade = Input.GetKey(KeyCode.LeftShift) ? velocidadeCorrida : velocidadeAndar;
        novaVelocidade.x = Input.GetAxis("Horizontal") * velocidade;
        novaVelocidade.z = Input.GetAxis("Vertical") * velocidade;
        rb.velocity = novaVelocidade;

    }
}
