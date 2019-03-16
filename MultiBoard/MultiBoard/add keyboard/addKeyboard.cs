﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MultiBoard.Keyboard;
using MultiBoard.KeyboardElements;
using MultiBoard.KeyboardElements.KeyboardScannerElements;

namespace MultiBoard
{
    public partial class addKeyboard : UserControl
    {
        private bool refreshing = false;
        private List<string> IDs = new List<string>();
        private List<string> ports = new List<string>();

        private AutoAddKeyboard aakb;
        private ManuallyAddKeyboard makb;

        public event EventHandler AddKeyboarde;
        public string kbName;
        public string kbId;
        public string kbPort;

        private List<string> IDsBlackList;

        public addKeyboard()
        {
            InitializeComponent();


            //start scanner
            //==============
            /*
            refreshing = true;
            AUTO_ADD_LABEL.Text = "Searching...";
            refreshKeyboards();
            REFRESH_BUTTON.Enabled = true;
            displayKeyboardCount();
            */
        }

        private void REFRESH_BUTTON_Click(object sender, EventArgs e)
        {
            if(refreshing == false)
            {
                refreshing = true;
                AUTO_ADD_LABEL.Text = "Searching...";
                REFRESH_BUTTON.Enabled = false;

                refreshKeyboards();
            }
            else
            {
                REFRESH_BUTTON.Enabled = false;
            }
        }

        private void displayKeyboardCount()
        {
            if (IDs.Count() > 0)
            {
                if (IDs.Count() > 1)
                {
                    AUTO_ADD_LABEL.Text = IDs.Count() + " keyboards found";
                }
                else
                {
                    AUTO_ADD_LABEL.Text = IDs.Count() + " keyboard found";
                }
            }
            else
            {
                AUTO_ADD_LABEL.Text = "No keyboards found";
            }
        }

        private void refreshKeyboards()
        {
            BACKGROUND_SCANNER.RunWorkerAsync();
        }

        public void idBlackListUpdate(List<string> blackIDs)
        {
            IDsBlackList = blackIDs;
        }

        private void filterKeyboards(List<string> AllPorts, List<string> AllIds)
        {
            IDs.Clear();
            ports.Clear();

            int index = 0;
            foreach(string s in AllIds)
            {
                bool newKB = true;
                if (IDsBlackList != null)
                {
                    foreach (string bs in IDsBlackList)
                    {
                        if (s == bs)
                        {
                            newKB = false;
                        }
                    }
                }

                if(newKB == true && s != "NONE")
                {
                    IDs.Add(s);
                    int indexP = 0;
                    foreach(string p in AllPorts)
                    {
                        if(index == indexP)
                        {
                            ports.Add(p);
                        }
                        indexP++;
                    }
                }

                index++;
            }
        }

        private void CANCEL_PANEL_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void AUTO_ADD_PANEL_Click(object sender, EventArgs e)
        {
            if (IDs.Count() > 0)
            {
                aakb = new AutoAddKeyboard();
                aakb.AddClicked += AutoAddKeyboardEvent;
                aakb.Location = new Point(0, 0);
                aakb.IDs = IDs;
                aakb.Ports = ports;
                aakb.loadKbList();
                this.Controls.Add(aakb);
                aakb.BringToFront();
            }
        }

        private void MANUAL_ADD_PANEL_Click(object sender, EventArgs e)
        {
            makb = new ManuallyAddKeyboard();
            makb.Location = new Point(0, 0);
            this.Controls.Add(makb);
            makb.BringToFront();
        }

        protected virtual void OnAddKeyboarde()
        {
            if (AddKeyboarde != null)
            {
                AddKeyboarde(this, EventArgs.Empty);
            }
        }

        private void AutoAddKeyboardEvent(object sender, EventArgs e)
        {
            kbName = aakb.kbName;
            kbId = aakb.kbUUID;
            kbPort = aakb.kbPort;
            OnAddKeyboarde();
        }

        private void BACKGROUND_SCANNER_DoWork(object sender, DoWorkEventArgs e)
        {
            KeyboardScanner kbs = new KeyboardScanner();
            kbs.loadList(115200);

            filterKeyboards(kbs.Ports, kbs.Uuid);
            refreshing = false;

            this.Invoke(new Action(() => {
                REFRESH_BUTTON.Enabled = true;
                displayKeyboardCount();
            }));
            
        }

        private void AUTO_ADD_HOVER_TIMER_Tick(object sender, EventArgs e)
        {
            AUTO_ADD_PANEL.BackColor = Color.DarkGray;
            REFRESH_BUTTON.BackColor = Color.DarkGray;
            AUTO_ADD_HOVER_TIMER.Stop();
        }

        private void MANUAL_ADD_HOVER_TIMER_Tick(object sender, EventArgs e)
        {
            MANUAL_ADD_PANEL.BackColor = Color.DarkGray;
            MANUAL_ADD_HOVER_TIMER.Stop();
        }

        private void CANCEL_HOVER_TIMER_Tick(object sender, EventArgs e)
        {
            CANCEL_PANEL.BackColor = Color.DarkGray;
            CANCEL_HOVER_TIMER.Stop();
        }

        private void AUTO_ADD_PANEL_MouseEnter(object sender, EventArgs e)
        {
            AUTO_ADD_HOVER_TIMER.Stop();
            AUTO_ADD_PANEL.BackColor = Color.Gray;
            REFRESH_BUTTON.BackColor = Color.Gray;
        }

        private void AUTO_ADD_PANEL_MouseLeave(object sender, EventArgs e)
        {
            AUTO_ADD_HOVER_TIMER.Start();
        }

        private void MANUAL_ADD_PANEL_MouseEnter(object sender, EventArgs e)
        {
            MANUAL_ADD_HOVER_TIMER.Stop();
            MANUAL_ADD_PANEL.BackColor = Color.Gray;
        }

        private void MANUAL_ADD_PANEL_MouseLeave(object sender, EventArgs e)
        {
            MANUAL_ADD_HOVER_TIMER.Start();
        }

        private void CANCEL_PANEL_MouseEnter(object sender, EventArgs e)
        {
            CANCEL_HOVER_TIMER.Stop();
            CANCEL_PANEL.BackColor = Color.Gray;
        }

        private void CANCEL_PANEL_MouseLeave(object sender, EventArgs e)
        {
            CANCEL_HOVER_TIMER.Start();
        }
    }
}
