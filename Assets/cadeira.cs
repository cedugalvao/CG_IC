using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [Header("Configurações de PickUp")]
    [SerializeField] Transform holdArea;
    private GameObject objSegurado;
    private Rigidbody objSeguradoRB;

    [Header("Paramentros da Fisica")]
    [SerializeField] private float pickupRange = 5.0f;
    [SerializeField] private float pickupForca = 150.0f;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (objSegurado == null)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickupRange))
                {   //Pega o objeto

                    PickupObject(hit.transform.gameObject);

                }
            }
            else
            {
                //Solta o objeto
                DropObject();

            }
        }
        if (objSegurado != null)
        {
            //Move o objeto
            MoverObj();


        }
    }
    void MoverObj()
    {
        if (Vector3.Distance(objSegurado.transform.position, holdArea.position) > 0.1f)
        {
            Vector3 moveDirection = (holdArea.position - objSegurado.transform.position);
            objSeguradoRB.AddForce(moveDirection * pickupForca);
        }
    }

    void PickupObject(GameObject pickObj)
    {
        if (pickObj.GetComponent<Rigidbody>())
        {
            objSeguradoRB = pickObj.GetComponent<Rigidbody>();
            objSeguradoRB.useGravity = false;
            objSeguradoRB.drag = 10;

            objSeguradoRB.transform.parent = holdArea;
            objSegurado = pickObj;
        }
    }
    void DropObject()
    {
        objSeguradoRB.useGravity = true;
        objSeguradoRB.drag = 1;

        objSegurado.transform.parent = null;
        objSegurado = null;

    }

}