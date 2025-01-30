using UnityEngine;

public class PointCollide : MonoBehaviour
{
    [SerializeField] private MeasureManager measureManager;
    private const string pointTag = "Point";

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(pointTag))
        {
            measureManager.SnapPoint = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        measureManager.SnapPoint = null;
    }
}