using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PartsSystem : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private RectTransform _rectTransform;
    public Canvas _canvas;
    Image _image;

    private Vector2 offset;
    private Vector2 oldPosition;

    [SerializeField] ScriptableObject _scriptableObject;

    public bool _wasDropped;
    public bool _rightplace = false;
    public int _count;

    [Header("Audio")]
     [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _pickUpSound;
    [SerializeField] private AudioClip _dropSound;

    void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _image = GetComponent<Image>();

    
            _audioSource = GetComponent<AudioSource>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _wasDropped = false;
        oldPosition = transform.position;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            _canvas.transform as RectTransform,
            eventData.position,
            eventData.pressEventCamera,
            out var localPoint
        );

        offset = _rectTransform.anchoredPosition - localPoint;

      
        if (_pickUpSound != null)
            _audioSource.PlayOneShot(_pickUpSound);
    }

    public void OnDrag(PointerEventData eventData)
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            _canvas.transform as RectTransform,
            eventData.position,
            eventData.pressEventCamera,
            out var localPoint
        );

        _image.raycastTarget = false;
        _rectTransform.anchoredPosition = localPoint + offset;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _image.raycastTarget = true;

        if (!_wasDropped)
        {
            transform.position = oldPosition;
        }

      
      
            _audioSource.PlayOneShot(_dropSound);
    }

    public void SetDropped()
    {
        _wasDropped = true;
    }
}