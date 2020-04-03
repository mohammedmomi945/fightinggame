using UnityEngine;

public class Camera : MonoBehaviour
{


	// Transform of the camera to shake. Grabs the gameObject's transform
	// if null.
	float Timer;
	public Transform camTransform;

	// How long the object should shake for.
	public float shakeDuration = 0f;

	// Amplitude of the shake. A larger value shakes the camera harder.
	public float shakeAmount = 0.7f;
	public float decreaseFactor = 1.0f;

	Vector3 originalPos;
	private void Start()
	{

	}
	void Awake()
	{
		if (camTransform == null)
		{
			camTransform = GetComponent(typeof(Transform)) as Transform;
		}
	}

	void OnEnable()
	{
		originalPos = camTransform.localPosition;
	}

	void Update()
	{


		if (Input.GetKey(KeyCode.Mouse0))
		{
			Timer += Time.deltaTime;
			if (Timer <= 1)
			{
				Timer = 0;
				camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;


			}
		}
	}

}
