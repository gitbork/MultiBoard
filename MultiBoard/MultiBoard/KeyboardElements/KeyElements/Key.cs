﻿using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Timers;

namespace MultiBoard.KeyboardElements.KeyElements
{
    public class Key
    {
        [DllImport("user32.dll", SetLastError = true)]
        static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

        //variables
        //===============================
        const int _KEYDOWN = 0x0100;

        private bool _onKeyDownSelected = false;
        private bool _onKeyUpSelected = false;
        private bool _onKeyPressedSelected = false;

        private string _keyName;
        private bool _recordingKey = false;
        private bool _enabled = true;
        private string _keyTag;
        private string _executeLocation;

        private Timer _timer = new Timer();
        private int _keyPressCount = 0;
        private const int _defInterval = 300;

        public Key(string name, int eventStateAr, string key, bool enabledKey, string executeLoc)
        {
            _keyName = name;
            EventState = eventStateAr;
            _keyTag = key;
            _enabled = enabledKey;
            _executeLocation = executeLoc;

            _timer.Interval = _defInterval;
            _timer.Elapsed += timerOnElapsed;
            _timer.Stop();
        }

        private void timerOnElapsed(object sender, EventArgs e)
        {
            if (_timer.Interval == _defInterval)
            {
                _timer.Interval = 200;
            }

            if (_timer.Interval != _defInterval)
            {
                _keyPressCount++;
                int newInter = 200 - _keyPressCount * 20;
                if (newInter > 50)
                {
                    _timer.Interval = newInter;
                }
            }

            executeFile();

        }

        public string key_name
        {
            get
            {
                return _keyName;
            }
            set
            {
                _keyName = value;
            }
        }

        public int EventState
        {
            get
            {
                if(_onKeyDownSelected == true)
                {
                    return 1;
                }
                else if(_onKeyUpSelected == true)
                {
                    return 2;
                }
                else if(_onKeyPressedSelected == true)
                {
                    return 3;
                }
                return 0;
            }

            set
            {
                _timer.Stop();
                if(value == 1)
                {
                    _onKeyDownSelected = true;
                    _onKeyUpSelected = false;
                    _onKeyPressedSelected = false;
                }
                else if(value == 2)
                {
                    _onKeyDownSelected = false;
                    _onKeyUpSelected = true;
                    _onKeyPressedSelected = false;
                }
                else
                {
                    _onKeyDownSelected = false;
                    _onKeyUpSelected = false;
                    _onKeyPressedSelected = true;
                }
            }
        }

        public bool keyEnebled
        {
            get
            {
                return _enabled;
            }
            set
            {
                _enabled = value;
            }
        }

        public string keyTag
        {
            get
            {
                return _keyTag;
            }
            set
            {
                _keyTag = value;
            }
        }

        public string executeLoc
        {
            get
            {
                return _executeLocation;
            }
            set
            {
                _executeLocation = value;
            }
        }

        public void keyDown(string key, bool allEnebled)
        {
            if (_recordingKey == false)
            {
                if (_keyTag == key && _enabled == true && _onKeyDownSelected && allEnebled)
                {
                    //execute
                    executeFile();
                }
                else if (_keyTag == key && _enabled == true && _onKeyPressedSelected && allEnebled)
                {
                    executeFile();
                    _timer.Start();
                }
            }
        }

        public void keyUp(string key, bool allEnebled)
        {
            if (_recordingKey == false)
            {
                if (_keyTag == key && _enabled == true && _onKeyUpSelected && allEnebled)
                {
                    executeFile();
                }
                else if (_keyTag == key && _enabled == true && _onKeyPressedSelected && allEnebled)
                {
                    _timer.Stop();
                    _timer.Interval = _defInterval;
                    _keyPressCount = 0;
                }
            }
        }

        private void executeFile()
        {
            if (_executeLocation.Remove('<') != _executeLocation)
            {
                //const int key = Int32.Parse(_executeLocation.Remove('<').Remove('>').Replace("VK", ""));
                const int key = 0xA1;
                keybd_event(key, 0, _KEYDOWN, 0);
            }
            else
            {
                if (File.Exists(_executeLocation))
                {
                    //execute
                    System.Diagnostics.Process.Start(_executeLocation);
                }
                else
                {
                    Properties.Settings.Default.ErrorList += ", execute file not found --> " + _keyName;
                }
            }
        }
    }
}
