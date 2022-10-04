using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BtLib;

namespace csNativeCoreSample
{
    public partial class frmMain : Form
    {
        static byte[] posblk = new byte[128];
        static byte[] dummy_data = new Byte[128];
        static byte[] keyBuf = Encoding.ASCII.GetBytes(@"btrv:///demodata?table=room");
        static Room room = new Room();
        static primaryKey pk = new primaryKey();
        static System.IntPtr ptr;
        static System.IntPtr keyPtr;
        static Encoding enc;
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnFill_Click(object sender, EventArgs e)
        {
            ushort dataLength = 0;
            Int16 rc;
            short keyBufLen = 128;

            // get shift jis encoder if it's japanese
            // enc = Encoding.GetEncoding("shift-jis");
            // get english encoder.
            enc = Encoding.GetEncoding("us-ascii");

            // open...
            rc = Native.BtrCall(Operation.Open, posblk, dummy_data, ref dataLength, keyBuf, (short)keyBuf.Length, 0);

            // get equal
            dataLength = (ushort)Marshal.SizeOf(room);
            ptr = Marshal.AllocCoTaskMem(dataLength);
            Marshal.StructureToPtr(room, ptr, true);

            pk.Building_Name = enc.GetBytes("Eldridge Building        ");
            //                               1234567890123456789012345
            pk.Number = 100;
            keyBufLen = (short)Marshal.SizeOf(pk);
            keyPtr = Marshal.AllocCoTaskMem(Marshal.SizeOf(pk));
            Marshal.StructureToPtr(pk, keyPtr, true);

            rc = Native.BtrCall(Operation.GetEqual, posblk, ptr, ref dataLength, keyPtr, keyBufLen, 0);
            lstRoom.Items.Clear();

            while (rc == 0)
            {
                Marshal.PtrToStructure(ptr, room);
                string str = room.Number.ToString() + "\t" + enc.GetString(room.Building_Name) + "\t" + enc.GetString(room.Type);
                lstRoom.Items.Add(str);
                // get next.
                rc = Native.BtrCall(Operation.GetNext, posblk, ptr, ref dataLength, dummy_data, keyBufLen, 0);
            }

            if (rc != 9)
            {
                MessageBox.Show(Convert.ToString(rc));
            }

            Marshal.FreeCoTaskMem(keyPtr);
            Marshal.FreeCoTaskMem(ptr);
            // close!
            rc = Native.BtrCall(Operation.Close, posblk, dummy_data, ref dataLength, keyBuf, keyBufLen, 0);
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public class Room
        {
            public byte null_flag1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 25, ArraySubType = UnmanagedType.U1)]
            public byte[] Building_Name = new byte[25];
            public byte null_flag2;
            public Int32 Number;
            public byte null_flag3;
            public Int16 Capacity;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20, ArraySubType = UnmanagedType.U1)]
            public byte[] Type = new byte[20];
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Ansi)]
        public class primaryKey
        {
            public byte null_flag1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 25)]
            public byte[] Building_Name = new byte[25];
            public byte null_flag2;
            public Int32 Number;
        }
    }
}
