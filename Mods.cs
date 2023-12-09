using ShibaGTTemplate.Utilities;
using Photon.Pun;   
using Photon.Realtime;
using System;
using System.Collections.Generic;
using System.Linq;
using Object = UnityEngine.Object;
using ExitGames.Client.Photon;
using UnityEngine;
using System.Text;
using System.Threading.Tasks;
using GorillaNetworking;
using RigStuff;
using GorillaLocomotion.Gameplay;
using GorillaExtensions;
using Steamworks;
using HarmonyLib;
using System.Reflection;
using GorillaTag;
using static UnityEngine.UI.GridLayoutGroup;
using Photon.Pun.UtilityScripts;
using System.IO;
using static MonoMod.Cil.RuntimeILReferenceBag.FastDelegateInvokers;
using Oculus.Interaction.HandGrab;
using UnityEngine.AI;
using UnityEngine.Animations.Rigging;
using GorillaTagScripts;
using UnityEngine.XR.Interaction.Toolkit;
using Photon.Voice.Unity;
using System.ComponentModel;
using UnityEngine.UIElements;
using OVRSimpleJSON;
using GTAG_NotificationLib;
using System.Threading;
using UnityEngine.XR;
using UnityEngine.InputSystem.HID;
using System.Runtime.InteropServices;
using TMPro;
using Random = UnityEngine.Random;
using MainModMenu;

namespace ModsMain
{
    internal class Mods : MonoBehaviour
    {
        public static bool oiwefkwenfjk;

        public static void HeadSpin()
        {
            RigShit.GetOwnVRRig().head.trackingRotationOffset.y += 15f;
        }

        public static void nuhuhheadspin()
        {
            RigShit.GetOwnVRRig().head.trackingRotationOffset.y = 0.0f;

        }

        public static bool inSettings = false;

        public static void Settings()
        {
            ActualMenu.settingsbuttons[0].enabled = false;
            ActualMenu.buttons[0].enabled = false;
            inSettings = !inSettings;
            ActualMenu.DestroyMenu();
            ActualMenu.instance.Draw();
        }

        public static bool invisplat = false;
        public static bool stickyplatforms = false;
        public static GameObject funn;
        public static bool fpcc;

        public static void Platforms()
        {
            PlatformsThing(invisplat, stickyplatforms);
        }

        public static GameObject pointer;
        public static void fpc()
        {
            fpcc = true;
            if (GameObject.Find("Third Person Camera") != null)
            {
                funn = GameObject.Find("Third Person Camera");
                funn.SetActive(false);
            }
            if (GameObject.Find("CameraTablet(Clone)") != null)
            {
                funn = GameObject.Find("CameraTablet(Clone)");
                funn.SetActive(false);
            }
        }

        public static void GhostSettings4()
        {
            Mods.TagFreezeRG();
            Mods.Fly();
            Mods.Invismonke();
        }

        public static void GhostSettings3()
        {
            Mods.TagFreezeRG();
            Mods.Fly();
            Mods.Ghostmonke();
        }

        public static void GhostSettings2()
        {
            Mods.WallWalk();
            Mods.Invismonke();
            Mods.Platforms();
        }

        public static void GhostSettings1()
        {
            Mods.WallWalk();
            Mods.Ghostmonke();
            Mods.Platforms();
        }

        public static void ChangeThemeOff()
        {
            ActualMenu.ChangingColors = false;
        }

        public static void ChangeThemeOn()
        {
            ActualMenu.ChangingColors = true;
        }

        public static void HandsInHead()
        {
            GorillaLocomotion.Player.Instance.rightControllerTransform.position = GorillaLocomotion.Player.Instance.headCollider.transform.position;
            GorillaLocomotion.Player.Instance.leftControllerTransform.position = GorillaLocomotion.Player.Instance.headCollider.transform.position;
        }



        public static void fpcoff()
        {
            fpcc = false;
            if (funn != null)
            {
                funn.SetActive(true);
                funn = null;
            }
        }

        public static void Ghostmonke()
        {
            if (ControllerInputPoller.instance.rightControllerSecondaryButton)
            {
                GorillaTagger.Instance.offlineVRRig.enabled = false;
                GameObject gameObject = GameObject.CreatePrimitive(0);
                GameObject.Destroy(gameObject.GetComponent<Rigidbody>());
                GameObject.Destroy(gameObject.GetComponent<SphereCollider>());
                gameObject.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                gameObject.transform.position = GorillaTagger.Instance.rightHandTransform.position;
                gameObject.GetComponent<Renderer>().material.color = new Color32(0, 0, 0, 1);
                GameObject gameObject2 = GameObject.CreatePrimitive(0);
                GameObject.Destroy(gameObject2.GetComponent<Rigidbody>());
                GameObject.Destroy(gameObject2.GetComponent<SphereCollider>());
                gameObject2.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                gameObject2.transform.position = GorillaTagger.Instance.leftHandTransform.position;
                gameObject2.GetComponent<Renderer>().material.color = new Color32(0, 0, 0, 1);
                GameObject.Destroy(gameObject, Time.deltaTime);
                GameObject.Destroy(gameObject2, Time.deltaTime);
            }
            else
            {
                GorillaTagger.Instance.offlineVRRig.enabled = true;
            }
        }

        public static float BoardSelectCooldown;


