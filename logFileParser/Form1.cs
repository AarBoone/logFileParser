using System;
using System.IO;


namespace logFileParser
{


    public partial class Form1 : Form
    {
        private String filename;
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
            filename = openFileDialog_FileName.FileName;
            label_FileName.Text = "File: " + filename;
            ReadFile(filename);

            label_FileName.Visible = true;
            label_GetMoreInfo.Visible = true;
            dataGridView_EventTypeCount.Visible = true;
            comboBox_AllEventTypes.Visible = true;
        }

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
                    if (line.StartsWith(' ')) { continue; }


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
                    String tempMessage = line.Substring(i + 1);
                    if (numMessagesForEvent.ContainsKey(tempEventType))
                    {
                        if (numMessagesForEvent[tempEventType].ContainsKey(tempMessage))
                        {
                            numMessagesForEvent[tempEventType][tempMessage]++;
                        }

                        else { numMessagesForEvent[tempEventType].Add(tempMessage, 1); }
                    }

                    else
                    {
                        Dictionary<String, int> tempDict = new Dictionary<String, int>();
                        tempDict.Add(tempMessage, 1);
                        numMessagesForEvent.Add(tempEventType, tempDict);
                    }

                }

                // Bind the Count of all event types to the 
                BindingSource countOfEventTypes = new BindingSource(numEventTypes, null);
                dataGridView_EventTypeCount.DataSource = countOfEventTypes;

                var arrayOfEventTypes = numEventTypes.Keys.ToArray();
                foreach (String x in arrayOfEventTypes)
                {
                    comboBox_AllEventTypes.Items.Add(x);
                }

                
                //comboBox_AllEventTypes.Items.Add("Will Cause Error"); // This line when uncommented will add an option to the comboBox guaranteed to cause an error
            }
        }

        private void comboBox_AllEventTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            String eventType = comboBox_AllEventTypes.SelectedItem.ToString();
            if (numMessagesForEvent.ContainsKey(eventType))
            {
                Dictionary<String, int> topThreeOfEvent = numMessagesForEvent[eventType].OrderByDescending(pair => pair.Value).Take(3).ToDictionary(pair => pair.Key, pair => pair.Value);

                BindingSource topThree = new BindingSource(topThreeOfEvent, null);
                dataGridView_MoreInfoAboutEventTypes.DataSource = topThree;
                dataGridView_MoreInfoAboutEventTypes.Visible = true;
            }
            else 
            {
                MessageBox.Show("ERROR: That Event Type Does Not Exist In The Dictionary");
            }
        }
    }
}
