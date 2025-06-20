1\. First Understanding and initial thoughts:

a\. Assumptions about log entries  
- Fixed \# of Characters for DateTime section
  - This will be useful for parsing as splitting the whole line by " " will be messy due to the fact that the message will contain spaces
  - EVENT_TYPE will always start at the same character but will not end at same character

b\. Assumptions about the problem  
  - While the test file only has 4 EVENT_TYPEs its not impossible that more could be added later
  - Dont have to store timestamps anywhere

2\. Chosen Solution - WinForms Application with some dictionaries and
DataGridViews

Part 1: Count number of times each event type shows up  
  - Use a Dictionary\<String, int\> numEventTypes with \["EVENT_TYPE"\] as key and a count of how many times "EVENT_TYPE" appears as value
  - Create Dictionary in such a way that EVENT_TYPES dont have to be hard coded so that if the EVENT_TYPES change in the future this program can still parse them 
  - Use this Dictionary to bind to a dataGridView and display "EVENT_TYPE" and Count

Part 2: Be able to display top 3 Messages associated with each EVENT_TYPE Use a Dictionary of Dictionaries \*\*numMessagesForEvent\*\* of the form Dictionary\<String, Dictionary\<String, int\>\> where the first key is "EVENT_TYPE"  
  - This will give access to a Dictionary\<String, int\> where the key will be "MESSAGE" and the value will be the number of times that message appears with the given EVENT_TYPE

Use a WinForms comboBox to select which EVENT_TYPE the user wants to see in more detail.  
  - To populate this combobox go through all keys of \*\*numMessagesForEvent\*\* and add them to the comboBox as strings
  - As strings is important so they can later be retrieved an used as keys again for \*\*numMessagesForEvent\*\*

When something is selected from the comboBox use the selected item as the key for \*\*numMessagesForEvent\*\*  
  - This will give us access to the dictionary containing all the messages and counts for the selected EVENT_TYPE
  - Sort the dictionary based on the values and display the top 3
  - This is done by making a new dictionary of just the top 3 and binding it to the 2nd dataGridView

Pros:  
  - New Event Types are implemented automatically because none of the dictionaries have hard coded keys
  - GUI applications are more user friendly than CLI

Cons: 
  - The Dictionary inside of another dictionary can have some confusing syntax
  - Because dictionaries are not sorted by default I had to use some confusing LINQ syntax to get the top 3 values
  - Program only runs on windows because I did it as a winForms application instead of just using .NET Core 
  - Currently only one EVENT_TYPE can be chosen at a time to display more info about 
  - Because I have assumed we are working with a properly formatted .txt file I do exactly 0 checking for that