        public static void WaterBalloonMinigun()
        {
            bool flag = ControllerInputPoller.instance.rightGrab && Time.time > Mods.BoardSelectCooldown + 0.1f;
            bool flag2 = flag;
            bool flag3 = flag2;
            if (flag3)
            {
                GameObject gameObject = GameObject.Find("Environment Objects/PersistentObjects_Prefab/GlobalObjectPools/WaterBalloonProjectile(Clone)");
                Mods.BoardSelectCooldown = Time.time;
                GameObject gameObject2 = ObjectPools.instance.Instantiate(gameObject);
                int num = PoolUtils.GameObjHashCode(gameObject2);
                SlingshotProjectile component = gameObject2.GetComponent<SlingshotProjectile>();
                int num2 = PoolUtils.GameObjHashCode(GorillaTagger.Instance.offlineVRRig.slingshot.projectileTrail);
                int num3 = GorillaGameManager.instance.IncrementLocalPlayerProjectileCount();
                Vector3 position = GorillaLocomotion.Player.Instance.rightControllerTransform.transform.position;
                Vector3 currentVelocity = GorillaLocomotion.Player.Instance.currentVelocity;
                Vector3 vector = -GorillaLocomotion.Player.Instance.rightControllerTransform.up * Time.deltaTime * 10000f;
                GorillaGameManager.instance.photonView.RPC("LaunchSlingshotProjectile", 0, new object[]
                {
            position,
            vector,
            num,
            num2,
            false,
            num3,
            false,
            1f,
            1f,
            1f,
            1f
                });
                gameObject.SetActive(true);
                component.Launch(position, vector, PhotonNetwork.LocalPlayer, true, false, num3, 1f, false, new Color(0f, 0f, 0f, 0f));
                Mods.AntiRpc();
            }
        }

        public static void AntiRpc()
        {
            GorillaNot.instance.rpcCallLimit = 99999999;
            GorillaNot.instance.rpcErrorMax = 9999999;
            GorillaNot.instance.rpcCallLimit = 9999999;
            PhotonNetwork.RemoveRPCs(PhotonNetwork.LocalPlayer);
            GorillaNot.instance.rpcCallLimit = 99999999;
            GorillaNot.instance.rpcErrorMax = 9999999;
            GorillaNot.instance.rpcCallLimit = 9999999;
            PhotonNetwork.RemoveRPCs(PhotonNetwork.LocalPlayer);
            GorillaNot.instance.rpcCallLimit = 9999;
            PhotonNetwork.RemoveRPCs(PhotonNetwork.LocalPlayer);
            PhotonNetwork.OpRemoveCompleteCache();
            PhotonNetwork.SendAllOutgoingCommands();
            PhotonNetwork.RemoveRPCsInGroup(666);
            PhotonNetwork.RemoveRPCsInGroup(666);
            PhotonNetwork.RemoveRPCs(PhotonNetwork.LocalPlayer);
        }

        public static void WaterBalloonProjectileSpammer()
        {
            bool flag = ControllerInputPoller.instance.rightGrab && Time.time > Mods.BoardSelectCooldown + 0f;
            if (flag)
            {
                GameObject gameObject = GameObject.Find("Environment Objects/PersistentObjects_Prefab/GlobalObjectPools/WaterBalloonProjectile(Clone)");
                Mods.BoardSelectCooldown = Time.time;
                GameObject gameObject2 = ObjectPools.instance.Instantiate(gameObject);
                int num = PoolUtils.GameObjHashCode(gameObject2);
                SlingshotProjectile component = gameObject2.GetComponent<SlingshotProjectile>();
                int num2 = PoolUtils.GameObjHashCode(GorillaTagger.Instance.offlineVRRig.slingshot.projectileTrail);
                int num3 = GorillaGameManager.instance.IncrementLocalPlayerProjectileCount();
                Vector3 position = GorillaLocomotion.Player.Instance.rightControllerTransform.transform.position;
                Vector3 currentVelocity = GorillaLocomotion.Player.Instance.currentVelocity;
                Vector3 vector = Vector3.up + GorillaLocomotion.Player.Instance.rightControllerTransform.transform.forward;
                GorillaGameManager.instance.photonView.RPC("LaunchSlingshotProjectile", 0, new object[]
                {
            position,
            vector,
            num,
            num2,
            false,
            num3,
            false,
            1f,
            1f,
            1f,
            1f
                });
                gameObject.SetActive(true);
                component.Launch(position, vector, PhotonNetwork.LocalPlayer, true, false, num3, 1f, false, new Color(1f, 0f, 1f, 1f));
            }
        }

        public static void Beacons()
        {
            bool flag = PhotonNetwork.CurrentRoom != null;
            if (flag)
            {
                foreach (Photon.Realtime.Player player in PhotonNetwork.PlayerListOthers)
                {
                    PhotonView photonView = GorillaGameManager.instance.FindVRRigForPlayer(player);
                    VRRig vrrig = GorillaGameManager.instance.FindPlayerVRRig(player);
                    bool flag2 = !vrrig.isOfflineVRRig && !vrrig.isMyPlayer && !photonView.IsMine;
                    if (flag2)
                    {
                        GameObject gameObject = GameObject.CreatePrimitive(0);
                        GameObject.Destroy(gameObject.GetComponent<BoxCollider>());
                        GameObject.Destroy(gameObject.GetComponent<Rigidbody>());
                        GameObject.Destroy(gameObject.GetComponent<Collider>());
                        gameObject.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.green);
                        gameObject.transform.rotation = Quaternion.identity;
                        gameObject.transform.localScale = new Vector3(0.04f, 200f, 0.04f);
                        gameObject.transform.position = vrrig.transform.position;
                        gameObject.GetComponent<MeshRenderer>().material = vrrig.mainSkin.material;
                        GameObject.Destroy(gameObject, Time.deltaTime);
                    }
                }
            }
        }

