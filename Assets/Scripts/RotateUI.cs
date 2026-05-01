using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotateUI : MonoBehaviour
{
    [SerializeField] Image rotateImage;
    [SerializeField] int maxStep = 8;
    [SerializeField] float stepTime = 0.3f;

    int currentStep = 0;
    float currentAngle = 0f;
    bool isRotating = false;

    public bool RotateStep(bool _direction)
    {
        if (this.isRotating) return false;
        int t_next = this.currentStep + (_direction ? 1 : -1);
        if (t_next < 0 || t_next > this.maxStep) return false;

        this.currentStep = t_next;
        float t_targetAngle = this.currentAngle - ((_direction ? 1 : -1) * (360f / this.maxStep));
        StartCoroutine(Rotate(t_targetAngle, this.stepTime));
        return true;
    }

    public void RotateFull(float _time)
    {
        StopAllCoroutines();
        this.isRotating = false;
        StartCoroutine(RotateFullCoroutine(_time));
    }

    IEnumerator RotateFullCoroutine(float _time)
    {
        yield return StartCoroutine(Rotate(this.currentAngle - 360f, _time));
        this.rotateImage.rectTransform.localEulerAngles = Vector3.zero;
        this.currentAngle = 0f;
        this.currentStep = 0;
    }

    public void RotateImage(float _angle, float _time)
    {
        if (this.isRotating) return;
        StartCoroutine(Rotate(this.currentAngle + _angle, _time));
    }

    IEnumerator Rotate(float _targetAngle, float _time)
    {
        this.isRotating = true;
        float t_interval = 0;
        float t_startAngle = this.currentAngle;

        while (t_interval <= _time)
        {
            t_interval += Time.fixedDeltaTime;
            float t_progress = Mathf.Clamp01(t_interval / _time);
            this.rotateImage.rectTransform.localEulerAngles = new Vector3(0, 0, Mathf.Lerp(t_startAngle, _targetAngle, t_progress));
            yield return new WaitForFixedUpdate();
        }

        this.rotateImage.rectTransform.localEulerAngles = new Vector3(0, 0, _targetAngle);
        float t_normalized = _targetAngle % 360f;
        this.currentAngle = t_normalized < 0f ? t_normalized + 360f : t_normalized;
        this.isRotating = false;
    }
}
