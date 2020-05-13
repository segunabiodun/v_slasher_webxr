using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] GameObject hitPointIndicator;
    public float laserMaxDistance = 5;
    public LayerMask layerMask;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer.enabled = true;
        hitPointIndicator.GetComponent<MeshRenderer>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3[] lineRendererPos = new Vector3[2];
        lineRendererPos[0] = transform.position;
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, laserMaxDistance, layerMask))
        {
            hitPointIndicator.transform.position = hit.point;
            lineRendererPos[1] = hit.point;
            hitPointIndicator.transform.position = hit.point;
            hitPointIndicator.SetActive(true);
            Debug.Log($"ray hit {hit.collider.gameObject.name}");
        }
        else
        {
            hitPointIndicator.SetActive(false);
            lineRendererPos[1] = transform.position + (transform.forward * laserMaxDistance);
        }

        lineRenderer.SetPositions(lineRendererPos);
    }
}