        public static void processTracers()
        {
            Transform rightControllerTransform = GorillaLocomotion.Player.Instance.rightControllerTransform;
            foreach (Photon.Realtime.Player player in PhotonNetwork.PlayerListOthers)
            {
                PhotonView photonView = GorillaGameManager.instance.FindVRRigForPlayer(player);
                VRRig vrrig = GorillaGameManager.instance.FindPlayerVRRig(player);
                bool flag = !vrrig.isOfflineVRRig && !vrrig.isMyPlayer && !photonView.IsMine && !vrrig.mainSkin.name.Contains("fected");
                bool flag2 = flag;
                if (flag2)
                {
                    GameObject gameObject = new GameObject("Line");
                    LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
                    lineRenderer.startColor = Color.magenta;
                    lineRenderer.endColor = Color.black;
                    lineRenderer.startWidth = 0.01f;
                    lineRenderer.endWidth = 0.01f;
                    lineRenderer.positionCount = 2;
                    lineRenderer.useWorldSpace = true;
                    lineRenderer.SetPosition(0, rightControllerTransform.position);
                    lineRenderer.SetPosition(1, vrrig.transform.position);
                    lineRenderer.material.shader = Shader.Find("GUI/Text Shader");
                    GameObject.Destroy(gameObject, Time.deltaTime);
                }
            }
        }

        public static void ProjectileSnowballMinigun()
        {
            bool flag = ControllerInputPoller.instance.rightGrab && Time.time > Mods.BoardSelectCooldown + 0.1f;
            bool flag2 = flag;
            bool flag3 = flag2;
            if (flag3)
            {
                GameObject gameObject = GameObject.Find("Environment Objects/PersistentObjects_Prefab/GlobalObjectPools/SnowballProjectile(Clone)");
                Mods.BoardSelectCooldown = Time.time;
                GameObject gameObject2 = ObjectPools.instance.Instantiate(gameObject);
                int num = PoolUtils.GameObjHashCode(gameObject2);
                SlingshotProjectile component = gameObject2.GetComponent<SlingshotProjectile>();
                int num2 = PoolUtils.GameObjHashCode(GorillaTagger.Instance.offlineVRRig.slingshot.projectileTrail);
                int num3 = GorillaGameManager.instance.IncrementLocalPlayerProjectileCount();
                Vector3 position = GorillaLocomotion.Player.Instance.rightControllerTransform.transform.position;
                Vector3 currentVelocity = GorillaLocomotion.Player.Instance.currentVelocity;
                Vector3 vector = -GorillaLocomotion.Player.Instance.rightControllerTransform.up * Time.deltaTime * 5000f;
                GorillaGameManager.instance.photonView.RPC("LaunchSlingshotProjectile", 0, new object[]
                {
            position,
            vector,
            num,
            num2,
            false,
            num3,
            false,
            1f,
            1f,
            1f,
            1f
                });
                gameObject.SetActive(true);
                component.Launch(position, vector, PhotonNetwork.LocalPlayer, true, false, num3, 1f, false, new Color(0f, 0f, 0f, 0f));
                Mods.AntiRpc();
            }
        }

        public static void SnowBallSpam()
        {
            if (ControllerInputPoller.instance.rightGrab && Time.time > BoardSelectCooldown + 0f)
            {
                GameObject gameObject = GameObject.Find("Environment Objects/PersistentObjects_Prefab/GlobalObjectPools/SnowballProjectile(Clone)");
                BoardSelectCooldown = Time.time;
                GameObject gameObject2 = ObjectPools.instance.Instantiate(gameObject);
                int num = PoolUtils.GameObjHashCode(gameObject2);
                SlingshotProjectile component = gameObject2.GetComponent<SlingshotProjectile>();
                int num2 = PoolUtils.GameObjHashCode(GorillaTagger.Instance.offlineVRRig.slingshot.projectileTrail);
                int num3 = GorillaGameManager.instance.IncrementLocalPlayerProjectileCount();
                Vector3 position = GorillaLocomotion.Player.Instance.rightControllerTransform.transform.position;
                Vector3 currentVelocity = GorillaLocomotion.Player.Instance.currentVelocity;
                Vector3 vector = Vector3.up + GorillaLocomotion.Player.Instance.rightControllerTransform.transform.forward;
                GorillaGameManager.instance.photonView.RPC("LaunchSlingshotProjectile", (RpcTarget)1, new object[]
                {
            position,
            vector,
            num,
            num2,
            true,
            num3,
            true,
            1f,
            1f,
            1f,
            1f
                });
                gameObject.SetActive(true);
                component.Launch(position, vector, PhotonNetwork.LocalPlayer, false, false, num3, 1f, false, new Color(1f, 0.5f, 0.6f, 1f));
            }
        }

