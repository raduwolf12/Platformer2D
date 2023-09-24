using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public Sprite HoverImage;
    public string levelName;
    private Sprite defaultImage;

    void Start()
    {
        defaultImage = GetComponent<Image>().sprite;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        this.GetComponent<Image>().sprite = HoverImage;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        this.GetComponent<Image>().sprite = defaultImage;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        SceneManager.LoadScene(levelName);
    }
}
