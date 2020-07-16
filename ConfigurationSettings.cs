using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Globalization;
using System.Resources;
using System.Data;
using System.Net;
using System.IO.Ports;
using System.IO;
using System.Linq;
using ClassList;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace WeiderMuller_Test_Utility
{
    public partial class ConfigurationSettings : Form
    {
        public ConfigurationSettings()
        {
            InitializeComponent();
            _FLBaseModule._basicInfo += new FLBaseModule.BasicInfo(_FLBaseModule__basicInfo);            
        }
        public string strUSBDwnlTest = "";
        Boolean DownloadComplete = false;
        public string AppVersion = "";

        int _downloadStatus = 0;
      
        public bool isProductMismatch = false;
        public static bool downloadCompleteFlag = false;
        public delegate void SetStatusBarDelegate(int pMessage);   
        public delegate void SetProgressBarDelegate(float pPercent);
        public delegate void SetMainWindowObject(ref string pProductName);
        public event SetMainWindowObject _setMainWindowObject;
        private object _prizmMDIStatusBar;
        private object _prizmMDIProgressBar;
        private object _prizmMDIProgressLabel;
        private static int _prizmMDISelProjectID;
        public static string pDownloadType;
       
        public static int StartTestResponse = 0;
        ResourceManager _manager = new ResourceManager(typeof(FLBaseModule));
        FLBaseModule _FLBaseModule = new FLBaseModule();  

        #region public Variables
        public static string path;
        public string strProdName1;
        public bool _blAlreadyOpen = false;
        public bool _reportFlag = true;
        #endregion
        
        private void ConfigurationSettings_Load(object sender, EventArgs e)
        {
            rdB_Ethernet_CheckedChanged(null, null);
            lbDownload_Progress.BackColor = System.Drawing.Color.Transparent;
            getApplicationVersion();
            this.Text = "Web Panel-Firmware Update [" + AppVersion +"]";
            lbl_portName.Visible = false;
            cmb_PortName.Visible = false;
            //txtB_ResultPath.Enabled = false;    

            //grpB_WiFiTest.Enabled = false;
          //  txtB_PCName.Text = SystemInformation.ComputerName;
            _reportFlag = true;
            //rdB_ContinuousMode.Checked = true;
            cmb_ModelName.SelectedIndex = 0;
           // cmb_DownlType.SelectedIndex = 0;
            string coms = ClassList.Serial.GetQTProductPort();
            cmb_PortName.Items.Add(coms);
            cmb_PortName.SelectedIndex = 0;
            //string[] ports = System.IO.Ports.SerialPort.GetPortNames();

          //  Array.Sort(ports);
            //if (cmb_PortName.Items.Count == 0 )
            //{
            //    foreach (string port in ports)
            //        cmb_PortName.Items.Add(port);
            //    cmb_PortName.SelectedIndex = 0;

              
            //}                     
            _reportFlag = true;

            if (_blAlreadyOpen == true)
            {
                cmb_PortName.SelectedItem = SetValues.Set_PortName;
              //  txtB_PCName.Text = SetValues.Set_PCName;
                cmb_ModelName.SelectedItem = SetValues.Set_ProductName;
             //   txtBx_UserName.Text = SetValues.Set_UserName;
                //txtB_ResultPath.Text = SetValues.Set_Path;
                //cmb_BaseModel.SelectedItem = SetValues.Set_BaseName;

                //if (rdB_ContinuousMode.Checked == true)
                //{
                //   // EnableDisableForContinuousMode();
                //}
              
                   // EnableDisableForSelectiveMode();
            }
            else
            {
               // txtB_ResultPath.Text = Directory.GetCurrentDirectory() + "\\" + _manager.GetString("strReport");
            }         
        }

        private void getApplicationVersion()
        {
            string versionFilePath = Directory.GetCurrentDirectory() + "\\version.txt";
            AppVersion = File.ReadAllText(versionFilePath);
           
        }

        private void rdB_ContinuousMode_CheckedChanged(object sender, EventArgs e)
        {
            //if (rdB_ContinuousMode.Checked == true)
            //{
            //  //  grpB_SeriesFLA.Enabled = false;
            //}
            //else
            //{
            //   // grpB_SeriesFLA.Enabled = true;
            //}
        }

        private void rdB_SelectiveMode_CheckedChanged(object sender, EventArgs e)
             {            
            //if (rdB_SelectiveMode.Checked == true)
            //{
            //   // EnableDisableForSelectiveMode();                
            //}
            //else
            //{
            //   // EnableDisableForContinuousMode();                
            //}            
        }        

        private void cmb_ModelName_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cmb_ProductName.SelectedItem.ToString() == _manager.GetString("FLA0004L") ||
            //    cmb_ProductName.SelectedItem.ToString() == _manager.GetString("FLA0002L"))
            //{
            //    lbl_Base.Visible = true;
            //    cmb_BaseModel.Visible = true;
            //    cmb_BaseModel.Enabled = true;
            //}
            //else
            //{
            //    lbl_Base.Visible = false;
            //    cmb_BaseModel.Visible = false;
            //    cmb_BaseModel.Enabled = false;
            //}

            //if (rdB_ContinuousMode.Checked == true)
            //{
            //    EnableDisableForContinuousMode();
            //}
            //else
            //    EnableDisableForSelectiveMode();      
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            //if (txtBx_UserName.Text != "")
            //{
            //    if (txtBx_UserName.Text.Length < 50)
            //    {
            //        if (true)
            //        {
            //            if (cmb_ModelName.SelectedIndex != 0)
            //            {
            //                StoreConfigurationSettings();                            
            //                SetProductId();
            //                if (_blAlreadyOpen == false)
            //                {
            //                    cmb_ModelName.SelectedItem.ToString();
            //                    this.Hide();
            //                    _FLBaseModule.ShowDialog();
            //                }
            //                else
            //                {
            //                    strProdName1 = cmb_ModelName.SelectedItem.ToString();
            //                    _setMainWindowObject(ref strProdName1);
            //                    this.Hide();
            //                }
            //            }
            //            else
            //            {
            //                MessageBox.Show(_manager.GetString("strSelectProdName"), "Warning");
            //            }
            //        }
            //        else
            //        {
            //            MessageBox.Show(_manager.GetString("strTestReportpath"), "Warning");
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("Maximum limit of User Name characters is 50.Please enter valid User Name", "Warning");
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Please enter valid User Name", "Warning");
            //}
        }

        public void _FLBaseModule__basicInfo(ref string strModeSelection, ref string strname1, ref string strPath)
        {            
            //if (rdB_ContinuousMode.Checked == true)
            //    strModeSelection = _manager.GetString("strContinuous");
            //else if (rdB_SelectiveMode.Checked == true)
            //    strModeSelection = _manager.GetString("strSelective");

            strname1 = cmb_ModelName.SelectedItem.ToString();
           // strPath = txtB_ResultPath.Text.ToString();
            _blAlreadyOpen = true;     
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            if (_blAlreadyOpen == true)
                this.Close();
            else
            {
                this.DialogResult = DialogResult.Cancel;
                Application.Exit();
            }
        }

        private void bttn_Path_Click(object sender, EventArgs e)
        {
          

            path = openFileDialog.SelectedPath;

            if (path.EndsWith("\\"))
            {
                string[] arstr = path.Split('\\');
                path = "";

                for (int i = 0; i < arstr.Length; i++)
                {
                    path += arstr[i];
                }
            }
        }

        public void StoreConfigurationSettings()
        {
            SetValues.Set_PortName = cmb_PortName.SelectedItem.ToString();
            //SetValues.Set_PCName = txtB_PCName.Text.ToString();
            //SetValues.Set_UserName = txtBx_UserName.Text.ToString();
            SetValues.Set_ProductName = cmb_ModelName.SelectedItem.ToString();
          //  SetValues.Set_Path = txtB_ResultPath.Text;
           // SetValues.Set_ProductSeriesName = cmb_ProductName.SelectedItem.ToString();
            //SetValues.Set_BaseName = cmb_BaseModel.SelectedItem.ToString();

            string s = _manager.GetString("WP-007");

            //if (rdB_ContinuousMode.Checked == true)
            //    SetValues.Set_Continuous = true;
            //else
            //    SetValues.Set_Continuous = false;

            //if (rdB_SelectiveMode.Checked == true)
            //    SetValues.Set_Selective = true;
            //else
            //    SetValues.Set_Selective = false;

            if (cmb_ModelName.SelectedItem.ToString() == _manager.GetString("WP-007"))
            {   //added by saood khan

               
            }
        }

        private void SetProductId()
        {
            string strText = cmb_ModelName.SelectedItem.ToString();
            FileStream objFileStream = new FileStream("ProductInformation.xml", FileMode.Open);
            DataSet objDataSet = new DataSet();
            objDataSet.ReadXml(objFileStream);
            objFileStream.Close();
            DataTable objDataTable;
            objDataTable = objDataSet.Tables["FL004"];

            //if (SetValues.Set_ProductSeriesName == "FL004")
            //    objDataTable = objDataSet.Tables["FL004"];
            //else if (SetValues.Set_ProductSeriesName == "FLD")
            //    objDataTable = objDataSet.Tables["FLD"];
            //else if (SetValues.Set_ProductSeriesName == "FLA")
            //    objDataTable = objDataSet.Tables["FLA"];
            //else if (SetValues.Set_ProductSeriesName == "FL005")
            //    objDataTable = objDataSet.Tables["FL005"];
            //else 
                if (SetValues.Set_ProductSeriesName == "WP")
                objDataTable = objDataSet.Tables["WP"];

            for (int i = 0; i < objDataTable.Rows.Count; i++)
            {
                if (objDataTable.Rows[i]["ProductName"].ToString() == strText)
                {
                    SetValues.ProductId = Convert.ToInt32(objDataTable.Rows[i]["ProductNo"]);
                    break;
                }
            }
            SetValues.Set_id = SetValues.ProductId;

            objDataTable = objDataSet.Tables["BaseModel"];
            for (int i = 0; i < objDataTable.Rows.Count; i++)
            {
                if (objDataTable.Rows[i]["BaseName"].ToString() == "FL004-0806N")
                {
                    SetValues.Set_ExpansionBaseID = Convert.ToInt32(objDataTable.Rows[i]["BaseId"]);
                    break;
                }
            }
        }

        private void cmb_ProductName_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet dsProductInfo = new DataSet();
            dsProductInfo.ReadXml("ProductInformation.xml");

           // string strProduct = cmb_ProductName.SelectedItem.ToString();
            cmb_ModelName.Items.Clear();
            DataRow[] drData;
            drData = dsProductInfo.Tables["WP"].Select();

            //if (strProduct.ToString() == "FL004")
            //    drData = dsProductInfo.Tables["FL004"].Select();
            //else if (strProduct.ToString() == "FLD")
            //    drData = dsProductInfo.Tables["FLD"].Select();
            //else if (strProduct.ToString() == "FLA")
            //    drData = dsProductInfo.Tables["FLA"].Select();
            //else if (strProduct.ToString() == "FL005")
            //    drData = dsProductInfo.Tables["FL005"].Select();
            //else if (strProduct.ToString() == "FLD")
            //    drData = dsProductInfo.Tables["FLD"].Select();
            //else
            //    if (strProduct.ToString()=="ML")
                drData = dsProductInfo.Tables["WP"].Select();
            cmb_ModelName.Items.Add("None");
            foreach (DataRow dr in drData)
            {
                cmb_ModelName.Items.Add(dr[1]);
            }
            cmb_ModelName.SelectedIndex = 0;
        }

        #region Enable Disable for Continuous Mode
        public void  EnableDisableForContinuousMode()
        {
           if (cmb_ModelName.SelectedItem.ToString()==("WP-007"))             
            {
               // grpB_SeriesFLA.Visible = true;
               // grpB_SeriesFLA.Enabled = false;
              
               // grpB_SeriesFL004.Visible = false;

               // chkB_EthernetDownload.Visible = true;
               // chkB_EthernetDownload.Checked = true;
               // chkB_USBDownload.Visible = true;
               //chkB_USBDownload.Checked = true;
                if (SetValues.IsProductionCheck)
                {
                    
                }
                else
                {
                    
                }
            }
            
        }
        #endregion
        
        #region Enable Disable for Selective Mode
        public void EnableDisableForSelectiveMode()
        {
            if (cmb_ModelName.SelectedItem.ToString() == "WP-007")  
            {
                //grpB_SeriesFLA.Visible = true;
                //grpB_SeriesFLA.Enabled = true;

                //grpB_SeriesFL004.Visible = false;

                //chkB_EthernetDownload.Visible = true;
                //chkB_EthernetDownload.Checked = false;
                //chkB_USBDownload.Visible = true;
                //chkB_USBDownload.Checked = false;

                if (SetValues.IsProductionCheck)
                {
                    //chkB_FLAVoltageCalibration_0to10V.Visible = true;
                    //chkB_FLACurrentCalibration_4to20mA.Visible = true;
                    //chkB_FLAVoltageCalibration_0to10V.Checked = true;
                    //chkB_FLACurrentCalibration_4to20mA.Checked = true;

                    //chkB_FLAOPCurrentCalibration_4to20mA.Visible = true;
                    //chkB_FLAOPVoltageCalibration_0to10V.Visible = true;
                    //chkB_FLAOPCurrentCalibration_4to20mA.Checked = true;
                    //chkB_FLAOPVoltageCalibration_0to10V.Checked = true;
                }
                else
                {
                    
                }
            }
            
            
        }