        public static void RoundGiftSpam()
        {
            if (ControllerInputPoller.instance.rightGrab && Time.time > BoardSelectCooldown + 0f)
            {
                GameObject gameObject = GameObject.Find("Environment Objects/PersistentObjects_Prefab/GlobalObjectPools/BucketGift_Round_Projectile Variant(Clone)");
                BoardSelectCooldown = Time.time;
                GameObject gameObject2 = ObjectPools.instance.Instantiate(gameObject);
                int num = PoolUtils.GameObjHashCode(gameObject2);
                SlingshotProjectile component = gameObject2.GetComponent<SlingshotProjectile>();
                int num2 = PoolUtils.GameObjHashCode(GorillaTagger.Instance.offlineVRRig.slingshot.projectileTrail);
                int num3 = GorillaGameManager.instance.IncrementLocalPlayerProjectileCount();
                Vector3 position = GorillaLocomotion.Player.Instance.rightControllerTransform.transform.position;
                Vector3 currentVelocity = GorillaLocomotion.Player.Instance.currentVelocity;
                Vector3 vector = Vector3.up + GorillaLocomotion.Player.Instance.rightControllerTransform.transform.forward;
                GorillaGameManager.instance.photonView.RPC("LaunchSlingshotProjectile", (RpcTarget)1, new object[]
                {
            position,
            vector,
            num,
            num2,
            true,
            num3,
            true,
            1f,
            1f,
            1f,
            1f
                });
                gameObject.SetActive(true);
                component.Launch(position, vector, PhotonNetwork.LocalPlayer, false, false, num3, 1f, false, new Color(1f, 0.5f, 0.6f, 1f));
            }
        }

        public static void LongGiftSpam()
        {
            if (ControllerInputPoller.instance.rightGrab && Time.time > BoardSelectCooldown + 0f)
            {
                GameObject gameObject = GameObject.Find("Environment Objects/PersistentObjects_Prefab/GlobalObjectPools/BucketGift_Roll_Projectile Variant(Clone)");
                BoardSelectCooldown = Time.time;
                GameObject gameObject2 = ObjectPools.instance.Instantiate(gameObject);
                int num = PoolUtils.GameObjHashCode(gameObject2);
                SlingshotProjectile component = gameObject2.GetComponent<SlingshotProjectile>();
                int num2 = PoolUtils.GameObjHashCode(GorillaTagger.Instance.offlineVRRig.slingshot.projectileTrail);
                int num3 = GorillaGameManager.instance.IncrementLocalPlayerProjectileCount();
                Vector3 position = GorillaLocomotion.Player.Instance.rightControllerTransform.transform.position;
                Vector3 currentVelocity = GorillaLocomotion.Player.Instance.currentVelocity;
                Vector3 vector = Vector3.up + GorillaLocomotion.Player.Instance.rightControllerTransform.transform.forward;
                GorillaGameManager.instance.photonView.RPC("LaunchSlingshotProjectile", (RpcTarget)1, new object[]
                {
            position,
            vector,
            num,
            num2,
            true,
            num3,
            true,
            1f,
            1f,
            1f,
            1f
                });
                gameObject.SetActive(true);
                component.Launch(position, vector, PhotonNetwork.LocalPlayer, false, false, num3, 1f, false, new Color(1f, 0.5f, 0.6f, 1f));
            }
        }

        public static void SquareGiftSpam()
        {
            if (ControllerInputPoller.instance.rightGrab && Time.time > BoardSelectCooldown + 0f)
            {
                GameObject gameObject = GameObject.Find("Environment Objects/PersistentObjects_Prefab/GlobalObjectPools/BucketGift_Square_Projectile Variant(Clone)");
                BoardSelectCooldown = Time.time;
                GameObject gameObject2 = ObjectPools.instance.Instantiate(gameObject);
                int num = PoolUtils.GameObjHashCode(gameObject2);
                SlingshotProjectile component = gameObject2.GetComponent<SlingshotProjectile>();
                int num2 = PoolUtils.GameObjHashCode(GorillaTagger.Instance.offlineVRRig.slingshot.projectileTrail);
                int num3 = GorillaGameManager.instance.IncrementLocalPlayerProjectileCount();
                Vector3 position = GorillaLocomotion.Player.Instance.rightControllerTransform.transform.position;
                Vector3 currentVelocity = GorillaLocomotion.Player.Instance.currentVelocity;
                Vector3 vector = Vector3.up + GorillaLocomotion.Player.Instance.rightControllerTransform.transform.forward;
                GorillaGameManager.instance.photonView.RPC("LaunchSlingshotProjectile", (RpcTarget)1, new object[]
                {
            position,
            vector,
            num,
            num2,
            true,
            num3,
            true,
            1f,
            1f,
            1f,
            1f
                });
                gameObject.SetActive(true);
                component.Launch(position, vector, PhotonNetwork.LocalPlayer, false, false, num3, 1f, false, new Color(1f, 0.5f, 0.6f, 1f));
            }
        }

