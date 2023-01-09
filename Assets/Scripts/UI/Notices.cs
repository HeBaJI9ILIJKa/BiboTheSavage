using UnityEngine;
using UnityEngine.UI;

public class Notices : MonoBehaviour
{
    [SerializeField] private GameObject noticePrefab, player, playScreen;

    [SerializeField] private Sprite boneSprite, heartSprite;

    [SerializeField] private float positionY;

    private GameObject notice;

    private static Notices instance;

    public static Notices GetInstance()
    {
        return instance;
    }

    private void Awake()
    {
        instance = this;
    }

    public void ShowNoticeBone(int value, float positionX = 0)
    {
        ShowNotice(value, boneSprite, positionX);
    }
    public void ShowNoticeHeart(int value, float positionX = 0)
    {
        ShowNotice(value, heartSprite, positionX);
    }

    public void ShowNotice(int value, Sprite noticeSpritePrefab, float shiftX = 0)
    {
        notice = Instantiate(noticePrefab, playScreen.transform) as GameObject;

        PlaceNotice(shiftX);

        string strvalue = value.ToString();

        if (value > 0)
            strvalue = "+" + value.ToString();

        notice.GetComponentInChildren<Text>().text = strvalue;
        notice.GetComponentInChildren<Image>().sprite = noticeSpritePrefab;
    }

    private void PlaceNotice(float shiftX)
    {
        Vector3 _position;
        float screenWidth = playScreen.GetComponent<RectTransform>().rect.width;
        float cameraSize = Camera.main.orthographicSize;

        _position.x = player.transform.position.x + cameraSize / 2;
        _position.x = _position.x * screenWidth / cameraSize;
        _position.x += shiftX;
        _position.y = positionY;
        _position.z = 0;

        notice.GetComponent<RectTransform>().anchoredPosition = _position;
    }




}
