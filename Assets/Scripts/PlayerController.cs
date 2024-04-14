using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Accelerometer")]
    [SerializeField] private bool useAccelerometer = false;
    public float accelerationSpeed = 5f;
    public float AvelocityY = 3;
    public float verticalThreshold = 0.5f;

    [Header("Gyroscope")]
    [SerializeField] private bool useGyroscope = false;
    public float GvelocityY = 3;
    private Vector3 gyroscopeRotationRate;
    private Vector3 gyroscopeOrientation;
    private Gyroscope gyroscope;

    [Header("Recursos")]
    public float maxY = 3f;
    public float minY = -3f;
    public GameObject cube;
    public GameObject cannon;
    public SelectorSO gameMode;
    public DynamicObjectPooling bulletOP;
    public float spawnInterval = 1.0f;


    private float nextSpawnTime = 0.0f;
    private Transform playerTransform;

    private void Start()
    {
        if (cube == null)
        {
            //sino le asignas nada, sera el mismo objeto el jugador
            playerTransform = GetComponent<Transform>();
        }
        else
        {
            playerTransform = cube.GetComponent<Transform>();
        }

        if (gameMode.GameMode)
        {
            useAccelerometer = true;
            useGyroscope = false;
        }
        else
        {
            if (SystemInfo.supportsGyroscope)
            {
                gyroscope = Input.gyro;
                gyroscope.enabled = true;
                Debug.Log("Gyroscope enabled");
                useAccelerometer = false;
                useGyroscope = true;
            }
            else
            {
                useAccelerometer = true;
                useGyroscope = false;
            }
        }
    }

    private void Update()
    {
        CheckPosition();
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Stationary && Time.time >= nextSpawnTime)
            {
                GameObject obj = bulletOP.GetObjetc();
                obj.transform.position = cannon.transform.position;
                nextSpawnTime = Time.time + spawnInterval; // Actualizar el tiempo para el próximo spawn
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                nextSpawnTime = 0;
            }
        }
        if (useAccelerometer)
        {
            playerTransform.position = new Vector3(playerTransform.position.x, playerTransform.position.y + AvelocityY * Time.deltaTime, playerTransform.position.z);
            AccelerometerBehavior();
        }
        if (useGyroscope && gyroscope != null)
        {
            playerTransform.position = new Vector3(playerTransform.position.x, playerTransform.position.y + GvelocityY * Time.deltaTime, playerTransform.position.z);
            GyroscopeBehavior();
        }
    }

    private void AccelerometerBehavior()
    {
        Vector3 accelerometerValue = Input.acceleration;
        float verticalAcceleration = Mathf.Abs(accelerometerValue.y);
        if (verticalAcceleration > verticalThreshold)
        {
            AvelocityY = Mathf.Abs(AvelocityY);
        }
        else
        {
            AvelocityY = -Mathf.Abs(AvelocityY);
        }
    }
    private void GyroscopeBehavior()
    {
        gyroscopeRotationRate = Input.gyro.rotationRateUnbiased;
        gyroscopeOrientation += gyroscopeRotationRate * Time.deltaTime;
        if(gyroscopeOrientation.x >= 0) //trabajamos con valores absolutos para evitar problemas de logica
        {
            GvelocityY = -Mathf.Abs(GvelocityY);
        }
        else
        {
            GvelocityY = Mathf.Abs(GvelocityY);
        }
    }
    private void CheckPosition()
    {
        Vector3 currentPosition = playerTransform.transform.position;
        currentPosition.y = Mathf.Clamp(currentPosition.y, minY, maxY);
        playerTransform.transform.position = currentPosition;
    }
}