        public static void waterself()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                GorillaTagger.Instance.myVRRig.RPC("PlaySplashEffect", 0, new object[]
                {
                    GorillaLocomotion.Player.Instance.bodyCollider.transform.position + new Vector3(0f, -0.1f, 0f),
                    GorillaTagger.Instance.offlineVRRig.transform.rotation,
                    4f,
                    100f,
                    true,
                    false               
                });
                Mods.AntiRpc();
            }
        }



        public static void RGB()
        {
            GradientColorKey[] array11 = new GradientColorKey[7];
            array11[0].color = Color.red;
            array11[0].time = 0f;
            array11[1].color = Color.yellow;
            array11[1].time = 0.2f;
            array11[2].color = Color.green;
            array11[2].time = 0.3f;
            array11[3].color = Color.cyan;
            array11[3].time = 0.5f;
            array11[4].color = Color.blue;
            array11[4].time = 0.6f;
            array11[5].color = Color.magenta;
            array11[5].time = 0.8f;
            array11[6].color = Color.red;
            array11[6].time = 1f;
            Gradient gradient = new Gradient();
            gradient.colorKeys = array11;
            float num8 = Mathf.PingPong(Time.time / 2f, 1f);
            Color color = gradient.Evaluate(num8);
            bool flag125 = GorillaComputer.instance.friendJoinCollider.playerIDsCurrentlyTouching.Contains(PhotonNetwork.LocalPlayer.UserId);
            if (flag125)
            {
                GorillaTagger.Instance.myVRRig.RPC("InitializeNoobMaterial", 0, new object[]
                {
                            color.r,
                            color.g,
                            color.b,
                            true
                });
            }
        }
            


        public static void BetterShitGun()
        {
            bool flag = ControllerInputPoller.instance.rightGrab && Time.time > Mods.BoardSelectCooldown + 0.1f;
            if (flag)
            {
                GameObject gameObject = GameObject.Find("Environment Objects/PersistentObjects_Prefab/GlobalObjectPools/CloudSlingshot_Projectile(Clone)");
                Mods.BoardSelectCooldown = Time.time;
                GameObject gameObject2 = ObjectPools.instance.Instantiate(gameObject);
                int num = PoolUtils.GameObjHashCode(gameObject2);
                SlingshotProjectile component = gameObject2.GetComponent<SlingshotProjectile>();
                int num2 = PoolUtils.GameObjHashCode(GorillaTagger.Instance.offlineVRRig.slingshot.projectileTrail);
                int num3 = GorillaGameManager.instance.IncrementLocalPlayerProjectileCount();
                Vector3 position = GorillaLocomotion.Player.Instance.rightControllerTransform.transform.position;
                Vector3 currentVelocity = GorillaLocomotion.Player.Instance.currentVelocity;
                Vector3 vector = -GorillaLocomotion.Player.Instance.rightControllerTransform.up * Time.deltaTime * 3000f;
                GorillaGameManager.instance.photonView.RPC("LaunchSlingshotProjectile", 0, new object[]
                {
                    position,
                    vector,
                    num,
                    num2,
                    false,
                    num3,
                    false,
                    1f,
                    1f,
                    1f,
                    1f
                });
                gameObject.SetActive(true);
                component.Launch(position, vector, PhotonNetwork.LocalPlayer, false, false, num3, 1f, false, new Color(0f, 8f, 64f, 29f));
            }
        }

        public static void clear()
        {
            NotifiLib.ClearAllNotifications();
        }
        public static void Disconnect()
        {
            PhotonNetwork.Disconnect();
        }

        public static void Fly()
        {
            if (ControllerInputPoller.instance.rightControllerPrimaryButton)
            {
                GorillaLocomotion.Player.Instance.transform.position += GorillaLocomotion.Player.Instance.headCollider.transform.forward * Time.deltaTime * 15f;
                GorillaLocomotion.Player.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
        }

        public static void ShitGunV2()
        {
            bool flag = ControllerInputPoller.instance.rightGrab && Time.time > Mods.BoardSelectCooldown + 0.1f;
            if (flag)
            {
                GameObject gameObject = GameObject.Find("Environment Objects/PersistentObjects_Prefab/GlobalObjectPools/CloudSlingshot_Projectile(Clone)");
                Mods.BoardSelectCooldown = Time.time;
                GameObject gameObject2 = ObjectPools.instance.Instantiate(gameObject);
                int num = PoolUtils.GameObjHashCode(gameObject2);
                SlingshotProjectile component = gameObject2.GetComponent<SlingshotProjectile>();
                int num2 = PoolUtils.GameObjHashCode(GorillaTagger.Instance.offlineVRRig.slingshot.projectileTrail);
                int num3 = GorillaGameManager.instance.IncrementLocalPlayerProjectileCount();
                Vector3 position = GorillaLocomotion.Player.Instance.rightControllerTransform.transform.position;
                Vector3 currentVelocity = GorillaLocomotion.Player.Instance.currentVelocity;
                Vector3 vector = -GorillaLocomotion.Player.Instance.rightControllerTransform.up * Time.deltaTime * 500f;
                GorillaGameManager.instance.photonView.RPC("LaunchSlingshotProjectile", 0, new object[]
                {
                    position,
                    vector,
                    num,
                    num2,
                    false,
                    num3,
                    false,
                    1f,
                    1f,
                    1f,
                    1f
                });
                gameObject.SetActive(true);
                component.Launch(position, vector, PhotonNetwork.LocalPlayer, false, false, num3, 1f, false, new Color(0f, 19f, 30f, 38f));
            }
        }

        public static void gun()
        {
            bool flag = ControllerInputPoller.instance.rightGrab && Time.time > Mods.BoardSelectCooldown + 0.1f;
            if (flag)
            {
                GameObject gameObject = GameObject.Find("Environment Objects/PersistentObjects_Prefab/GlobalObjectPools/SlingshotProjectile(Clone)");
                Mods.BoardSelectCooldown = Time.time;
                GameObject gameObject2 = ObjectPools.instance.Instantiate(gameObject);
                int num = PoolUtils.GameObjHashCode(gameObject2);
                SlingshotProjectile component = gameObject2.GetComponent<SlingshotProjectile>();
                int num2 = PoolUtils.GameObjHashCode(GorillaTagger.Instance.offlineVRRig.slingshot.projectileTrail);
                int num3 = GorillaGameManager.instance.IncrementLocalPlayerProjectileCount();
                Vector3 position = GorillaLocomotion.Player.Instance.rightControllerTransform.transform.position;
                Vector3 currentVelocity = GorillaLocomotion.Player.Instance.currentVelocity;
                Vector3 vector = -GorillaLocomotion.Player.Instance.rightControllerTransform.up * Time.deltaTime * 3000f;
                GorillaGameManager.instance.photonView.RPC("LaunchSlingshotProjectile", 0, new object[]
                {
                    position,
                    vector,
                    num,
                    num2,
                    false,
                    num3,
                    false,
                    1f,
                    1f,
                    1f,
                    1f
                });
                gameObject.SetActive(true);
                component.Launch(position, vector, PhotonNetwork.LocalPlayer, false, false, num3, 1f, false, new Color(0f, 8f, 64f, 29f));
            }
        }

        public static void RGBSnowballs()
        {
            SnowballThrowable component = GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/Holdables/SnowballLeftAnchor/LMACE.").GetComponent<SnowballThrowable>();
            component.randomizeColor = true;
            GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/Holdables/SnowballLeftAnchor/LMACF.").GetComponent<SnowballThrowable>();
            component.randomizeColor = true;
        }

        public static void WallWalk()
        {
            RaycastHit raycastHit;
            Physics.Raycast(GorillaLocomotion.Player.Instance.rightControllerTransform.position, -GorillaLocomotion.Player.Instance.rightControllerTransform.right, out raycastHit, 100f, int.MaxValue);
            RaycastHit raycastHit2;
            Physics.Raycast(GorillaLocomotion.Player.Instance.leftControllerTransform.position, GorillaLocomotion.Player.Instance.leftControllerTransform.right, out raycastHit2, 100f, int.MaxValue);
            if (ControllerInputPoller.instance.rightGrab)
            {
                bool flag37 = raycastHit.distance < raycastHit2.distance;
                if (flag37)
                {
                    bool flag38 = raycastHit.distance < 1f;
                    if (flag38)
                    {
                        Vector3 normalized = (raycastHit.point - GorillaLocomotion.Player.Instance.rightControllerTransform.position).normalized;
                        Physics.gravity = normalized * 9.81f;
                    }
                    else
                    {
                        Physics.gravity = new Vector3(0f, -9.81f, 0f);
                    }
                }
                bool flag39 = raycastHit.distance == raycastHit2.distance;
                if (flag39)
                {
                    Physics.gravity = new Vector3(0f, -9.81f, 0f);
                }
            }
            else
            {
                Physics.gravity = new Vector3(0f, -9.81f, 0f);
            }
            if (ControllerInputPoller.instance.leftGrab)
            {
                bool flag40 = raycastHit.distance > raycastHit2.distance;
                if (flag40)
                {
                    bool flag41 = raycastHit2.distance < 1f;
                    if (flag41)
                    {
                        Vector3 normalized2 = (raycastHit2.point - GorillaLocomotion.Player.Instance.leftControllerTransform.position).normalized;
                        Physics.gravity = normalized2 * 9.81f;
                    }
                    else
                    {
                        Physics.gravity = new Vector3(0f, -9.81f, 0f);
                    }
                }
                bool flag42 = raycastHit.distance == raycastHit2.distance;
                if (flag42)
                {
                    Physics.gravity = new Vector3(0f, -9.81f, 0f);
                }
            }
            else
            {
                Physics.gravity = new Vector3(0f, -9.81f, 0f);
            }
        }

        public static void PEEONMEHEAD()
        {
            if (ControllerInputPoller.instance.rightGrab && (double)Time.time > (double)Mods.projectiletimeout + 0.01)
            {
                Mods.projectiletimeout = Time.time;
                GorillaGameManager.instance.photonView.RPC("LaunchSlingshotProjectile", 0, new object[]
                {
                            GorillaLocomotion.Player.Instance.headCollider.transform.position + new Vector3(0f, -0.1f, 0f),
                            GorillaLocomotion.Player.Instance.headCollider.transform.forward * Time.deltaTime * 500f,
                            -820530352,
                            -1,
                            true,
                            GorillaGameManager.instance.IncrementLocalPlayerProjectileCount(),
                            true,
                            255f,
                            105f,
                            0f,
                            1f
                });
            }
        }

        public static void PEEONME()
        {
            if (ControllerInputPoller.instance.rightGrab && (double)Time.time > (double)Mods.projectiletimeout + 0.01)
            {
                Mods.projectiletimeout = Time.time;
                GorillaGameManager.instance.photonView.RPC("LaunchSlingshotProjectile", 0, new object[]
                {
                            GorillaLocomotion.Player.Instance.bodyCollider.transform.position + new Vector3(0f, -0.1f, 0f),
                            GorillaLocomotion.Player.Instance.bodyCollider.transform.forward * Time.deltaTime * 500f,
                            -820530352,
                            -1,
                            true,
                            GorillaGameManager.instance.IncrementLocalPlayerProjectileCount(),
                            true,
                            255f,
                            105f,
                            0f,
                            1f
                });
            }
        }

        private static bool regbool2 = false;

        private static bool regbool1 = true;

        public static void ProcessNoClip()
        {
            bool noclipbool = false;
            List<InputDevice> list = new List<InputDevice>();
            InputDevices.GetDevicesWithCharacteristics(InputDeviceCharacteristics.HeldInHand | InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.Left, list);
            list[0].TryGetFeatureValue(CommonUsages.triggerButton, out noclipbool);
            if (noclipbool)
            {
                if (!Mods.regbool2)
                {
                    MeshCollider[] array = Resources.FindObjectsOfTypeAll<MeshCollider>();
                    foreach (MeshCollider meshCollider in array)
                    {
                        meshCollider.transform.localScale = meshCollider.transform.localScale / 10000f;
                    }
                    Mods.regbool2 = true;
                    Mods.regbool1 = false;
                }
            }
            else
            {
                if (!Mods.regbool1)
                {
                    MeshCollider[] array3 = Resources.FindObjectsOfTypeAll<MeshCollider>();
                    foreach (MeshCollider meshCollider2 in array3)
                    {
                        meshCollider2.transform.localScale = meshCollider2.transform.localScale * 10000f;
                    }
                    Mods.regbool1 = true;
                    Mods.regbool2 = false;
                }
            }
        }

        public static void cumouthead()
        {
            if (ControllerInputPoller.instance.rightGrab && (double)Time.time > (double)Mods.projectiletimeout + 0.01)
            {
                Mods.projectiletimeout = Time.time;
                GorillaGameManager.instance.photonView.RPC("LaunchSlingshotProjectile", 0, new object[]
                {
                            GorillaLocomotion.Player.Instance.headCollider.transform.position + new Vector3(0f, -0.1f, 0f),
                            GorillaLocomotion.Player.Instance.headCollider.transform.forward * Time.deltaTime * 500f,
                            -820530352,
                            -1,
                            true,
                            GorillaGameManager.instance.IncrementLocalPlayerProjectileCount(),
                            true,
                            45f,
                            25f,
                            22f,
                            1f
                });
            }
        }

        public static void cum()
        {
            if (ControllerInputPoller.instance.rightGrab && (double)Time.time > (double)Mods.projectiletimeout + 0.01)
            {
                Mods.projectiletimeout = Time.time;
                GorillaGameManager.instance.photonView.RPC("LaunchSlingshotProjectile", 0, new object[]
                {
                            GorillaLocomotion.Player.Instance.bodyCollider.transform.position + new Vector3(0f, -0.1f, 0f),
                            GorillaLocomotion.Player.Instance.bodyCollider.transform.forward * Time.deltaTime * 500f,
                            -820530352,
                            -1,
                            true,
                            GorillaGameManager.instance.IncrementLocalPlayerProjectileCount(),
                            true,
                            45f,
                            25f,
                            22f,
                            1f
                });
            }
        }


       

        public static void Invismonke()
        {
            if (ControllerInputPoller.instance.rightControllerSecondaryButton)
            {
                GorillaTagger.Instance.offlineVRRig.headBodyOffset = new Vector3(999f, 999f, 999f);
                GameObject gameObject = GameObject.CreatePrimitive(0);
                GameObject.Destroy(gameObject.GetComponent<Rigidbody>());
                GameObject.Destroy(gameObject.GetComponent<SphereCollider>());
                gameObject.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                gameObject.transform.position = GorillaTagger.Instance.rightHandTransform.position;
                gameObject.GetComponent<Renderer>().material.color = new Color32(0, 0, 0, 1);
                GameObject gameObject2 = GameObject.CreatePrimitive(0);
                GameObject.Destroy(gameObject2.GetComponent<Rigidbody>());
                GameObject.Destroy(gameObject2.GetComponent<SphereCollider>());
                gameObject2.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                gameObject2.transform.position = GorillaTagger.Instance.leftHandTransform.position;
                gameObject2.GetComponent<Renderer>().material.color = new Color32(0, 0, 0, 1);
                GameObject.Destroy(gameObject, Time.deltaTime);
                GameObject.Destroy(gameObject2, Time.deltaTime);
            }
            else
            {
                GorillaTagger.Instance.offlineVRRig.headBodyOffset = Vector3.zero;
            }
        }

        public static void Save()
        {
            ActualMenu.settingsbuttons[1].enabled = false;
            ActualMenu.DestroyMenu();
            ActualMenu.instance.Draw();
            List<String> list = new List<String>();
            foreach (ButtonInfo info in ActualMenu.settingsbuttons)
            {
                if (info.enabled == true)
                {
                    list.Add(info.buttonText);
                }
            }
            System.IO.Directory.CreateDirectory("TemplatePrefs");
            System.IO.File.WriteAllLines("TemplatePrefs\\templateSavedPrefs.txt", list);
        }

        public static void TagFreezeRG()
        {
            if (ControllerInputPoller.instance.rightGrab)
            {
                GorillaLocomotion.Player.Instance.disableMovement = true;
            }
            else
            {
                GorillaLocomotion.Player.Instance.disableMovement = false;
            }
        }

        public static void Load()
        {
            String[] thing = System.IO.File.ReadAllLines("TemplatePrefs\\templateSavedPrefs.txt");
            foreach (String thing2 in thing)
            {
                foreach (ButtonInfo b in ActualMenu.settingsbuttons)
                {
                    if (b.buttonText == thing2)
                    {
                        b.enabled = true;
                    }
                }
            }
        }

        private static void PlatformsThing(bool invis, bool sticky)
        {
            colorKeysPlatformMonke[0].color = Color.red;
            colorKeysPlatformMonke[0].time = 0f;
            colorKeysPlatformMonke[1].color = Color.green;
            colorKeysPlatformMonke[1].time = 0.3f;
            colorKeysPlatformMonke[2].color = Color.blue;
            colorKeysPlatformMonke[2].time = 0.6f;
            colorKeysPlatformMonke[3].color = Color.red;
            colorKeysPlatformMonke[3].time = 1f;
            bool inputr;
            bool inputl;
                inputr = ActualMenu.gripDownR;
                inputl = ActualMenu.gripDownL;
            if (inputr)
            {
                if (!once_right && jump_right_local == null)
                {
                    if (sticky)
                    {
                        jump_right_local = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    }
                    else
                    {
                        jump_right_local = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    }
                    jump_right_local.GetComponent<Renderer>().material.SetColor("_Color", Color.black);
                    if (invis)
                    {
                        UnityEngine.Object.Destroy(jump_right_local.GetComponent<Renderer>());
                    }
                    jump_right_local.transform.localScale = scale;
                    jump_right_local.transform.position = new Vector3(0f, -0.0100f, 0f) + GorillaLocomotion.Player.Instance.rightControllerTransform.position;
                    jump_right_local.transform.rotation = GorillaLocomotion.Player.Instance.rightControllerTransform.rotation;
                    object[] eventContent = new object[2]
                    {
                    new Vector3(0f, -0.0100f, 0f) + GorillaLocomotion.Player.Instance.rightControllerTransform.position,
                    GorillaLocomotion.Player.Instance.rightControllerTransform.rotation
                    };
                    RaiseEventOptions raiseEventOptions = new RaiseEventOptions
                    {
                        Receivers = ReceiverGroup.Others
                    };
                    PhotonNetwork.RaiseEvent(70, eventContent, raiseEventOptions, SendOptions.SendReliable);
                    once_right = true;
                    once_right_false = false;
                    ColorChanger colorChanger = jump_right_local.AddComponent<ColorChanger>();
                    Gradient gradient = new Gradient();
                    gradient.colorKeys = colorKeysPlatformMonke;
                    colorChanger.colors = gradient;
                    colorChanger.Start();
                }
            }
            else if (!once_right_false && jump_right_local != null)
            {
                UnityEngine.Object.Destroy(jump_right_local);
                jump_right_local = null;
                once_right = false;
                once_right_false = true;
                RaiseEventOptions raiseEventOptions2 = new RaiseEventOptions
                {
                    Receivers = ReceiverGroup.Others
                };
                PhotonNetwork.RaiseEvent(72, null, raiseEventOptions2, SendOptions.SendReliable);
            }
            if (inputl)
            {
                if (!once_left && jump_left_local == null)
                {
                    if (sticky)
                    {
                        jump_left_local = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    }
                    else
                    {
                        jump_left_local = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    }
                    jump_left_local.GetComponent<Renderer>().material.SetColor("_Color", Color.black);
                    if (invis)
                    {
                        UnityEngine.Object.Destroy(jump_left_local.GetComponent<Renderer>());
                    }
                    jump_left_local.transform.localScale = scale;
                    jump_left_local.transform.position = new Vector3(0f, -0.0100f, 0f) + GorillaLocomotion.Player.Instance.leftControllerTransform.position;
                    jump_left_local.transform.rotation = GorillaLocomotion.Player.Instance.leftControllerTransform.rotation;
                    object[] eventContent2 = new object[2]
                    {
                    new Vector3(0f, -0.0100f, 0f) + GorillaLocomotion.Player.Instance.leftControllerTransform.position,
                    GorillaLocomotion.Player.Instance.leftControllerTransform.rotation
                    };
                    RaiseEventOptions raiseEventOptions3 = new RaiseEventOptions
                    {
                        Receivers = ReceiverGroup.Others
                    };
                    PhotonNetwork.RaiseEvent(69, eventContent2, raiseEventOptions3, SendOptions.SendReliable);
                    once_left = true;
                    once_left_false = false;
                    ColorChanger colorChanger2 = jump_left_local.AddComponent<ColorChanger>();
                    Gradient gradient2 = new Gradient();
                    gradient2.colorKeys = colorKeysPlatformMonke;
                    colorChanger2.colors = gradient2;
                    colorChanger2.Start();
                }
            }
            else if (!once_left_false && jump_left_local != null)
            {
                UnityEngine.Object.Destroy(jump_left_local);
                jump_left_local = null;
                once_left = false;
                once_left_false = true;
                RaiseEventOptions raiseEventOptions4 = new RaiseEventOptions
                {
                    Receivers = ReceiverGroup.Others
                };
                PhotonNetwork.RaiseEvent(71, null, raiseEventOptions4, SendOptions.SendReliable);
            }
            if (!PhotonNetwork.InRoom)
            {
                for (int i = 0; i < jump_right_network.Length; i++)
                {
                    UnityEngine.Object.Destroy(jump_right_network[i]);
                }
                for (int j = 0; j < jump_left_network.Length; j++)
                {
                    UnityEngine.Object.Destroy(jump_left_network[j]);
                }
            }
        }

        private static Vector3 scale = new Vector3(0.0125f, 0.28f, 0.3825f);

        private static bool once_left;

        private static bool once_right;

        private static bool once_left_false;

        private static bool once_right_false;

        private static bool once_networking;

        private static GameObject[] jump_left_network = new GameObject[9999];

        private static GameObject[] jump_right_network = new GameObject[9999];

        private static GameObject jump_left_local = null;

        public static float projectiletimeout = 0f;

        private static GameObject jump_right_local = null;

        private static GradientColorKey[] colorKeysPlatformMonke = new GradientColorKey[4];

        private static Vector3? checkpointPos;

    }
}
