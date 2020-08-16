using UnityEngine;

public class CelestialBodyMovement : MonoBehaviour
{
    [Range(0.1f, 2.0f)]
    public float rotationSpeed;

    [SerializeField] private float xRot;

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
        rot = rot + 10 * Time.deltaTime * rotationSpeed;

        if (rot >= 360)
            rot = 0;

        return rot;
    }
}
