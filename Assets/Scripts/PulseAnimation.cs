using System.Collections;
using UnityEngine;

public class PulseAnimation : MonoBehaviour
{
    [SerializeField] private GameObject pulseObject;

    [Space]
    [Header("Pulse Variables")]
    [SerializeField] AnimationCurve expandCurve;
    [SerializeField] float expandAmount;
    [Range(0,1)] 
    [SerializeField] float expandSpeed;
    [SerializeField] float pulseDuration;

    private Vector3 m_startSize;
    private Vector3 m_targetSize;
    private float m_scrollAmount;

    private void Start()
    {
        InitPulseVariables();
        StartCoroutine(RunPulseAnimation());
    }

    private void Update()
    {
    }

    private void InitPulseVariables()
    {
        m_startSize = transform.localScale;
        m_targetSize = m_startSize * expandAmount;
    }

    public void PlayPulseAnimation()
    {
        m_scrollAmount += Time.deltaTime * expandSpeed;
        float _percent = expandCurve.Evaluate(m_scrollAmount);
        transform.localScale = Vector2.Lerp(m_startSize, m_targetSize, _percent);
    }

    public IEnumerator RunPulseAnimation()
    {
        float startTime = Time.time;
        while (Time.time < startTime + pulseDuration)
        {
            m_scrollAmount += Time.deltaTime * expandSpeed;
            float _percent = expandCurve.Evaluate(m_scrollAmount);
            transform.localScale = Vector2.Lerp(m_startSize, m_targetSize, _percent);
            yield return null;
        }

        startTime = Time.time;
        Vector3 currentSize = transform.localScale;
        yield return null;

        while (Time.time < startTime + 0.25f)
        {
            m_scrollAmount += Time.deltaTime * expandSpeed;
            float _percent = expandCurve.Evaluate(m_scrollAmount);
            transform.localScale = Vector2.Lerp(currentSize, m_startSize, _percent);
            yield return null;
        }
        transform.localScale = m_startSize;
        yield break;
    }
}
