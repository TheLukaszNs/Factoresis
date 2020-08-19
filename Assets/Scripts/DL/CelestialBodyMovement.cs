using UnityEngine;
using System.Linq;

public class CelestialBodyMovement : MonoBehaviour
{
    public CelestialBody[] celestialBodies;

    [Range(0.1f, 2.0f)]
    public float rotationSpeed;

    private void Update()
    {
        foreach (CelestialBody celestialBody in celestialBodies)
        {
            celestialBody.xRot = IncreaseRotationValue(celestialBody.xRot, celestialBody.isSun);

            celestialBody.CelestialBodyTR.localRotation = Quaternion.Euler(celestialBody.xRot, 45, 0);
        }
    }

    private float IncreaseRotationValue(float rot, bool isSun)
    {
        rot = rot + 10 * Time.deltaTime * rotationSpeed;

        if (rot >= 360)
        {
            if (isSun)
            {
                var dayPassedArray = FindObjectsOfType<MonoBehaviour>().OfType<IDayPassed>();

                foreach (IDayPassed dayPassed in dayPassedArray)
                {
                    dayPassed.DayPassed();
                }
            }

            rot = 0;
        }

        return rot;
    }

    [System.Serializable]
    public class CelestialBody
    {
        public Transform CelestialBodyTR;

        public bool isSun;
        public float xRot;
    }
}
