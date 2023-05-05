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

            LogData(Utilities.ReadResourceContent("ReportByLineMen"));

        }

        private void AddHtmlPanel()
        {
            HtmlPanel _htmlLabel = new HtmlPanel();

            _htmlLabel.Text = SampleHtmlPanelText;
            _htmlLabel.Top = 100;
            _htmlLabel.Left = 100;
            _htmlLabel.Height = 200;
            _htmlLabel.Width = 200;
            this.Controls.Add(_htmlLabel);
        }

        public static String SampleHtmlPanelText
        {
            get
            {
                return "This is an <b>HtmlPanel</b> with <span style=\"color: red\">colors</span> and links: <a href=\"http://htmlrenderer.codeplex.com/\">HTML Renderer</a>" +
                       "<div style=\"font-size: 1.2em; padding-top: 10px;\" >If there is more text than the size of the control scrollbars will appear.</div>" +
                       "<br/>Click me to change my <code>Text</code> property.";
            }
        }

        public static string GetStylesheet(string src)
        {
            if (src == "StyleSheet")
            {
                return @"h1, h2, h3 { color: navy; font-weight:normal; }
                    h1 { margin-bottom: .47em }
                    h2 { margin-bottom: .3em }
                    h3 { margin-bottom: .4em }
                    ul { margin-top: .5em }
                    ul li {margin: .25em}
                    body { font:10pt Tahoma }
		            pre  { border:solid 1px gray; background-color:#eee; padding:1em }
                    a:link { text-decoration: none; }
                    a:hover { text-decoration: underline; }
                    .gray    { color:gray; }
                    .example { background-color:#efefef; corner-radius:5px; padding:0.5em; }
                    .whitehole { background-color:white; corner-radius:10px; padding:15px; }
                    .caption { font-size: 1.1em }
                    .comment { color: green; margin-bottom: 5px; margin-left: 3px; }
                    .comment2 { color: green; }";
            }
            return null;
        }

        private void btnSubmit_Click_1(object sender, EventArgs e)
        {
            LogData("Process started");
            try
            {
                var filePath = ConfigurationManager.AppSettings["ExcelFilePath"];

                if (filePath == null) throw new ArgumentNullException("File Path Not found");

                var excelManager = new ExcelManager();

                //dataGridView1.DataSource = excelManager.ProcessData(filePath);

                reportPanel.Text = excelManager.ProcessData(filePath);// Utilities.ReadResourceContent("ReportByLineMen");

            }
            catch (Exception ex)
            {
                LogData(ex.ToString());
            }
        }
    }
}