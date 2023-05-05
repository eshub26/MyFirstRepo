using ExcelDataReader;
using ExcelDataReader.Core;
using ReadFromExcelSB.Managers;
using System.Configuration;
using TheArtOfDev.HtmlRenderer.Core;

namespace ReadFromExcelSB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {



            LogData("Process started");
            try
            {
                var filePath = ConfigurationManager.AppSettings["ExcelFilePath"];

                if (filePath == null) throw new ArgumentNullException("File Path Not found");

                var excelManager = new ExcelManager();

                dataGridView1.DataSource = excelManager.ProcessData(filePath);

            }
            catch (Exception ex)
            {
                LogData(ex.ToString());
            }

        }

        public void LogData(string log)
        {
            logTextBox.Text = $"{DateTime.Now.ToLongTimeString()}: {log} {Environment.NewLine} {logTextBox.Text}";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TheArtOfDev.HtmlRenderer.WinForms.HtmlPanel _htmlLabel = new TheArtOfDev.HtmlRenderer.WinForms.HtmlPanel();

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
    }
}