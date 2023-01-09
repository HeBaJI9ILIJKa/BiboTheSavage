using UnityEngine;

public class Notice : MonoBehaviour
{
    [SerializeField] private float shift;

    private Vector3 position, targetPotision;
    public float smoothTime = 1F;
    private Vector3 velocity = Vector3.zero;

    private void DestroyNotice()
    {
        Destroy(this.gameObject);
    }

    private void Start()
    {
        position = GetComponent<RectTransform>().anchoredPosition;
        targetPotision = position;
        targetPotision.y += shift;
    }

    private void Update()
    {
        AscentAnimation();
    }

    private void AscentAnimation()
    {
        GetComponent<RectTransform>().anchoredPosition = Vector3.SmoothDamp(GetComponent<RectTransform>().anchoredPosition, targetPotision, ref velocity, smoothTime);
    }
}
