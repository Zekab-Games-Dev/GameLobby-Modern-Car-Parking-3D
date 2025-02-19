using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetRewardType : MonoBehaviour
{
    public RewardAdType selectedRewardType;

    public void OnSetRewardType()
    {
        AdsManager.Instance.currentRewardAdType = selectedRewardType;
    }
}
