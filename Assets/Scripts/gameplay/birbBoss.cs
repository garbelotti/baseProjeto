using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class birbBoss : MonoBehaviour {
	public enum  birbState {
		idle, feed, defeated
	}
	public birbState me;
	public float seedNeeded,tamMax;	

	private float tamPiece,piece;
	// Use this for initialization
	void Start () {
		me = birbState.idle;
		//startFeed();
		//startFeed();
		tamPiece = (tamMax-1) / 10;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void startFeed(float val=25){
		me = birbState.feed;
		seedNeeded=val;
		piece=seedNeeded/10;
	}
	
	

	public void feedMe(float val){
		if (me==birbState.feed) {
			seedNeeded-=val;
			if (seedNeeded%piece<=1){
				transform.DOScale(transform.localScale+new Vector3(tamPiece,tamPiece,tamPiece),1);
			}
			
			//Debug.Log(seedNeeded);
			if (seedNeeded<=0) {
				me=birbState.defeated;
				//Invoke("newBoss",1);
				gamePlayManager.Instance.newBoss();
			}
		}
	}

	public void newBoss(){
		transform.DOScale(Vector3.zero,0.5f).OnComplete(() => {
			transform.DOScale(Vector3.one,0.5f).OnComplete(() => {
				if (piece>0)
					startFeed(piece*25);
				else
					startFeed();
				});
		});
	}
}
