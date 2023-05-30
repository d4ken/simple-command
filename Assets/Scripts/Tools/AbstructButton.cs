using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using UnityEngine.Events;

[RequireComponent(typeof(CanvasGroup))]
public abstract class AbstructButton : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{
    private bool _isPushed = false;
    protected UnityAction OnClickCallback;
    protected CanvasGroup CanvasGroup;
    void Awake()
    {
        DOTween.Init();
        CanvasGroup = gameObject.GetComponent<CanvasGroup>();
    }
    
    void OnEnable()
    {
        ButtonActive(true);
    }
    
    // ボタンが押下状況を取得する
    protected bool IsPushed { get { return _isPushed; }}
    
    // ボタンの押下状況を設定
    protected void ButtonActive(bool active)
    {
        _isPushed = !active;
    }

    public virtual void OnPointerClick(PointerEventData eventData)
    {
        OnButtonClicked();
        OnClickCallback?.Invoke();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (_isPushed) return;
        OnButtonDown();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (_isPushed) return;
        OnButtonUp();
    }

    protected virtual void OnButtonDown()
    {
        // Down時の共通処理
        transform.DOScale(0.9f, 0.3f).SetEase(Ease.OutElastic).SetLink(gameObject);
        CanvasGroup.DOFade(0.8f, 0.3f).SetEase(Ease.InCubic).SetLink(gameObject);
    }

    protected virtual void OnButtonUp()
    {
        // Up時の共通処理
        transform.DOScale(1f, 0.3f).SetEase(Ease.OutElastic).SetLink(gameObject);
        CanvasGroup.DOFade(1f, 0.3f).SetEase(Ease.OutCubic).SetLink(gameObject);
    }

    // Click時の共通処理
    protected virtual void OnButtonClicked()
    {
    }
}