using UnityEditor;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.iOS;

public class GyroManager : MonoBehaviour
{
    #region Instance

    private static GyroManager instance;
    public static GyroManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GyroManager>();
                if (instance == null)
                {
                    instance = new GameObject("Spawned GyroManager", typeof(GyroManager)).GetComponent<GyroManager>();
                }
            }

            return instance;
        }
        set
        {
            instance = value;
        }
    }

    #endregion

    #region Logic

    [Header("Logic")]
    private Gyroscope gyro;
    private Quaternion rotation;
    private bool gyroActive;

    public void EnableGyro()
    {
        // Already Activated
        if (gyroActive)
        {
            return;
        }

        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
            gyroActive = gyro.enabled;
            Debug.Log("App is running in " + SystemInfo.deviceModel);
        }
        else
        {
            Debug.Log("Gyro is not supported on this device");
        }
    }

    private void Update()
    {
        if (gyroActive)
        {
            rotation = gyro.attitude;
        }
    }

    public Quaternion GetGyroRotation()
    {
        return rotation;
    }

    #endregion
}
