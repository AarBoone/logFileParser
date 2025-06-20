using System;
using System.Data;
using System.IO;


namespace logFileParser
{


    public partial class Form1 : Form
    {
        // Global filename
        private String filename;
        // Global Dictionaries
        private Dictionary<String, int> numEventTypes = new Dictionary<String, int>();
        private Dictionary<String, Dictionary<String, int>> numMessagesForEvent = new Dictionary<String, Dictionary<String, int>>();

        public Form1()
        {
            InitializeComponent();
        }

        private void button_SelectFile_Click(object sender, EventArgs e)
        {
            openFileDialog_FileName.ShowDialog();
        }

        private void openFileDialog_FileName_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //Set the global filename to that of the file opened by OFD
            filename = openFileDialog_FileName.FileName;
            label_FileName.Text = "File: " + filename;
            // Call the ReadFile function using the selected file as filename
            ReadFile(filename);

            // Making WinForms Controls visible now that they are usefull
            label_FileName.Visible = true;
            label_GetMoreInfo.Visible = true;
            dataGridView_EventTypeCount.Visible = true;
            comboBox_AllEventTypes.Visible = true;
        }

        /// <summary>
        /// Function that uses a StreamReader to read a file line by line 
        /// For each line is expected to be of the for [DATETIME] [EVENT_TYPE] [MESSAGE]
        /// This function is totally useless if the file isn't formatted correctly
        /// On each line this function extracts the EVENT_TYPE and MESSAGE and updates the counts in the global dictionaries for them
        /// </summary>
        /// <param name="filename"></param>
        private void ReadFile(String filename)
        {

            // Use StreamReader to read every line of the file individually
            using (StreamReader sr = new StreamReader(filename))
            {
                string line;
                // Read and lines from the file until the end of
                // the file is reached.
                while ((line = sr.ReadLine()) != null)
                {
                    //Skips any blank lines
                    if (line.StartsWith('\n') || line.StartsWith(' ') || line.StartsWith('\t')) { continue; }


                    //------------------------------------------- Getting Event Type -----------------------------------------------------------------
                    //EVENTTYPE Starts at index 22 of line
                    // Tracking the index current character
                    int i = 22;
                    //MessageBox.Show(line[i].ToString());
                    // From the start of the EventType go until you read a space
                    while (line[i] != ' ')
                    {
                        i++;
                    }
                    // Get the EVENTTYPE using the index of the first character and the length of EVENTTYPE
                    String tempEventType = line.Substring(22, i - 22);

                    // Check if the given EVENTTYPE exists in our dictionary yet
                    if (numEventTypes.ContainsKey(tempEventType))
                    {
                        // If it does exist, incremement the count of the EVENTTYPE
                        numEventTypes[tempEventType]++;
                    }

                    else
                    {
                        // If it does not yet add it to the dictionary with a count of 1
                        numEventTypes.Add(tempEventType, 1);
                    }

                    //------------------------------------------- Reading Message and Storing ---------------------------------------------------------
                    // The message starts 1 after the current index and goes to the end of the line
                    // store the substring of the line from that index to the end
                    String tempMessage = line.Substring(i + 1);
                    // If the primary key "EVENT_TYPE" exists
                    if (numMessagesForEvent.ContainsKey(tempEventType))
                    {
                        // and the secondary key "Message" exists
                        if (numMessagesForEvent[tempEventType].ContainsKey(tempMessage))
                        {
                            // increment the count
                            numMessagesForEvent[tempEventType][tempMessage]++;
                        }
                        // if only the primary key exists add the Secondary Key "Message" with a count of 1
                        else { numMessagesForEvent[tempEventType].Add(tempMessage, 1); }
                    }

                    // If the primary key does not exist
                    else
                    {
                        // Create a new dictionary to act as the value for the primary key
                        Dictionary<String, int> tempDict = new Dictionary<String, int>();
                        //Fill the dictionary with <"Message", 1>
                        tempDict.Add(tempMessage, 1);
                        // Add the new dictionary with the primary key "EVENT_TYPE"
                        numMessagesForEvent.Add(tempEventType, tempDict);
                    }

                }

                // Bind the Count of all event types to the first DataGridView
                BindingSource countOfEventTypes = new BindingSource(numEventTypes, null);
                dataGridView_EventTypeCount.DataSource = countOfEventTypes;

                // Fill the comboBox with all of the EVENT_TYPES that appear in the log file
                foreach (String x in numEventTypes.Keys)
                {
                    comboBox_AllEventTypes.Items.Add(x);
                }

                
                //comboBox_AllEventTypes.Items.Add("Will Cause Error"); // This line when uncommented will add an option to the comboBox guaranteed to cause an error
            }
        }

        private void comboBox_AllEventTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the selected EVENT_TYPE from the comboBox
            String eventType = comboBox_AllEventTypes.SelectedItem.ToString();

            // If EVENT_TYPE is a primary key for numMessagesForEvent (it should always be but this check is for safety)
            if (numMessagesForEvent.ContainsKey(eventType))
            {
                // Create a new dictionary to hold the top 3 values for the selected EVENT_TYPE
                Dictionary<String, int> topThreeOfEvent = numMessagesForEvent[eventType].
                    OrderByDescending(pair => pair.Value). // Sort numMessagesForEvent[eventType] by their values
                    Take(3). // Return the top 3
                    ToDictionary(pair => pair.Key, pair => pair.Value); // as a dictionary

                // Bind the new dictionary to the DataGridView
                BindingSource topThree = new BindingSource(topThreeOfEvent, null);
                dataGridView_MoreInfoAboutEventTypes.DataSource = topThree;
                dataGridView_MoreInfoAboutEventTypes.Visible = true;
            }
            // If for some reason the selected string isnt a Primary Key
            else 
            {
                // Show a message box with an error, but don't crash the program
                MessageBox.Show("ERROR: That Event Type Does Not Exist In The Dictionary");
            }
        }
    }
}
