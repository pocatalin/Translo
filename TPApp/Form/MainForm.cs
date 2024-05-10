using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xceed.Words.NET;

namespace Translao
{
    public partial class MainForm : Form
    {
        #region Constructor
        private Gradient gradient;
        private Size formSize;
        private string langIn = "ro";
        private string langOut = "en";
        private const string apiKey = "bbd3451dd1bf40ceab31dc67cf3c0f9d";
        private const string endpoint = "https://api.cognitive.microsofttranslator.com";
        private const string location = "westeurope";
        private readonly HttpClient client = new HttpClient();
        private CancellationTokenSource cancellationTokenSource;
        private List<Language> languages;
        private bool allowComboBoxIndexChanged = true;
        public MainForm()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.Icon = Properties.Resources.icon_t;
            gradient = new Gradient(this, Color.White, Color.Black, Gradient.GradientType.Angular);
            this.Load += MainForm_Load;
            tbIn.TextChanged += TbText_TextChanged;
            client.Timeout = TimeSpan.FromSeconds(30);
            LoadLanguages();
            cmbIn.SelectedIndexChanged += cmbIn_SelectedIndexChanged;
            cmbOut.SelectedIndexChanged += cmbOut_SelectedIndexChanged;
            cmbIn.DropDown += comboBox_DropDown;
            cmbOut.DropDown += comboBox_DropDown;
            this.Load += MainForm_Load;
            this.Resize += MainForm_Resize;
            formSize = this.ClientSize;
        }
        private void MainForm_Resize(object sender, EventArgs e)
        {
            int widthChange = this.ClientSize.Width - formSize.Width;

            tbIn.Width += widthChange / 2;

            int newTbOutX = tbOut.Location.X - (widthChange / 2);

            if (newTbOutX < 0)
            {
                int excessWidth = Math.Abs(newTbOutX);

                tbOut.Width -= excessWidth;

                tbOut.Location = new Point(0, tbOut.Location.Y);
            }
            else
            {
                tbOut.Width += widthChange / 2;
                tbOut.Location = new Point(newTbOutX, tbOut.Location.Y);
            }
            int newCmbOutX = cmbOut.Location.X - (widthChange / 2);

            cmbIn.Width += widthChange / 2;
            cmbOut.Width += widthChange / 2;

            if (newCmbOutX < 0)
            {
                int excessWidth = Math.Abs(newCmbOutX);
                cmbOut.Width -= excessWidth;
                cmbOut.Location = new Point(0, cmbOut.Location.Y);
            }
            else
            {
                cmbOut.Location = new Point(newCmbOutX, cmbOut.Location.Y);
            }

            int switchButtonX = cmbIn.Right + 3;
            int switchButtonY = (cmbIn.Top + cmbIn.Bottom - btnSwitch.Height) / 2;

            int switchButtonRight = cmbOut.Left - 3;
            switchButtonX = Math.Min(switchButtonX, switchButtonRight - btnSwitch.Width);
            btnSwitch.Location = new Point(switchButtonX, switchButtonY);

            labelOut.Left = tbOut.Left - labelOut.Width + 69;

            formSize = this.ClientSize;
        }


        private async void MainForm_Load(object sender, EventArgs e)
        {
            cmbIn.SelectedItem = languages.FirstOrDefault(lang => lang.name == "Auto Detect");
            cmbOut.SelectedItem = languages.FirstOrDefault(lang => lang.name == "English");
            labelIn.Text = "Auto Detect";
            try
            {
                string translatedText = await TranslateText("Hello", "en", "ro");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        #region ComboBox
        private void comboBox_DropDown(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;

            int maxHeight = comboBox.ItemHeight * 11;
            comboBox.DropDownHeight = (comboBox.Items.Count > 10) ? maxHeight : comboBox.PreferredHeight;

        }
        private async void cmbIn_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnROIn.Highlight = false;
            btnENIn.Highlight = false;
            btnSPIn.Highlight = false;
            RepaintControls(tbIn, tbOut, cmbIn, cmbOut, btnSwitch, labelOut);
            if (allowComboBoxIndexChanged)
            {

                if (cmbIn.SelectedItem != null)
                {
                    Language selectedLanguage = (Language)cmbIn.SelectedItem;
                    langIn = selectedLanguage.code;
                    string langInName = selectedLanguage.name;
                    labelIn.Text = langInName;

                    await TranslateAndDisplay();
                }
            }
        }

        private async void cmbOut_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnROOut.Highlight = false;
            btnENOut.Highlight = false;
            btnSPOut.Highlight = false;
            RepaintControls(tbIn, tbOut, cmbIn, cmbOut, btnSwitch, labelOut);
            if (allowComboBoxIndexChanged)
            {

                if (cmbOut.SelectedItem != null)
                {
                    Language selectedLanguage = (Language)cmbOut.SelectedItem;
                    langOut = selectedLanguage.code;
                    string langInName = selectedLanguage.name;
                    labelOut.Text = langInName;

                    await TranslateAndDisplay();
                }
            }
        }

