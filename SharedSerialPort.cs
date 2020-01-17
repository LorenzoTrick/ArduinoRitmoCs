using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArduBeats
{
    //classe SerialPort, per poterla condividere tra gli oggetti TimingPlayer e NotesPlayer
    class SharedSerialPort
    {
        private static SharedSerialPort _instance;

        private SerialPort com;
        private bool isThereData;

        public static SharedSerialPort StartInstance()
        {
            if (_instance == null)
            {
                _instance = new SharedSerialPort();
            }

            return _instance;
        }
        private SharedSerialPort()
        {
            com = new SerialPort();
            com.DataReceived += Com_DataReceived;
            com.Open();

            isThereData = false;
        }

        private void Com_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            isThereData = true;
        }
        public char ReadData()
        {
            if (isThereData)
            {
                isThereData = false;
                return (char)com.ReadByte();
            }
            else return '\0';
        }

        public void WriteData(char c)
        {
            com.Write(c.ToString());
        }
    }
}
