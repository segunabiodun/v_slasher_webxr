using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] GameObject laserOrigin = null;
    [SerializeField] LineRenderer lineRenderer = null;
    [SerializeField] GameObject hitPointIndicator = null;
    [SerializeField] Canvas mainCanvas = null;
    float laserMaxDistance = 5;
    public LayerMask layerMask;

    public static Vector3 laserHitPoint { get; private set; }
    public static Vector2 laserScreenPos { get; private set; }

    //debug
    public UnityEngine.UI.Text rayHitText;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer.enabled = true;
        hitPointIndicator.GetComponent<MeshRenderer>().enabled = true;
        /* Set laser max distance to the distance between the canvas and the
         the camera. This is necessary because if the ray goes beyond the
        canvas and it ends/ccollides at a point whose line of sight from the camera
        passes through the canvas, it would be wrongly seen as being on the canvas
        when Camera.WorldPointToScreen is called.*/
        //should be updated every frame
        laserMaxDistance = Vector3.Distance(laserOrigin.transform.position,
            mainCanvas.transform.position);
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
            rayHitText.text = $"Hit {hit.collider.gameObject.name}";
            //Debug.Log($"ray hit {hit.collider.gameObject.name}");
            laserHitPoint = hit.point;
        }
        else
        {
            hitPointIndicator.SetActive(false);
            laserHitPoint = laserOrigin.transform.position + (laserOrigin.transform.forward * laserMaxDistance);
            lineRendererPos[1] = laserHitPoint;
            rayHitText.text = "-";
        }
        laserScreenPos = mainCanvas.worldCamera.WorldToScreenPoint(laserHitPoint);
        lineRenderer.SetPositions(lineRendererPos);
    }
}
