using UnityEngine;
using System.Collections;

public class CollisionScript : MonoBehaviour 
{
	GameObject parentMarsRover;
	public ParticleSystem explosionEffect;

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Terrain") 
		{
			print ("Collided " + other.name);

			if (parentMarsRover.GetComponent<AssemblyScript> ().readyToDetectCollision) 
			{
				parentMarsRover.GetComponent<AssemblyScript> ().readyToDetectCollision = false;
				explosionEffect.Play ();
			}
		} 
		else 
		{
			print (other.name);
		}
	}

	// Use this for initialization
	void Start () 
	{
		parentMarsRover = GameObject.Find ("MarsRover");
		if (parentMarsRover == null)
			print ("Could not find parent object.");
		else
			print ("Found parent at " + parentMarsRover.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
