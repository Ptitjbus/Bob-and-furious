using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class OnGlassesCollect : OnCollectStruct
{
    [SerializeField] private Volume volumeEffect;
    private DepthOfField depthOfField;
    public override void OnCollect() {
        //disable the depth of field effect
        if (volumeEffect.profile.TryGet(out depthOfField)) {
            depthOfField.active = false;
        }
    }
}
