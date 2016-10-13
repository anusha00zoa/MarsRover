using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AssemblyScript : MonoBehaviour 
{
	public Text labelText;

	//public GameObject middleBody;
	public GameObject rearBody;

	public GameObject mainDeckTop, mainDeckMiddle, mainDeckBase;
	public GameObject mainDeckBaseTop1, mainDeckBaseTop2, mainDeckBaseMiddle1,mainDeckBaseMiddle2,mainDeckBaseBottom1;

	// Drivers deck game objects

	public GameObject driverDeckTop , driverDeckBase , driverDeckEngine;


	// Wheel related game objects

	public GameObject wheelBaseFront;
	public GameObject wheelBaseRear;

	public GameObject wheelBaseLeft;
	public GameObject wheelBaseRight;

	public GameObject frontRightWheel;
	public GameObject frontRightWheelAxle;

	public GameObject rearRightWheel;
	public GameObject rearRightWheelAxle;

	public GameObject rearLeftWheel;
	public GameObject rearLeftWheelAxle;

	public GameObject frontLeftWheel;
	public GameObject frontLeftWheelAxle;

	public GameObject frontSeparator;
	public GameObject backSeparator;

	// Rear Part Base variables 

	public GameObject satelliteBase;
	public GameObject satelliteCup;

	public GameObject solarPanel;
	public GameObject solarPanelsphere;

	public GameObject weatherSensor;
	public GameObject angleRodOne;
	public GameObject angleRodTwo;

	private Rigidbody rb;
	private Vector3 velocity;

	public AudioSource avatarDriveDeckTop , avatarDriveDeckBase , avatarDriveDeckEngine, avatarLetsAssemble;
	public AudioSource avatarMainDeckIntro, avatarMainDeckBase,avatarMainDeckBattery,avatarMainDeckOxygen, 
	avatarMainDeckAdditional ,avatarMainDeckFood, avatarMainDeckWater ,avatarMainDeckBody , avatarMainDeckTop ;

	public AudioSource avatarWelCome, avatarDriverDeck, avatarMainDeck,  avatarRearBase, avatarSeperator,
	avatarAngleRods, avatarWheels, avatarSatelite,avatarSolar, avatarWeatherSensor,avatarFinal;


	// Driver deck positions
	private Vector3 driverDeckTopPos1 = new Vector3 (-222.57f, 36.24f, 185.98f);
	private Vector3 driverDeckTopPos2 = new Vector3 (-222.57f, 11.24f, 185.98f);

	private Vector3 driverDeckBasePos1 = new Vector3 (-222.6f, 36.13f, 186.1f);
	private Vector3 driverDeckBasePos2 = new Vector3 (-222.6f, 11.13f, 186.1f);

	private Vector3 driverDeckEnginePos1 = new Vector3 (-222.89f, 34.69f, 180.74f);
	private Vector3 driverDeckEnginePos2 = new Vector3 (-222.89f, 9.69f, 180.74f);





	private Vector3 middleBodyPos1 = new Vector3 (136.5f, 37.1f, 36.8f);
	private Vector3 middleBodyPos2 = new Vector3 (136.5f, 12.1f, 11.8f);



	private Vector3 frontSeparatorPos1 = new Vector3 (432f, 26.79f, 219.6f);
	private Vector3 frontSeparatorPos2 = new Vector3 (432f, 1.79f, 194.6f);

	private Vector3 backSeparatorPos1 = new Vector3 (405f, 37.95f, 229.6f);
	private Vector3 backSeparatorPos2 = new Vector3 (405f, 12.95f, 204.6f);



	private Vector3 frontRightWheelPos1 = new Vector3 (4.94f, -2.75f, 4.54f);
	private Vector3 frontRightWheelPos2 = new Vector3 (4.89f, -0.95f, 4.49f);

	private Vector3 frontRightWheelAxlePos1 = new Vector3 (293f, 28.48f, -68.75f);
	private Vector3 frontRightWheelAxlePos2 = new Vector3 (293f, 3.48f, -93.75f);

	private Vector3 frontLeftWheelPos = new Vector3 (2.87f, -0.74f, 5.97f);

	private Vector3 frontLeftWheelAxlePos1 = new Vector3 (289f, 21.328413f, 141.98f);
	private Vector3 frontLeftWheelAxlePos2 = new Vector3 (289f, -4.328413f, 116.98f);


	private Vector3 rearRightWheelPos = new Vector3 (2.29f, -0.72f, 2.09f);

	private Vector3 rearRightWheelAxlePos1 = new Vector3 (264f, 22.1884f, 123.25f);
	private Vector3 rearRightWheelAxlePos2 = new Vector3 (264f, -3.1884f, 98.25f);

	private Vector3 rearLeftWheelPos = new Vector3 (0.24f, -0.58f, 3.92f);

	private Vector3 rearLeftWheelAxlePos1 = new Vector3 (260f, 29.4f, 145.81f);
	private Vector3 rearLeftWheelAxlePos2 = new Vector3 (260f, 4.4f, 120.81f);


	private Vector3 wheelBaseFrontPos1 = new Vector3 (326.6f, 27.1f,315.6f);
	private Vector3 wheelBaseFrontPos2 = new Vector3 (326.6f, 2.1f,290.6f);

	private Vector3 wheelBaseRightPos1 = new Vector3 (297.72f, 27.635f, 333.82f);
	private Vector3 wheelBaseRightPos2 = new Vector3 (297.72f, 2.635f, 308.82f);

	private Vector3 wheelBaseLeftPos1 = new Vector3 (297.76f, 27.13f, 314.5f);
	private Vector3 wheelBaseLeftPos2 = new Vector3 (297.76f, 2.13f, 289.5f);

	private Vector3 wheelBaseRearPos1 = new Vector3 (300.11f, 27.41f,316.8f);
	private Vector3 wheelBaseRearPos2 = new Vector3 (300.11f, 2.41f,291.8f);

	// Main Body 

	private Vector3 mainDeckTopPos1 = new Vector3 (479.9f, 44.2f, 403.3f);
	private Vector3 mainDeckTopPos2 = new Vector3 (479.9f, 19.2f, 378.3f);

	private Vector3 mainDeckMiddlePos1 = new Vector3 (479.9f, 44.7f, 403.3f);
	private Vector3 mainDeckMiddlePos2 = new Vector3 (479.9f, 19.7f, 378.3f);

	private Vector3 mainDeckBasePos1 = new Vector3 (479.9f, 35f, 403.3f);
	private Vector3 mainDeckBasePos2 = new Vector3 (479.9f, 10f, 378.3f);

	private Vector3 mainDeckBaseTop1Pos1 = new Vector3 (500.4f, 35.1f, 387.2f);
	private Vector3 mainDeckBaseTop1Pos2 = new Vector3 (500.4f, 10.1f, 362.2f);

	private Vector3 mainDeckBaseTop2Pos1 = new Vector3 (500.4f, 35f, 385.2f);
	private Vector3 mainDeckBaseTop2Pos2 = new Vector3 (500.9f, 10.0f, 360.2f);

	private Vector3 mainDeckBaseMiddle1Pos1 = new Vector3(480f, 35.5f, 394.1f);
	private Vector3 mainDeckBaseMiddle1Pos2 = new Vector3 (480f, 10.5f, 369.1f);

	private Vector3 mainDeckBaseMiddle2Pos1 = new Vector3(488f, 33.5f, 386.7f);
	private Vector3 mainDeckBaseMiddle2Pos2 = new Vector3 (488f, 8.5f, 361.7f);

	private Vector3 mainDeckBaseBottom1Pos1 = new Vector3(479.97f, 32.83f, 378.2f);
	private Vector3 mainDeckBaseBottom1Pos2 = new Vector3 (479.97f, 7.83f, 353.2f);

	// Rear Part

	private Vector3 rearBodyPos1 = new Vector3 (199.4f, 21.6f, 229.9f);
	private Vector3 rearBodyPos2 = new Vector3 (199.4f, -4.6f, 204.9f);

	private Vector3 angleRodLeftPos1 = new Vector3 (207.8f, 29.4f, 238.9f);
	private Vector3 angleRodLeftPos2 = new Vector3 (207.8f, 4.4f, 213.9f);

	private Vector3 angleRodRightPos1 = new Vector3 (160.79f,3.01f,320.5f);
	private Vector3 angleRodRightPos2 = new Vector3 (208.3f,3.4f,195.9f);


	private Vector3 satelliteBasePos1 = new Vector3 (202f,22.6f,220.9f);
	private Vector3 satelliteBasePos2 = new Vector3 (202f,-3.6f,195.9f);

	private Vector3 satelliteCupPos1 = new Vector3 (207.3f,43.4f, 220.9f);
	private Vector3 satelliteCupPos2 = new Vector3 (207.3f,9.4f, 195.9f);

	private Vector3 solarPanelBasePos1 = new Vector3 (191.5f, 22.6f,224.9f);
	private Vector3 solarPanelBasePos2 = new Vector3 (191.5f, -3.6f,199.9f);

	private Vector3 solarPanelspherePos1 = new Vector3 (196.4f, 25.4f, 231.9f); 
	private Vector3 solarPanelspherePos2 = new Vector3 (196.4f, .4f, 206.9f); 

	private Vector3 weatherSensorPos1 = new Vector3 (235.79f, 22.13f, 203.9f);
	private Vector3 weatherSensorPos2 = new Vector3 (235.79f, -3.13f, 178.9f);


	private Camera mainCamera, driverDeckCamera, sideCamera, mainDeckCamera;

	[HideInInspector]
	public bool readyToDetectCollision = false;

	// Use this for initialization
	void Start () 
	{
		Application.runInBackground = true;

		driverDeckCamera = GameObject.Find("CameraDriverDeck").GetComponent<Camera> ();
		mainDeckCamera= GameObject.Find ("CameraMainBody").GetComponent<Camera> ();

		mainCamera = GameObject.Find("CameraFront").GetComponent<Camera> ();

		sideCamera = GameObject.Find ("CameraSide").GetComponent<Camera> ();



		rb = transform.GetComponentInChildren<Rigidbody> ();
		if (rb == null)
			print ("Could not find rigidbody");
		else
			print ("Found rigidbody. At " + rb.gameObject);

		StartCoroutine (PerformAssembly ());
	}

	IEnumerator PerformAssembly()
	{	
		
		//avatarWelCome.Play();
		//yield return new WaitForSeconds (5);

		// Driver deck starts
		/*
		labelUpdate("Driver Deck Top");
		StartCoroutine (MoveCamera (driverDeckCamera, driverDeckCamera.gameObject.transform.position,  new Vector3 (9.1f, 8.2f, 453.2f), 2f));
		RotateCamera (driverDeckCamera,	-7.741f, 0.087f);
		yield return new WaitForSeconds (5);
		avatarDriveDeckTop.Play();
		yield return new WaitForSeconds (3);

		labelUpdate("Driver Deck Base");
		StartCoroutine (MoveCamera (driverDeckCamera, driverDeckCamera.gameObject.transform.position,  new Vector3 (59.2f, -1.8f, 453.2f), 2f));
		yield return new WaitForSeconds (5);
		avatarDriveDeckBase.Play();
		yield return new WaitForSeconds (3);

		labelUpdate("Engine");
		StartCoroutine (MoveCamera (driverDeckCamera, driverDeckCamera.gameObject.transform.position,  new Vector3 (99.57f, 4.68f, 453.2f), 2f));
		yield return new WaitForSeconds (5);
		avatarDriveDeckEngine.Play();
		yield return new WaitForSeconds (3);

		avatarLetsAssemble.Play();

		StartCoroutine (MoveCamera (driverDeckCamera, driverDeckCamera.gameObject.transform.position,  new Vector3 (169.8f, 1.9f, 444.7f), 2f));

		//***Driver deck base***
		StartCoroutine (Move (driverDeckBase, driverDeckBase.gameObject.transform.position, driverDeckBasePos1, Vector3.zero, Vector3.zero, 2f));
		yield return new WaitForSeconds (2);
		StartCoroutine (Move (driverDeckBase, driverDeckBase.gameObject.transform.position, driverDeckBasePos2, Vector3.zero, Vector3.zero, 2f));

		//***Driver deck engine***
		StartCoroutine (Move (driverDeckEngine, driverDeckEngine.gameObject.transform.position, driverDeckEnginePos1, Vector3.zero, Vector3.zero, 2f));
		yield return new WaitForSeconds (2);
		StartCoroutine (Move (driverDeckEngine, driverDeckEngine.gameObject.transform.position, driverDeckEnginePos2, Vector3.zero, Vector3.zero, 2f));

		//***Driver deck***
		StartCoroutine (Move (driverDeckTop, driverDeckTop.gameObject.transform.position, driverDeckTopPos1, Vector3.zero, Vector3.zero, 2f));
		yield return new WaitForSeconds (2);
		StartCoroutine (Move (driverDeckTop, driverDeckTop.gameObject.transform.position, driverDeckTopPos2, Vector3.zero, Vector3.zero, 2f));

*/
		yield return new WaitForSeconds (5);
		avatarMainDeckIntro.Play();	
		yield return new WaitForSeconds (7);

		labelUpdate("Main Deck base");
		StartCoroutine (MoveCamera (mainDeckCamera, mainDeckCamera.gameObject.transform.position,  new Vector3 (16.4f, 8.199f, 320.9f), 2f));
		RotateCamera (mainDeckCamera,	-7.741f, 0.087f);
		yield return new WaitForSeconds (5);
		avatarMainDeckBase.Play();	
		yield return new WaitForSeconds (3);

		labelUpdate("Battery");
		StartCoroutine (MoveCamera (mainDeckCamera, mainDeckCamera.gameObject.transform.position,  new Vector3 (55.4f, 8.199f, 320.9f), 2f));	
		yield return new WaitForSeconds (5);
		avatarMainDeckBattery.Play();	
		yield return new WaitForSeconds (3);

		labelUpdate("Oxygen tank");
		StartCoroutine (MoveCamera (mainDeckCamera, mainDeckCamera.gameObject.transform.position,  new Vector3 (88.3f, 8.199f, 320.9f), 2f));	
		yield return new WaitForSeconds (5);
		avatarMainDeckOxygen.Play();	
		yield return new WaitForSeconds (3);

		labelUpdate("Additional storage");
		StartCoroutine (MoveCamera (mainDeckCamera, mainDeckCamera.gameObject.transform.position,  new Vector3 (124.3f, 8.199f, 320.9f), 2f));	
		yield return new WaitForSeconds (5);
		avatarMainDeckAdditional.Play();	
		yield return new WaitForSeconds (3);

		labelUpdate("Food storage");
		StartCoroutine (MoveCamera (mainDeckCamera, mainDeckCamera.gameObject.transform.position,  new Vector3 (164.1f, 8.199f, 320.9f), 2f));	
		yield return new WaitForSeconds (5);
		avatarMainDeckFood.Play();	
		yield return new WaitForSeconds (3);

		labelUpdate("Water storage");
		StartCoroutine (MoveCamera (mainDeckCamera, mainDeckCamera.gameObject.transform.position,  new Vector3 (205.7f, 8.199f, 320.9f), 2f));	
		yield return new WaitForSeconds (5);
		avatarMainDeckWater.Play();	
		yield return new WaitForSeconds (3);

		labelUpdate("Main deck body");
		StartCoroutine (MoveCamera (mainDeckCamera, mainDeckCamera.gameObject.transform.position,  new Vector3 (253f, 21.0f, 309f), 2f));	
		yield return new WaitForSeconds (5);
		avatarMainDeckBody.Play();	
		yield return new WaitForSeconds (3);

		labelUpdate("Main deck top");
		StartCoroutine (MoveCamera (mainDeckCamera, mainDeckCamera.gameObject.transform.position,  new Vector3 (296f, 21f, 309f), 2f));	
		yield return new WaitForSeconds (5);
		avatarMainDeckTop.Play();	
		yield return new WaitForSeconds (3);

		avatarLetsAssemble.Play();

		 mainDeckTop, mainDeckMiddle, 
	 mainDeckBaseTop1, mainDeckBaseTop2, mainDeckBaseMiddle1,mainDeckBaseMiddle2,mainDeckBaseBottom1;

		//***Main deck base***
		StartCoroutine (Move (mainDeckBase, mainDeckBase.gameObject.transform.position, mainDeckBasePos1, Vector3.zero, Vector3.zero, 2f));
		yield return new WaitForSeconds (2);
		StartCoroutine (Move (mainDeckBase, driverDeckBase.gameObject.transform.position, mainDeckBasePos2, Vector3.zero, Vector3.zero, 2f));

		//***Main deck base***
		StartCoroutine (Move (mainDeckBaseBottom1, mainDeckBaseBottom1.gameObject.transform.position, mainDeckBaseBottom1Pos1, Vector3.zero, Vector3.zero, 2f));
		yield return new WaitForSeconds (2);
		StartCoroutine (Move (mainDeckBaseBottom1, mainDeckBaseBottom1.gameObject.transform.position, mainDeckBaseBottom1Pos2, Vector3.zero, Vector3.zero, 2f));


		// Driver deck ends

//		labelUpdate("");
//
//		//***main deck focus***
//		yield return new WaitForSeconds (5);
//
//		StartCoroutine (MoveCamera (insideCamera, insideCamera.gameObject.transform.position,  new Vector3 (40, 0, 61), 2f));
//		yield return new WaitForSeconds (3);
//
//		labelUpdate("Main body");
//
//
//		yield return new WaitForSeconds (3);
//
//		labelUpdate("");
//
//		StartCoroutine (Move (middleBody, middleBody.gameObject.transform.position, middleBodyPos1, Vector3.zero, Vector3.zero, 2f));
//		yield return new WaitForSeconds (2);
//
//		StartCoroutine (Move (middleBody, middleBody.gameObject.transform.position, middleBodyPos2, Vector3.zero, Vector3.zero, 2f));
//
//	
	/*
		//***Front and Back Separators***
		//yield return new WaitForSeconds (5);

		//StartCoroutine (MoveCamera (insideCamera, insideCamera.gameObject.transform.position,  new Vector3 (118.1f, 2.4f, 66.0002f), 2f));
		//yield return new WaitForSeconds (3);

		labelUpdate("Front and Back Separators");
		avatarSeperator.Play();	
		yield return new WaitForSeconds (3);
		labelUpdate("");


		StartCoroutine (Move (frontSeparator, frontSeparator.gameObject.transform.position, frontSeparatorPos1, Vector3.zero, Vector3.zero, 2f));
		StartCoroutine (Move (backSeparator, backSeparator.gameObject.transform.position, backSeparatorPos1, Vector3.zero, Vector3.zero, 2f));

		yield return new WaitForSeconds (2);

		StartCoroutine (Move (frontSeparator, frontSeparator.gameObject.transform.position, frontSeparatorPos2, Vector3.zero, Vector3.zero, 2f));
		StartCoroutine (Move (backSeparator, backSeparator.gameObject.transform.position, backSeparatorPos2, Vector3.zero, Vector3.zero, 2f));




		
		//***Wheels***
		yield return new WaitForSeconds (5);
		StartCoroutine (MoveCamera (driverDeckCamera, driverDeckCamera.gameObject.transform.position,  new Vector3 (187.9f, 2.4f, 48.9f), 2f));
		yield return new WaitForSeconds (2);

		labelUpdate("Wheels with axle");
		avatarWheels.Play();	
		yield return new WaitForSeconds (3);
		labelUpdate("");

		float wheelFix = 5f;

		StartCoroutine (Move (frontRightWheel, frontRightWheel.gameObject.transform.position, frontRightWheelPos2, Vector3.zero, Vector3.zero, wheelFix));

		StartCoroutine (Move (frontRightWheelAxle, frontRightWheelAxle.gameObject.transform.position, frontRightWheelAxlePos2, Vector3.zero, Vector3.zero, wheelFix));
		StartCoroutine (Move (frontLeftWheelAxle, frontLeftWheelAxle.gameObject.transform.position, frontLeftWheelAxlePos2, Vector3.zero, Vector3.zero, wheelFix));
		StartCoroutine (Move (rearLeftWheelAxle, rearLeftWheelAxle.gameObject.transform.position, rearLeftWheelAxlePos2, Vector3.zero, Vector3.zero, wheelFix));
		StartCoroutine (Move (rearRightWheelAxle, rearRightWheelAxle.gameObject.transform.position, rearRightWheelAxlePos2, Vector3.zero, Vector3.zero, wheelFix));

		StartCoroutine (Move (frontLeftWheel, frontLeftWheel.gameObject.transform.position, frontLeftWheelPos, Vector3.zero, Vector3.zero, wheelFix));
		StartCoroutine (Move (rearRightWheel, rearRightWheel.gameObject.transform.position, rearRightWheelPos, Vector3.zero, Vector3.zero, wheelFix));
		StartCoroutine (Move (rearLeftWheel, rearLeftWheel.gameObject.transform.position, rearLeftWheelPos, Vector3.zero, Vector3.zero, wheelFix));

		*/

		//StartCoroutine (MoveCamera (insideCamera, insideCamera.gameObject.transform.position,  new Vector3 (40, 0, 61), 2f));

//		labelUpdate("Main body");
//
//		avatarMainDeck.Play();	
//		// + Line 1 should added
//		yield return new WaitForSeconds (5);
//		labelUpdate("");
//
//
//
//		StartCoroutine (MoveCamera (mainBodyCamera, mainBodyCamera.gameObject.transform.position,  new Vector3 (2.2f, 25f, 70.6f), 340f));
//		StartCoroutine (MoveCamera (sideCamera, sideCamera.gameObject.transform.position,  new Vector3 (2.2f, 25f, 70.6f), 340f));
//		yield return new WaitForSeconds (2);
//
//		// Base of the main deck 
//
//		labelUpdate("Main body base");
//
//		avatarMainDeckBase.Play();	
//		yield return new WaitForSeconds (3);
//		labelUpdate("");
//
//		StartCoroutine (Move (mainDeckBase, mainDeckBase.gameObject.transform.position, mainDeckBasePos1, Vector3.zero, Vector3.zero, 2f));
//		yield return new WaitForSeconds (5);
//		StartCoroutine (Move (mainDeckBase, mainDeckBase.gameObject.transform.position, mainDeckBasePos2, Vector3.zero, Vector3.zero, 2f));
//
//	
//
		/*
		 
		labelUpdate("Rear base");

		avatarRearBase.Play();	
		yield return new WaitForSeconds (3);
		labelUpdate("");

		StartCoroutine (Move (rearBody, rearBody.gameObject.transform.position, rearBodyPos1, Vector3.zero, Vector3.zero, 2f));
		yield return new WaitForSeconds (5);

		StartCoroutine (Move (rearBody, rearBody.gameObject.transform.position, rearBodyPos2, Vector3.zero, Vector3.zero, 2f));

		//***Angle Rod 1 & Rod 2***
		yield return new WaitForSeconds (5);
		StartCoroutine (MoveCamera (insideCamera, insideCamera.gameObject.transform.position,  new Vector3 (143.7f, 2.4f, 66.0002f), 2f));
		yield return new WaitForSeconds (2);

		labelUpdate("Angle Rods");
		avatarAngleRods.Play();	
		yield return new WaitForSeconds (3);
		labelUpdate("");

		StartCoroutine (Move (angleRodOne, angleRodOne.gameObject.transform.position, angleRodLeftPos1, Vector3.zero, Vector3.zero, 2f));
		StartCoroutine (Move (angleRodTwo, angleRodTwo.gameObject.transform.position, angleRodRightPos1, Vector3.zero, Vector3.zero, 2f));

		yield return new WaitForSeconds (2);

		StartCoroutine (Move (angleRodOne, angleRodOne.gameObject.transform.position, angleRodLeftPos2, Vector3.zero, Vector3.zero, 2f));
		StartCoroutine (Move (angleRodTwo, angleRodTwo.gameObject.transform.position, angleRodRightPos2, Vector3.zero, Vector3.zero, 2f));

		//***Satellite***
		yield return new WaitForSeconds (5);
		StartCoroutine (MoveCamera (insideCamera, insideCamera.gameObject.transform.position,  new Vector3 (229.8f, 2.4f, 70.6f), 2f));
		yield return new WaitForSeconds (2);

		labelUpdate("Satellite");
		avatarSatelite.Play();	
		yield return new WaitForSeconds (3);
		labelUpdate("");

		StartCoroutine (Move (satelliteBase, satelliteBase.gameObject.transform.position, satelliteBasePos1, Vector3.zero, Vector3.zero, 2f));
		StartCoroutine (Move (satelliteCup, satelliteCup.gameObject.transform.position, satelliteCupPos1, Vector3.zero, Vector3.zero, 2f));

		yield return new WaitForSeconds (2);

		StartCoroutine (Move (satelliteBase, satelliteBase.gameObject.transform.position, satelliteBasePos2, Vector3.zero, Vector3.zero, 2f));
		yield return new WaitForSeconds (2);

		StartCoroutine (Move (satelliteCup, satelliteCup.gameObject.transform.position, satelliteCupPos2, Vector3.zero, Vector3.zero, 2f));
		yield return new WaitForSeconds (2);

		//***Solar Panel***
		yield return new WaitForSeconds (5);
		StartCoroutine (MoveCamera (insideCamera, insideCamera.gameObject.transform.position,  new Vector3 (257.8f, 2.4f, 70.6f), 2f));
		yield return new WaitForSeconds (2);

		labelUpdate("Solar Panel");
		avatarSolar.Play();	
		yield return new WaitForSeconds (3);
		labelUpdate("");

		StartCoroutine (Move (solarPanel, solarPanel.gameObject.transform.position, solarPanelBasePos1, Vector3.zero, Vector3.zero, 2f));
		StartCoroutine (Move (solarPanelsphere, solarPanelsphere.gameObject.transform.position, solarPanelspherePos1, Vector3.zero, Vector3.zero, 2f));
		yield return new WaitForSeconds (2);

		StartCoroutine (Move (solarPanel, solarPanel.gameObject.transform.position, solarPanelBasePos2, Vector3.zero, Vector3.zero, 2f));
		yield return new WaitForSeconds (2);

		StartCoroutine (Move (solarPanelsphere, solarPanelsphere.gameObject.transform.position, solarPanelspherePos2, Vector3.zero, Vector3.zero, 2f));
		yield return new WaitForSeconds (2);

		//***weatherSensor*** 
		yield return new WaitForSeconds (5);
		StartCoroutine (MoveCamera (insideCamera, insideCamera.gameObject.transform.position,  new Vector3 (280.2f, 11.2f, 53.5f), 2f));
		yield return new WaitForSeconds (2);

		labelUpdate("Weather sensors");
		avatarWeatherSensor.Play();	
		yield return new WaitForSeconds (3);
		labelUpdate("");

		StartCoroutine (Move (weatherSensor, weatherSensor.gameObject.transform.position, weatherSensorPos1, Vector3.zero, Vector3.zero, 2f));
		yield return new WaitForSeconds (2);

		StartCoroutine (Move (weatherSensor, weatherSensor.gameObject.transform.position, weatherSensorPos2, Vector3.zero, Vector3.zero, 2f));
		yield return new WaitForSeconds (2);

		avatarFinal.Play();	
		yield return new WaitForSeconds (3);

		readyToDetectCollision = true;

		*/

	}

	IEnumerator Move(GameObject obj, Vector3 sPos, Vector3 ePos, Vector3 sRot, Vector3 eRot, float time)
	{
		float i = 0.0f;
		float rate = (float)1.0/time;
		while (i < 1.0f) 
		{
			i += Time.deltaTime * rate;
			//obj.transform.localPosition = Vector3.Slerp(sPos, ePos, i);
			obj.transform.localPosition = Vector3.Lerp(sPos, ePos, i);
			//obj.transform.localEulerAngles = Vector3.Lerp (sRot,eRot,i);
			yield return true;
		}
	}

	void labelUpdate(string txt)
	{
		labelText.text = txt;

	}

	IEnumerator MoveCamera(Camera cam, Vector3 sPos, Vector3 ePos, float time)
	{
		float i = 0.0f;
		float rate = (float)1.0/time;
		while (i < 1.0f) 
		{
			i += Time.deltaTime * rate;
			cam.transform.position = Vector3.Slerp(sPos, ePos, i);
			yield return true;
		
		}
	}


	void RotateCamera(Camera cam,float xPos, float zPos)
	{

		float target = 270.0F;
		float speed = 45.0F;

			float angle = Mathf.MoveTowardsAngle(transform.eulerAngles.y, target, speed * Time.deltaTime);
		cam.transform.eulerAngles = new Vector3(xPos,angle,zPos );

	}



	void FixedUpdate()
	{
		if(readyToDetectCollision)
		{
			transform.position += transform.right * 10f * Time.deltaTime;
			mainCamera.transform.position += transform.right * 9f * Time.deltaTime;
			sideCamera.transform.position += transform.right * 9f * Time.deltaTime;
		}
	}

	// Update is called once per frame
	void Update () 
	{

	}
}