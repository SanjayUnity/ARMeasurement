using TMPro;
using UnityEngine;

public class LineManager : MonoBehaviour
{
    [SerializeField] private Transform startPoint;
    [SerializeField] private Transform endPoint;
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private TMP_Text measureText;
    private float distance;
    private bool isFirstPoint = false;

    public void SetLineColor(Color lineColor)
    {
        lineRenderer.material.color = lineColor;
        lineRenderer.material.SetColor("_EmissionColor", lineColor);
    }

    public void SetTwoHandLinePosition(Vector3 startPos, Vector3 endPos)
    {
        startPoint.position = startPos;
        endPoint.position = endPos;
        lineRenderer.SetPosition(0, startPos);
        lineRenderer.SetPosition(1, endPos);
        distance = Vector3.Distance(startPoint.position, endPoint.position);
        measureText.text = $"{(distance * 100).ToString("00.00")} cm";
    }

    public void SetOneHandLinePosition(Vector3 startPos, Vector3 endPos)
    {
        if (!isFirstPoint)
        {
            startPoint.position = startPos;
            lineRenderer.SetPosition(0, startPos);
            isFirstPoint = true;
        }

        endPoint.position = endPos;
        lineRenderer.SetPosition(1, endPos);
        distance = Vector3.Distance(startPoint.position, endPoint.position);
        measureText.text = $"{(distance * 100).ToString("00.00")} cm";
    }

    public void OnRelease()
    {
        if (startPoint.TryGetComponent(out SphereCollider startPointCollider))
        {
            startPointCollider.enabled = true;
        }

        if (endPoint.TryGetComponent(out SphereCollider endPointCollider))
        {
            endPointCollider.enabled = true;
        }
    }
}