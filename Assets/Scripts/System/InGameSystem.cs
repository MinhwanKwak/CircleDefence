using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using oddments;
public class InGameSystem : MonoBehaviour
{
    public void InGameLoad()
    {
        var stageidx = GameRoot.Instance.UserDataSystem.userdata.CurStageIdx;

        var td = Tables.Instance.GetTable<Stage>().GetData(stageidx);

        if (td != null)
        {
            Addressables.InstantiateAsync(td.Stage_BG).Completed += (handle) =>
            {
                var ingamestage = handle.Result.GetComponent<InGameStage>();
                if (ingamestage != null)
                {
                    ingamestage.transform.SetParent(GameRoot.Instance.WorldCanvasTr);
                    ingamestage.transform.position = Vector3.zero;
                }
            };
        }
    }
}
