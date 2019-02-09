﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MultiBoard.Keyboard;

namespace MultiBoard
{
    public partial class KeyBoard : UserControl
    {
        private string ID;
        private string name;
        private string comPort;

        private string saveFile;

        private int numberOfKeys = 0;

        private List<Key> keyList = new List<Key>();
        private List<string> KeyNameList = new List<string>();
        private List<KeyListPanel> keyPanelList = new List<KeyListPanel>();

        private Point nextKeyListPoint = new Point(3, 3);

        public Key createKey(string namekey, int eventState, string keytag, bool keyEnebled, string exeLoc)
        {
            KEYLIST_PANEL.BackgroundImage = null;

            Key obj = new Key();
            obj.Location = new Point(194, 0);

            obj.UpdatedData += onUpdatedKey;
            obj.DeleteKey += onDeleteKey;

            obj.settings(namekey, eventState, keytag, keyEnebled, exeLoc);
            numberOfKeys++;

            keyList.Add(obj);
            this.Controls.Add(obj);

            return obj;
        }

        private bool checkName(string s)
        {
            foreach(string n in KeyNameList)
            {
                if(n == s)
                {
                    return false;
                }
            }
            return true;
        }

        public KeyBoard()
        {
            InitializeComponent();
        }

        private void addNewKeyClicked(object sender, EventArgs e)
        {
            //add key clicked
            foreach(Key akey in keyList)
            {
                akey.Visible = false;
            }

            string kname;
            kname = "KEY " + (numberOfKeys);

            while (!checkName(kname))
            {
                numberOfKeys++;
                kname = "KEY " + (numberOfKeys);
            }

            Key k = createKey(kname, 1, "NONE", true, "");
            k.Visible = false;

            addKeyToListVieuw(k);

            k.Visible = true;
            updateKeyNameList();
        }

        public void setKeyBoardName(string NAME)
        {
            name = NAME;
            NAME_LABEL.Text = name;
        }

        public string getKeyboardName()
        {
            return name;
        }

        public void setKeyboardUUID(string UUID)
        {
            ID = UUID;
        }

        public string getKeyboardUUID()
        {
            return ID;
        }

        public void setComPort(string port)
        {
            comPort = port;
        }

        public string getComPort()
        {
            return comPort;
        }

        public void loadKeys(string mainDirecory)
        {
            if(!File.Exists(mainDirecory + @"\" + name + ".inf"))
            {
                File.Create(mainDirecory + @"\" + name + ".inf").Close();
            }

            saveFile = mainDirecory + @"\" + name + ".inf";

            //read keys
            //============================
            string line;
            int counter = 0;

            System.IO.StreamReader file =
                new System.IO.StreamReader(mainDirecory + @"\" + name + ".inf");
            while ((line = file.ReadLine()) != null)
            {
                if (line != "")
                {
                    string[] splits = line.Split('|');

                    Key k = createKey(splits[0], Int32.Parse(splits[1]), splits[2], Convert.ToBoolean(splits[3]), splits[4]);

                    if(counter == 0)
                    {
                        k.Visible = true;
                    }
                    else
                    {
                        k.Visible = false;
                    }

                    counter++;
                }
            }

            file.Close();
            loadListVieuw();
            updateKeyNameList();
        }

        public void keyDown(string KEY,string keyboardUUID, bool allEnebled)
        {
            if (keyboardUUID == ID)
            {
                foreach (Key aKey in keyList)
                {
                    aKey.keyDown(KEY, allEnebled);
                }
            }
        }

        public void keyUp(string KEY, string keyboardUUID , bool allEnebled)
        {
            if (keyboardUUID == ID)
            {
                foreach (Key aKey in keyList)
                {
                    aKey.keyUp(KEY, allEnebled);
                }
            }
        }

        public void loadListVieuw()
        {

            clearKeyList();

            nextKeyListPoint.X = 5;
            nextKeyListPoint.Y = 3;

            for(int i = 0; i < keyList.Count; i++)
            {
                Key aKey = keyList[i];
                ref Key refKey = ref aKey;

                KeyListPanel item = new KeyListPanel(aKey.getName(), aKey.getEnebled(), ref refKey);

                item.Location = nextKeyListPoint;
                nextKeyListPoint.Y = nextKeyListPoint.Y + item.Height + 5;
                item.ClickedKey += userSelectedKey;

                KEYLIST_PANEL.Controls.Add(item);
                item.BringToFront();

                keyPanelList.Add(item);
            }

        }

        public void addKeyToListVieuw(Key k)
        {
            Key aKey = k;
            ref Key refKey = ref aKey;

            KeyListPanel item = new KeyListPanel(aKey.getName(), aKey.getEnebled(), ref refKey);

            //item.Location = nextKeyListPoint;
            item.Location = new Point(5, keyPanelList[keyPanelList.Count - 1].Location.Y + item.Height + 5);
            nextKeyListPoint.Y = nextKeyListPoint.Y + item.Height + 5;
            item.ClickedKey += userSelectedKey;

            KEYLIST_PANEL.Controls.Add(item);
            item.BringToFront();

            keyPanelList.Add(item);
            updateKeyNameList();
        }

        public void updateListView()
        {
            foreach(KeyListPanel klp in keyPanelList)
            {
                Key k = klp.connectedkey;
                klp.kname = k.getName();
                klp.setState(k.getEnebled());
            }

            updateKeyNameList();
        }

        private void userSelectedKey(object sender, EventArgs e)
        {
            KeyListPanel k = sender as KeyListPanel;

            foreach(Key aKey in keyList)
            {
                if(aKey == k.connected_key)
                {
                    aKey.Visible = true;
                    aKey.BringToFront();
                }
                else
                {
                    aKey.Hide();
                }
            }
        }

        void onUpdatedKey(object sender, EventArgs e)
        {
            string lines = "";

            foreach (Key aKey in keyList)
            {
                lines += aKey.getName() + "|";
                lines += aKey.getEvent() + "|";
                lines += aKey.getKeytag() + "|";
                lines += aKey.getEnebled() + "|";
                lines += aKey.getExecuteLocation() + "\n";
            }
            string[] splits = lines.Split('\n');

            System.IO.File.WriteAllLines(saveFile, splits);

            updateListView();
            updateKeyNameList();
        }

        void onDeleteKey(object sender, objKeyEventArgs e)
        {
            keyList.Remove(e.objKey);
            e.objKey.Dispose();

            onUpdatedKey(sender, EventArgs.Empty);
            loadListVieuw();
        }

        private void updateKeyNameList()
        {
            KeyNameList.Clear();
            foreach(Key k in keyList)
            {
                KeyNameList.Add(k.getName());
            }
            
            //foreach (Key k in keyList)
            //{
            //    k.nameAllKeys = KeyNameList;
            //}
        }

        public void clearKeyList()
        {
            foreach(KeyListPanel k in keyPanelList)
            {
                k.Dispose();
            }

            keyPanelList.Clear();
        }
    }
}