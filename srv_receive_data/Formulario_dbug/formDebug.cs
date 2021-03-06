﻿using dsrUtil;
using dsrUtil.constant;
using Repository;
using Repository.Entities;
using srv_receive_data.source;
using srv_receive_data.source.util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formulario_dbug
{
    public partial class formDebug : Form
    {
        private Log objLog;
        private SerialPort modemPort;

        private readDataThread thread01;
        private sendDataThread threadSend;
        private readGPRSDataThread threadGprs;
        private static readonly object serial_block = new object();
        public formDebug()
        {
            InitializeComponent();

            IniFile init = new IniFile(Constants.INIT_PATH, Constants.INIT_NAME);

            //Cria o objeto de log
            objLog = new Log(init.IniReadInt("levelLog"), Constants.INIT_PATH);
            //Loga a inicializacao do servico
            objLog.writeTraceLog("Initializing the Service ...");

            //Buscando String de conexão
            sessionFacrtoy.setConString(init.IniReadString("conString"));

            //Conectando a porta serial
            modemPort = utilSerialPort.OpenPort(
                init.IniReadString("comPort", "COM4"),
                init.IniReadInt("baudRate", 9600),
                init.IniReadInt("dataBits", 8),
                init.IniReadInt("readTimeout", 300),
                init.IniReadInt("writeTimeout", 300),
                objLog);

            thread01 = new readDataThread(modemPort, objLog, serial_block);
            threadSend = new sendDataThread(modemPort, objLog,serial_block);
            threadGprs = new readGPRSDataThread(objLog, 8686);

            thread01.Call();
            threadSend.Call();
            threadGprs.Call();

        }
    }
}
