using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using Photon.Pun;

public class XRGrabNetworkInteractable : XRGrabInteractable
{

    private PhotonView photonView;
    void Start()
    {
        photonView=GetComponent<PhotonView>();
    }

    void Update()
    {
        
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        photonView.RequestOwnership();//오브젝트 잡을 시 해당 오브젝트 소유권 갖음.
        base.OnSelectEntered(args);
    }
}
