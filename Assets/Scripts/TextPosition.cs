using UnityEngine;

public class TextPosition : MonoBehaviour
{
    [SerializeField] private LineRenderer _lineRenderer;
    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        transform.rotation =
            Quaternion.Euler(mainCamera.transform.eulerAngles.x, mainCamera.transform.eulerAngles.y, 0f);
        transform.localPosition = GetBoundsCenter(_lineRenderer.transform);
    }

    public Vector3 GetBoundsCenter(Transform t)
    {
        Renderer r = t.GetComponent<Renderer>();
        if (r != null)
        {
            return new Vector3(r.bounds.center.x, r.bounds.center.y + 0.012f, r.bounds.center.z);
        }
        else
        {
            return t.position;
        }
    }
}