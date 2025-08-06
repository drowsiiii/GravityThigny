using BepInEx;
using UnityEngine;
using Utilla;
using Utilla.Attributes;
using System;
using Photon.Pun;
namespace FixedGTagMod1
{
    [BepInPlugin("com.drowsii.GravityMesserarounder", "SomethingToDoWithGravity", "1.2.12234443")]
    [BepInDependency("org.legoandmars.gorillatag.utilla")]
    [ModdedGamemode] // Enable callbacks in default modded gamemodes
    public class Plugin : BaseUnityPlugin
    {
        private bool inAllowedRoom = false;
        private bool buttonrandom;
        private bool buttonnograv;
        private bool buttonreset;
        private bool buttony;
        private bool buttonx;
        private bool buttonz;
        private bool buttonconstantrandom;
        private bool minusbuttonx;
        private bool minusbuttonz;
        private bool buttonreset2;
        private bool Lowgrav;

        private bool HighGrav;
        private bool Disconnecter = true; // Safety Disconnect Spam

        void OnGUI()
        {
            // GUI SPACINGS: Text always 50 away from a button or another GUI element, and a away from the side of the screen.    The buttons are 20 away from eachother.


            int x = 230;
            int y = 600;

            GUI.color = Color.magenta;
            GUI.Label(new Rect(x, y, 600, 600), "@drowsiiis gravity stinky thing - made with confusion for no reason <3");

            y += 50; // space below label
            GUI.color = Color.yellow;
            GUI.Label(new Rect(x, y, 600, 600), "no clue if you will get banned with this, so... your at fault if you get struck by the ban hammer, You can use this mod in disconnected rooms (not in room) ");

            y += 65;
            GUI.Label(new Rect(x, y, 600, 600), "i am not responsible for any bans or anything that happens to you, so dont blame me if you get banned ive added a always disconnect button for you so you can use the mod safely");

            y += 80;
            GUI.color = Color.cyan;
            this.Disconnecter = GUI.Toggle(new Rect(x, y, 200, 20), Disconnecter, "Safety Disconnect Spam ");

            y += 50;
            GUI.color = Color.white;
            GUI.Label(new Rect(x, y, 600, 600), "Gravity Things:");

            y += 50;
            GUI.color = Color.cyan;
            this.buttonrandom = GUI.Button(new Rect(x, y, 200, 20), "Randomise Gravity (i love this)");

            y += 30;
            GUI.color = Color.grey;
            this.buttonnograv = GUI.Button(new Rect(x, y, 200, 20), "No Gravity");

            y += 30;
            GUI.color = Color.white;
            this.buttonreset = GUI.Button(new Rect(x, y, 200, 20), "Reset/Normal Gravity");

            y += 50;
            GUI.color = Color.white;
            GUI.Label(new Rect(x, y, 600, 600), "Axis Gravity Things:");

            y += 50;
            GUI.color = Color.green;
            this.buttony = GUI.Button(new Rect(x, y, 200, 20), "Y axis Grav (Upwards Gravity)");
            y += 30;
            GUI.color = Color.cyan;
            this.buttonx = GUI.Button(new Rect(x, y, 200, 20), "X axis Grav");
            y += 30;
            GUI.color = Color.red;
            this.buttonz = GUI.Button(new Rect(x, y, 200, 20), "Z axis Grav");


            y += 50;
            GUI.color = Color.green;
            this.buttonreset2 = GUI.Button(new Rect(x, y, 200, 20), "-Y axis Grav (Downwards Gravity)");
            y += 30;
            GUI.color = Color.cyan;
            this.minusbuttonx = GUI.Button(new Rect(x, y, 200, 20), "-X axis Grav");
            y += 30;
            GUI.color = Color.red;
            this.minusbuttonz = GUI.Button(new Rect(x, y, 200, 20), "-Z axis Grav");


            y += 50;
            GUI.color = Color.white;
            GUI.Label(new Rect(x, y, 600, 600), "Stupid Gravity Things:");

            y += 50;
            GUI.color = Color.cyan;
            this.buttonconstantrandom = GUI.Toggle(new Rect(x, y, 200, 20), buttonconstantrandom, "(Really Funny) Random Spaz Gravity");
            y += 30;
            GUI.color = Color.yellow;
            this.Lowgrav = GUI.Button(new Rect(x, y, 200, 20), "Low Gravity");
            y += 30;
            GUI.color = Color.yellow;
            this.HighGrav = GUI.Button(new Rect(x, y, 200, 20), "High Gravity");


        }

        void RandomGravity()
        {
            System.Random random = new System.Random();
            float Val1 = random.Next(-100, 100);
            float Val2 = random.Next(-100, 100);
            float Val3 = random.Next(-100, 100);
            Physics.gravity = new Vector3(Val1, Val2, Val3);
        }

        void NoGravity()
        {
            Physics.gravity = new Vector3(0, 0, 0);
        }

        void ResetGravity()
        {
            Physics.gravity = new Vector3(0, -9.81f, 0);
        }

        void LowGravity()
        {
            Physics.gravity = new Vector3(0, -2.54f, 0);
        }
        void HighGravity()
        {
            Physics.gravity = new Vector3(0, -18.26f, 0);
        }

        void YAxisGravity()
        {
            Physics.gravity = new Vector3(0, 9.81f, 0);
        }

        void XAxisGravity()
        {
            Physics.gravity = new Vector3(9.81f, 0, 0);
        }

        void ZAxisGravity()
        {
            Physics.gravity = new Vector3(0, 0, 9.81f);
        }

        void MinusXAxisGravity()
        {
            Physics.gravity = new Vector3(-9.81f, 0, 0);
        }

        void MinusZAxisGravity()
        {
            Physics.gravity = new Vector3(0, 0, -9.81f);
        }
        void disconnecter()
        {
            if (Disconnecter && PhotonNetwork.IsConnected)
            {
                PhotonNetwork.Disconnect();
            }
        }

        private void Update()
        {

            disconnecter();
            if (inAllowedRoom || !PhotonNetwork.IsConnected)
            {
                if (HighGrav)
                {
                    HighGravity();
                    HighGrav = false;
                }
                if (Lowgrav)
                {
                    LowGravity();
                    Lowgrav = false;
                }
                if (buttonrandom)
                {
                    RandomGravity();
                    buttonrandom = false;
                }
                if (buttonnograv)
                {
                    NoGravity();
                    buttonnograv = false;
                }
                if (buttonreset)
                {
                    ResetGravity();
                    buttonreset = false;
                }
                if (buttonreset2)
                {
                    ResetGravity();
                    buttonreset2 = false;
                }
                if (buttony)
                {
                    YAxisGravity();
                    buttony = false;
                }
                if (buttonx)
                {
                    XAxisGravity();
                    buttonx = false;
                }
                if (buttonz)
                {
                    ZAxisGravity();
                    buttonz = false;
                }
                if (buttonconstantrandom)
                {
                    RandomGravity();
                }
                if (minusbuttonx)
                {
                    MinusXAxisGravity();
                    minusbuttonx = false;
                }
                if (minusbuttonz)
                {
                    MinusZAxisGravity();
                    minusbuttonz = false;
                }

            }
            else
            {
                Physics.gravity = new Vector3(0, -9.81f, 0); 
            }
        }

        [ModdedGamemodeJoin]
        private void RoomJoined(string gamemode)
        {
            inAllowedRoom = true;
        }

        [ModdedGamemodeLeave]
        private void RoomLeft(string gamemode)
        {
            inAllowedRoom = false;
        }
    }
}

