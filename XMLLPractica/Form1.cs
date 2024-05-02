using System.Xml;

namespace XMLLPractica
{
    public partial class Form1 : Form
    {
        String URLString;
        XmlTextReader reader;
        public Form1()
        {
            InitializeComponent();

            URLString = "https://www.w3schools.com/xml/cd_catalog.xml";
            listView1.View = View.Details;
            reader = new XmlTextReader(URLString);

            AddValue(URLString);
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element: // The node is an element.

                        if (listView1.Columns.Count < 8)
                        {
                            listView1.Columns.Add(reader.Name);

                            if (listView1.Columns.Count > 6)
                            {
                                listView1.Columns.RemoveAt(0);
                            }
                        }
                        break;
                }
            }
        }
        private void txtXMLData_TextChanged(object sender, EventArgs e)
        {

        }

        private void AddValue(String path)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(path);
            XmlNodeList nodeList = xmlDoc.SelectNodes(" / CATALOG / CD");
            foreach (XmlNode node in nodeList)
            {

                string title = node.SelectSingleNode("TITLE").InnerText; ;
                string artist = node.SelectSingleNode("ARTIST").InnerText; ;
                string country = node.SelectSingleNode("COUNTRY").InnerText; ;
                string company = node.SelectSingleNode("COMPANY").InnerText; ;
                string price = node.SelectSingleNode("PRICE").InnerText; ;
                string year = node.SelectSingleNode("YEAR").InnerText;
                ListViewItem item = new ListViewItem(new string[] { title, artist, country, company, price, year });
                listView1.Items.Add(item);
            }

            foreach (ColumnHeader column in listView1.Columns)
            {
                column.Width = -3;
            }
        }




  

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
