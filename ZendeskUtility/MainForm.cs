using log4net;
using System.Diagnostics;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace ZendeskUtility
{
    //todo: update ticket message : bool public private, etc

    public partial class MainForm : Form
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(MainForm));
        private readonly List<string> CloseTicketList;
        private static Boolean CloseLimitEnabled = false;
        static ColorGenerator colorGenerator = new ColorGenerator();
        public MainForm()
        {
            try
            {
                string key = System.IO.File.ReadAllText("APIKEY.txt");
                if (key != "")
                {

                    Globals.API_KEY = key;
                }
                else
                {
                    throw new Exception("APIKEY.txt is empty");
                }
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show("You need an API key in APIKEY.txt");
                File.Create("APIKEY.txt");
                log.Error("APIKEY.txt not found. Created new file.");
                Environment.Exit(0);
            }
            catch (Exception e)
            {
                MessageBox.Show("Error reading APIKEY.txt: " + e.Message);
            }
            CloseTicketList = new List<string>();
            Cleanup();
            InitializeComponent();
            UpdateStatus("Idle", 0);
            Globals.client.DefaultRequestHeaders.Accept.Add(
           new MediaTypeWithQualityHeaderValue("application/json"));
            Globals.client.DefaultRequestHeaders.Add("Authorization", "Basic " + Globals.API_KEY);
            InitialsTextBox.Text = LoadInitials();
            Globals.RedColor = 0;
            Globals.GreenColor = 0;
            Globals.BlueColor = 0;
            Globals.ColorIncrement = 5;
            Globals.ColorMode = 1;

            ColorGenerator.addTarget(this);
        }

        private void Cleanup()
        {
            log.Info("Performing cleanup before exit...");
            string filePath = "exported.txt";
            if (File.Exists(filePath))
            {
                try
                {
                    File.Delete(filePath);
                    log.Info("Deleted existing 'exported.txt' file");
                }
                catch (Exception ex)
                {
                    log.Error("Error deleting 'exported.txt' file: " + ex.Message);
                }
            }
            filePath = "shipper.csv";
            if (File.Exists(filePath))
            {
                try
                {
                    File.Delete(filePath);
                    log.Info("Deleted existing 'shipper.csv' file");
                }
                catch (Exception ex)
                {
                    log.Error("Error deleting 'shipper.csv' file: " + ex.Message);
                }
            }
            log.Info("Cleanup complete...");
            log.Info("Exiting.");
        }
        private async void ZDTicketSearchButton_Click(object sender, EventArgs e)
        {
            UpdateStatus("Starting Search", 5);
            // Step 1: Retrieve the ticket number from ZDTicketTextBox
            string ticketNumberText = ZDTicketTextBox.Text;

            UpdateStatus($"Search: Ticket {ticketNumberText}", 10);
            // Log the ticket number retrieval
            log.Debug($"Retrieved ticket number: {ticketNumberText}");

            // Validate that the ticket number is an integer
            bool isValidTicketNumber = int.TryParse(ticketNumberText, out int ticketNumber);

            if (isValidTicketNumber)
            {

                UpdateStatus("Search: Valid Number", 15);
                // Log the valid ticket number
                log.Info($"Valid ticket number: {ticketNumber}");

                UpdateStatus("Search: Getting Subject", 20);
                // Step 2: Pass the ticket number as a parameter to a new function that returns a string
                string ticketSubject = await GetTicketSubjectAsync(ticketNumber);

                UpdateStatus("Search: Retrieved Subject", 80);
                // Log the ticket subject retrieval
                log.Debug($"Retrieved ticket subject: {ticketSubject}");

                // Step 3: Set TicketSubjectTextBox text to the returned string
                TicketSubjectTextBox.Text = ticketSubject;

                UpdateStatus("Search: Updated Label", 100);

                // Log the assignment of the ticket subject to the TextBox
                log.Info("Ticket subject assigned to TextBox");

                UpdateStatus("Idle", 0);
            }
            else
            {
                // Log the invalid ticket number
                log.Warn($"Invalid ticket number: {ticketNumberText}");

                // Handle the case when the ticket number is not a valid integer
                MessageBox.Show("Please enter a valid ticket number.");

                // Log the invalid ticket number message
                log.Warn("Invalid ticket number entered");

                UpdateStatus("Idle", 0);
            }
        }
        private void DiagSubmitButton_Click(object sender, EventArgs e)
        {

            UpdateStatus("Diagnostics", 0);
            bool isValidTicketNumber = int.TryParse(ZDTicketTextBox.Text, out int ticketNumber);
            if (isValidTicketNumber)
            {
                UpdateStatus("D: Coallating Notes", 25);
                string diagnosis = Diag_TechDiagnosisTextBox.Text;
                string partsNeeded = Diag_PartsTextBox.Text;
                string[] techNotes = Diag_NotesTextBox.Lines;

                string techNotesFormatted = "";
                foreach (string technote in techNotes)
                {
                    techNotesFormatted += technote + "\n";
                }


                UpdateStatus("D: Generating Payload", 50);

                var payload = new
                {
                    ticket = new Ticket
                    {
                        status = "hold",
                        custom_fields = new List<Custom_Fields>()
                {
                    new Custom_Fields() { id = 360015841891, value = "diagnostics" }
                },
                        comment = new Comment
                        {
                            @public = "false",
                            body = ("**Diagnosis:** \n" + diagnosis + "\n\n" + "**Part(s) needed:** \n" + partsNeeded + "\n\n" + "**Technician's Notes:**\n" + techNotesFormatted + "\n-" + InitialsTextBox.Text).ToString()
                        }
                    }
                };
                UpdateStatus("D: Uploading Payload", 75);
                SendZendeskPayload(ticketNumber, payload);

                UpdateStatus("D: Done", 100);
                Diag_TechDiagnosisTextBox.Clear();
                Diag_PartsTextBox.Clear();
                Diag_NotesTextBox.Clear();
                UpdateStatus("Idle", 0);
            }
            else
            {
                MessageBox.Show("Invalid Ticket #");
                UpdateStatus("Idle", 0);
            }
        }
        private void RepairSubmitButton_Click(object sender, EventArgs e)
        {
            UpdateStatus("Repair", 0);
            UpdateStatus("R: Checking Ticket #", 1, 10);
            bool isValidTicketNumber = int.TryParse(ZDTicketTextBox.Text, out int ticketNumber);
            if (isValidTicketNumber)
            {
                UpdateStatus("R: Coallating Parts", 2, 10);
                string? PartsListForZD = "";
                if (repairPartsSelector.CheckedItems.Count != 0)
                {
                    // If so, loop through all checked items and print results.  
                    PartsListForZD = repairPartsSelector.CheckedItems[0].ToString();

                    for (int x = 1; x < repairPartsSelector.CheckedItems.Count; x++)
                    {
                        PartsListForZD = PartsListForZD + ", " + repairPartsSelector.CheckedItems[x].ToString();
                    }

                }
                UpdateStatus("R: Return Part Condition", 3, 10);
                if (repairPartsSelector.CheckedItems.Contains("Motherboard"))
                {
                    log.Info("Motherboard detected.");
                    ReturnPartSubroutine(ticketNumber);
                }
                if (repairPartsSelector.CheckedItems.Contains("LCD / Screen"))
                {
                    log.Info("LCD Detected.");
                    ReturnPartSubroutine(ticketNumber);
                }
                UpdateStatus("R: Generating ZD Public Payload", 8, 10);
                var ZDPublicRepairNotePayload = new
                {
                    ticket = new Ticket
                    {
                        status = "hold",
                        custom_fields = new List<Custom_Fields>()
                {
                    new Custom_Fields() { id = 360015841891, value = "qc" }
                },
                        comment = new Comment
                        {
                            @public = "true",
                            body = "Replaced: \n" + PartsListForZD + "\n" + repairOtherPartsTextBox.Text + "\n -" + InitialsTextBox.Text + "\n" + repairNotes.Text,
                        }
                    }
                };
                UpdateStatus("R: Sending Payload", 9, 10);
                log.Debug($"Creating ZDPublicRepairNotePayload for ticket number: {ticketNumber}");
                SendZendeskPayload(ticketNumber, ZDPublicRepairNotePayload);
                UpdateStatus("R: Payload Sent", 10, 10);
                repairNotes.Clear();
                repairOtherPartsTextBox.Clear();
                for (int i = 0; i < repairPartsSelector.Items.Count; i++)
                {
                    repairPartsSelector.SetItemChecked(i, false);
                }
                UpdateStatus("Idle", 0);
            }
            else
            {
                MessageBox.Show("Invalid Ticket #");
                UpdateStatus("Idle", 0);
            }
        }
        private void Close_SubmitButton_Click(object sender, EventArgs e)
        {
            UpdateStatus("C: Closer Started", 1, 4);
            log.Info("Ticket Closing Submit Button Pressed");
            Cleanup();
            UpdateStatus("C: Export Started", 2, 4);
            string filePath = "exported.txt";
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine("Initials:" + InitialsTextBox.Text.ToString());
                writer.WriteLine("Tickets:" + string.Join(",", CloseTicketList));
            }
            UpdateStatus("C: Starting Python", 3, 4);
            log.Debug("Starting Python process");
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "python"; // Replace with the actual path to the Python executable if needed
            startInfo.Arguments = "PyCloser.py";
            Process process = new()
            {
                StartInfo = startInfo
            };
            process.Start();
            log.Info("Started Py Process.");
            process.WaitForExit();
            log.Info("Exited Py Process.");
            UpdateStatus("C: Reparse", 4, 4);
            try
            {
                Close_ShipperOutput.Clear();
                using (StreamReader reader = new StreamReader("shipper.csv"))
                {
                    string line;
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                    while ((line = reader.ReadLine()) != null)
                    {
                        Close_ShipperOutput.AppendText(line + Environment.NewLine);
                    }
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                }
                log.Info("Reading CSV file successful");
            }
            catch (Exception ex)
            {
                log.Error("Error reading CSV file: " + ex.Message);
            }

            UpdateStatus("Idle", 0);
            Cleanup();
        }
        private void Close_AddButton_Click(object sender, EventArgs e)
        {
            UpdateTicketList();

        }
        private void Close_ClearListButton_Click(object sender, EventArgs e)
        {
            CloseTicketList.Clear();
            UpdateItemList();
        }
        private void Close_DeleteItemButton_Click(object sender, EventArgs e)
        {
            if (Close_TicketDisplayListBox.SelectedItem != null)
            {
                string? selectedItem = Close_TicketDisplayListBox.SelectedItem.ToString();
#pragma warning disable CS8604 // Possible null reference argument.
                CloseTicketList.Remove(selectedItem);
#pragma warning restore CS8604 // Possible null reference argument.
                UpdateItemList();
            }
        }
        private void InputTicketTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                UpdateTicketList();
                e.Handled = true; // Prevent further processing of the Enter key
            }
        }
        private void UpdateItemList()
        {
            Close_TicketDisplayListBox.DataSource = null;
            Close_TicketDisplayListBox.DataSource = CloseTicketList;
        }
        private void UpdateStatus(String status, int progress)
        {
            if (progress >= progressBar.Minimum && progress <= progressBar.Maximum)
            {
                progressBar.Value = progress;
            }
            statusLabel.Text = status;
            log.Info(status);
        }
        private void UpdateStatus(String status, int currStage, int lastStage)
        {
            int value = (currStage / lastStage) * progressBar.Maximum;
            // Make sure the value is within the valid range of the progress bar
            if (value >= progressBar.Minimum && value <= progressBar.Maximum)
            {
                progressBar.Value = value;
            }
            statusLabel.Text = status;
            log.Info(status);
        }
        private static void SendZendeskPayload(int ticketNumber, object payload)
        {
            // Convert the ZDImagePayload object to JSON
            string jsonPayload = System.Text.Json.JsonSerializer.Serialize(payload);

            log.Debug($"Payload created for ticket number: {ticketNumber}");
            HttpWebResponse response = null;
            try
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(Globals.url + ticketNumber + ".json");
                request.Method = "PUT";
                request.Headers[HttpRequestHeader.Authorization] = "Basic " + Globals.API_KEY;
                request.ContentType = "application/json";
                byte[] payloadBytes = Encoding.UTF8.GetBytes(jsonPayload);
                Stream requestStream = request.GetRequestStream();
                requestStream.Write(payloadBytes, 0, payloadBytes.Length);
                requestStream.Close();

                log.Debug($"PUT request sent for ticket number: {ticketNumber}");

                response = (HttpWebResponse)request.GetResponse();


                log.Info($"Ticket update successful for ticket number: {ticketNumber}");
            }
            catch (Exception ex)
            {
                log.Error($"Error occurred while updating ticket number {ticketNumber}: {ex.Message}");
                log.Info(System.Text.Json.JsonSerializer.Serialize(jsonPayload));
                log.Error(ex.Message);
                log.Error(ex.ToString());
            }
        }
        private static async Task<string> GetTicketSubjectAsync(int ticketNumber)
        {
            string responseString = "";
            try
            {
                // Make the GET ZDImageRequest
                responseString = await Globals.client.GetStringAsync(Globals.url + ticketNumber + ".json");
                // Process the ZDImageResponse
                log.Debug($"GET ZDImageRequest completed for ticket number: {ticketNumber}");
            }
            catch (Exception e)
            {
                log.Error($"Error occurred during GET ZDImageRequest for ticket number {ticketNumber}: {e.Message}");
                log.Info(e.Message);
            }

            JsonDocument jsonResponse = JsonDocument.Parse(responseString);
            string? subject = jsonResponse.RootElement.GetProperty("ticket").GetProperty("subject").GetString();

            if (subject != null)
            {
                log.Info($"Retrieved subject '{subject}' for ticket number: {ticketNumber}");
                return subject;
            }
            else
            {
                log.Warn($"No subject found for ticket number: {ticketNumber}");
                return "No Data Found";
            }
        }
        private void UpdateTicketList()
        {
            string item = InputTicketTextBox.Text.Trim();
            if (!string.IsNullOrEmpty(item))
            {
                if (CloseLimitEnabled)
                {
                    if (CloseTicketList.Count < 10)
                    {
                        CloseTicketList.Insert(0, item);
                        UpdateItemList();
                        InputTicketTextBox.Clear();
                    }
                    else
                    {
                        MessageBox.Show("We already have 10 tickets in this list. ");
                    }
                }
                else
                {
                    CloseTicketList.Insert(0, item);
                    UpdateItemList();
                    InputTicketTextBox.Clear();
                }


            }
        }
        private void ReturnPartSubroutine(int ticketNumber)
        {
            string[] tokens = Array.Empty<string>();
            UpdateStatus("P: File Dialog", 1, 10);
            log.Debug("Opening file dialog for selecting images");
            OpenFileDialog openFileDialog = new()
            {
                Multiselect = true,
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif|All Files|*.*"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                UpdateStatus("P: Images Received", 2, 10);
                // Process the selected images
                List<string> zdTokens = new();
                int tokenCount = 0;
                foreach (string filename in openFileDialog.FileNames)
                {
                    UpdateStatus($"P: Uploading Image {tokenCount + 1}", (tokenCount + 3), 10);
                    byte[] fileContents = File.ReadAllBytes(filename);
                    string url = "https://dhecs.zendesk.com/api/v2/uploads" + "?filename=" + Path.GetFileName(filename);
                    HttpWebRequest imgrequest = (HttpWebRequest)WebRequest.Create(url);
                    imgrequest.Method = "POST";
                    imgrequest.ContentType = "application/binary";
                    imgrequest.Headers["Authorization"] = "Basic " + Globals.API_KEY;
                    using (Stream imgrequestStream = imgrequest.GetRequestStream())
                    {
                        imgrequestStream.Write(fileContents, 0, fileContents.Length);
                    }
                    try
                    {
                        using HttpWebResponse imgresponse = (HttpWebResponse)imgrequest.GetResponse();
                        if (imgresponse.StatusCode == HttpStatusCode.Created)
                        {
                            log.Info($"Uploaded {Path.GetFileName(filename)} to Zendesk.");
                            using var reader = new StreamReader(imgresponse.GetResponseStream());
                            string responseText = reader.ReadToEnd();
                            dynamic? jsonResponse = Newtonsoft.Json.JsonConvert.DeserializeObject(responseText);
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                            string? token = jsonResponse["upload"]["token"];
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                            zdTokens.Add(token);
                            tokenCount++;
                            log.Debug($"Token generated: {token}");
                        }
                        else
                        {
                            log.Warn($"Error uploading {Path.GetFileName(filename)} to Zendesk: {imgresponse.StatusCode} - {imgresponse.StatusDescription}");
                        }
                    }
                    catch (WebException ex)
                    {
                        log.Error($"Error uploading {Path.GetFileName(filename)} to Zendesk: {ex.Message}");

                    }
                }
                tokens = zdTokens.ToArray();
            }
            UpdateStatus("P: Sending Image Post", 7, 10);
            var ZDImagePayload = new
            {
                ticket = new Ticket
                {
                    status = "hold",
                    comment = new Comment
                    {
                        @public = "false",
                        body = "Images:",
                        uploads = tokens
                    }
                }
            };
            SendZendeskPayload(ticketNumber, ZDImagePayload);
            // Display a textbox for additional input
            UpdateStatus("P: Gathering SOID", 8, 10);
            string soidInput = Microsoft.VisualBasic.Interaction.InputBox("Enter Part SOID:", "SOID Input", "");
            UpdateStatus("P: Sending SOID Post", 9, 10);
            var ZDSOIDPayload = new
            {
                ticket = new Ticket
                {
                    status = "hold",
                    comment = new Comment
                    {
                        @public = "false",

                        body = $"ID: {soidInput}",
                    }
                }
            };
            log.Debug($"Creating ZDSOIDPayload for ticket number: {ticketNumber}");
            SendZendeskPayload(ticketNumber, ZDSOIDPayload);
            UpdateStatus("P: Done", 10, 10);
        }
        public static string LoadInitials()
        {
            if (File.Exists(Globals.PersistenceFilePath))
            {
                try
                {
                    using StreamReader reader = new StreamReader(Globals.PersistenceFilePath);
#pragma warning disable CS8603 // Possible null reference return.
                    return reader.ReadLine();
#pragma warning restore CS8603 // Possible null reference return.
                }
                catch (Exception ex)
                {
                    // Handle any exceptions when reading the persistence file
                    log.Info("Error reading persistence file: " + ex.Message);
                }
            }

            return string.Empty;
        }
        public static void SaveInitials(string initials)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(Globals.PersistenceFilePath))
                {
                    writer.WriteLine(initials);
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions when writing to the persistence file
                log.Info("Error writing to persistence file: " + ex.Message);
            }
        }
        private void InitialsTextBox_TextChanged(object sender, EventArgs e)
        {
            log.Info("Initials modified. Saving for persistence.");
            SaveInitials(InitialsTextBox.Text);
        }

        private void Close_LimitToggle_CheckedChanged(object sender, EventArgs e)
        {
            CloseLimitEnabled = !Close_LimitToggle.Checked;
            if (CloseLimitEnabled)
            {
                colorGenerator.StopTimer();
            }
            else
            {
                colorGenerator.StartTimer();
            }
        }
    }
}
