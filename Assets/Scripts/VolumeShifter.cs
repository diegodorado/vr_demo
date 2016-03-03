using UnityEngine;
using System.Collections;

public class VolumeShifter : MonoBehaviour {

  [Range(0f,1f)]
  public float minVolume = 0.3f;
  [Range(0f,1f)]
  public float maxVolume = 1f;
  [Range(0f,20f)]
  public float volDamp = 1f;
  private Camera cam;
  private AudioSource aud;
  private float m_targetVol;


  void Awake () {
    cam = Camera.main;	
    aud = GetComponent<AudioSource>();
    m_targetVol = minVolume;
	}
	
	// Update is called once per frame
	void Update () {

    RaycastHit hit;
    Ray ray = new Ray(cam.transform.position, cam.transform.forward);

    bool isLooked = GetComponent<Collider>().Raycast(ray,out hit,Mathf.Infinity);
    if(isLooked)
      m_targetVol = maxVolume;
    else
      m_targetVol = minVolume;


    aud.volume = Mathf.Lerp(aud.volume, m_targetVol, Time.deltaTime * volDamp);
	
	}
}
