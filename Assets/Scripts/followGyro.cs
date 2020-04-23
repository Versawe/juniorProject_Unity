using UnityEngine;

public class followGyro : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Tweaks")]
    [SerializeField] private Quaternion baseRotation = new Quaternion(0, 0, 1, 0);

    private void Start()
    {
        gyroManager.Instance.EnableGyro();
    }

    private void Update()
    {
        transform.localRotation = gyroManager.Instance.GetGyroRotation() * baseRotation;
    }
}
