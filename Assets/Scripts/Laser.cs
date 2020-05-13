using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] GameObject laserOrigin = null;
    [SerializeField] LineRenderer lineRenderer = null;
    [SerializeField] GameObject hitPointIndicator = null;
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
        lineRendererPos[0] = laserOrigin.transform.position;
        Ray ray = new Ray(laserOrigin.transform.position, laserOrigin.transform.forward);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, laserMaxDistance, layerMask))
        {
            lineRendererPos[1] = hit.point;
            hitPointIndicator.transform.position = hit.point;
            hitPointIndicator.SetActive(true);
            //Debug.Log($"ray hit {hit.collider.gameObject.name}");
        }
        else
        {
            hitPointIndicator.SetActive(false);
            lineRendererPos[1] = laserOrigin.transform.position + (laserOrigin.transform.forward * laserMaxDistance);
        }

        lineRenderer.SetPositions(lineRendererPos);
    }
}
