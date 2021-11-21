using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using oddments;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    [SerializeField]
    private CanvasGroup group;
    [SerializeField]
    private GameObject FullScreen;
    [SerializeField]
    private GameObject Spinner;
    [SerializeField]
    private float hideTime = 3f;

    private float deletaTime = 0f;
    private bool hideAni = false;
    public void Show(bool worldTranslate)
    {
        Utility.SetActiveCheck(gameObject, true);
        Utility.SetActiveCheck(FullScreen, worldTranslate);
        Utility.SetActiveCheck(Spinner, !worldTranslate);
        group.alpha = 1f;

       // var colorComponents = GetComponentsInChildren<ImageColorSetting>();
       // foreach (var img in colorComponents) img.UpdateColor();
    }

    public void Hide(bool Immediately = true)
    {
        if (Immediately)
            Utility.SetActiveCheck(gameObject, false);
        else
            hideAni = true;

        deletaTime = 0f;
    }

    private void Update()
    {
        if (hideAni)
        {
            if (deletaTime > 1f)
            {
                if (deletaTime >= hideTime)
                {
                    Utility.SetActiveCheck(gameObject, false);
                    hideAni = false;
                }
                group.alpha = 1f - (deletaTime / hideTime);
            }

            deletaTime += Time.deltaTime;
        }
    }
}
