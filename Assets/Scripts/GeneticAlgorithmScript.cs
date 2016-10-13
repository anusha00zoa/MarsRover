using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

public class GeneticAlgorithmScript : MonoBehaviour 
{
	struct Coordinate
	{
		public Vector3 xy;
		public string letter;
	}

	Coordinate[] coordinatesArray = new Coordinate[8]; 	//Coordinate A, B, C, D, F1, F2, F3, F4;
	string parentOne, parentTwo, child;

	[HideInInspector]
	public string finalSequence;

	//private Dictionary<int, string> feederPartDict = new Dictionary<int, string>();

	// Use this for initialization
	void Start () 
	{
		//get coordinates for driverDeck, middleBody, rearBase and Wheels and assign to A, B, C, D	
		//associate feeders with the parts
		coordinatesArray[0].xy = new Vector3(50.0f, 0.0f, 0.0f);		coordinatesArray[0].letter = "A";		//feederPartDict.Add (1, "A");
		coordinatesArray[1].xy = new Vector3(0.0f, 0.0f, 0.0f); 		coordinatesArray[1].letter = "B";		//feederPartDict.Add (2, "B");
		coordinatesArray[2].xy = new Vector3(-50.0f, -20.0f, 0.0f);		coordinatesArray[2].letter = "C";		//feederPartDict.Add (3, "C");
		coordinatesArray[3].xy = new Vector3(0.0f, -20.0f, 0.0f); 		coordinatesArray[3].letter = "D";		//feederPartDict.Add (4, "D");

		coordinatesArray[4].xy = new Vector3(-50.0f, 100.0f, 0.0f); 		coordinatesArray[4].letter = "F1";
		coordinatesArray[5].xy = new Vector3 (-20.0f, 100.0f, 0.0f);		coordinatesArray[5].letter = "F2";
		coordinatesArray[6].xy = new Vector3 (20.0f, 100.0f, 0.0f);		coordinatesArray[6].letter = "F3";
		coordinatesArray[7].xy = new Vector3 (50.0f, 100.0f, 0.0f);		coordinatesArray [7].letter = "F4";
	}

	public void Initialize()
	{
		int count = 7;
		float travelDist = 0.0f, minDist = 0.0f;

		parentOne = "A,B,C,D";
		travelDist = CalculateDistanceFitnessFunction (parentOne);
		print ("parentOne = " + parentOne + " " + travelDist);

		minDist = travelDist;
		finalSequence = parentOne;

		parentTwo = "D,C,B,A";
		travelDist = CalculateDistanceFitnessFunction (parentTwo);
		if (travelDist < minDist) 
		{
			minDist = travelDist;
			finalSequence = parentTwo;
		}
		print ("parentTwo = " + parentTwo + " " + travelDist);


		//perform crossover, mutation operation on both parents
		while (count > 0) 
		{
			int coPt = Random.Range (0, 4);
			child = PerformCrossover (parentOne, parentTwo, coPt);
			travelDist = CalculateDistanceFitnessFunction (child);
			print ("crossover point = " + coPt + " child = " + child + " distance = " + travelDist);
			if (travelDist < minDist) 
			{
				minDist = travelDist;
				finalSequence = child;
			}

			coPt = Random.Range (0, 4);
			parentOne = PerformMutation (parentOne, coPt);
			CalculateDistanceFitnessFunction (parentOne);
			print ("mutation point = " + coPt + " parentOne = " + parentOne + " distance = " + travelDist);
			if (travelDist < minDist) 
			{
				minDist = travelDist;
				finalSequence = parentOne;
			}

			coPt = Random.Range (0, 4);
			parentTwo = PerformMutation (parentTwo, coPt);
			CalculateDistanceFitnessFunction (parentTwo);
			print ("mutation point = " + coPt + " parentTwo = " + parentTwo + " distance = " + travelDist);
			if (travelDist < minDist) 
			{
				minDist = travelDist;
				finalSequence = parentTwo;
			}

			count--;
		}
		print ("minDist = " + minDist);
	}

