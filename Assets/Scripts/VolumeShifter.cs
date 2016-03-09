using UnityEngine;
using System.Collections;

public class VolumeShifter : MonoBehaviour
{
    [Range(0f, 1f)]
    public float minVolume = 0.3f;
    [Range(0f, 1f)]
    public float maxVolume = 1f;
    [Range(0f, 20f)]
    public float volDamp = 1f;
    private Camera cam;
    private AudioSource aud;
    private float m_targetVol;

    public bool isLooked;
    void Awake()
    {
        cam = Camera.main;
        aud = GetComponent<AudioSource>();
        m_targetVol = minVolume;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        isLooked = GetComponent<Collider>().Raycast(ray, out hit, Mathf.Infinity);
        m_targetVol = isLooked ? maxVolume : minVolume;
        aud.volume = Mathf.Lerp(aud.volume, m_targetVol, Time.deltaTime * volDamp);
    }
}
