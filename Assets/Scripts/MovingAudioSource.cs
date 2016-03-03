using UnityEngine;
using System.Collections;

public class MovingAudioSource : MonoBehaviour {
  public AnimationCurve xCurve;
  public AnimationCurve yCurve;
  public AnimationCurve zCurve;
	
	// Update is called once per frame
	void Update () {

    if ( xCurve.length == 0 || yCurve.length == 0 || zCurve.length == 0 )
      return;
    
    var t = Time.time;///acLength;
    transform.position = new Vector3 (xCurve.Evaluate(t), yCurve.Evaluate(t), zCurve.Evaluate(t));

	}
}
