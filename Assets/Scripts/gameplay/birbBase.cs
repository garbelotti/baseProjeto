using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class birbBase : MonoBehaviour {
	public float attackTime,attackDelay,seedPower;
	public birbBoss boss;
	public GameObject seed;
	private Vector3 seedOrigin,bossPos;
	// Use this for initialization
	void Start () {
		boss=gamePlayManager.Instance.birb;
		seedOrigin=seed.transform.position;
		bossPos=boss.transform.position;
		//_attackDelay=attackDelay;
		attackDelay+=Random.value;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.I)){
			resumeFeed();
		}
	}

	public void feedBoss(float val){
		if (boss.me == birbBoss.birbState.feed){
			boss.feedMe(val);
			Invoke("animaFeed",attackTime);
		}
	}

	public void feedBoss(){
		feedBoss(seedPower);
	}

	public void animaFeed(){
		/*DOJump(Vector3 endValue, float jumpPower, int numJumps, float duration, bool snapping) */
		if (boss.me == birbBoss.birbState.feed){
		seed.transform.position = seedOrigin;
		seed.transform.DOJump(bossPos,2f,1,0.8f,false).OnComplete(() => {
			feedBoss();
		});
		}else {
			CancelInvoke();
			Invoke("animaFeed",attackTime);
		}
	}

	public void resumeFeed(){
		CancelInvoke();
		StartCoroutine(startFeed(seedPower));
	}

	public IEnumerator startFeed(float val) {
		if (attackDelay!=0) yield return new WaitForSeconds(attackDelay);
			animaFeed();
		yield break;
	}
}
