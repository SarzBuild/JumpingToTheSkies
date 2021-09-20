using System.Collections;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;

public class DoTweenJump : MonoBehaviour
{
    private Vector3 startPos;
    private Vector3 startScale;
    private IEnumerator coroutine;
    private bool stopCoroutine;
    private bool doOnce;
    private TextMeshProUGUI jumpText;
    private PlayerInputs _playerInputs;
    
    private void Start()
    {
        jumpText = transform.GetComponent<TextMeshProUGUI>();
        startPos = transform.position;
        startScale = transform.localScale;
        stopCoroutine = true;
        doOnce = true;
        _playerInputs = PlayerInputs.Instance;
        StartCoroutine(WaitAndAnimate());
    }

    private void Update()
    {
        if (_playerInputs.GetMovingUp()) 
            AnimateOut();

    }

    private IEnumerator WaitAndAnimate()
    {
        while(stopCoroutine)
        {
            yield return new WaitForSeconds(1f);
            Animate();
        }
    }

    private void Animate()
    {
        Reset();
        transform.DOPunchScale(new Vector3(1.1f, 1.1f, 1.1f), 1f, 1);
    }

    private void AnimateOut()
    {
        if (doOnce)
        {
            stopCoroutine = false;
            Reset();
            transform.DOMove(new Vector3(0f, 10f, 0f), 1f);
            Color newColor = new Color(1f,1f,1f,0f);
            jumpText.DOColor(newColor,1f);
            doOnce = false;
        }
    }

    private void Reset()
    {
        transform.position = startPos;
        transform.localScale = startScale;
        DOTween.Kill(transform);
    }
}
