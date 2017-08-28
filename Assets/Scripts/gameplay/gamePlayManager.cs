using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class gamePlayManager : MonoBehaviour {
	public birbBoss birb;
	public birbBase[] birbs;

	private static gamePlayManager _instance = null;
	public static gamePlayManager Instance
    {
        get
        {
            return _instance;
        }
    }

	void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
		}
	}

	public void newBoss(){
		birb.newBoss();
		Invoke("birbFeed",1);
		//birbFeed();
		
	}
	
	// Use this for initialization
	void Start () {
		newBoss();
		birbs=GameObject.FindObjectsOfType<birbBase>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void birbFeed(){
		foreach (birbBase birbAtual in birbs)
		{
			//birbAtual.animaFeed();
			birbAtual.resumeFeed();
		}
	}
}
