using UnityEngine;

public class CelestialBodyMovement : MonoBehaviour
{
    [Range(0.1f, 2.0f)]
    [SerializeField] private float rotationSpeed;

    [SerializeField] private float xRot;

    private enum CelestialBodyType
    {
        sun,
        moon
    }

    [SerializeField] private CelestialBodyType celestialBodyType;

    private void Update()
    {
        xRot = IncreaseRotationValue(xRot);

        RotateCelestialBody();
    }

    private void RotateCelestialBody()
    {
        this.transform.localRotation = Quaternion.Euler(xRot, 45, 0);
    }

    private float IncreaseRotationValue(float rot)
    {
        rot = Mathf.Lerp(rot, rot + 10, Time.deltaTime * rotationSpeed);

        if (rot >= 360)
            rot = 0;

        return rot;
    }
}
