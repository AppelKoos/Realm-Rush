using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CubeEditor : MonoBehaviour
{
    [SerializeField][Range(1f,20f)] float gridSize = 10f;

    TextMesh textMesh;

    private void Start()
    {
        
    }
    void Update()
    {
        Vector3 snapPos;
        textMesh = GetComponentInChildren<TextMesh>();
        snapPos.x = Mathf.RoundToInt(transform.position.x / gridSize) * gridSize;
        snapPos.z = Mathf.RoundToInt(transform.position.z / gridSize) * gridSize;
        snapPos.y = Mathf.RoundToInt(transform.position.y / gridSize) * gridSize;
        textMesh.text = snapPos.x / gridSize + "," + snapPos.z / gridSize;
        transform.position = new Vector3(snapPos.x, snapPos.y, snapPos.z);
    }
}
