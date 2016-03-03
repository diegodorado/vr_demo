using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CycleAnimations : MonoBehaviour {
  private Animation anim;
  private List<AnimationClip> clips;
	// Use this for initialization
	void Awake () {
    anim = GetComponent<Animation>();
    clips =  new List<AnimationClip>();
    foreach(AnimationState s in anim){
      clips.Add(s.clip);
    }
	
	}
	
	// Update is called once per frame
	void Update () {

    if(!anim.isPlaying){
      int i = Random.Range(0, clips.Count-1);
      var clip = clips[i];
      anim.clip = clip;
      anim.Play();
    }
	
	}
}
