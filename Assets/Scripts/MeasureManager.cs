using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MeasureManager : MonoBehaviour
{
    [SerializeField] private LineManager lineManagerPrefab;
    [SerializeField] private Transform pointTransform;
    [SerializeField] private List<LineManager> spawnedLines = new List<LineManager>();
    [SerializeField] private GameObject snapPoint;
    [SerializeField] Color selectedColor;
    [SerializeField] private Image selectedColorImage;
    private LineManager lineManagerSpawnObject;

    public Color SelectedColor
    {
        get => selectedColor;
        set
        {
            selectedColor = value;
            selectedColorImage.color = selectedColor;
        }
    }

    public GameObject SnapPoint
    {
        get { return snapPoint; }
        set { snapPoint = value; }
    }

    private void Update()
    {
        OnActionPerformed();
    }

    private void OnActionPerformed()
    {
        if (GameHelper.isOverUI())
        {
            return;
        }

        if (Input.GetMouseButton(0))
        {
            SpawnLine();
            if (lineManagerSpawnObject != null)
            {
                lineManagerSpawnObject.SetOneHandLinePosition(
                    (snapPoint != null) ? snapPoint.transform.position : pointTransform.position,
                    (snapPoint != null) ? snapPoint.transform.position : pointTransform.position);
            }
        }
        else
        {
            if (lineManagerSpawnObject != null)
            {
                lineManagerSpawnObject.OnRelease();
                lineManagerSpawnObject = null;
            }
        }
    }

    private void SpawnLine()
    {
        if (lineManagerSpawnObject == null)
        {
            lineManagerSpawnObject = Instantiate(lineManagerPrefab);
            lineManagerSpawnObject.SetLineColor(selectedColor);
            spawnedLines.Add(lineManagerSpawnObject);
        }
    }

    public void ClearAllLine()
    {
        for (int i = 0; i < spawnedLines.Count; i++)
        {
            Destroy(spawnedLines[i].gameObject);
        }

        spawnedLines.Clear();
    }

    public void UndoLines()
    {
        if (spawnedLines.Count != 0)
        {
            Destroy(spawnedLines[ ^ 1].gameObject);
            spawnedLines.Remove(spawnedLines[ ^ 1]);
        }
    }
}