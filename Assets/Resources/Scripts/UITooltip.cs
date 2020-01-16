using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class UITooltip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public GameObject tooltipPF;
    public string tooltipText;
    GameObject tooltip;
    GameObject parent;
    float width;
    float height;

    void Start()
    {
        parent = GameObject.Find("Tooltips");
    }

    IEnumerator DrawTooltip(PointerEventData eventData)
    {
        //print(eventData.pointerEnter.name);
        tooltip = Instantiate(tooltipPF, new Vector3(eventData.position.x + tooltipPF.GetComponent<RectTransform>().rect.width / 2 + 3, eventData.position.y + tooltipPF.GetComponent<RectTransform>().rect.height / 2 + 3), Quaternion.identity, parent.transform);
        TMP_Text tooltipObj = tooltip.GetComponentInChildren<TMP_Text>();
        //print(eventData.pointerEnter.name);
        tooltipObj.text = tooltipText;
        tooltip.name = "tooltip";
        tooltipObj.faceColor = new Color(0, 0, 0, 0);
        Image tooltipBG = tooltip.GetComponent<Image>();
        tooltipBG.color = new Color(1, 1, 1, 0);
        width = tooltipPF.GetComponent<RectTransform>().rect.width;
        height = tooltipPF.GetComponent<RectTransform>().rect.width;
        yield return new WaitForSeconds(0.3f);

        for (float i = 0; i < 0.75; i += 0.08f)
        {
            try
            {
                tooltipBG.color = new Color(1, 1, 1, i);
                tooltipObj.faceColor = new Color(0, 0, 0, i * 2);

            }
            catch (MissingReferenceException) { }
            yield return new WaitForSeconds(0.001f);
        }

        //tooltip.GetComponent<Renderer>().i
        //StartCoroutine(drawTooltip(eventData));
        //Debug.Log(tooltipPF.GetComponent<RectTransform>().rect.width);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        StartCoroutine(DrawTooltip(eventData));
        StartCoroutine(UpdatePos(tooltip));

        //print("entered");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Destroy(tooltip);
    }

    IEnumerator UpdatePos(GameObject tooltip)
    {
        while (tooltip != null)
        {
            if (Input.mousePosition.x + tooltip.transform.GetComponent<RectTransform>().rect.width >= Screen.width)
            {
                tooltip.transform.SetPositionAndRotation(new Vector3(Screen.width - tooltip.transform.GetComponent<RectTransform>().rect.width, Input.mousePosition.y + height / 2 + 3), Quaternion.identity);
            }
            else
            {
                tooltip.transform.SetPositionAndRotation(new Vector3(Input.mousePosition.x + tooltip.transform.GetComponent<RectTransform>().rect.width / 2, Input.mousePosition.y + tooltip.transform.GetComponent<RectTransform>().rect.height / 2), Quaternion.identity);

            }
            yield return new WaitForFixedUpdate();
        }
    }

    public void OnDisable()
    {
        Destroy(tooltip);
    }
}

