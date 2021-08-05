using UnityEngine;
using UnityEngine.UI;
 
public class BloodScreen : MonoBehaviour
{
    public float blinkSpeed;//闪烁速度
    private bool isAddAlpha;//是否增加透明度
 
    private Image img;//指向自身图片
 
    private void Start()
    {
        img = GetComponent<Image>();
    }
 
    private void Update()
    {
        if (isAddAlpha)
        {
            img.color += new Color(0, 0, 0, Time.deltaTime * blinkSpeed);
            if (img.color.a >= 1)
            {
                img.color = new Color(img.color.r, img.color.g, img.color.b, 1);
                isAddAlpha = false;
            }
        }
        else
        {
            img.color -= new Color(0, 0, 0, Time.deltaTime * blinkSpeed);
            if (img.color.a <= 0)
            {
                img.color = new Color(img.color.r, img.color.g, img.color.b, 0);
                isAddAlpha = true;
            }
        }
    }
}

