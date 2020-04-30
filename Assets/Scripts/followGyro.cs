using UnityEngine;

public class followGyro : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Tweaks")]
    [SerializeField] private Quaternion baseRotation = new Quaternion(0,0,0,0);
    private Quaternion deviceRotation;
    private Quaternion deviceRotationLast;
    private Quaternion differencePerFrame;
    private Quaternion currentRotation;
    private Quaternion initialRotation;
    private Quaternion initialRotationOnStart;
    private bool hasRecordedInitialRotation = false;

    private void Start()
    {
        gyroManager.Instance.EnableGyro();
        initialRotation = transform.localRotation;
    }

    private void Update()
    {
        currentRotation = gyroManager.Instance.GetGyroRotation() * baseRotation;

        transform.localRotation = initialRotation * currentRotation;
        print(initialRotation);
        /*
        if(hasRecordedInitialRotation == false)
        {
            currentRotation = transform.localRotation * new Quaternion(0,0,0,1);
        }
        
        deviceRotationLast = deviceRotation;
        deviceRotation = gyroManager.Instance.GetGyroRotation() * baseRotation;
        differencePerFrame = deviceRotationLast * Quaternion.Inverse(deviceRotation);
        currentRotation = currentRotation * differencePerFrame;

        transform.localRotation = currentRotation;
        */
        //print(gyroManager.Instance.GetGyroRotation());
    }
}