	string PerformCrossover(string pOne, string pTwo, int crossoverPoint)
	{
		int i = 0, j = 0, flag = 0;
		string nextGen = "", nextGen1 = "";

		string[] splitPOne = pOne.Split (',');
		string[] splitPTwo = pTwo.Split (',');
		string[] ng = new string[splitPOne.Length];

		if (crossoverPoint == 0)
			nextGen = pTwo;
		else if (crossoverPoint == pOne.Length)
			nextGen = pOne;
		else 
		{	
			i = 0;
			while (i < crossoverPoint) 		//the child has the same sequence of alphabets until the crossover point 
			{		
				nextGen1 += splitPOne [i];
				ng [i] = splitPOne [i];
				i++;
			}
			for (i = 0; i < nextGen1.Length; i++)
				nextGen += ng [i] + ",";

			i = crossoverPoint;	
			while (i <= splitPOne.Length) 	//for determining what comesafter the crossover point
			{ 	 
				if (nextGen1.Length == splitPOne.Length)
					break;
				
				if (nextGen1.Length < splitPOne.Length && i == splitPOne.Length) 
					i = 0;
					
				j = 0;
				flag = 0;
				while (j < crossoverPoint) 
				{
					if (ng [j] == splitPTwo [i]) 
					{
						flag = 1;
						break;
					} 
					else
						j++;
				}
				if (flag == 0) 
				{
					nextGen1 += splitPTwo [i];
					ng [i] = splitPTwo [i];
				}
				i++;
			}

			for (i = 0; i < (ng.Length - crossoverPoint); i++) 
				nextGen += ng [i] + ",";

			nextGen = nextGen.Substring (0, nextGen.Length - 1);
		}

		return nextGen;
	}

	string PerformMutation(string p, int mutationPoint)		//move the first alphabet of the parent to the mutationPoint to get child
	{
		string nextGen = "";
		int i = 0;

		string[] splitP = p.Split (',');
		string[] ng = new string[splitP.Length];

		for(i = 0; i < mutationPoint; i++)
			ng [i] = splitP [i + 1];

		ng [mutationPoint] = splitP [0];

		for (i = mutationPoint + 1; i < splitP.Length; i++)
			ng [i] = splitP [i];

		for (i = 0; i < splitP.Length; i++)
			nextGen += ng [i] + ",";

		nextGen = nextGen.Substring (0, nextGen.Length - 1);

		return nextGen;
	}

	float CalculateDistanceFitnessFunction(string sequence)
	{
		float sequenceDistance = 0.0f;
		int i = 0, k = 0;
		Coordinate c1 = coordinatesArray[0], c2 = coordinatesArray[0];

		string[] splitSeq = sequence.Split(',');

		i = 0;
		while (i < splitSeq.Length) 
		{
			for (k = 0; k < coordinatesArray.Length; k++) 
			{
				if (coordinatesArray [k].letter == splitSeq [i]) 
				{
					c1 = coordinatesArray [k];
					break;
				}
			}
			c2 = coordinatesArray [k + 4];
			sequenceDistance += CalculatePythagoreanDistance (c1, c2);
			i += 1;
		}
		return sequenceDistance;
	}

	//utility function to return distance between two points
	float CalculatePythagoreanDistance(Coordinate c1, Coordinate c2)
	{
		return Mathf.Sqrt (Mathf.Pow ((c2.xy.x - c1.xy.x), 2) + Mathf.Pow ((c2.xy.y - c1.xy.y), 2) + Mathf.Pow((c2.xy.z - c1.xy.z), 2));
	}

	// Update is called once per frame
	void FixedUpdate () 
	{
		if (transform.GetComponent<AssemblyScript> ().readyToRunGA)
			Initialize ();
	}
}