#endregion               

        private void chkB_FLAVoltageCalibration_0to10V_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void grpB_SeriesFLA_Enter(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void chkB_RS232test_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkB_RS485Test_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkB_TouchScreenTest_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkB_GPRSTest_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkB_BatteryCalibration_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void grpB_WiFiTest_Enter(object sender, EventArgs e)
        {

        }

       

        private void btn_USBDownload_Click(object sender, EventArgs e)
        {
            if (cmb_ModelName.SelectedIndex == 0)
            {
                MessageBox.Show("Please select the product model", null, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                lbl_dash.Visible = true;
                SetValues.Set_ProductName = cmb_ModelName.SelectedItem.ToString();
                ClassList.CommonConstants._strProdName=cmb_ModelName.SelectedItem.ToString();
                if (rdB_Ethernet.Checked == true)
                {
                    pDownloadType = rdB_Ethernet.Text;
                    ClassList.CommonConstants._strDownloadtype = rdB_Ethernet.Text;
                }
                else
                {
                    pDownloadType = rdB_USB.Text;
                    ClassList.CommonConstants._strDownloadtype = rdB_USB.Text;
                }
                SetValues.ProductId = GetProductID(SetValues.Set_ProductName);
                Control.CheckForIllegalCrossThreadCalls = false;
                btn_USBDownload.Enabled = false;
                pgbDownload.Value = 0;
                lbDownload_Progress.Text ="0";
                GetDownLoadParameter_new(pgbDownload, statusStrip1, lbDownload_Progress);  //check for  USB  
                //if (pgbDownload.Value >80)
                //{
                //    btn_USBDownload.Enabled = true;
                //}
                //else 
                //{
                //    btn_USBDownload.Enabled = false;
                //}
                //pgbDownload.Value = 100;
              //  btn_USBDownload.Enabled = true;
              //  this.BeginInvoke((System.Windows.Forms.MethodInvoker)delegate() { pgbDownload.Value = 100; });
                //if (downloadCompleteFlag == true)
                //{
                //    this.BeginInvoke((System.Windows.Forms.MethodInvoker)delegate() { pgbDownload.Value = 100;  });
                //   // pgbDownload.Value = 100;
                //}
            }
        }

        private void btn_EthernetDownload_Click(object sender, EventArgs e)
        {
            if (cmb_ModelName.SelectedIndex == 0)
            {
                MessageBox.Show("Please select the product model", null, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
            }
        }
        public int GetProductID(string productName)
        {
            if (productName == "UV66-ECO-4-RES-W")
            {
                return 1201;
            }
            else if (productName == "UV66-ECO-7-RES-W")
            {
                return 1202;
            }
            else if (productName == "UV66-ECO-10-RES-W")
            {
                return 1203;
            }
            else return 0;
        }


        private void GetDownLoadParameter_new(ProgressBar pProgressBar, StatusStrip pStatusBar, Label pProgressLabel)
        {
           
            Refresh();
            _prizmMDIProgressBar = pProgressBar;
            _prizmMDIStatusBar = pStatusBar;
            _prizmMDIProgressLabel = pProgressLabel;

            int retVal = ClassList.CommonConstants.FAILURE;

            ClassList.CommonConstants.ProductFolderName = SetValues.Set_ProductName;
            int ID = SetValues.ProductId;

            ClassList.CommonConstants.IsVirtualUSB = false;
            int iProductID = ID;
            ClassList.CommonConstants.ProductIdentifier = iProductID;
            string IpAddress = ipAddrCntrl_ipaddrWiFi.Text;
            try
            {
                if (pDownloadType == "Ethernet")
                {
                    OnFTPEthernetDownload(IpAddress, iProductID);
                   
                }
                else
                {
                    OnUSBDownload(_prizmMDISelProjectID, pDownloadType, iProductID);
                  
                }
            }
            catch (Exception ex)
            {
                ClassList.LogWriter.WriteLog("At GetDownload parameter : " + ex.StackTrace + " Message : " + ex.ToString());
                return ;
            }
        }
        #region Ethernet Download
        public void OnFTPEthernetDownload(string ipAddress, int pProductID)
        {
            // 2121 is the port no same  as  flexisoft download.
            FTPDownload(ClassList.DownloadType.Ethernet, ipAddress, 2121, pProductID);
        }

        public void FTPDownload(ClassList.DownloadType pDownloadType, string ipAddress, int portNumber, int pProductID)
        {
            byte[] elevenframe = new byte[11];
            //compare FP version 
            if (true)
            {
                #region  version check saod khan
                string FilePath = "";
                if (rdB_OS.Checked == true)
                    FilePath = Directory.GetCurrentDirectory() + "\\" + ClassList.CommonConstants._strProdName + "\\" + "Update OS\\update.ini";
                else
                    FilePath = Directory.GetCurrentDirectory() + "\\" + ClassList.CommonConstants._strProdName + "\\" + "Update Browser\\update.ini";
                string versionInString = ReadINIForVersion(FilePath);
                char[] spearator = { '.' };
                Int32 count = 2;

                // Using the Method 
                String[] strlist = versionInString.Split(spearator, count, StringSplitOptions.None);
                string verion1 = strlist[0].ToString();
                string version2 = strlist[1].ToString();

                #endregion

                int firstValue = int.Parse(verion1);
                int secondValue = int.Parse(version2);

                ushort _framSize = 8;
                ushort _ProductID = (ushort)pProductID;
               
                ushort _downloadUploadType = 1;
                ushort _versionNumberHI = (ushort)firstValue;
                ushort _versionNumberLO = (ushort)secondValue;

                byte[] ProdIDbytes = BitConverter.GetBytes(_ProductID);
                Console.WriteLine(string.Join(" ", ProdIDbytes));
                //byte[] _ProductIDArray = CommonConstants.RawSerialize(_ProductID);
                //byte[] _ProductIDArray = CommonConstants.RawSerialize(4000);
                byte[] _framSizeArray = CommonConstants.RawSerialize(_framSize);
                byte[] _downloadUploadTypeArray = CommonConstants.RawSerialize(_downloadUploadType);
                byte[] _higherNumberVersion = CommonConstants.RawSerialize(_versionNumberHI);
                byte[] _lowerNumberVersion = CommonConstants.RawSerialize(_versionNumberLO);
                byte[] dataFrame = new byte[11];
                #region old frame
                //dataFrame[0] = _framSizeArray[1];
                //dataFrame[1] = _framSizeArray[0];
                //dataFrame[2] = _ProductIDArray[1];
                //dataFrame[3] = _ProductIDArray[0];
                //dataFrame[4] = _downloadUploadTypeArray[1];
                //dataFrame[5] = _downloadUploadTypeArray[0];
                //dataFrame[6] = _higherNumberVersion[1];
                //dataFrame[7] = _higherNumberVersion[0];
                //dataFrame[8] = _lowerNumberVersion[1];
                //dataFrame[9] = _lowerNumberVersion[0];
               
                #endregion
                dataFrame[0] = 0x00;                //ProdID
                dataFrame[1] = 0x00;
                dataFrame[2] = ProdIDbytes[1];
                dataFrame[3] = ProdIDbytes[0];
                dataFrame[4] = _framSizeArray[1];             //Frame size
                dataFrame[5] = _framSizeArray[0];
                dataFrame[6] = _downloadUploadTypeArray[1];   //downl type
                dataFrame[7] = _downloadUploadTypeArray[0];
                dataFrame[8] =_lowerNumberVersion[0];        //version 
                dataFrame[9] = _higherNumberVersion[0];
                if (rdB_OS.Checked == true)                   //type of update
                {
                    CommonConstants._strSubDownloadFor = true;
                    dataFrame[10] = 0x01;
                }
                else
                {
                    
                    CommonConstants._strSubDownloadFor = false;
                    if (chkB_Enabled.Checked == true)
                    {
                        dataFrame[10] = 0x03;  //3 for splash screen
                    }
                    else
                    {
                        dataFrame[10] = 0x02;
                    }
                }

                #region SG_TCPProtocolFP4
                TCPEthernetQT _TCPEthernetQT = new TCPEthernetQT(ipAddress, ClassList.CommonConstants.ETHERNET_PORT_NUMBER, portNumber);    // This port is FTP port which is 2121
                _TCPEthernetQT._deviceDownloadEthernetStatus += new TCPEthernetQT.DownloadStatusForQT(StatusForQT__deviceDownloadStatus);
                _TCPEthernetQT._deviceDownloadEthernetPercentage += new TCPEthernetQT.DownloadPercentage(GetDownloadPercentage);
                _TCPEthernetQT._deviceDownloadbutton += new TCPEthernetQT.DownloadbuttonQT(EnabledDisabledButton);     // added  delegaet  for  button enabled  and disable
                _TCPEthernetQT._ShowDownloadedFiles += new TCPEthernetQT.ShowNoOfFilesGettingDownloaded(DisplaySendingFiles); // added  by saood khan (9th March 2020)  for  Display no of files
                try
                {
                    new LogWriter("11 byte frame made");
                    int _connectResult = _TCPEthernetQT.connect();
                    if (_connectResult == 0)//TCP connection is ok and if recives -1 then failure
                    {
                        int result = _TCPEthernetQT.SendData(dataFrame);
                        new LogWriter("-------------------------------------------------------------------------------------------");
                        new LogWriter("-------------------------------------------------------------------------------------------");
                        new LogWriter("start new :-" + System.DateTime.Now);
                        new LogWriter("11 byte frame send------->");
                        if (result == ClassList.CommonConstants.SUCCESS)
                        {
                            byte[] _TCPResult = _TCPEthernetQT.ReadData(1); 
                            ClassList.LogWriter.WriteLog("TCP result: " + _TCPResult[0]);
                            if (_TCPResult[0] == 2)  //reading   3  from  device(1 byte)
                            {
                                bool _tcpResult = _TCPEthernetQT.TCPEthernetDownload();//start sending file from TCPEthernetQT class
                                if (!_tcpResult)
                                    StatusForQT__deviceDownloadStatus(Convert.ToInt32(DownloadingStatusMessagesForQT.strCommunicationAborted));
                                else   // added to see the pg bar 100 %
                                {
                                    downloadCompleteFlag = true;
                                    // pgbDownload.Value = 100;
                                }
                                EnabledDisabledButton(true);
                                applicationDownloadPercentage(0);
                            }
                            else  if (_TCPResult[0] == 3)     //reading   3  from  device(1 byte)
                            {
                                _TCPResult = _TCPEthernetQT.ReadData(11);   //reading  full frame  from  device(11 byte)

                               
                                Array.Copy(_TCPResult, 0 ,elevenframe,0, 11);
                                if (dataFrame.SequenceEqual<byte>(elevenframe) == true)   //checkk if the frammis  saem of not(sent  and reeived)
                                {
                                    new LogWriter("<-------Data frame  sent is equal to frame recieved (device  have  same  version of OS/Browser  ) ");
                                 DialogResult dr=   MessageBox.Show("Device is Up To date .Do you want to Continue download?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                                 if (dr == System.Windows.Forms.DialogResult.Yes)
                                 {
                                     bool _tcpResult = _TCPEthernetQT.TCPEthernetDownload();//start sending file from TCPEthernetQT class
                                     if (!_tcpResult)
                                         StatusForQT__deviceDownloadStatus(Convert.ToInt32(DownloadingStatusMessagesForQT.strCommunicationAborted));
                                     else   // added to see the pg bar 100 %
                                     {
                                         downloadCompleteFlag = true;
                                         // pgbDownload.Value = 100;
                                     }
                                     EnabledDisabledButton(true);
                                     applicationDownloadPercentage(0);
                                 }
                                 else
                                 {
                                     StatusForQT__deviceDownloadStatus(Convert.ToInt32(DownloadingStatusMessagesForQT.strReady));
                                     EnabledDisabledButton(true);
                                     this.BeginInvoke((System.Windows.Forms.MethodInvoker)delegate() { lbl_dash.Visible = false; });
                                 }
                                }
                                else
                                {

                                    if (Convert.ToInt32(dataFrame[8]) < Convert.ToInt32(elevenframe[8]))  // checkk if  8th byte is same or not
                                    {
                                        new LogWriter("<-------Data frame  sent is not  equal to frame recieved (device already have higher version of OS/Browser  ) ");
                                        MessageBox.Show("Device is Up To date", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        StatusForQT__deviceDownloadStatus(Convert.ToInt32(DownloadingStatusMessagesForQT.strReady));
                                        EnabledDisabledButton(true);
                                        this.BeginInvoke((System.Windows.Forms.MethodInvoker)delegate() { lbl_dash.Visible = false; });
                                    }
                                    else if (Convert.ToInt32(dataFrame[9]) < Convert.ToInt32(elevenframe[9]))   // checkk if  9th byte is same or not
                                    {
                                        new LogWriter("<-------Data frame  sent is not  equal to frame recieved (device already have higher version of OS/Browser  ) ");
                                        MessageBox.Show("Device is Up To date", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        StatusForQT__deviceDownloadStatus(Convert.ToInt32(DownloadingStatusMessagesForQT.strReady));
                                        EnabledDisabledButton(true);
                                        this.BeginInvoke((System.Windows.Forms.MethodInvoker)delegate() { lbl_dash.Visible = false; });
                                    }
                                    else                                                    //final download
                                    {

                                        // if (_TCPResult[0] == 2)
                                        {
                                            new LogWriter("<-------1 recieved for 11 byte :connection started");
                                            bool _tcpResult = _TCPEthernetQT.TCPEthernetDownload();//start sending file from TCPEthernetQT class
                                            if (!_tcpResult)
                                                StatusForQT__deviceDownloadStatus(Convert.ToInt32(DownloadingStatusMessagesForQT.strCommunicationAborted));
                                            else   // added to see the pg bar 100 %
                                            {
                                                downloadCompleteFlag = true;
                                                // pgbDownload.Value = 100;
                                            }
                                        }
                                        //else//fail
                                        {
                                            #region
                                            //new LogWriter("<-------connection failed ,responded as :- " + _TCPResult[0].ToString());
                                            //if (_TCPResult[0] == 254)//FE
                                            //{
                                            //    new LogWriter("<-------254 recieved for 11 byte :connection failed");
                                            //    StatusForQT__deviceDownloadStatus(Convert.ToInt32(DownloadingStatusMessagesForQT.strPrizmNotReady));
                                            //    _TCPEthernetQT.Close();
                                            //}
                                            //else if (_TCPResult[0] == 255)//FF
                                            //{
                                            //    StatusForQT__deviceDownloadStatus(Convert.ToInt32(DownloadingStatusMessagesForQT.strProductMismatch));
                                            //    _TCPEthernetQT.Close();
                                            //}
                                            //else
                                            //{
                                            //    StatusForQT__deviceDownloadStatus(Convert.ToInt32(DownloadingStatusMessagesForQT.strProductMismatch));
                                            //    _TCPEthernetQT.Close();
                                            //}
                                            #endregion
                                            EnabledDisabledButton(true);
                                            applicationDownloadPercentage(0);
                                        }
                                    }
                                }
                            }
                            else if (_TCPResult[0] == 255)//FF
                            {
                                StatusForQT__deviceDownloadStatus(Convert.ToInt32(DownloadingStatusMessagesForQT.strProductMismatch));
                                _TCPEthernetQT.Close();
                                EnabledDisabledButton(true);
                            }
                            else
                            {
                                StatusForQT__deviceDownloadStatus(Convert.ToInt32(DownloadingStatusMessagesForQT.strProductMismatch));
                                _TCPEthernetQT.Close();
                                EnabledDisabledButton(true);
                            }
                        }
                        else
                        {
                            new LogWriter("<-------No reply for 11 bytes:- " + result.ToString());
                            StatusForQT__deviceDownloadStatus(Convert.ToInt32(DownloadingStatusMessagesForQT.strProductMismatch));
                            applicationDownloadPercentage(0);
                            EnabledDisabledButton(true);
                            _TCPEthernetQT.Close();
                        }

                    }
                    else
                    {
                        StatusForQT__deviceDownloadStatus(Convert.ToInt32(DownloadingStatusMessagesForQT.strCommunicationTimeout));
                        applicationDownloadPercentage(0);
                        EnabledDisabledButton(true);
                    }
                }
                catch (Exception ex)
                {
                    ClassList.LogWriter.WriteLog("Eception at Pp3 FTP Ethernet :" + ex.Message + " Trace: " + ex.StackTrace);
                    StatusForQT__deviceDownloadStatus(Convert.ToInt32(DownloadingStatusMessagesForQT.strPrizmNotReady));
                    applicationDownloadPercentage(0);
                    EnabledDisabledButton(true);
                }
                #endregion
            }
            else
                StatusForQT__deviceDownloadStatus(Convert.ToInt32(DownloadingStatusMessagesForQT.strVersionUpdateAvilable));
        }
        #endregion

        public void OnUSBDownload(int pProjectID, string pDownloadType, int pProductID)
        {
            ClassList.CommonConstants.ProductData tempInfo;
            tempInfo = ClassList.CommonConstants.ProductDataInfo;
            tempInfo.iProductID = ClassList.CommonConstants.ProductIdentifier;
            ClassList.CommonConstants.ProductDataInfo = tempInfo;
            USBDownload(pDownloadType, pProductID);
        }
        public void StatusForQT__deviceDownloadStatus(int pMessage)
        {
            applicationDownloadStatus(pMessage);
        }
        public void EnabledDisabledButton(bool status)
        {
            applicationButtonEnableDisable(status);
        }
        public void DisplaySendingFiles(int CurrentFileNo, int TotalFiles) // added  by saood khan (9th March 2020)  for  Display no of files
        {
            applicationFilesCountSending(CurrentFileNo, TotalFiles);
        }

        private void applicationFilesCountSending(int CurrentFileNo, int TotalFiles)// added  by saood khan (9th March 2020)  for  Display no of files
        {
            lbl_CurrentFileNo.Text = CurrentFileNo.ToString();
            lbl_TotalFiles.Text = TotalFiles.ToString();
        }

        private void applicationButtonEnableDisable(bool status)
        {
            if (status == true)
            {
                btn_USBDownload.Enabled = true;
                rdB_OS.Enabled = true;
                rdB_Browser.Enabled = true;
                rdB_Ethernet.Enabled = true;
                rdB_USB.Enabled = true;
                if (rdB_USB.Checked == true)
                {
                    ipAddrCntrl_ipaddrWiFi.Enabled = false;
                }
                else 
                {
                    ipAddrCntrl_ipaddrWiFi.Enabled = true;
                }
               
                cmb_ModelName.Enabled = true;
            }
            else 
            {
                btn_USBDownload.Enabled = false;
                rdB_OS.Enabled = false;
                rdB_Browser.Enabled = false;
                rdB_Ethernet.Enabled = false;
                rdB_USB.Enabled = false;
                ipAddrCntrl_ipaddrWiFi.Enabled = false;
                cmb_ModelName.Enabled = false;
            }
        }
        private void applicationDownloadPercentage(float pPercentage)
        {
            if (_prizmMDIProgressBar != null && ClassList.CommonConstants.communicationStatus >= 0)
            {
                if (((ProgressBar)_prizmMDIProgressBar).InvokeRequired)
                {
                    ((ProgressBar)_prizmMDIProgressBar).Invoke(new SetProgressBarDelegate(applicationDownloadPercentage), (pPercentage));
                }
                else
                {
                    ((ProgressBar)_prizmMDIProgressBar).Value = Convert.ToInt32(pPercentage);
                    ((Label)_prizmMDIProgressLabel).Text = Convert.ToInt32(pPercentage).ToString() + "%";
                }
            }
        }
        private void applicationDownloadStatus(int pMessage)
        {
            if (_prizmMDIStatusBar != null)
                if (((StatusStrip)_prizmMDIStatusBar).InvokeRequired)
                    ((StatusStrip)_prizmMDIStatusBar).Invoke(new SetStatusBarDelegate(applicationDownloadStatus), (pMessage));
                else
                {
                    ((StatusStrip)_prizmMDIStatusBar).Items[0].Text = "";
                    ((StatusStrip)_prizmMDIStatusBar).Items[0].Text = _manager.GetString(((ClassList.DownloadingStatusMessagesForQT)(pMessage & 255)).ToString());
                    if ((pMessage & 65280) > 0)
                        ((StatusStrip)_prizmMDIStatusBar).Items[0].Text += _manager.GetString(((ClassList.DownloadingStatusMessagesForQT)(pMessage & 65280)).ToString());
                    ((StatusStrip)_prizmMDIStatusBar).Parent.Refresh();
                }
            if (toolStripStatusLabel1.Text == "Download Completed")
            {
                strUSBDwnlTest = "Download Completed";
                pgbDownload.Value = 100;
                lbDownload_Progress.Text = "100";

                if (DownloadComplete == false)
                {
                    DownloadComplete = true;
                }
                _downloadStatus = 1;
                StartTestResponse = 1;
            }
            else
            {
            }
            if (toolStripStatusLabel1.Text == "Product Mismatch")
            {
                ClassList.CommonConstants.communicationStatus = 0;
                DialogResult result1;
                result1 = MessageBox.Show("Unable to Download in unit, Please check connected unit", "Download", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (result1 == DialogResult.OK)
                {
                    StartTestResponse = 1;
                    isProductMismatch = true;
                }
            }
            if (toolStripStatusLabel1.Text == "Device not responding")
            {
                if (ClassList.CommonConstants.blUSBHostDwnld)
                {
                    pgbDownload.Value = 0;
                    lbDownload_Progress.Text = "0";
                    StartTestResponse = 1;
                }          
            }
        }

        private void GetDownloadPercentage(float pPercentage)
        {
            applicationDownloadPercentage(pPercentage);
        }
        public string ReadINIForVersion(string Filepath)
        {
            string filename = Filepath;
            var Ini = new ClassList.ReadWriteINI(filename);
            var value = Ini.Read("MIN_RUNTIME_VERSION", "UPDATE");
            return value.ToString();
        }
        public void USBDownload(string pDownloadType, int pProductID)
        {
            byte[] elevenframe = new byte[11];
            int result = 0;
            new LogWriter(" Done version");
            //compare FP version 
            if (true)
            {
            #region  version check saod khan
                string FilePath = "";
                if (rdB_OS .Checked== true)
                    FilePath = Directory.GetCurrentDirectory() + "\\" + ClassList.CommonConstants._strProdName + "\\" + "Update OS\\update.ini";
                else
                    FilePath = Directory.GetCurrentDirectory() + "\\" + ClassList.CommonConstants._strProdName + "\\" + "Update Browser\\update.ini";
                 string versionInString=  ReadINIForVersion(FilePath);
                 char[] spearator = { '.'};
                 Int32 count = 2;

                 // Using the Method 
                 String[] strlist = versionInString.Split(spearator,count, StringSplitOptions.None);
                 string verion1 = strlist[0].ToString();
                 string version2 = strlist[1].ToString();
          
            #endregion
                 int firstValue = int.Parse(verion1);
                 int secondValue = int.Parse(version2);

                ushort _framSize = 8;
                ushort _ProductID = (ushort)pProductID;
            resetunit:
                ushort _downloadUploadType = 1;
                ushort _versionNumberHI = (ushort)firstValue;
                ushort _versionNumberLO = (ushort)secondValue;
                byte[] ProdIDbytes = BitConverter.GetBytes(_ProductID);
                Console.WriteLine(string.Join(" ", ProdIDbytes));
                //byte[] _ProductIDArray = CommonConstants.RawSerialize(_ProductID);
                //byte[] _ProductIDArray = CommonConstants.RawSerialize(4000);
                byte[] _framSizeArray = CommonConstants.RawSerialize(_framSize);
                byte[] _downloadUploadTypeArray = CommonConstants.RawSerialize(_downloadUploadType);
                byte[] _higherNumberVersion = CommonConstants.RawSerialize(_versionNumberHI);
                byte[] _lowerNumberVersion = CommonConstants.RawSerialize(_versionNumberLO);
                byte[] dataFrame = new byte[11];

                #region old frame
                //dataFrame[0] = _framSizeArray[1];
                //dataFrame[1] = _framSizeArray[0];
                //dataFrame[2] = _ProductIDArray[1];
                //dataFrame[3] = _ProductIDArray[0];
                //dataFrame[4] = _downloadUploadTypeArray[1];
                //dataFrame[5] = _downloadUploadTypeArray[0];
                //dataFrame[6] = _higherNumberVersion[1];
                //dataFrame[7] = _higherNumberVersion[0];
                //dataFrame[8] = _lowerNumberVersion[1];
                //dataFrame[9] = _lowerNumberVersion[0];

                #endregion
                dataFrame[0] = 0x00;                //ProdID
                dataFrame[1] = 0x00;
                dataFrame[2] = ProdIDbytes[1];
                dataFrame[3] = ProdIDbytes[0];
                dataFrame[4] = _framSizeArray[1];             //Frame size
                dataFrame[5] = _framSizeArray[0];
                dataFrame[6] = _downloadUploadTypeArray[1];   //downl type
                dataFrame[7] = _downloadUploadTypeArray[0];
                dataFrame[8] =  _lowerNumberVersion[0];        //version 
               // dataFrame[8] = _lowerNumberVersion[1];        //version 
                dataFrame[9] = _higherNumberVersion[0]; 
                if (rdB_OS.Checked == true)                   //type of update
                {
                    CommonConstants._strSubDownloadFor = true;
                    dataFrame[10] = 0x01;
                }
                else
                {
                    CommonConstants._strSubDownloadFor = false;
                    if (chkB_Enabled.Checked == true)
                    {
                        dataFrame[10] = 0x03;   //3 for splash screen
                    }
                    else
                    {
                        dataFrame[10] = 0x02;
                    }
                }
             
                new LogWriter(" start Port");

                string _comPort = USBSerialQT.GetQTProductPort();
                byte[] reciveFramData;
                if (_comPort != "None")
                {
                    new LogWriter(" Got Port");
                    USBSerialQT usb = new USBSerialQT(_comPort);
                    new LogWriter("Done ctor, start event instialize");
                    usb._deviceDownloadEthernetPercentage += new USBSerialQT.DownloadPercentage(GetDownloadPercentage);
                    usb._deviceDownloadEthernetStatus += new USBSerialQT.DownloadStatusForQT(StatusForQT__deviceDownloadStatus);
                    usb._deviceDownloadbutton += new USBSerialQT.DownloadbuttonQT(EnabledDisabledButton);
                    usb._ShowDownloadedFiles += new USBSerialQT.ShowNoOfFilesGettingDownloaded(DisplaySendingFiles);  // added  by saood khan (9th March 2020)  for  Display no of files
                    new LogWriter(" open call");
                    usb.Open();

                    new LogWriter(" open call end ,  start Port Done in PP3 class");
                    StatusForQT__deviceDownloadStatus(Convert.ToInt32(DownloadingStatusMessagesForQT.strConnectingtoPrizm));
                 
                     result = usb.SendData(dataFrame);
                    if (result == ClassList.CommonConstants.SUCCESS)
                    {
                        new LogWriter("-------------------------------------------------------------------------------------------");
                        new LogWriter("-------------------------------------------------------------------------------------------");
                        new LogWriter("start new :-" + System.DateTime.Now);
                        new LogWriter("11 byte frame send-------for USB>");
                       
                        System.Threading.Thread.Sleep(200);

                        reciveFramData = usb.ReadData(1);  //reading   data  from  device(1 byte)
                        if (reciveFramData[0] == 2)
                        {
                            bool _USBResult = usb.USBDownload();//start sending file from usbSerialQT class
                            if (!_USBResult)
                                StatusForQT__deviceDownloadStatus(Convert.ToInt32(DownloadingStatusMessagesForQT.strCommunicationAborted));
                            else   // added to see the pg bar 100 %
                            {
                                downloadCompleteFlag = true;
                                // pgbDownload.Value = 100;
                            }
                            EnabledDisabledButton(true);
                        }
                        else if (reciveFramData[0] == 3)    
                        {
                            reciveFramData = usb.ReadData(11);   //reading  full frame  from  device(11 byte)
                            Array.Copy(reciveFramData, 0, elevenframe, 0, 11);
                            if (dataFrame.SequenceEqual<byte>(elevenframe) == true)  //Checking the  frames are  similar
                            {
                                new LogWriter("<-------Data frame  sent is equal to frame recieved (device  have  same  version of OS/Browser  ) ");
                                new LogWriter("recieved frame :" + elevenframe[0] + "|" + elevenframe[1] + "|" + elevenframe[2] + "|" + elevenframe[3] + "|" + elevenframe[4] + "|" + elevenframe[5] + "|" + elevenframe[6] + "|" + elevenframe[7] + "|" + elevenframe[8] + "|" + elevenframe[9] + "|" + elevenframe[10]);
                                new LogWriter("sent frame     :" + dataFrame[0] + "|" + dataFrame[1] + "|" + dataFrame[2] + "|" + dataFrame[3] + "|" + dataFrame[4] + "|" + dataFrame[5] + "|" + dataFrame[6] + "|" + dataFrame[7] + "|" + dataFrame[8] + "|" + dataFrame[9] + "|" + dataFrame[10]);
                             DialogResult dr =  MessageBox.Show("Device is Up To date. Do you want to continue download ?.", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                             if (dr == System.Windows.Forms.DialogResult.Yes)
                             {
                                 bool _USBResult = usb.USBDownload();//start sending file from usbSerialQT class
                                 if (!_USBResult)
                                     StatusForQT__deviceDownloadStatus(Convert.ToInt32(DownloadingStatusMessagesForQT.strCommunicationAborted));
                                 else   // added to see the pg bar 100 %
                                 {
                                     downloadCompleteFlag = true;
                                 }
                                 EnabledDisabledButton(true);
                             }
                             else
                             {
                                 StatusForQT__deviceDownloadStatus(Convert.ToInt32(DownloadingStatusMessagesForQT.strReady));
                                 EnabledDisabledButton(true);
                                 this.BeginInvoke((System.Windows.Forms.MethodInvoker)delegate() { lbl_dash.Visible = false; });
                             }
                            }
                            else
                            {
                                if (Convert.ToInt32(dataFrame[8]) < Convert.ToInt32(elevenframe[8]))      // checking the 8th byte  of the array
                                {
                                    new LogWriter("<-------Data frame  sent is not  equal to frame recieved (device already have higher version of OS/Browser  ) ");
                                    new LogWriter("recieved frame :" + elevenframe[0] + "|" + elevenframe[1] + "|" + elevenframe[2] + "|" + elevenframe[3] + "|" + elevenframe[4] + "|" + elevenframe[5] + "|" + elevenframe[6] + "|" + elevenframe[7] + "|" + elevenframe[8] + "|" + elevenframe[9] + "|" + elevenframe[10]);
                                    new LogWriter("sent frame     :" + dataFrame[0] + "|" + dataFrame[1] + "|" + dataFrame[2] + "|" + dataFrame[3] + "|" + dataFrame[4] + "|" + dataFrame[5] + "|" + dataFrame[6] + "|" + dataFrame[7] + "|" + dataFrame[8] + "|" + dataFrame[9] + "|" + dataFrame[10]);
                                    MessageBox.Show("Device is Up To date", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    StatusForQT__deviceDownloadStatus(Convert.ToInt32(DownloadingStatusMessagesForQT.strReady));
                                    EnabledDisabledButton(true);
                                    this.BeginInvoke((System.Windows.Forms.MethodInvoker)delegate() { lbl_dash.Visible = false; });
                                }
                                else if (Convert.ToInt32(dataFrame[9]) < Convert.ToInt32(elevenframe[9]))  // checking the 9th byte  of the array
                                {
                                    new LogWriter("<-------Data frame  sent is not  equal to frame recieved (device already have higher version of OS/Browser  ) ");
                                    new LogWriter("recieved frame :" + elevenframe[0] + "|" + elevenframe[1] + "|" + elevenframe[2] + "|" + elevenframe[3] + "|" + elevenframe[4] + "|" + elevenframe[5] + "|" + elevenframe[6] + "|" + elevenframe[7] + "|" + elevenframe[8] + "|" + elevenframe[9] + "|" + elevenframe[10]);
                                    new LogWriter("sent frame     :" + dataFrame[0] + "|" + dataFrame[1] + "|" + dataFrame[2] + "|" + dataFrame[3] + "|" + dataFrame[4] + "|" + dataFrame[5] + "|" + dataFrame[6] + "|" + dataFrame[7] + "|" + dataFrame[8] + "|" + dataFrame[9] + "|" + dataFrame[10]);
                                    StatusForQT__deviceDownloadStatus(Convert.ToInt32(DownloadingStatusMessagesForQT.strReady));
                                    EnabledDisabledButton(true);
                                    this.BeginInvoke((System.Windows.Forms.MethodInvoker)delegate() { lbl_dash.Visible = false; });
                                    MessageBox.Show("Device is Up To date", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                                else                                                     //final Download
                                {
                                    // if (reciveFramData[0] == 2)
                                    {
                                        new LogWriter("<-------2 recieved for 11 byte :connection started");
                                        new LogWriter("recieved frame :" + elevenframe[0] + "|" + elevenframe[1] + "|" + elevenframe[2] + "|" + elevenframe[3] + "|" + elevenframe[4] + "|" + elevenframe[5] + "|" + elevenframe[6] + "|" + elevenframe[7] + "|" + elevenframe[8] + "|" + elevenframe[9] + "|" + elevenframe[10]);
                                        new LogWriter("sent frame     :" + dataFrame[0] + "|" + dataFrame[1] + "|" + dataFrame[2] + "|" + dataFrame[3] + "|" + dataFrame[4] + "|" + dataFrame[5] + "|" + dataFrame[6] + "|" + dataFrame[7] + "|" + dataFrame[8] + "|" + dataFrame[9] + "|" + dataFrame[10]);
                                        bool _USBResult = usb.USBDownload();//start sending file from usbSerialQT class
                                        if (!_USBResult)
                                            StatusForQT__deviceDownloadStatus(Convert.ToInt32(DownloadingStatusMessagesForQT.strCommunicationAborted));
                                        else   // added to see the pg bar 100 %
                                        {
                                            downloadCompleteFlag = true;
                                            // pgbDownload.Value = 100;
                                        }
                                    }

                                    // else
                                    {
                                        #region
                                        //if (reciveFramData[0] == 254)
                                        //{
                                        //    new LogWriter("<------------ 254 recieved :device not ready");
                                        //    StatusForQT__deviceDownloadStatus(Convert.ToInt32(DownloadingStatusMessagesForQT.strPrizmNotReady));
                                        //    usb.Close();
                                        //}
                                        //else if (reciveFramData[0] == 255)
                                        //{
                                        //    new LogWriter("<------------ 255 recieved :device mismatch");
                                        //    StatusForQT__deviceDownloadStatus(Convert.ToInt32(DownloadingStatusMessagesForQT.strProductMismatch));
                                        //    usb.Close();
                                        //}
                                        //else
                                        //{
                                        //    new LogWriter(" Got SomthingElse");
                                        //    StatusForQT__deviceDownloadStatus(Convert.ToInt32(DownloadingStatusMessagesForQT.strProductMismatch));
                                        //    usb.Close();
                                        //}
                                        #endregion
                                        EnabledDisabledButton(true);
                                    }
                                }
                            }
                        }
                        else  if (reciveFramData[0] == 254)       // device is not ready
                        {
                            new LogWriter("<------------ 254 recieved :device not ready");
                            StatusForQT__deviceDownloadStatus(Convert.ToInt32(DownloadingStatusMessagesForQT.strPrizmNotReady));
                            usb.Close();
                            this.BeginInvoke((System.Windows.Forms.MethodInvoker)delegate() { lbl_dash.Visible = true; });
                            EnabledDisabledButton(true);
                        }
                        else if (reciveFramData[0] == 255)     //device  mismatch
                        {
                            new LogWriter("<------------ 255 recieved :device mismatch");
                            StatusForQT__deviceDownloadStatus(Convert.ToInt32(DownloadingStatusMessagesForQT.strProductMismatch));
                            usb.Close();
                            this.BeginInvoke((System.Windows.Forms.MethodInvoker)delegate() { lbl_dash.Visible = true; });
                            EnabledDisabledButton(true);
                        }
                        else
                        {
                            new LogWriter(" Got SomthingElse");
                            StatusForQT__deviceDownloadStatus(Convert.ToInt32(DownloadingStatusMessagesForQT.strProductMismatch));
                            usb.Close();
                            this.BeginInvoke((System.Windows.Forms.MethodInvoker)delegate() { lbl_dash.Visible = true; });
                            EnabledDisabledButton(true);
                        }
                    }
                    else
                    {
                        new LogWriter(" Timeout error");
                        StatusForQT__deviceDownloadStatus(Convert.ToInt32(DownloadingStatusMessagesForQT.strCommunicationTimeout));
                        EnabledDisabledButton(true);
                        usb.Close();
                        this.BeginInvoke((System.Windows.Forms.MethodInvoker)delegate() { lbl_dash.Visible = true; });
                        EnabledDisabledButton(true);
                    }

                }
                else
                {
                    new LogWriter("<-------No reply for 11 bytes:- " + result.ToString());
                    StatusForQT__deviceDownloadStatus(Convert.ToInt32(DownloadingStatusMessagesForQT.strDeviceIsNotConnected));
                    this.BeginInvoke((System.Windows.Forms.MethodInvoker)delegate() { lbl_dash.Visible = false; });
                    EnabledDisabledButton(true);
                }

            }
            else
            {
                StatusForQT__deviceDownloadStatus(Convert.ToInt32(DownloadingStatusMessagesForQT.strVersionUpdateAvilable));
            }
        }

        private void cmb_PortName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void rdB_Ethernet_CheckedChanged(object sender, EventArgs e)
        {
            if (rdB_Ethernet.Checked == true)
            {
               // lbl_IP.Enabled = true;
                ipAddrCntrl_ipaddrWiFi.Enabled = true;
                lbl_portName.Visible = false;
                cmb_PortName.Visible = false;
                chkB_AutoSearch.Visible = true;
            }
            else 
            {
                //lbl_IP.Enabled = false;
                ipAddrCntrl_ipaddrWiFi.Enabled = false;
                lbl_portName.Visible = false;
                cmb_PortName.Visible = false;
                chkB_AutoSearch.Visible = false;
            }
        }

        private void grpB_Download_Enter(object sender, EventArgs e)
        {

        }

        private void rdB_Browser_CheckedChanged(object sender, EventArgs e)
        {
            if (rdB_Browser.Checked == true)
            {
                chkB_Enabled.Visible = true;
            }
            else 
            {
                chkB_Enabled.Visible = false;
            }
        }

        private void rdB_OS_CheckedChanged(object sender, EventArgs e)
        {
            if (rdB_OS.Checked == true)
            {
                chkB_Enabled.Visible = false;
                chkB_Enabled.Checked = false;
            }
            else
            {
                chkB_Enabled.Visible = false;
            }
        }
      

        private void chkB_SplashScreen_CheckedChanged(object sender, EventArgs e)
        {
            if (chkB_Enabled.Checked == true)
            {
               
                ClassList.CommonConstants._strSplashScreenChecked = true;
                using (OpenFileDialog dlg = new OpenFileDialog())
                {
                    dlg.Title = "Open Image";
                    //dlg.Filter = "bmp files (*.bmp)|*.bmp";
                    dlg.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        PictureBox PictureBox1 = new PictureBox();

                        // Create a new Bitmap object from the picture file on disk,
                        // and assign that to the PictureBox.Image property
                        PictureBox1.Image = new Bitmap(dlg.FileName);
                        ClassList.CommonConstants.IMG_Path = dlg.FileName.ToString();
                        FileInfo fi = new FileInfo(dlg.FileName);
                        if (fi.Exists)
                        {
                            lbl_ValidateIamge.Visible = false;
                        }
                        else
                        {
                            lbl_ValidateIamge.Visible = true;
                        }
                        string extension = fi.Extension;
                        if (extension == ".bmp")
                        {
                            ClassList.CommonConstants.imageExtension = 2;
                        }
                        else if (extension == ".png")
                        {
                            ClassList.CommonConstants.imageExtension = 1;
                        }
                        else if (extension == ".jpg" || extension == ".jpeg")
                        {
                            ClassList.CommonConstants.imageExtension = 0;
                        }
                        var cc = Convert.ToByte(ClassList.CommonConstants.imageExtension);
                        #region testing
                        // byte[] _imgDetails = new byte[3];
                        // _imgDetails[0] = Convert.ToByte(ClassList.CommonConstants.imageExtension);

                        // fi = new FileInfo(dlg.FileName);
                        // // _fileSize = CommonConstants.RawSerialize(fi.Length);
                        // byte[] b = new byte[2];

                        ////var  b1 = BitConverter.GetBytes(Convert.ToInt16(fi.Length));
                        //// b = BitConverter.GetBytes(fi.Length);
                        // _imgDetails = CommonConstants.RawSerialize(fi.Length);
                        #endregion
                    }
                    else 
                    {
                        chkB_Enabled.Checked = false;
                        lbl_ValidateIamge.Visible = true;
                    }
                }
                //chkB_Disabled.Checked = true;
            }
            else 
            {
                ClassList.CommonConstants._strSplashScreenChecked = false;
            }
        }

         
        private void chkB_AutoSearch_CheckedChanged(object sender, EventArgs e)
        {
            if (chkB_AutoSearch.Checked == true)
            {
                FrmAutoSearchIP AutoSearch = new FrmAutoSearchIP();
                AutoSearch.ShowDialog();
                ipAddrCntrl_ipaddrWiFi.Clear();
                ipAddrCntrl_ipaddrWiFi.Text = string.IsNullOrEmpty(ClassList.CommonConstants.FinalBindingIP)?"192.168.0.153":ClassList.CommonConstants.FinalBindingIP;
                chkB_AutoSearch.Checked = false;
            }
        }

        private void chkB_Disabled_CheckedChanged(object sender, EventArgs e)
        {
            chkB_Enabled.Checked = false;
        }

       
    }

    #region Public Properties
    static class SetValues
    {        
        private static string set_portname;
        public static string Set_PortName
        {
            get
            {
                return set_portname;
            }
            set
            {
                set_portname = value;
            }
        }

        private static string set_slot1;
        public static string Set_Slot1
        {
            get
            {
                return set_slot1;
            }
            set
            {
                set_slot1 = value;
            }
        }

        private static string set_username;
        public static string Set_UserName
        {
            get
            {
                return set_username;
            }
            set
            {
                set_username = value;
            }

        }

        private static string set_pcname;
        public static string Set_PCName
        {
            get
            {
                return set_pcname;
            }
            set
            {
                set_pcname = value;
            }
        }

        private static bool set_Continuous;
        public static bool Set_Continuous
        {
            get
            {
                return set_Continuous;
            }
            set
            {
                set_Continuous = value;
            }
        }

        private static bool set_Selective;
        public static bool Set_Selective
        {
            get
            {
                return set_Selective;
            }
            set
            {
                set_Selective = value;
            }
        }

        private static int set_BaseModelId;
        public static int Set_BaseModelId
        {
            get
            {
                return set_BaseModelId;
            }
            set
            {
                set_BaseModelId = value;
            }
        }

        #region ShitalG
        private static bool set_RunHaltSwitchTest;
        public static bool Set_RunHaltSwitchTest
        {
            get
            {
                return set_RunHaltSwitchTest;
            }
            set
            {
                set_RunHaltSwitchTest = value;
            }
        }

        private static bool set_RS232Test;
        public static bool Set_RS232Test
        {
            get
            {
                return set_RS232Test;
            }
            set
            {
                set_RS232Test = value;
            }
        }

        private static bool set_RS485Test;
        public static bool Set_RS485Test
        {
            get
            {
                return set_RS485Test;
            }
            set
            {
                set_RS485Test = value;
            }
        }

        private static bool set_PowerDownSave;
        public static bool Set_PowerDownSave
        {
            get
            {
                return set_PowerDownSave;
            }
            set
            {
                set_PowerDownSave = value;
            }
        }

        private static bool set_RetentiveMemoryTest;
        public static bool Set_RetentiveMemoryTest
        {
            get
            {
                return set_RetentiveMemoryTest;
            }
            set
            {
                set_RetentiveMemoryTest = value;
            }
        }

        private static bool set_SetRTC;
        public static bool Set_SetRTC
        {
            get
            {
                return set_SetRTC;
            }
            set
            {
                set_SetRTC = value;
            }
        }

        private static bool set_TestRTC;
        public static bool Set_TestRTC
        {
            get
            {
                return set_TestRTC;
            }
            set
            {
                set_TestRTC = value;
            }
        }

        private static bool set_DisplayRTC;
        public static bool Set_DisplayRTC
        {
            get
            {
                return set_DisplayRTC;
            }
            set
            {
                set_DisplayRTC = value;
            }
        }
        private static bool set_USBStickTest;
        public static bool Set_USBStickTest
        {
            get
            {
                return set_USBStickTest;
            }
            set
            {
                set_USBStickTest = value;
            }
        }


        private static bool set_USBTest;
        public static bool Set_USBTest
        {
            get
            {
                return set_USBTest;
            }
            set
            {
                set_USBTest = value;
            }
        }

        private static bool set_DigitalInputTest;
        public static bool Set_DigitalInputTest
        {
            get
            {
                return set_DigitalInputTest;
            }
            set
            {
                set_DigitalInputTest = value;
            }
        }

        private static bool set_DigitalOutputTest;
        public static bool Set_DigitalOutputTest
        {
            get
            {
                return set_DigitalOutputTest;
            }
            set
            {
                set_DigitalOutputTest = value;
            }
        }

        private static bool set_HighSpeedInputTest;
        public static bool Set_HighSpeedInputTest
        {
            get
            {
                return set_HighSpeedInputTest;
            }
            set
            {
                set_HighSpeedInputTest = value;
            }
        }

        private static bool set_PWMOutputTest;
        public static bool Set_PWMOutputTest
        {
            get
            {
                return set_PWMOutputTest;
            }
            set
            {
                set_PWMOutputTest = value;
            }
        }

        private static bool set_QuadratureInputTest;
        public static bool Set_QuadratureInputTest
        {
            get
            {
                return set_QuadratureInputTest;
            }
            set
            {
                set_QuadratureInputTest = value;
            }
        }
       
        private static bool set_PowerLEDTest;
        public static bool Set_PowerLEDTest
        {
            get
            {
                return set_PowerLEDTest;
            }
            set
            {
                set_PowerLEDTest = value;
            }
        }        
        
        private static bool set_RunLEDTest;
        public static bool Set_RunLEDTest
        {
            get
            {
                return set_RunLEDTest;
            }
            set
            {
                set_RunLEDTest = value;
            }
        }

        private static bool set_InputLEDTest;
        public static bool Set_InputLEDTest
        {
            get
            {
                return set_InputLEDTest;
            }
            set
            {
                set_InputLEDTest = value;
            }
        }

        private static bool set_OutputLEDTest;
        public static bool Set_OutputLEDTest
        {
            get
            {
                return set_OutputLEDTest;
            }
            set
            {
                set_OutputLEDTest = value;
            }
        }

        private static bool set_COM1LEDTest;
        public static bool Set_COM1LEDTest
        {
            get
            {
                return set_COM1LEDTest;
            }
            set
            {
                set_COM1LEDTest = value;
            }
        }

        private static bool set_COM2LEDTest;
        public static bool Set_COM2LEDTest
        {
            get
            {
                return set_COM2LEDTest;
            }
            set
            {
                set_COM2LEDTest = value;
            }
        }

        private static bool set_USBLEDTest;
        public static bool Set_USBLEDTest
        {
            get
            {
                return set_USBLEDTest;
            }
            set
            {
                set_USBLEDTest = value;
            }
        }


        private static bool set_ErrorLEDTest;
        public static bool Set_ErrorLEDTest
        {
            get
            {
                return set_ErrorLEDTest;
            }
            set
            {
                set_ErrorLEDTest = value;
            }
        }

        private static bool set_DigitalInputTest_16IP;
        public static bool Set_DigitalInputTest_16IP
        {
            get
            {
                return set_DigitalInputTest_16IP;
            }
            set
            {
                set_DigitalInputTest_16IP = value;
            }
        }

        private static bool set_DigitalOutputTest_16OP;
        public static bool Set_DigitalOutputTest_16OP
        {
            get
            {
                return set_DigitalOutputTest_16OP;
            }
            set
            {
                set_DigitalOutputTest_16OP = value;
            }
        }

        private static bool set_BaseMsgFlag;
        public static bool Set_BaseMsgFlag
        {
            get
            {
                return set_BaseMsgFlag;
            }
            set
            {
                set_BaseMsgFlag = value;
            }
        }

        private static bool set_AnalogVoltCalibration;
        public static bool Set_AnalogVoltCalibration
        {
            get
            {
                return set_AnalogVoltCalibration;
            }
            set
            {
                set_AnalogVoltCalibration = value;
            }
        }

        private static bool set_AnalogCurrentCalibration;
        public static bool Set_AnalogCurrentCalibration
        {
            get
            {
                return set_AnalogCurrentCalibration;
            }
            set
            {
                set_AnalogCurrentCalibration = value;
            }
        }

        private static bool set_AnalogVoltTest_0to10V;
        public static bool Set_AnalogVoltTest_0to10V
        {
            get
            {
                return set_AnalogVoltTest_0to10V;
            }
            set
            {
                set_AnalogVoltTest_0to10V = value;
            }
        }

        private static bool set_AnalogVoltTest_0to5V;
        public static bool Set_AnalogVoltTest_0to5V
        {
            get
            {
                return set_AnalogVoltTest_0to5V;
            }
            set
            {
                set_AnalogVoltTest_0to5V = value;
            }
        }

        private static bool set_AnalogCurrentTest_0t020mA;
        public static bool Set_AnalogCurrentTest_0t020mA
        {
            get
            {
                return set_AnalogCurrentTest_0t020mA;
            }
            set
            {
                set_AnalogCurrentTest_0t020mA = value;
            }
        }

        private static bool set_AnalogCurrentTest_4t020mA;
        public static bool Set_AnalogCurrentTest_4t020mA
        {
            get
            {
                return set_AnalogCurrentTest_4t020mA;
            }
            set
            {
                set_AnalogCurrentTest_4t020mA = value;
            }
        }

        private static bool set_AnalogOPCurrentCalib;
        public static bool Set_AnalogOPCurrentCalib
        {
            get
            {
                return set_AnalogOPCurrentCalib;
            }
            set
            {
                set_AnalogOPCurrentCalib = value;
            }
        }

        private static bool set_AnalogOPVoltageCalib;
        public static bool Set_AnalogOPVoltageCalib
        {
            get
            {
                return set_AnalogOPVoltageCalib;
            }
            set
            {
                set_AnalogOPVoltageCalib = value;
            }
        }

        private static bool set_AnalogOPCurrentTest;
        public static bool Set_AnalogOPCurrentTest
        {
            get
            {
                return set_AnalogOPCurrentTest;
            }
            set
            {
                set_AnalogOPCurrentTest = value;
            }
        }

        private static bool set_AnalogOPVoltageTest;
        public static bool Set_AnalogOPVoltageTest
        {
            get
            {
                return set_AnalogOPVoltageTest;
            }
            set
            {
                set_AnalogOPVoltageTest = value;
            }
        }

        private static bool set_CalibrationTest;
        public static bool Set_CalibrationTest
        {
            get
            {
                return set_CalibrationTest;
            }
            set
            {
                set_CalibrationTest = value;
            }
        }

        private static bool set_PowerSupplyTest;
        public static bool Set_PowerSupplyTest
        {
            get
            {
                return set_PowerSupplyTest;
            }
            set
            {
                set_PowerSupplyTest = value;
            }
        }

        private static bool set_ExpansionTest;
        public static bool Set_ExpansionTest
        {
            get
            {
                return set_ExpansionTest;
            }
            set
            {
                set_ExpansionTest = value;
            }
        }

        private static bool set_USBDetected;
        public static bool SetUSBDetected
        {
            get
            {
                return set_USBDetected;
            }
            set
            {
                set_USBDetected = value;
            }
        }
        #endregion       

        #region ShitalG_MsgFlag
        private static bool set_IPVoltageFlag;
        public static bool Set_IPVoltageFlag
        {
            get
            {
                return set_IPVoltageFlag;
            }
            set
            {
                set_IPVoltageFlag = value;
            }
        }

        private static bool set_IPCurrentFlag;
        public static bool Set_IPCurrentFlag
        {
            get
            {
                return set_IPCurrentFlag;
            }
            set
            {
                set_IPCurrentFlag = value;
            }
        }

        private static bool set_IPmVFlag;
        public static bool Set_IPmVFlag
        {
            get
            {
                return set_IPmVFlag;
            }
            set
            {
                set_IPmVFlag = value;
            }
        }

        private static bool set_IPTCFlag;
        public static bool Set_IPTCFlag
        {
            get
            {
                return set_IPTCFlag;
            }
            set
            {
                set_IPTCFlag = value;
            }
        }

        private static bool set_OPConnectorFlag;
        public static bool Set_OPConnectorFlag
        {
            get
            {
                return set_OPConnectorFlag;
            }
            set
            {
                set_OPConnectorFlag = value;
            }
        }

        private static bool set_OPConnectorFlag_CH3_CH4;
        public static bool Set_OPConnectorFlag_CH3_CH4
        {
            get
            {
                return set_OPConnectorFlag_CH3_CH4;
            }
            set
            {
                set_OPConnectorFlag_CH3_CH4 = value;
            }
        } 

        #endregion

        #region ShitalG Input

        private static bool set_Input_ConnectivityTest;
        public static bool Set_Input_ConnectivityTest
        {
            get
            {
                return set_Input_ConnectivityTest;
            }
            set
            {
                set_Input_ConnectivityTest = value;
            }
        }

        private static bool set_VoltageCalibration_0to10V;
        public static bool Set_VoltageCalibration_0to10V
        {
            get
            {
                return set_VoltageCalibration_0to10V;
            }
            set
            {
                set_VoltageCalibration_0to10V = value;
            }
        }

        private static bool set_MilliVoltCalibration;
        public static bool Set_MilliVoltCalibration
        {
            get
            {
                return set_MilliVoltCalibration;
            }
            set
            {
                set_MilliVoltCalibration = value;
            }
        }

        private static bool set_CurrentCalibration_0to20mA;
        public static bool Set_CurrentCalibration_0to20mA
        {
            get
            {
                return set_CurrentCalibration_0to20mA;
            }
            set
            {
                set_CurrentCalibration_0to20mA = value;
            }
        }
        private static bool set_CurrentCalibration_4to20mA;
        public static bool Set_CurrentCalibration_4to20mA
        {
            get
            {
                return set_CurrentCalibration_4to20mA;
            }
            set
            {
                set_CurrentCalibration_4to20mA = value;
            }
        }

        private static bool set_RTD_PT100Calibration;
        public static bool Set_RTD_PT100Calibration
        {
            get
            {
                return set_RTD_PT100Calibration;
            }
            set
            {
                set_RTD_PT100Calibration = value;
            }
        }

        private static bool set_RTD_PT1000Calibration;
        public static bool Set_RTD_PT1000Calibration
        {
            get
            {
                return set_RTD_PT1000Calibration;
            }
            set
            {
                set_RTD_PT1000Calibration = value;
            }
        }

        private static bool set_TCCalibration;
        public static bool Set_TCCalibration
        {
            get
            {
                return set_TCCalibration;
            }
            set
            {
                set_TCCalibration = value;
            }
        }

        private static bool set_VoltageTesting_0to10V;
        public static bool Set_VoltageTesting_0to10V
        {
            get
            {
                return set_VoltageTesting_0to10V;
            }
            set
            {
                set_VoltageTesting_0to10V = value;
            }
        }

        private static bool set_VoltageTesting_0to5V;
        public static bool Set_VoltageTesting_0to5V
        {
            get
            {
                return set_VoltageTesting_0to5V;
            }
            set
            {
                set_VoltageTesting_0to5V = value;
            }
        }

        private static bool set_VoltageTesting_10to10V;
        public static bool Set_VoltageTesting_10to10V
        {
            get
            {
                return set_VoltageTesting_10to10V;
            }
            set
            {
                set_VoltageTesting_10to10V = value;
            }
        }


        private static bool set_mVTesting_0to100mV;
        public static bool Set_mVTesting_0to100mV
        {
            get
            {
                return set_mVTesting_0to100mV;
            }
            set
            {
                set_mVTesting_0to100mV = value;
            }
        }

        private static bool set_mVTesting_0to50mV;
        public static bool Set_mVTesting_0to50mV
        {
            get
            {
                return set_mVTesting_0to50mV;
            }
            set
            {
                set_mVTesting_0to50mV = value;
            }
        }

        private static bool set_CurrentTesting_0to20mA;
        public static bool Set_CurrentTesting_0to20mA
        {
            get
            {
                return set_CurrentTesting_0to20mA;
            }
            set
            {
                set_CurrentTesting_0to20mA = value;
            }
        }

        private static bool set_CurrentTesting_4to20mA;
        public static bool Set_CurrentTesting_4to20mA
        {
            get
            {
                return set_CurrentTesting_4to20mA;
            }
            set
            {
                set_CurrentTesting_4to20mA = value;
            }
        }

        private static bool set_RTD_PT100Testing;
        public static bool Set_RTD_PT100Testing
        {
            get
            {
                return set_RTD_PT100Testing;
            }
            set
            {
                set_RTD_PT100Testing = value;
            }
        }

        private static bool set_RTD_PT1000Testing;
        public static bool Set_RTD_PT1000Testing
        {
            get
            {
                return set_RTD_PT1000Testing;
            }
            set
            {
                set_RTD_PT1000Testing = value;
            }
        }

        private static bool set_TCTesting;
        public static bool Set_TCTesting
        {
            get
            {
                return set_TCTesting;
            }
            set
            {
                set_TCTesting = value;
            }
        }
        #endregion

        #region ShitalG Output

        private static bool set_Output_ConnectivityTest;
        public static bool Set_Output_ConnectivityTest
        {
            get
            {
                return set_Output_ConnectivityTest;
            }
            set
            {
                set_Output_ConnectivityTest = value;
            }
        }

        private static bool set_OPVoltageCalibration_0to10V;
        public static bool Set_OPVoltageCalibration_0to10V
        {
            get
            {
                return set_OPVoltageCalibration_0to10V;
            }
            set
            {
                set_OPVoltageCalibration_0to10V = value;
            }
        }

        private static bool set_Output_VoltageCalibration_0to5V;
        public static bool Set_Output_VoltageCalibration_0to5V
        {
            get
            {
                return set_Output_VoltageCalibration_0to5V;
            }
            set
            {
                set_Output_VoltageCalibration_0to5V = value;
            }
        }

        private static bool set_OPCurrentCalibration_0to20mA;
        public static bool Set_OPCurrentCalibration_0to20mA
        {
            get
            {
                return set_OPCurrentCalibration_0to20mA;
            }
            set
            {
                set_OPCurrentCalibration_0to20mA = value;
            }
        }

        private static bool set_OPCurrentCalibration_4to20mA;
        public static bool Set_OPCurrentCalibration_4to20mA
        {
            get
            {
                return set_OPCurrentCalibration_4to20mA;
            }
            set
            {
                set_OPCurrentCalibration_4to20mA = value;
            }
        }

        private static bool set_OPVoltageTesting_0to10V;
        public static bool Set_OPVoltageTesting_0to10V
        {
            get
            {
                return set_OPVoltageTesting_0to10V;
            }
            set
            {
                set_OPVoltageTesting_0to10V = value;
            }
        }

        private static bool set_Output_VoltageTesting_0to5V;
        public static bool Set_Output_VoltageTesting_0to5V
        {
            get
            {
                return set_Output_VoltageTesting_0to5V;
            }
            set
            {
                set_Output_VoltageTesting_0to5V = value;
            }
        }


        private static bool set_OPCurrrentTesting_0to20mA;
        public static bool Set_OPCurrrentTesting_0to20mA
        {
            get
            {
                return set_OPCurrrentTesting_0to20mA;
            }
            set
            {
                set_OPCurrrentTesting_0to20mA = value;
            }
        }

        private static bool set_OPCurrrentTesting_4to20mA;
        public static bool Set_OPCurrrentTesting_4to20mA
        {
            get
            {
                return set_OPCurrrentTesting_4to20mA;
            }
            set
            {
                set_OPCurrrentTesting_4to20mA = value;
            }
        }

        private static bool set_OutputVoltageCalibration;
        public static bool Set_OutputVoltageCalibration
        {
            get
            {
                return set_OutputVoltageCalibration;
            }
            set
            {
                set_OutputVoltageCalibration = value;
            }
        }

        private static bool set_OutputVoltageCalibration_CH3_CH4;
        public static bool Set_OutputVoltageCalibration_CH3_CH4
        {
            get
            {
                return set_OutputVoltageCalibration_CH3_CH4;
            }
            set
            {
                set_OutputVoltageCalibration_CH3_CH4 = value;
            }
        }

        private static bool set_OutputCurrentCalibration;
        public static bool Set_OutputCurrentCalibration
        {
            get
            {
                return set_OutputCurrentCalibration;
            }
            set
            {
                set_OutputCurrentCalibration = value;
            }
        }

        private static bool set_OutputCurrentCalibration_CH3_CH4;
        public static bool Set_OutputCurrentCalibration_CH3_CH4
        {
            get
            {
                return set_OutputCurrentCalibration_CH3_CH4;
            }
            set
            {
                set_OutputCurrentCalibration_CH3_CH4 = value;
            }
        }

        private static bool set_OutputVoltageTesting_0to10V;
        public static bool Set_OutputVoltageTesting_0to10V
        {
            get
            {
                return set_OutputVoltageTesting_0to10V;
            }
            set
            {
                set_OutputVoltageTesting_0to10V = value;
            }
        }

        private static bool set_OutputVoltageTesting_0to10V_CH3_CH4;
        public static bool Set_OutputVoltageTesting_0to10V_CH3_CH4
        {
            get
            {
                return set_OutputVoltageTesting_0to10V_CH3_CH4;
            }
            set
            {
                set_OutputVoltageTesting_0to10V_CH3_CH4 = value;
            }
        }

        private static bool set_OutputCurrentTesting_4to20mA;
        public static bool Set_OutputCurrentTesting_4to20mA
        {
            get
            {
                return set_OutputCurrentTesting_4to20mA;
            }
            set
            {
                set_OutputCurrentTesting_4to20mA = value;
            }
        }

        private static bool set_OutputCurrentTesting_4to20mA_CH3_CH4;
        public static bool Set_OutputCurrentTesting_4to20mA_CH3_CH4
        {
            get
            {
                return set_OutputCurrentTesting_4to20mA_CH3_CH4;
            }
            set
            {
                set_OutputCurrentTesting_4to20mA_CH3_CH4 = value;
            }
        }
        #endregion

        private static bool flag;
        public static bool IsProductionCheck
        {
            get
            {
                return flag;
            }
            set
            {
                flag = value;
            }
        }

        private static int set_AutoIncreementOrderNumber;
        public static int SetAutoIncreementOrderNumber
        {
            get
            {
                return set_AutoIncreementOrderNumber;
            }
            set
            {
                set_AutoIncreementOrderNumber = value;
            }
        }

        private static int set_AutoIncreementSerialNumber;
        public static int SetAutoIncreementSerialNumber
        {
            get
            {
                return set_AutoIncreementSerialNumber;
            }
            set
            {
                set_AutoIncreementSerialNumber = value;
            }
        }

        private static string set_ProductName;
        public static string Set_ProductName
        {
            get
            {
                return set_ProductName;
            }
            set
            {
                set_ProductName = value;
            }
        }

        private static string set_startTime;
        public static string Set_startTime
        {
            get
            {
                return set_startTime;
            }
            set
            {
                set_startTime = value;
            }
        }

        private static string set_WorkOrderNumber;
        public static string SetWorkOrderNumber
        {
            get
            {
                return set_WorkOrderNumber;
            }
            set
            {
                set_WorkOrderNumber = value;
            }
        }

        private static string set_serialNu;
        public static string Set_SerialNu
        {
            get
            {
                return set_serialNu;
            }
            set
            {
                set_serialNu = value;
            }
        }

        private static string set_path;
        public static string Set_Path
        {
            get
            {
                return set_path;
            }
            set
            {
                set_path = value;
            }
        }

        private static int _productId;
        public static int ProductId
        {
            get
            {
                return _productId;
            }
            set
            {
                _productId = value;
            }
        }

        private static string ProductSeriesName;
        public static string Set_ProductSeriesName
        {
            get
            {
                return ProductSeriesName;
            }
            set
            {
                ProductSeriesName = value;
            }
        }

        private static string set_BaseName;
        public static string Set_BaseName
        {
            get
            {
                return set_BaseName;
            }
            set
            {
                set_BaseName = value;
            }
        }

        private static bool _timeOut;
        public static bool TimeOut
        {
            get
            {
                return _timeOut;
            }
            set
            {
                _timeOut = value;
            }
        }

        private static int set_ID;
        public static int Set_id
        {
            get
            {
                return set_ID;
            }
            set
            {
                set_ID = value;
            }
        }

        private static int set_ExpansionBaseID;
        public static int Set_ExpansionBaseID
        {
            get
            {
                return set_ExpansionBaseID;
            }
            set
            {
                set_ExpansionBaseID = value;
            }
        }
        //added by saood khan
        private static bool set_EthernetTest;
        public static bool Set_EthernetTest
        {
            get
            {
                return set_EthernetTest;
            }
            set
            {
                set_EthernetTest = value;
            }
        }
        private static bool set_BatteryCalibration12V_24V;
        public static bool Set_BatteryCalibration12V_24V
        {
            get
            {
                return set_BatteryCalibration12V_24V;
            }
            set
            {
                set_BatteryCalibration12V_24V = value;
            }
        }
        private static bool set_SDCardTest;
        public static bool Set_SDCardTest
        {
            get
            {
                return set_SDCardTest;
            }
            set
            {
                set_SDCardTest = value;
            }
        }

        private static bool set_SDI12Test;
        public static bool Set_SDI12Test
        {
            get
            {
                return set_SDI12Test;
            }
            set
            {
                set_SDI12Test = value;
            }
        }
        private static bool set_BluetoothTest;
        public static bool Set_BluetoothTest
        {
            get
            {
                return set_BluetoothTest;
            }
            set
            {
                set_BluetoothTest = value;
            }
        }
        private static bool set_GSMTest;
        public static bool Set_GSMTest
        {
            get
            {
                return set_GSMTest;
            }
            set
            {
                set_GSMTest = value;
            }
        }
        private static bool set_GPRSTest;
        public static bool Set_GPRSTest
        {
            get
            {
                return set_GPRSTest;
            }
            set
            {
                set_GPRSTest = value;
            }
        }

        private static bool set_TouchScreenTest;
        public static bool Set_TouchScreenTest 
        {
            get 
            {
                return set_TouchScreenTest;
            }
            set
            {
                set_TouchScreenTest = value;
            }
        }

        private static bool set_LCDTest;
        public static bool Set_LCDTest
        {
            get
            {
                return set_LCDTest;
            }
            set
            {
                set_LCDTest = value;
            }
        }

        private static bool set_WiFiTest;
        public static bool Set_WiFiTest
        {
            get
            {
                return set_WiFiTest;
            }
            set
            {
                set_WiFiTest = value;
            }
        }
        private static bool set_DownlaodBar;
        public static bool Set_DownlaodBar
        {
            get
            {
                return set_DownlaodBar;
            }
            set
            {
                set_DownlaodBar = value;
            }
        }
    }
    #endregion
    
}