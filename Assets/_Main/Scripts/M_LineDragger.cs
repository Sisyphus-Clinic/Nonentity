using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_LineDragger : MonoBehaviour
{
    public LayerMask groundLayer;
    public LayerMask draggerLayer;
    public static Transform currentDragger;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, draggerLayer))
                currentDragger = raycastHit.transform;

            Debug.Log(currentDragger.name);

            Ray rayG = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(rayG, out RaycastHit raycastHitG, float.MaxValue, groundLayer))
            {
                Vector3 targetPos = new Vector3(raycastHitG.point.x, 0.2f, raycastHitG.point.z);
                currentDragger.position = targetPos;
            }
        }

    }

    private void OnMouseDrag()
    {
        //transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //RaycastHit hit;
        //if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, environmentLayer))
        //{

        //}
        //Debug.Log("eadasda");
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //if (Physics.Raycast(ray, out RaycastHit raycastHit,float.MaxValue,groundLayer))
        //{
        //    Vector3 targetPos = new Vector3(raycastHit.point.x, 0.2f, raycastHit.point.z);
        //    transform.position = targetPos;
        //}
    }
}
