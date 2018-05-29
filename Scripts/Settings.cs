using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour {

	[Range(1,2)]public int decision1;
	[Range(1,2)]public int decision3;
	public string decision4;

	private Randomize randomize;
	private Timer timer;
	private OutsideInfluence outsideInfluence;
	private CoinFlip coinFlip;
	private D2DestroyOrCreate d2;


	public int value1;
	public float seconds = 0f;
	public float minutes = 0f;
	public bool german;
	public int environmentTilt = 0;
	public bool preserved;

	// Use this for initialization
	void Start () {
		
		timer = GameObject.FindGameObjectWithTag("Player").GetComponent<Timer> ();
		randomize = GameObject.FindGameObjectWithTag("Player").GetComponent<Randomize> ();
		outsideInfluence = GameObject.FindGameObjectWithTag("Player").GetComponent<OutsideInfluence> ();
		d2 = GameObject.FindGameObjectWithTag("egg").GetComponent<D2DestroyOrCreate> ();
	}
	
	// Update is called once per frame
	void Update () {
		value1 = randomize.value1;
		seconds = timer.seconds;
		minutes = timer.minutes;
		environmentTilt = outsideInfluence.environmentTilt;

		if (d2 != null) {
			preserved = d2.preserved;
		}

		if(GameObject.FindGameObjectWithTag("coin") != null)
			coinFlip = GameObject.FindGameObjectWithTag("coin").GetComponent<CoinFlip> ();
		
		if(coinFlip != null)
			decision4 = coinFlip.face;
	}
}
