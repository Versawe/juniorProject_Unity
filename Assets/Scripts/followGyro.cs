using UnityEngine;

public class followGyro : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Tweaks")]
    [SerializeField] private Quaternion baseRotation = new Quaternion(0,0,1,0);
    private Quaternion currentRotation;
    private Quaternion differenceFromCenter;
    private float rotDifX;
    private float rotDifY;
    private float rotDifZ;
    private Quaternion initialRotationOnStart;
    private Quaternion deviceRotation;
    private int method = 0;

    private void Start()
    {
        gyroManager.Instance.EnableGyro();
        if(gyroManager.Instance.CheckGyroActive() == true)
        {
            method = 0;
        }

        if (gyroManager.Instance.CheckGyroActive() == false)
        {
            method = 1;
        }
        switch (method)
        {
            case 0:
                currentRotation = Quaternion.Euler(90, 90, 0);
                deviceRotation = gyroManager.Instance.GetGyroRotation() * baseRotation;
                rotDifX = currentRotation.x - deviceRotation.x;
                rotDifY = currentRotation.y - deviceRotation.y;
                rotDifZ = currentRotation.z - deviceRotation.z;

                differenceFromCenter = Quaternion.Euler(rotDifX, rotDifY, rotDifZ);
                break;
            case 1:
                currentRotation = Quaternion.Euler(0, 0, 0);
                break;
        }
    }

    private void Update()
    {
        if(method == 0)
        {
            deviceRotation = gyroManager.Instance.GetGyroRotation() * baseRotation;

            transform.localRotation = currentRotation * deviceRotation;
        }

        if (method == 1)
        {
            transform.localRotation = currentRotation;
        }
    }
}
