using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ReticalManager : MonoBehaviour
{
    [SerializeField] private Transform retical;
    [SerializeField] private ARRaycastManager arRaycastManager;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private void Update()
    {
        if (arRaycastManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.Planes))
        {
            if (!retical.gameObject.activeSelf)
            {
                retical.gameObject.SetActive(true);
            }

            retical.transform.localPosition = hits[0].pose.position;
        }
    }
}