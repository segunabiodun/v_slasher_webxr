/*
 * Copyright (c) 2019 Razeware LLC
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * Notwithstanding the foregoing, you may not use, copy, modify, merge, publish, 
 * distribute, sublicense, create a derivative work, and/or sell copies of the 
 * Software in any work that is designed, intended, or marketed for pedagogical or 
 * instructional purposes related to programming, coding, application development, 
 * or information technology.  Permission for such use, copying, modification,
 * merger, publication, distribution, sublicensing, creation of derivative works, 
 * or sale is expressly withheld.
 *    
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slicer 
{
    public GameObject gameManager;

    //private void OnTriggerEnter(Collider other)
    //{
    //    // 1. Generate haptic event
    //    ControllerHaptics haptics = GetComponentInParent<ControllerHaptics>();
    //    if (haptics)
    //    {
    //        haptics.HapticEvent();
    //    }
    //    if (gameManager)
    //    {
    //        gameManager.GetComponent<GameManager>().score += 100;
    //    }
    //    SplitMesh(other.gameObject);
    //    Destroy(other.gameObject);
    //}

    // Get a cutting plane from the rotation/position of the saber
    private static Plane GetCuttingPlane(Transform goTransform)
    {
        // 1.
        Vector3 pt1 = goTransform.rotation * new Vector3(0, 0, 0);
        Vector3 pt2 = goTransform.rotation * new Vector3(0, 1, 0);
        Vector3 pt3 = goTransform.rotation * new Vector3(0, 0, 1);

        // 2.
        Plane rv = new Plane();
        rv.Set3Points(pt1, pt2, pt3);
        return rv;
    }

    // Clone a Mesh "half"
    private static Mesh CloneMesh(Plane p, Mesh oMesh, bool halve)
    {
        // 1.
        Mesh cMesh = new Mesh();
        cMesh.name = "slicedMesh";
        Vector3[] vertices = oMesh.vertices;
        for (int i = 0; i < vertices.Length; i++)
        {
            bool side = p.GetSide(vertices[i]);

            if (side == halve)
            {
                vertices[i] = p.ClosestPointOnPlane(vertices[i]);
            }
        }

        // 2.
        cMesh.vertices = vertices;
        cMesh.triangles = oMesh.triangles;
        cMesh.normals = oMesh.normals;
        cMesh.uv = oMesh.uv;
        return cMesh;
    }

    // Configure the GameObject
    private static GameObject MakeHalf(GameObject go, Transform cuttingPlaneTransform, bool isLeft)
    {
        // 1.
        float sign = isLeft ? -1 : 1;
        GameObject half = GameObject.Instantiate(go);
        MeshFilter filter = half.GetComponent<MeshFilter>();

        // 2.
        Plane cuttingPlane = GetCuttingPlane(cuttingPlaneTransform);
        filter.mesh = CloneMesh(cuttingPlane, filter.mesh, isLeft);


        // 3.
        half.transform.position = go.transform.position + cuttingPlaneTransform.rotation * new Vector3(sign * 0.05f, 0, 0);
        if (!GameManager.instance.isDemo)
        {
            half.GetComponent<Rigidbody>().isKinematic = false;
            half.GetComponent<Rigidbody>().useGravity = true;
        }

        if (!GameManager.instance.isDemo)
        {
            // 4.
            half.GetComponent<Collider>().isTrigger = false;
            GameObject.Destroy(half, 2);
        }

        return half;
    }

    // Make two GameObjects with "halves" of the original
    public static GameObject[] SplitMesh(GameObject go, Transform cuttingPlaneTransform)
    {
        // 1.
        GameObject leftHalf = MakeHalf(go, cuttingPlaneTransform, true);
        GameObject rightHalf = MakeHalf(go, cuttingPlaneTransform, false);

        return new GameObject[]{ leftHalf, rightHalf};
    }
}
