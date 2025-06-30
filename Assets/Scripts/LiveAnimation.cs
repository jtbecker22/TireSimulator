using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class LiveAnimation : MonoBehaviour
{
    public string animationName = "RecordedAnimation";
    public KeyCode recordKey = KeyCode.R;

    private bool isRecording = false;
    private float startTime;

    private List<Keyframe> posX = new List<Keyframe>();
    private List<Keyframe> posY = new List<Keyframe>();
    private List<Keyframe> posZ = new List<Keyframe>();

    private List<Keyframe> rotX = new List<Keyframe>();
    private List<Keyframe> rotY = new List<Keyframe>();
    private List<Keyframe> rotZ = new List<Keyframe>();

    private List<Keyframe> scaleX = new List<Keyframe>();
    private List<Keyframe> scaleY = new List<Keyframe>();
    private List<Keyframe> scaleZ = new List<Keyframe>();

    void Update()
    {
        if (Input.GetKeyDown(recordKey))
        {
            isRecording = !isRecording;

            if (isRecording)
            {
                Debug.Log("Recording started.");
                ClearKeyframes();
                startTime = Time.time;
            }
            else
            {
                Debug.Log("Recording stopped.");
                SaveAnimationClip();
            }
        }

        if (isRecording)
        {
            float time = Time.time - startTime;
            Vector3 pos = transform.localPosition;
            Vector3 rot = transform.localEulerAngles;
            Vector3 scale = transform.localScale;

            posX.Add(new Keyframe(time, pos.x));
            posY.Add(new Keyframe(time, pos.y));
            posZ.Add(new Keyframe(time, pos.z));

            rotX.Add(new Keyframe(time, rot.x));
            rotY.Add(new Keyframe(time, rot.y));
            rotZ.Add(new Keyframe(time, rot.z));

            scaleX.Add(new Keyframe(time, scale.x));
            scaleY.Add(new Keyframe(time, scale.y));
            scaleZ.Add(new Keyframe(time, scale.z));
        }
    }

    void ClearKeyframes()
    {
        posX.Clear(); posY.Clear(); posZ.Clear();
        rotX.Clear(); rotY.Clear(); rotZ.Clear();
        scaleX.Clear(); scaleY.Clear(); scaleZ.Clear();
    }

    void SaveAnimationClip()
    {
#if UNITY_EDITOR
        AnimationClip clip = new AnimationClip();
        clip.frameRate = 60f;

        clip.SetCurve("", typeof(Transform), "m_LocalPosition.x", new AnimationCurve(posX.ToArray()));
        clip.SetCurve("", typeof(Transform), "m_LocalPosition.y", new AnimationCurve(posY.ToArray()));
        clip.SetCurve("", typeof(Transform), "m_LocalPosition.z", new AnimationCurve(posZ.ToArray()));

        clip.SetCurve("", typeof(Transform), "m_LocalRotation.x", new AnimationCurve(rotX.ToArray()));
        clip.SetCurve("", typeof(Transform), "m_LocalRotation.y", new AnimationCurve(rotY.ToArray()));
        clip.SetCurve("", typeof(Transform), "m_LocalRotation.z", new AnimationCurve(rotZ.ToArray()));

        clip.SetCurve("", typeof(Transform), "m_LocalScale.x", new AnimationCurve(scaleX.ToArray()));
        clip.SetCurve("", typeof(Transform), "m_LocalScale.y", new AnimationCurve(scaleY.ToArray()));
        clip.SetCurve("", typeof(Transform), "m_LocalScale.z", new AnimationCurve(scaleZ.ToArray()));

        string path = "Assets/" + animationName + ".anim";
        AssetDatabase.CreateAsset(clip, path);
        AssetDatabase.SaveAssets();

        Debug.Log("Animation saved to " + path);
#else
        Debug.LogWarning("Saving animation is only supported in the Unity Editor.");
#endif
    }
}