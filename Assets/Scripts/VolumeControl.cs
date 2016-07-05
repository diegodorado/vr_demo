using UnityEngine;
using System.Collections;

public class VolumeControl : MonoBehaviour {
  private AudioSource aud;
  void Awake () {
    aud = GetComponent<AudioSource>();

	}
	
  public void ChangeVolume (float val) {
    aud.volume = val;
	}
  public void ChangeVolume2 (float val) {
    aud.volume = val;
  }
}