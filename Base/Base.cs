﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Stroke
{
    public class Base
    {
        private static class API
        {
            public enum VirtualKeyCodes : short
            {
                VK_LBUTTON = 0x01,
                VK_RBUTTON = 0x02,
                VK_CANCEL = 0x03,
                VK_MBUTTON = 0x04,
                VK_XBUTTON1 = 0x05,
                VK_XBUTTON2 = 0x06,
                VK_BACK = 0x08,
                VK_TAB = 0x09,
                VK_CLEAR = 0x0C,
                VK_RETURN = 0x0D,
                VK_SHIFT = 0x10,
                VK_CONTROL = 0x11,
                VK_MENU = 0x12,
                VK_PAUSE = 0x13,
                VK_CAPITAL = 0x14,
                VK_KANA = 0x15,
                VK_HANGUEL = 0x15,
                VK_HANGUL = 0x15,
                VK_IME_ON = 0x16,
                VK_JUNJA = 0x17,
                VK_FINAL = 0x18,
                VK_HANJA = 0x19,
                VK_KANJI = 0x19,
                VK_IME_OFF = 0x1A,
                VK_ESCAPE = 0x1B,
                VK_CONVERT = 0x1C,
                VK_NONCONVERT = 0x1D,
                VK_ACCEPT = 0x1E,
                VK_MODECHANGE = 0x1F,
                VK_SPACE = 0x20,
                VK_PRIOR = 0x21,
                VK_NEXT = 0x22,
                VK_END = 0x23,
                VK_HOME = 0x24,
                VK_LEFT = 0x25,
                VK_UP = 0x26,
                VK_RIGHT = 0x27,
                VK_DOWN = 0x28,
                VK_SELECT = 0x29,
                VK_PRINT = 0x2A,
                VK_EXECUTE = 0x2B,
                VK_SNAPSHOT = 0x2C,
                VK_INSERT = 0x2D,
                VK_DELETE = 0x2E,
                VK_HELP = 0x2F,
                VK_0 = 0x30,
                VK_1 = 0x31,
                VK_2 = 0x32,
                VK_3 = 0x33,
                VK_4 = 0x34,
                VK_5 = 0x35,
                VK_6 = 0x36,
                VK_7 = 0x37,
                VK_8 = 0x38,
                VK_9 = 0x39,
                VK_A = 0x41,
                VK_B = 0x42,
                VK_C = 0x43,
                VK_D = 0x44,
                VK_E = 0x45,
                VK_F = 0x46,
                VK_G = 0x47,
                VK_H = 0x48,
                VK_I = 0x49,
                VK_J = 0x4A,
                VK_K = 0x4B,
                VK_L = 0x4C,
                VK_M = 0x4D,
                VK_N = 0x4E,
                VK_O = 0x4F,
                VK_P = 0x50,
                VK_Q = 0x51,
                VK_R = 0x52,
                VK_S = 0x53,
                VK_T = 0x54,
                VK_U = 0x55,
                VK_V = 0x56,
                VK_W = 0x57,
                VK_X = 0x58,
                VK_Y = 0x59,
                VK_Z = 0x5A,
                VK_LWIN = 0x5B,
                VK_RWIN = 0x5C,
                VK_APPS = 0x5D,
                VK_SLEEP = 0x5F,
                VK_NUMPAD0 = 0x60,
                VK_NUMPAD1 = 0x61,
                VK_NUMPAD2 = 0x62,
                VK_NUMPAD3 = 0x63,
                VK_NUMPAD4 = 0x64,
                VK_NUMPAD5 = 0x65,
                VK_NUMPAD6 = 0x66,
                VK_NUMPAD7 = 0x67,
                VK_NUMPAD8 = 0x68,
                VK_NUMPAD9 = 0x69,
                VK_MULTIPLY = 0x6A,
                VK_ADD = 0x6B,
                VK_SEPARATOR = 0x6C,
                VK_SUBTRACT = 0x6D,
                VK_DECIMAL = 0x6E,
                VK_DIVIDE = 0x6F,
                VK_F1 = 0x70,
                VK_F2 = 0x71,
                VK_F3 = 0x72,
                VK_F4 = 0x73,
                VK_F5 = 0x74,
                VK_F6 = 0x75,
                VK_F7 = 0x76,
                VK_F8 = 0x77,
                VK_F9 = 0x78,
                VK_F10 = 0x79,
                VK_F11 = 0x7A,
                VK_F12 = 0x7B,
                VK_F13 = 0x7C,
                VK_F14 = 0x7D,
                VK_F15 = 0x7E,
                VK_F16 = 0x7F,
                VK_F17 = 0x80,
                VK_F18 = 0x81,
                VK_F19 = 0x82,
                VK_F20 = 0x83,
                VK_F21 = 0x84,
                VK_F22 = 0x85,
                VK_F23 = 0x86,
                VK_F24 = 0x87,
                VK_NUMLOCK = 0x90,
                VK_SCROLL = 0x91,
                VK_LSHIFT = 0xA0,
                VK_RSHIFT = 0xA1,
                VK_LCONTROL = 0xA2,
                VK_RCONTROL = 0xA3,
                VK_LMENU = 0xA4,
                VK_RMENU = 0xA5,
                VK_BROWSER_BACK = 0xA6,
                VK_BROWSER_FORWARD = 0xA7,
                VK_BROWSER_REFRESH = 0xA8,
                VK_BROWSER_STOP = 0xA9,
                VK_BROWSER_SEARCH = 0xAA,
                VK_BROWSER_FAVORITES = 0xAB,
                VK_BROWSER_HOME = 0xAC,
                VK_VOLUME_MUTE = 0xAD,
                VK_VOLUME_DOWN = 0xAE,
                VK_VOLUME_UP = 0xAF,
                VK_MEDIA_NEXT_TRACK = 0xB0,
                VK_MEDIA_PREV_TRACK = 0xB1,
                VK_MEDIA_STOP = 0xB2,
                VK_MEDIA_PLAY_PAUSE = 0xB3,
                VK_LAUNCH_MAIL = 0xB4,
                VK_LAUNCH_MEDIA_SELECT = 0xB5,
                VK_LAUNCH_APP1 = 0xB6,
                VK_LAUNCH_APP2 = 0xB7,
                VK_OEM_1 = 0xBA,
                VK_OEM_PLUS = 0xBB,
                VK_OEM_COMMA = 0xBC,
                VK_OEM_MINUS = 0xBD,
                VK_OEM_PERIOD = 0xBE,
                VK_OEM_2 = 0xBF,
                VK_OEM_3 = 0xC0,
                VK_OEM_4 = 0xDB,
                VK_OEM_5 = 0xDC,
                VK_OEM_6 = 0xDD,
                VK_OEM_7 = 0xDE,
                VK_OEM_8 = 0xDF,
                VK_OEM_102 = 0xE2,
                VK_PROCESSKEY = 0xE5,
                VK_PACKET = 0xE7,
                VK_ATTN = 0xF6,
                VK_CRSEL = 0xF7,
                VK_EXSEL = 0xF8,
                VK_EREOF = 0xF9,
                VK_PLAY = 0xFA,
                VK_ZOOM = 0xFB,
                VK_NONAME = 0xFC,
                VK_PA1 = 0xFD,
                VK_OEM_CLEAR = 0xFE
            }

            [StructLayout(LayoutKind.Explicit)]
            public struct INPUT
            {
                [FieldOffset(0)]
                public INPUTTYPE type;

                [FieldOffset(4)]
                public MOUSEINPUT mi;

                [FieldOffset(4)]
                public KEYBDINPUT ki;

                [FieldOffset(4)]
                public HARDWAREINPUT hi;
            }

            public enum INPUTTYPE : uint
            {
                MOUSE,
                KEYBOARD,
                HARDWARE
            }

            public struct MOUSEINPUT
            {
                public int dx;
                public int dy;
                public int mouseData;
                public MOUSEEVENTF dwFlags;
                public uint time;
                public UIntPtr dwExtraInfo;
            }

            public struct KEYBDINPUT
            {
                public VirtualKeyCodes wVk;
                public short wScan;
                public KEYEVENTF dwFlags;
                public int time;
                public UIntPtr dwExtraInfo;
            }

            public struct HARDWAREINPUT
            {
                public int uMsg;
                public short wParamL;
                public short wParamH;
            }

            [Flags]
            public enum MOUSEEVENTF : uint
            {
                MOVE = 0x0001,
                LEFTDOWN = 0x0002,
                LEFTUP = 0x0004,
                RIGHTDOWN = 0x0008,
                RIGHTUP = 0x0010,
                MIDDLEDOWN = 0x0020,
                MIDDLEUP = 0x0040,
                XDOWN = 0x0080,
                XUP = 0x0100,
                WHEEL = 0x0800,
                HWHEEL = 0x01000,
                MOVE_NOCOALESCE = 0x2000,
                VIRTUALDESK = 0x4000,
                ABSOLUTE = 0x8000
            }

            [Flags]
            public enum KEYEVENTF : uint
            {
                EXTENDEDKEY = 0x0001,
                KEYUP = 0x0002,
                UNICODE = 0x0004,
                SCANCODE = 0x0008
            }

            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            public static extern uint SendInput(uint cInputs, ref INPUT pInput, int cbSize);

            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            public static extern IntPtr GetForegroundWindow();

            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool SetForegroundWindow(IntPtr hWnd);

            public const uint WM_SYSCOMMAND = 0x0112;

            public enum SystemCommand : int
            {
                SC_SIZE = 0xF000,
                SC_MOVE = 0xF010,
                SC_MINIMIZE = 0xF020,
                SC_MAXIMIZE = 0xF030,
                SC_NEXTWINDOW = 0xF040,
                SC_PREVWINDOW = 0xF050,
                SC_CLOSE = 0xF060,
                SC_VSCROLL = 0xF070,
                SC_HSCROLL = 0xF080,
                SC_MOUSEMENU = 0xF090,
                SC_KEYMENU = 0xF100,
                SC_RESTORE = 0xF120,
                SC_TASKLIST = 0xF130,
                SC_SCREENSAVE = 0xF140,
                SC_HOTKEY = 0xF150,
                SC_DEFAULT = 0xF160,
                SC_MONITORPOWER = 0xF170,
                SC_CONTEXTHELP = 0xF180,
                SCF_ISSECURE = 0x00000001
            }

            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            public static extern int PostMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);

            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool IsZoomed(IntPtr hWnd);

            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool IsIconic(IntPtr hWnd);

            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            public static extern int GetClassName(IntPtr hWnd, System.Text.StringBuilder lpClassName, int nMaxCount);

        }

        public static Dictionary<string, object> Data = new Dictionary<string, object>();

        public static void Activate()
        {
            while (!API.SetForegroundWindow(Stroke.CurrentWindow)) ;
        }

        public static void KeyDown(Keys key)
        {
            API.INPUT input = new API.INPUT();
            input.type = API.INPUTTYPE.KEYBOARD;
            input.ki.time = 0;
            input.ki.wVk = (API.VirtualKeyCodes)key;
            input.ki.dwExtraInfo = (UIntPtr)0;
            input.ki.dwFlags = 0;
            input.ki.wScan = 0;
            API.SendInput(1u, ref input, Marshal.SizeOf(typeof(API.INPUT)));
        }

        public static void KeyUp(Keys key)
        {
            API.INPUT input = new API.INPUT();
            input.type = API.INPUTTYPE.KEYBOARD;
            input.ki.time = 0;
            input.ki.wVk = (API.VirtualKeyCodes)key;
            input.ki.dwExtraInfo = (UIntPtr)0;
            input.ki.dwFlags = API.KEYEVENTF.KEYUP;
            input.ki.wScan = 0;
            API.SendInput(1u, ref input, Marshal.SizeOf(typeof(API.INPUT)));
        }

        public static void PressKeys(string keys)
        {
            keys = keys.ToUpper();

            for (int i = 0; i < keys.Length; i++)
            {
                if (keys[i] == '\\')
                {
                    i++;
                    switch (keys[i])
                    {
                        case 'T':
                            KeyDown(Keys.Tab);
                            KeyUp(Keys.Tab);
                            break;
                        case 'R':
                            KeyDown(Keys.Return);
                            KeyUp(Keys.Return);
                            break;
                        case 'E':
                            KeyDown(Keys.Escape);
                            KeyUp(Keys.Escape);
                            break;
                        case 'S':
                            KeyDown(Keys.Space);
                            KeyUp(Keys.Space);
                            break;
                        case 'B':
                            KeyDown(Keys.Back);
                            KeyUp(Keys.Back);
                            break;
                        case 'I':
                            KeyDown(Keys.Insert);
                            KeyUp(Keys.Insert);
                            break;
                        case 'D':
                            KeyDown(Keys.Delete);
                            KeyUp(Keys.Delete);
                            break;
                    }
                }
                else
                {
                    switch (keys[i])
                    {
                        case '(':
                            KeyDown(Keys.ControlKey);
                            break;
                        case ')':
                            KeyUp(Keys.ControlKey);
                            break;
                        case '[':
                            KeyDown(Keys.ShiftKey);
                            break;
                        case ']':
                            KeyUp(Keys.ShiftKey);
                            break;
                        case '{':
                            KeyDown(Keys.Menu);
                            break;
                        case '}':
                            KeyUp(Keys.Menu);
                            break;
                        case '<':
                            KeyDown(Keys.LWin);
                            break;
                        case '>':
                            KeyUp(Keys.LWin);
                            break;
                    }

                    if ((keys[i] >= 0x30 && keys[i] < 0x40) || (keys[i] >= 65 && keys[i] <= 90))
                    {
                        KeyDown((Keys)keys[i]);
                        KeyUp((Keys)keys[i]);
                    }
                }
            }

        }

        public enum WindowState
        {
            Normal,
            Minimize,
            Maximize,
            Close
        }

        public static void SetWindowState(WindowState state)
        {
            System.Text.StringBuilder windowClassName = new System.Text.StringBuilder(256);
            API.GetClassName(Stroke.CurrentWindow, windowClassName, windowClassName.Capacity);

            if (windowClassName.ToString() == "WorkerW")
            {
                return;
            }

            switch (state)
            {
                case WindowState.Normal:
                    API.PostMessage(Stroke.CurrentWindow, API.WM_SYSCOMMAND, (int)API.SystemCommand.SC_RESTORE, 0);
                    break;
                case WindowState.Minimize:
                    API.PostMessage(Stroke.CurrentWindow, API.WM_SYSCOMMAND, (int)API.SystemCommand.SC_MINIMIZE, 0);
                    break;
                case WindowState.Maximize:
                    API.PostMessage(Stroke.CurrentWindow, API.WM_SYSCOMMAND, (int)API.SystemCommand.SC_MAXIMIZE, 0);
                    break;
                case WindowState.Close:
                    API.PostMessage(Stroke.CurrentWindow, API.WM_SYSCOMMAND, (int)API.SystemCommand.SC_CLOSE, 0);
                    break;
            }
        }

        public static WindowState GetWindowState()
        {
            if (API.IsIconic(Stroke.CurrentWindow))
            {
                return WindowState.Minimize;
            }
            else if (API.IsZoomed(Stroke.CurrentWindow))
            {
                return WindowState.Maximize;
            }
            else
            {
                return WindowState.Normal;
            }
        }

        public static void Run(string fileName, string arguments = "", string workingDirectory = "")
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo.FileName = fileName;
            process.StartInfo.Arguments = arguments;

            if (workingDirectory == "" && File.Exists(fileName))
            {
                process.StartInfo.WorkingDirectory = fileName.Substring(0, fileName.LastIndexOf('\\'));
            }
            else
            {
                process.StartInfo.WorkingDirectory = workingDirectory;
            }

            process.Start();
        }

    }
}