        private void LoadLanguages()
        {
            byte[] bytes = Properties.Resources.languages;
            string json = System.Text.Encoding.UTF8.GetString(bytes);

            languages = JsonConvert.DeserializeObject<List<Language>>(json);
            BindLanguagesToComboBoxOut();
            BindLanguagesToComboBoxIn();
        }


        private void BindLanguagesToComboBoxIn()
        {
            cmbIn.DataSource = languages;
            cmbIn.DisplayMember = "name";
            cmbIn.ValueMember = "code";
        }
        private void BindLanguagesToComboBoxOut()
        {
            List<Language> cmbOutLanguages = new List<Language>(languages);
            cmbOutLanguages.RemoveAll(lang => lang.name == "Auto Detect");
            cmbOut.DataSource = cmbOutLanguages;
            cmbOut.DisplayMember = "name";
            cmbOut.ValueMember = "code";
        }
        #endregion
        #region Tasks
        private async Task TranslateAndDisplay()
        {
            string textToTranslate = tbIn.Text.Trim();

            if (string.IsNullOrEmpty(textToTranslate))
            {
                tbOut.Text = "";
                return;
            }

            if (string.IsNullOrEmpty(langIn) || string.IsNullOrEmpty(langOut))
            {
                MessageBox.Show("Please select both input and output languages.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (langIn == "Auto Detect")
            {
                langIn = await DetectLanguage(textToTranslate);
            }

            string translatedText = await TranslateText(textToTranslate, langIn, langOut);
            tbOut.Text = translatedText;
        }

        private async Task<string> DetectLanguage(string text)
        {
            string route = "/detect?api-version=3.0";
            object[] body = new object[] { new { Text = text } };
            var requestBody = JsonConvert.SerializeObject(body);

            using (var request = new HttpRequestMessage())
            {
                request.Method = HttpMethod.Post;
                request.RequestUri = new Uri(endpoint + route);
                request.Content = new StringContent(requestBody, Encoding.UTF8, "application/json");
                request.Headers.Add("Ocp-Apim-Subscription-Key", apiKey);
                request.Headers.Add("Ocp-Apim-Subscription-Region", location);

                HttpResponseMessage response = await client.SendAsync(request).ConfigureAwait(false);
                string result = await response.Content.ReadAsStringAsync();
                dynamic detectionResult = JsonConvert.DeserializeObject(result);
                string detectedLanguage = detectionResult[0].language;
                return detectedLanguage;
            }
        }
        private async Task<string> ExtractTextFromWord(string filePath)
        {
            try
            {
                return await Task.Run(() =>
                {
                    using (DocX docX = DocX.Load(filePath))
                    {
                        return docX.Text;
                    }
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error extracting text from Word file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
        }
        private async Task<string> ExtractTextFromPdf(string filePath)
        {
            return await Task.Run(() =>
            {
                StringBuilder textBuilder = new StringBuilder();

                using (PdfDocument pdfDocument = new PdfDocument(new PdfReader(filePath)))
                {
                    for (int page = 1; page <= pdfDocument.GetNumberOfPages(); page++)
                    {
                        var pageText = PdfTextExtractor.GetTextFromPage(pdfDocument.GetPage(page));
                        textBuilder.Append(pageText);
                    }
                }

                return textBuilder.ToString();
            });
        }

        private async Task<string> TranslateText(string text, string fromLanguage, string toLanguage)
        {
            string route = $"/translate?api-version=3.0&from={fromLanguage}&to={toLanguage}";
            object[] body = new object[] { new { Text = text } };
            var requestBody = JsonConvert.SerializeObject(body);

            using (var request = new HttpRequestMessage())
            {
                request.Method = HttpMethod.Post;
                request.RequestUri = new Uri(endpoint + route);
                request.Content = new StringContent(requestBody, Encoding.UTF8, "application/json");
                request.Headers.Add("Ocp-Apim-Subscription-Key", apiKey);
                request.Headers.Add("Ocp-Apim-Subscription-Region", location);

                HttpResponseMessage response = await client.SendAsync(request).ConfigureAwait(false);
                string result = await response.Content.ReadAsStringAsync();
                dynamic translatedResult = JsonConvert.DeserializeObject(result);
                string translatedText = translatedResult[0].translations[0].text;
                return translatedText;
            }
        }
        #endregion
        #region TextBox

        private async void TbText_TextChanged(object sender, EventArgs e)
        {
            try
            {
                cancellationTokenSource?.Cancel();
                cancellationTokenSource = new CancellationTokenSource();

                await Task.Delay(500, cancellationTokenSource.Token);

                string textToTranslate = tbIn.Text.Trim();

                if (string.IsNullOrEmpty(textToTranslate))
                {
                    tbOut.Text = "";
                    return;
                }
                if (cmbIn.SelectedItem != null && ((Language)cmbIn.SelectedItem).name == "Auto Detect")
                {
                    string detectedLanguage = await DetectLanguage(textToTranslate);

                    if (languages.Any(lang => lang.code == detectedLanguage))
                    {
                        cmbIn.SelectedValue = detectedLanguage;
                        langIn = detectedLanguage;
                    }
                    else
                    {
                        MessageBox.Show("Detected language is not supported.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                await TranslateAndDisplay();
            }
            catch (OperationCanceledException)
            {
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
        #region Button&Panel
        private void btnSwitch_Click(object sender, EventArgs e)
        {
            string tempLang = langIn;
            langIn = langOut;
            langOut = tempLang;
            string switchText = tbIn.Text;
            tbIn.Text = tbOut.Text;
            tbOut.Text = switchText;

            UpdateButtonHighlights();
            TbText_TextChanged(null, EventArgs.Empty);
            UpdateComboBoxes();
            RepaintControls(tbIn, tbOut, cmbIn, cmbOut, btnSwitch, labelOut, btnENIn, btnENOut, btnROIn, btnROOut, btnSPIn, btnSPOut, btnFRIn, btnFROut); TbText_TextChanged(null, EventArgs.Empty);


        }
        private void RepaintControls(params Control[] controls)
        {
            foreach (Control control in controls)
            {
                control.Invalidate();
                control.Update();
            }
        }


        private void UpdateButtonHighlights()
        {
            btnROIn.Highlight = langIn == "ro";
            btnENIn.Highlight = langIn == "en";
            btnSPIn.Highlight = langIn == "es";
            btnFRIn.Highlight = langIn == "fr";

            btnROOut.Highlight = langOut == "ro";
            btnENOut.Highlight = langOut == "en";
            btnSPOut.Highlight = langOut == "es";
            btnFROut.Highlight = langOut == "fr";

        }

        private async void UpdateComboBoxes()
        {
            allowComboBoxIndexChanged = false;

            cmbIn.SelectedValue = langIn;

            cmbOut.SelectedValue = langOut;

            allowComboBoxIndexChanged = true;

            await TranslateAndDisplay();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnResize_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                formSize = this.ClientSize;
                this.WindowState = FormWindowState.Maximized;
                btnResize.Image = Properties.Resources.minimize;
                Refresh();
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                this.Size = formSize;
                btnResize.Image = Properties.Resources.maximize;
                Refresh();
            }

        }

        private async void btnOpen_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(langIn) || string.IsNullOrEmpty(langOut))
                {
                    MessageBox.Show("Please select both input and output languages.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "Text files (*.txt)|*.txt|PDF files (*.pdf)|*.pdf|Word files (*.doc;*.docx)|*.doc;*.docx|All files (*.*)|*.*";
                    openFileDialog.FilterIndex = 1;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = openFileDialog.FileName;
                        string textToTranslate = "";

                        if (Path.GetExtension(filePath).Equals(".txt", StringComparison.OrdinalIgnoreCase))
                        {
                            textToTranslate = File.ReadAllText(filePath, Encoding.UTF8);
                        }
                        else if (Path.GetExtension(filePath).Equals(".pdf", StringComparison.OrdinalIgnoreCase))
                        {
                            textToTranslate = await ExtractTextFromPdf(filePath);
                        }
                        else if (Path.GetExtension(filePath).Equals(".doc", StringComparison.OrdinalIgnoreCase) ||
                                 Path.GetExtension(filePath).Equals(".docx", StringComparison.OrdinalIgnoreCase))
                        {
                            textToTranslate = await ExtractTextFromWord(filePath);
                        }

                        tbIn.Text = textToTranslate;

                        string translatedText = await TranslateText(textToTranslate, langIn, langOut);
                        tbOut.Text = translatedText;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnTask_Click(object sender, EventArgs e)
        {
            formSize = this.ClientSize;
            this.WindowState = FormWindowState.Minimized;
        }

        private void titlePanel_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void btnENIn_Click(object sender, EventArgs e)
        {
            allowComboBoxIndexChanged = false;
            langIn = "en";
            cmbIn.SelectedIndexChanged -= cmbIn_SelectedIndexChanged;
            cmbIn.SelectedValue = langIn;
            cmbIn.SelectedIndexChanged += cmbIn_SelectedIndexChanged;
            btnENIn.Highlight = true;
            btnROIn.Highlight = false;
            btnSPIn.Highlight = false;
            btnFRIn.Highlight = false;
            allowComboBoxIndexChanged = true;
            RepaintControls(tbIn, tbOut, cmbIn, cmbOut, btnSwitch, labelOut, btnENIn, btnENOut, btnROIn, btnROOut, btnSPIn, btnSPOut, btnFRIn, btnFROut); TbText_TextChanged(null, EventArgs.Empty);
            labelIn.Text = "English";
        }

        private void btnROIn_Click(object sender, EventArgs e)
        {
            allowComboBoxIndexChanged = false;
            langIn = "ro";
            cmbIn.SelectedIndexChanged -= cmbIn_SelectedIndexChanged;
            cmbIn.SelectedValue = langIn;
            cmbIn.SelectedIndexChanged += cmbIn_SelectedIndexChanged;
            btnROIn.Highlight = true;
            btnSPIn.Highlight = false;
            btnENIn.Highlight = false;
            btnFRIn.Highlight = false;
            allowComboBoxIndexChanged = true;
            RepaintControls(tbIn, tbOut, cmbIn, cmbOut, btnSwitch, labelOut, btnENIn, btnENOut, btnROIn, btnROOut, btnSPIn, btnSPOut, btnFRIn, btnFROut); TbText_TextChanged(null, EventArgs.Empty);
            labelIn.Text = "Romanian";
        }

        private void btnSPIn_Click(object sender, EventArgs e)
        {
            allowComboBoxIndexChanged = false;
            langIn = "es";
            cmbIn.SelectedIndexChanged -= cmbIn_SelectedIndexChanged;
            cmbIn.SelectedValue = langIn;
            cmbIn.SelectedIndexChanged += cmbIn_SelectedIndexChanged;
            btnSPIn.Highlight = true;
            btnENIn.Highlight = false;
            btnROIn.Highlight = false;
            btnFRIn.Highlight = false;
            allowComboBoxIndexChanged = true;
            RepaintControls(tbIn, tbOut, cmbIn, cmbOut, btnSwitch, labelOut, btnENIn, btnENOut, btnROIn, btnROOut, btnSPIn, btnSPOut, btnFRIn, btnFROut); TbText_TextChanged(null, EventArgs.Empty);
            labelIn.Text = "Spanish";
        }
        private void btnFRIn_Click(object sender, EventArgs e)
        {
            allowComboBoxIndexChanged = false;
            langIn = "fr";
            cmbIn.SelectedIndexChanged -= cmbIn_SelectedIndexChanged;
            cmbIn.SelectedValue = langIn;
            cmbIn.SelectedIndexChanged += cmbIn_SelectedIndexChanged;
            btnSPIn.Highlight = false;
            btnENIn.Highlight = false;
            btnROIn.Highlight = false;
            btnFRIn.Highlight = true;
            allowComboBoxIndexChanged = true;
            RepaintControls(tbIn, tbOut, cmbIn, cmbOut, btnSwitch, labelOut, btnENIn, btnENOut, btnROIn, btnROOut, btnSPIn, btnSPOut, btnFRIn, btnFROut); TbText_TextChanged(null, EventArgs.Empty);
            labelIn.Text = "French";
        }


        private void btnROOut_Click(object sender, EventArgs e)
        {
            allowComboBoxIndexChanged = false;
            langOut = "ro";
            cmbOut.SelectedIndexChanged -= cmbOut_SelectedIndexChanged;
            cmbOut.SelectedValue = langOut;
            cmbOut.SelectedIndexChanged += cmbOut_SelectedIndexChanged;
            btnROOut.Highlight = true;
            btnENOut.Highlight = false;
            btnSPOut.Highlight = false;
            btnFROut.Highlight = false;
            allowComboBoxIndexChanged = true;
            RepaintControls(tbIn, tbOut, cmbIn, cmbOut, btnSwitch, labelOut, btnENIn, btnENOut, btnROIn, btnROOut, btnSPIn, btnSPOut, btnFRIn, btnFROut); TbText_TextChanged(null, EventArgs.Empty);
            labelOut.Text = "Romanian";
        }

        private void btnSPOut_Click(object sender, EventArgs e)
        {
            allowComboBoxIndexChanged = false;
            langOut = "es";
            cmbOut.SelectedIndexChanged -= cmbOut_SelectedIndexChanged;
            cmbOut.SelectedValue = langOut;
            cmbOut.SelectedIndexChanged += cmbOut_SelectedIndexChanged;
            btnSPOut.Highlight = true;
            btnENOut.Highlight = false;
            btnROOut.Highlight = false;
            btnFROut.Highlight = false;
            allowComboBoxIndexChanged = true;
            RepaintControls(tbIn, tbOut, cmbIn, cmbOut, btnSwitch, labelOut, btnENIn, btnENOut, btnROIn, btnROOut, btnSPIn, btnSPOut, btnFRIn, btnFROut); TbText_TextChanged(null, EventArgs.Empty);
            labelOut.Text = "Spanish";
        }

        private void btnENOut_Click(object sender, EventArgs e)
        {
            allowComboBoxIndexChanged = false;
            langOut = "en";
            cmbOut.SelectedIndexChanged -= cmbOut_SelectedIndexChanged;
            cmbOut.SelectedValue = langOut;
            cmbOut.SelectedIndexChanged += cmbOut_SelectedIndexChanged;
            btnENOut.Highlight = true;
            btnROOut.Highlight = false;
            btnSPOut.Highlight = false;
            btnFROut.Highlight = false;
            allowComboBoxIndexChanged = true;
            RepaintControls(tbIn, tbOut, cmbIn, cmbOut, btnSwitch, labelOut, btnENIn, btnENOut, btnROIn, btnROOut, btnSPIn, btnSPOut, btnFRIn, btnFROut); TbText_TextChanged(null, EventArgs.Empty);
            labelOut.Text = "English";
        }
        private void btnFROut_Click(object sender, EventArgs e)
        {
            allowComboBoxIndexChanged = false;
            langOut = "fr";
            cmbOut.SelectedIndexChanged -= cmbOut_SelectedIndexChanged;
            cmbOut.SelectedValue = langOut;
            cmbOut.SelectedIndexChanged += cmbOut_SelectedIndexChanged;
            btnFROut.Highlight = true;
            btnENOut.Highlight = false;
            btnROOut.Highlight = false;
            btnSPOut.Highlight = false;
            allowComboBoxIndexChanged = true;
            RepaintControls(tbIn, tbOut, cmbIn, cmbOut, btnSwitch, labelOut, btnENIn, btnENOut, btnROIn, btnROOut, btnSPIn, btnSPOut, btnFRIn, btnFROut);
            TbText_TextChanged(null, EventArgs.Empty);
            labelOut.Text = "French";
        }
        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Text files (*.txt)|*.txt";
                    saveFileDialog.FilterIndex = 1;
                    saveFileDialog.RestoreDirectory = true;
                    saveFileDialog.FileName = "TranslatedText.txt";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = saveFileDialog.FileName;
                        await Task.Run(() => File.WriteAllText(filePath, tbOut.Text, Encoding.UTF8));
                        MessageBox.Show("File saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        #endregion
        #region DONT Touch
        //Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        //Overridden methods
        protected override void WndProc(ref Message m)
        {
            const int WM_NCCALCSIZE = 0x0083;//Standar Title Bar - Snap Window
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_MINIMIZE = 0xF020; //Minimize form (Before)
            const int SC_RESTORE = 0xF120; //Restore form (Before)
            const int WM_NCHITTEST = 0x0084;//Win32, Mouse Input Notification: Determine what part of the window corresponds to a point, allows to resize the form.
            const int resizeAreaSize = 10;

            #region Form Resize
            // Resize/WM_NCHITTEST values
            const int HTCLIENT = 1; //Represents the client area of the window
            const int HTLEFT = 10;  //Left border of a window, allows resize horizontally to the left
            const int HTRIGHT = 11; //Right border of a window, allows resize horizontally to the right
            const int HTTOP = 12;   //Upper-horizontal border of a window, allows resize vertically up
            const int HTTOPLEFT = 13;//Upper-left corner of a window border, allows resize diagonally to the left
            const int HTTOPRIGHT = 14;//Upper-right corner of a window border, allows resize diagonally to the right
            const int HTBOTTOM = 15; //Lower-horizontal border of a window, allows resize vertically down
            const int HTBOTTOMLEFT = 16;//Lower-left corner of a window border, allows resize diagonally to the left
            const int HTBOTTOMRIGHT = 17;//Lower-right corner of a window border, allows resize diagonally to the right

            ///<Doc> More Information: https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-nchittest </Doc>

            if (m.Msg == WM_NCHITTEST)
            { //If the windows m is WM_NCHITTEST
                base.WndProc(ref m);
                if (this.WindowState == FormWindowState.Normal)//Resize the form if it is in normal state
                {
                    if ((int)m.Result == HTCLIENT)//If the result of the m (mouse pointer) is in the client area of the window
                    {
                        Point screenPoint = new Point(m.LParam.ToInt32()); //Gets screen point coordinates(X and Y coordinate of the pointer)                           
                        Point clientPoint = this.PointToClient(screenPoint); //Computes the location of the screen point into client coordinates                          

                        if (clientPoint.Y <= resizeAreaSize)//If the pointer is at the top of the form (within the resize area- X coordinate)
                        {
                            if (clientPoint.X <= resizeAreaSize) //If the pointer is at the coordinate X=0 or less than the resizing area(X=10) in 
                                m.Result = (IntPtr)HTTOPLEFT; //Resize diagonally to the left
                            else if (clientPoint.X < (this.Size.Width - resizeAreaSize))//If the pointer is at the coordinate X=11 or less than the width of the form(X=Form.Width-resizeArea)
                                m.Result = (IntPtr)HTTOP; //Resize vertically up
                            else //Resize diagonally to the right
                                m.Result = (IntPtr)HTTOPRIGHT;
                        }
                        else if (clientPoint.Y <= (this.Size.Height - resizeAreaSize)) //If the pointer is inside the form at the Y coordinate(discounting the resize area size)
                        {
                            if (clientPoint.X <= resizeAreaSize)//Resize horizontally to the left
                                m.Result = (IntPtr)HTLEFT;
                            else if (clientPoint.X > (this.Width - resizeAreaSize))//Resize horizontally to the right
                                m.Result = (IntPtr)HTRIGHT;
                        }
                        else
                        {
                            if (clientPoint.X <= resizeAreaSize)//Resize diagonally to the left
                                m.Result = (IntPtr)HTBOTTOMLEFT;
                            else if (clientPoint.X < (this.Size.Width - resizeAreaSize)) //Resize vertically down
                                m.Result = (IntPtr)HTBOTTOM;
                            else //Resize diagonally to the right
                                m.Result = (IntPtr)HTBOTTOMRIGHT;
                        }
                    }
                }
                return;
            }
            #endregion

            //Remove border and keep snap window
            if (m.Msg == WM_NCCALCSIZE && m.WParam.ToInt32() == 1)
            {
                return;
            }

            //Keep form size when it is minimized and restored. Since the form is resized because it takes into account the size of the title bar and borders.
            if (m.Msg == WM_SYSCOMMAND)
            {
                /// <see cref="https://docs.microsoft.com/en-us/windows/win32/menurc/wm-syscommand"/>
                /// Quote:
                /// In WM_SYSCOMMAND messages, the four low - order bits of the wParam parameter 
                /// are used internally by the system.To obtain the correct result when testing 
                /// the value of wParam, an application must combine the value 0xFFF0 with the 
                /// wParam value by using the bitwise AND operator.
                int wParam = (m.WParam.ToInt32() & 0xFFF0);

                if (wParam == SC_MINIMIZE)  //Before
                    formSize = this.ClientSize;
                if (wParam == SC_RESTORE)// Restored form(Before)
                    this.Size = formSize;
            }
            base.WndProc(ref m);
        }



        #endregion



    }


}