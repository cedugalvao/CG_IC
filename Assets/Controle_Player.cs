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
    public float velocidadePulo;

    [Header("Executando")]
    Vector3 novaVelocidade;
    bool noChao = false;
    bool pulando = false;



    // Start is called before the first frame update
    void Start(){
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update(){
        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * 3f);

        novaVelocidade = Vector3.up * rb.velocity.y;
        float velocidade = Input.GetKey(KeyCode.LeftShift) ? velocidadeCorrida : velocidadeAndar;
        novaVelocidade.x = Input.GetAxis("Horizontal") * velocidade;
        novaVelocidade.z = Input.GetAxis("Vertical") * velocidade;
        if (noChao)
        {
            if (Input.GetKeyDown(KeyCode.Space) && !pulando)
            {
                novaVelocidade.y = velocidadePulo;
                pulando = true;
            }
        }
        rb.velocity = transform.TransformDirection(novaVelocidade);

    }
    public static float RestrictAngle(float angle, float angleMin, float angleMax){
        if (angle > 180)
            angle -= 360;
        else if (angle < -180)
            angle += 360;

        if (angle > angleMax)
            angle = angleMax;
        if (angle < angleMin)
            angle = angleMin;

        return angle;
    }
    void LateUpdate()
    {
        // Vertical rotation
        Vector3 e = head.eulerAngles;
        e.x -= Input.GetAxis("Mouse Y") * 2f;   //  Edit the multiplier to adjust the rotate speed
        e.x = RestrictAngle(e.x, -85f, 85f);    //  This is clamped to 85 degrees. You may edit this.
        head.eulerAngles = e;
    }
    void FixedUpdate(){
        if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, 1f))
        {
            noChao = true;
        }
        else noChao = false;

    }
    private void OnCollisionStay(Collision collision)
    {
        noChao = true;
        pulando = false;
    }


    void OnCollisionExit(Collision collision){
        noChao = false;
    }
}
