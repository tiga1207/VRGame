using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Photon.Pun;
using UnityEngine.XR.Interaction.Toolkit;
using Unity.XR.CoreUtils;

public class NetworkPlayer : MonoBehaviour
{ 
    public Transform head;
    public Transform leftHand;
    public Transform rightHand;
    public Transform body;

    public Animator leftHandAnimator;
    public Animator rightHandAnimator;
    private PhotonView photonView;    

    private Transform headRig;
    private Transform leftHandRig;
    private Transform rightHandRig;
    private Transform bodyRig;
    void Start()
    {
        photonView= GetComponent<PhotonView>();
        XROrigin xROrigin= FindObjectOfType<XROrigin>();
        headRig=xROrigin.transform.Find("Camera Offset/Main Camera");
        leftHandRig=xROrigin.transform.Find("Camera Offset/Left Controller");
        rightHandRig=xROrigin.transform.Find("Camera Offset/Right Controller");
        bodyRig=xROrigin.transform.Find("Camera Offset/Body");

        // if(photonView.IsMine)
        // {
        //     foreach(var item in GetComponentsInChildren<Renderer>())
        //     {
        //         item.enabled=true;
        //     }

        // }
    }

    void Update()
    {
        if(photonView.IsMine)
        {
            MapPosition(head,headRig);
            MapPosition(leftHand,leftHandRig);
            MapPosition(rightHand,rightHandRig);
            MapPosition(body,bodyRig);

            // Body를 카메라 아래에 위치시키되, 일정한 거리만큼 아래에 고정
            // body.position = headRig.position + new Vector3(0, -1.5f, 0);  // -1.5f는 카메라 아래 일정 거리, 필요에 따라 조정

            float headHeight = CalculateHeadHeight();
            body.position = headRig.position - new Vector3(0, headHeight / 2 + 0.5f, 0);  // 머리 아래에 0.5 단위로 몸을 위치시킴, 필요에 따라 조정

            // Body가 카메라의 회전을 따라가지만, X축 회전(고개 숙이기/들기)은 무시하도록 설정
            Quaternion bodyRotation = Quaternion.Euler(0, headRig.rotation.eulerAngles.y, 0);
            body.rotation = bodyRotation;

            UpdateHandAnimation(InputDevices.GetDeviceAtXRNode(XRNode.LeftHand),leftHandAnimator);
            UpdateHandAnimation(InputDevices.GetDeviceAtXRNode(XRNode.RightHand),rightHandAnimator);
        }

        
    }

    void UpdateHandAnimation(InputDevice targetDevice, Animator handAnimator)
    {
        if(targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
        {
            handAnimator.SetFloat("Trigger", triggerValue);
        }
        else
        {
            handAnimator.SetFloat("Trigger", 0);
        }

        if (targetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
        {
            handAnimator.SetFloat("Grip", gripValue);
        }
        else
        {
            handAnimator.SetFloat("Grip", 0);
        }
    }

    void MapPosition(Transform target, Transform rigTransform)
    {
        target.position = rigTransform.position;
        target.rotation = rigTransform.rotation;
    }    
    float CalculateHeadHeight()
{
    Renderer headRenderer = headRig.GetComponent<Renderer>();
    if (headRenderer != null)
    {
        return headRenderer.bounds.size.y;  // 머리의 Y축 크기(높이)를 반환
    }

    Collider headCollider = headRig.GetComponent<Collider>();
    if (headCollider != null)
    {
        return headCollider.bounds.size.y;  // 머리의 Y축 크기(높이)를 반환
    }

    // 머리 크기를 알 수 없는 경우 기본값 반환
    return 0.3f;  // 기본 머리 높이 (상황에 맞게 수정)
}
}



// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// usiusing Unity.Netcode;
// using Oculus.Interaction.Input;

// public class NetworkPlayer : NetworkBehaviour
// {
// 	//First define some global variables in order to speed up the Update() function
// 	GameObject myXRRig;
// 	OVRCameraRigRef RigRef;                 //Script with transform parameteres for camera and controllers.
// 	Transform myXRLC, myXRRC, myXRCam;                  //positions and rotations of controllers and camera
// 	Transform avHead, avLeft, avRight, avBody;          //avatars moving parts 

// 	//some fine tuning parameters if needed
// 	[SerializeField]
// 	private Vector3 avatarLeftPositionOffset, avatarRightPositionOffset;
// 	[SerializeField]
// 	private Quaternion avatarLeftRotationOffset, avatarRightRotationOffset;
// 	[SerializeField]
// 	private Vector3 avatarHeadPositionOffset;
// 	[SerializeField]
// 	private Quaternion avatarHeadRotationOffset;
// 	[SerializeField]
// 	private Vector3 avatarBodyPositionOffset;

// 	// Start is called before the first frame update
// 	public override void OnNetworkSpawn()
// 	{
// 		var myID = transform.GetComponent<NetworkObject>().NetworkObjectId;
// 		if (IsOwnedByServer)
// 			transform.name = "Host:" + myID;    //this must be the host
// 		else
// 			transform.name = "Client:" + myID; //this must be the client 

// 		if (!IsOwner) return;

// 		myXRRig = GameObject.Find("OVRInteraction");
// 		if (myXRRig) Debug.Log("Found OVRCameraRig");
// 		else Debug.Log("Could not find OVRCameraRig!");

// 		//pointers to the XR RIg
// 		RigRef = myXRRig.GetComponent<OVRCameraRigRef>();
// 		myXRLC = RigRef.LeftController;
// 		myXRRC = RigRef.RightController;
// 		myXRCam = RigRef.CameraRig.centerEyeAnchor.transform;

// 		//pointers to the avatar
// 		avLeft = transform.Find("Left Hand");
// 		avRight = transform.Find("Right Hand");
// 		avHead = transform.Find("Head");
// 		avBody = transform.Find("Body");
// 	}

// 	void Update()
// 	{
// 		if (!IsOwner) return;
// 		if (!myXRRig) return;

// 		if (avLeft)
// 		{
// 			avLeft.rotation = myXRLC.rotation * avatarLeftRotationOffset;
// 			avLeft.position = myXRLC.position + avatarLeftPositionOffset.x * myXRLC.transform.right + avatarLeftPositionOffset.y * myXRLC.transform.up + avatarLeftPositionOffset.z * myXRLC.transform.forward;
// 		}

// 		if (avRight)
// 		{
// 			avRight.rotation = myXRRC.rotation * avatarRightRotationOffset;
// 			avRight.position = myXRRC.position + avatarRightPositionOffset.x * myXRRC.transform.right + avatarRightPositionOffset.y * myXRRC.transform.up + avatarRightPositionOffset.z * myXRRC.transform.forward;
// 		}

// 		if (avHead)
// 		{
// 			avHead.rotation = myXRCam.rotation/* * avatarHeadRotationOffset*/;
// 			avHead.position = myXRCam.position + avatarHeadPositionOffset.x * myXRCam.transform.right + avatarHeadPositionOffset.y * myXRCam.transform.up + avatarHeadPositionOffset.z * myXRCam.transform.forward;
// 		}

// 		if (avBody)
// 		{
// 			avBody.position = avHead.position + avatarBodyPositionOffset;
// 		}
// 	}