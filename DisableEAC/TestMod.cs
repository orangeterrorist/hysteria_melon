using System;
using System.Text;
using Il2Cpp;
using Il2CppPhoton.Pun;
using Il2CppRecRoom.Core;
using Il2CppRecRoom.Core.Combat;
using Il2CppRecRoom.Core.Creation;
using Il2CppRecRoom.Players;
using Il2CppSystem;
using MelonLoader;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TestMod
{
	// Token: 0x02000010 RID: 16
	public class TestMod : MelonMod
	{
		// Token: 0x0600001B RID: 27 RVA: 0x000022B1 File Offset: 0x000004B1
		public override void OnApplicationStart()
		{
			MelonLogger.Msg("OnApplicationStart");
		}

		// Token: 0x0600001C RID: 28 RVA: 0x000022C0 File Offset: 0x000004C0
		public override void OnUpdate()
		{
			Player localPlayer = Player.LocalPlayer;
			if (Input.GetMouseButton(0))
			{
				PlayerHand hand = localPlayer.GetHand(0);
				if (hand.HAMDMEEKPEM != null && hand.HAMDMEEKPEM.gameObject.GetComponent<RangedWeapon>() && this.rapidfire)
				{
					hand.HAMDMEEKPEM.gameObject.GetComponent<RangedWeapon>().Fire(1f);
				}
			}
			if (Input.GetMouseButton(1))
			{
				PlayerHand hand2 = localPlayer.GetHand(1);
				if (hand2.HAMDMEEKPEM != null && hand2.HAMDMEEKPEM.gameObject.GetComponent<RangedWeapon>() && this.rapidfire)
				{
					hand2.HAMDMEEKPEM.gameObject.GetComponent<RangedWeapon>().Fire(1f);
				}
			}
			if (this.shouldDrop)
			{
				foreach (PlayerHand playerHand in Object.FindObjectsOfType<PlayerHand>())
				{
					if (playerHand._thisPlayer != localPlayer && playerHand.HAMDMEEKPEM != null)
					{
						playerHand.TryReleaseTool(Vector3.zero, Vector3.zero, 0);
					}
				}
			}
			if (this.shouldFire)
			{
				foreach (RangedWeapon rangedWeapon in Object.FindObjectsOfType<RangedWeapon>())
				{
					for (int j = 0; j < this.numFires; j++)
					{
						rangedWeapon.Fire(1f);
					}
				}
			}
			if (this.shouldhack)
			{
				foreach (Player player in this.allPlayers)
				{
					if (player != localPlayer)
					{
						player.head.transform.position = localPlayer.head.transform.position + localPlayer.head.transform.forward * 3f;
					}
				}
			}
			if (this.LoopTP)
			{
				foreach (Player player2 in this.allPlayers)
				{
					if (player2 != localPlayer)
					{
						PhotonView photonView = player2.photonView;
						this.Teleport(photonView, Player.LocalPlayer.GetHand(1).transform.position + Player.LocalPlayer.GetHand(1).transform.forward * 3f);
					}
				}
			}
			if (this.makerpenheld)
			{
				PlayerBackpack backpack = localPlayer.backpack;
				Tool backpackTool = backpack.GetBackpackTool(1);
				if (backpackTool == null)
				{
					backpack.UseTool(1, true);
					backpackTool = backpack.GetBackpackTool(1);
				}
				PlayerHand hand3 = localPlayer.GetHand(1);
				PlayerHand hand4 = localPlayer.GetHand(0);
				if (this.toggleleft)
				{
					if (hand3.HeldTool != backpackTool)
					{
						hand3.TryPickupTool(backpackTool, true, true);
						return;
					}
				}
				else if (hand4.HeldTool != backpackTool)
				{
					hand4.TryPickupTool(backpackTool, true, true);
				}
			}
		}

		// Token: 0x0600001D RID: 29 RVA: 0x000025AC File Offset: 0x000007AC
		public static string RepeatString(string input, int x)
		{
			return new StringBuilder().Insert(0, input, x).ToString();
		}

		// Token: 0x0600001E RID: 30 RVA: 0x000025C0 File Offset: 0x000007C0
		private void Chat(PhotonView view, string text)
		{
			view.RPC("RpcChatMessage", 0, new Object[]
			{
				text
			});
			view.RPC("RpcSendMajorNotification", 0, new Object[]
			{
				"Discord.gg/ApeShop\nThe Best RecRoom Cheats."
			});
		}

		// Token: 0x0600001F RID: 31 RVA: 0x000025FC File Offset: 0x000007FC
		private void Teleport(PhotonView view, Vector3 pos)
		{
			view.RPC("RpcAuthorityCV2SetPosition", 0, new Object[]
			{
				pos.BoxIl2CppObject()
			});
			view.RPC("RpcAuthorityCV2SetPosition", 0, new Object[]
			{
				string.Concat(new string[]
				{
					pos.x.ToString(),
					" ",
					pos.y.ToString(),
					" ",
					pos.z.ToString()
				})
			});
		}

		// Token: 0x06000020 RID: 32 RVA: 0x00002687 File Offset: 0x00000887
		private void Kill(PhotonView view)
		{
			NFNMGBBEDLH.MLPABKMMEMB(view);
			NFNMGBBEDLH.JEJABENIPLF(view);
			NFNMGBBEDLH.OHGKIJDDBGG(view);
			NFNMGBBEDLH.MLDDCJLKFMP(view);
			NFNMGBBEDLH.AKHGOMMPLNG(view);
			NFNMGBBEDLH.NMCLIGLOBMB(view);
			NFNMGBBEDLH.DJGBPNEOAPC(view);
			NFNMGBBEDLH.FNDNNJNBKLP(view);
		}

		// Token: 0x06000021 RID: 33 RVA: 0x000026BC File Offset: 0x000008BC
		public override void OnGUI()
		{
			if (GUILayout.Button("Respawn", new GUILayoutOption[]
			{
				new GUILayoutOption(13, 13)
			}))
			{
				SceneManager.LoadScene("LogoutSecene");
			}
			if (GUILayout.Button("Text Advertisement", new GUILayoutOption[]
			{
				new GUILayoutOption(13, 13)
			}))
			{
				Player localPlayer = Player.LocalPlayer;
				foreach (Player player in this.allPlayers)
				{
					if (player != localPlayer)
					{
						PhotonView photonView = player.photonView;
						this.Chat(photonView, TestMod.RepeatString("Discord.gg/ApeShop\nThe Best RecRoom Cheats.\n", 75));
					}
				}
				foreach (MultiPlayerEditableTextV2 multiPlayerEditableTextV in Object.FindObjectsOfType<MultiPlayerEditableTextV2>())
				{
					multiPlayerEditableTextV.DDGLHGBHNCE("Discord.gg/ApeShop\nThe Best RecRoom Cheats.");
				}
			}
			if (GUILayout.Button("Kill All", new GUILayoutOption[]
			{
				new GUILayoutOption(13, 13)
			}))
			{
				Player localPlayer2 = Player.LocalPlayer;
				foreach (Player player2 in this.allPlayers)
				{
					if (player2 != localPlayer2)
					{
						PhotonView photonView2 = player2.photonView;
						this.Kill(photonView2);
					}
				}
			}
			if (GUILayout.Button("TP All", new GUILayoutOption[]
			{
				new GUILayoutOption(13, 13)
			}))
			{
				Player localPlayer3 = Player.LocalPlayer;
				foreach (Player player3 in this.allPlayers)
				{
					if (player3 != localPlayer3)
					{
						PhotonView photonView3 = player3.photonView;
						this.Teleport(photonView3, Player.LocalPlayer.GetHand(1).transform.position + Player.LocalPlayer.GetHand(1).transform.forward * 3f);
					}
				}
			}
			this.LoopTP = GUILayout.Toggle(this.LoopTP, "Loop TP All", null);
			this.shouldDrop = GUILayout.Toggle(this.shouldDrop, "Drop Toggle", null);
			if (GUILayout.Button("MakeAllGrabMP", new GUILayoutOption[]
			{
				new GUILayoutOption(13, 13)
			}))
			{
				Player localPlayer4 = Player.LocalPlayer;
				foreach (Player player4 in this.allPlayers)
				{
					if (player4 != localPlayer4)
					{
						PlayerHand hand = player4.GetHand(0);
						PlayerBackpack backpack = localPlayer4.backpack;
						backpack.UseTool(1, true);
						Tool backpackTool = backpack.GetBackpackTool(1);
						hand.TryReleaseTool(Vector3.zero, Vector3.zero, 0);
						hand.TryPickupTool(backpackTool, true, true);
						hand.TryReleaseTool(Vector3.zero, Vector3.zero, 0);
					}
				}
			}
			this.toggleleft = GUILayout.Toggle(this.toggleleft, "MP Hand Toggle", null);
			this.makerpenheld = GUILayout.Toggle(this.makerpenheld, "ForceMakerpenHeld", null);
			if (GUILayout.Button("testdelete", new GUILayoutOption[]
			{
				new GUILayoutOption(13, 13)
			}))
			{
				foreach (CreationObject creationObject in Object.FindObjectsOfType<CreationObject>())
				{
					for (int j = 0; j < 5; j++)
					{
						creationObject.RequestMasterDespawn();
						creationObject.Scale(0f);
					}
				}
			}
			if (GUILayout.Button("HitboxHack", new GUILayoutOption[]
			{
				new GUILayoutOption(13, 13)
			}))
			{
				this.shouldhack = !this.shouldhack;
			}
			if (GUILayout.Button("Rapidfire Toggle", new GUILayoutOption[]
			{
				new GUILayoutOption(13, 13)
			}))
			{
				this.rapidfire = !this.rapidfire;
			}
			GUILayout.Label("Number of Spawns: " + this.numSpawns.ToString(), null);
			this.numSpawns = (int)GUILayout.HorizontalSlider((float)this.numSpawns, 1f, 400f, new GUILayoutOption[]
			{
				GUILayout.Width(200f)
			});
			GUILayout.Label("Spawn Size: " + this.SpawnSize.ToString(), null);
			this.SpawnSize = GUILayout.HorizontalSlider(this.SpawnSize, 0.01f, 40f, new GUILayoutOption[]
			{
				GUILayout.Width(200f)
			});
			if (GUILayout.Button("Reset Size", new GUILayoutOption[]
			{
				new GUILayoutOption(13, 13)
			}))
			{
				this.SpawnSize = 1f;
			}
			if (GUILayout.Button("SpawnPrefab", null))
			{
				for (int k = 0; k < this.numSpawns; k++)
				{
					NFNMGBBEDLH.DBMKBBAHMAH(GUIUtility.systemCopyBuffer, Player.LocalPlayer.head.transform.position, Player.LocalPlayer.head.transform.rotation, this.SpawnSize, 0, null, true);
				}
			}
			GUILayout.Label("Number of Fires: " + this.numFires.ToString(), null);
			this.numFires = (int)GUILayout.HorizontalSlider((float)this.numFires, 1f, 25f, new GUILayoutOption[]
			{
				GUILayout.Width(200f)
			});
			if (GUILayout.Button("Fire", new GUILayoutOption[]
			{
				new GUILayoutOption(13, 13)
			}))
			{
				foreach (RangedWeapon rangedWeapon in Object.FindObjectsOfType<RangedWeapon>())
				{
					for (int l = 0; l < this.numFires; l++)
					{
						rangedWeapon.Fire(1f);
					}
				}
			}
			if (GUILayout.Button("Toggle Fire", new GUILayoutOption[]
			{
				new GUILayoutOption(13, 13)
			}))
			{
				this.shouldFire = !this.shouldFire;
			}
			if (GUILayout.Button("Flashbang", new GUILayoutOption[]
			{
				new GUILayoutOption(13, 13)
			}))
			{
				foreach (PlayerHead playerHead in Object.FindObjectsOfType<PlayerHead>())
				{
					for (int m = 0; m < 25; m++)
					{
						NFNMGBBEDLH.DBMKBBAHMAH("[Quest_VolleyEnemy_Projectile]", playerHead.transform.position, playerHead.transform.rotation, 5f, 0, null, true);
					}
				}
			}
			if (GUILayout.Button("VisFix", new GUILayoutOption[]
			{
				new GUILayoutOption(13, 13)
			}))
			{
				GameObject gameObject = GameObject.Find("GlobalSSFX");
				if (gameObject != null)
				{
					gameObject.SetActive(false);
				}
				foreach (ScreenHUD screenHUD in Resources.FindObjectsOfTypeAll<ScreenHUD>())
				{
					screenHUD.gameObject.SetActive(true);
				}
			}
			if (GUILayout.Button("Update PlayerTab", new GUILayoutOption[]
			{
				new GUILayoutOption(13, 13)
			}))
			{
				this.allPlayers = Object.FindObjectsOfType<Player>();
			}
			if (GUILayout.Button("Toggle PlayerTab", new GUILayoutOption[]
			{
				new GUILayoutOption(13, 13)
			}))
			{
				this.playerTab = !this.playerTab;
			}
			if (this.playerTab)
			{
				Player localPlayer5 = Player.LocalPlayer;
				this.scrollPosition = GUILayout.BeginScrollView(this.scrollPosition, null);
				foreach (Player player5 in this.allPlayers)
				{
					if (player5 != localPlayer5)
					{
						GUILayout.Label("DisplayName: " + player5.PlayerName + " Userid:" + player5._playerId.hiddenValue.ToString(), null);
						if (GUILayout.Button("Ban", null))
						{
							PlayerHand hand2 = player5.GetHand(0);
							PlayerBackpack backpack2 = localPlayer5.backpack;
							backpack2.UseTool(1, true);
							Tool backpackTool2 = backpack2.GetBackpackTool(1);
							hand2.TryReleaseTool(Vector3.zero, Vector3.zero, 0);
							hand2.TryPickupTool(backpackTool2, true, true);
							hand2.TryReleaseTool(Vector3.zero, Vector3.zero, 0);
						}
						if (GUILayout.Button("Drop", null))
						{
							player5.GetHand(0).TryReleaseTool(Vector3.zero, Vector3.zero, 0);
							player5.GetHand(1).TryReleaseTool(Vector3.zero, Vector3.zero, 0);
						}
						if (GUILayout.Button("Frame", null))
						{
							PlayerHand hand3 = player5.GetHand(1);
							Tool component = NFNMGBBEDLH.DBMKBBAHMAH("[CharadesPen]", hand3.transform.position, hand3.transform.rotation, 1f, 0, null, true).GetComponent<Tool>();
							hand3.TryReleaseTool(Vector3.zero, Vector3.zero, 0);
							hand3.TryPickupTool(component, true, true);
							PhotonView photonView4 = player5.photonView;
							this.Chat(photonView4, "discord.gg/ApeShop for my cheat");
						}
						if (GUILayout.Button("Frame (Real Makerpen)", null))
						{
							PlayerHand hand4 = player5.GetHand(1);
							Tool component2 = NFNMGBBEDLH.DBMKBBAHMAH("[MakerPen]", hand4.transform.position, hand4.transform.rotation, 1f, 0, null, true).GetComponent<Tool>();
							hand4.TryReleaseTool(Vector3.zero, Vector3.zero, 0);
							hand4.TryPickupTool(component2, true, true);
							PhotonView photonView5 = player5.photonView;
							this.Chat(photonView5, "discord.gg/ApeShop for my cheat");
						}
						if (GUILayout.Button("Kill", null))
						{
							PhotonView photonView6 = player5.photonView;
							this.Kill(photonView6);
						}
					}
				}
				GUILayout.EndScrollView();
			}
		}

		// Token: 0x04000007 RID: 7
		private bool shouldFire;

		// Token: 0x04000008 RID: 8
		private int numFires = 1;

		// Token: 0x04000009 RID: 9
		private int numSpawns = 1;

		// Token: 0x0400000A RID: 10
		private float SpawnSize = 1f;

		// Token: 0x0400000B RID: 11
		private bool shouldDrop;

		// Token: 0x0400000C RID: 12
		private bool rapidfire;

		// Token: 0x0400000D RID: 13
		private string SpawnPrefab = "";

		// Token: 0x0400000E RID: 14
		private bool shouldhack;

		// Token: 0x0400000F RID: 15
		private bool playerTab;

		// Token: 0x04000010 RID: 16
		private Vector2 scrollPosition;

		// Token: 0x04000011 RID: 17
		private bool LoopTP;

		// Token: 0x04000012 RID: 18
		private Player[] allPlayers;

		// Token: 0x04000013 RID: 19
		private bool toggleleft;

		// Token: 0x04000014 RID: 20
		private bool makerpenheld;
	}
}
