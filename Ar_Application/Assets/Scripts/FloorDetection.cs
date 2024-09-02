using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class FloorDetection : MonoBehaviour
{
    public ARPlaneManager planeManager;
    public GameObject objectToShow;
    void OnEnable()
    {
        planeManager.planesChanged += OnPlanesChanged;
    }

    void OnDisable()
    {
        planeManager.planesChanged -= OnPlanesChanged;
    }

    private void OnPlanesChanged(ARPlanesChangedEventArgs args)
    {
        foreach (var plane in args.added)
        {
            if (plane.alignment == PlaneAlignment.HorizontalUp)
            {
                // This is a horizontal plane, likely the floor
                // Place your object or trigger your event here
                Debug.Log("Floor detected!");
                objectToShow.SetActive(true); // Show the object
                // Optionally, position the object on the plane
                objectToShow.transform.position = plane.center;

            }
        }
    }
}
