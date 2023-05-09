using ExcelDataReader;
using ExcelDataReader.Core;
using ReadFromExcelSB.Helpers;
using ReadFromExcelSB.Managers;
using System.Configuration;
using TheArtOfDev.HtmlRenderer.WinForms;

namespace ReadFromExcelSB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        public void LogData(string log)
        {
            string logFilePath = $"{ConfigurationManager.AppSettings["LogFilePath"]}ExcelReports_{DateTime.Now.ToString("ddMMyyyy")}.log" ;
            string logData = $"{Environment.NewLine}{DateTime.Now.ToLongTimeString()}: {log} ";
            File.WriteAllText(logFilePath, logData);
            logTextBox.Text = $"{logData} {logTextBox.Text}";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           // AddHtmlPanel();

            //LogData(Utilities.ReadResourceContent("ReportByLineMen"));

        }

        private void AddHtmlPanel()
        {
            HtmlPanel _htmlLabel = new HtmlPanel();

           // _htmlLabel.Text = SampleHtmlPanelText;
            _htmlLabel.Top = 100;
            _htmlLabel.Left = 100;
            _htmlLabel.Height = 200;
            _htmlLabel.Width = 200;
            this.Controls.Add(_htmlLabel);
        }

      

        private void btnSubmit_Click_1(object sender, EventArgs e)
        {
            LogData("Process started");
            try
            {
                var filePath = ConfigurationManager.AppSettings["ExcelFilePath"];

                if (filePath == null) throw new ArgumentNullException("File Path Not found");

                var openXmlFacade = new ReportByLineMenManager();
                string outputHtml = openXmlFacade.GetReport(filePath);
                reportPanel.Text = outputHtml;

            }
            catch (Exception ex)
            {
                LogData(ex.ToString());
            }
        }

        private void LenMenReportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                var openXmlFacade = new ReportByLineMenManager();
                var filePath = ConfigurationManager.AppSettings["ExcelFilePath"];
                string output = openXmlFacade.DownloadExcel(filePath);
                lblMessage.Text = $"Excel report created in in {output}";
            }
            catch(Exception ex)
            {
                lblMessage.Text = ex.Message;
                LogData(ex.ToString());
            }
            

        }
    }
}