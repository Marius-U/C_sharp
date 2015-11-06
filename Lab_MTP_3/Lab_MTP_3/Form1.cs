using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_MTP_3
{
    public partial class Contacts : Form
    {
        private List<Contact> friends       = new List<Contact>();
        private List<Contact> colleagues    =  new List<Contact>();
        private List<Contact> relatives     = new List<Contact>();
        private List<Contact> others        = new List<Contact>();
        private TreeNode friendsNode        = new TreeNode();
        private TreeNode colleaguesNode     = new TreeNode();
        private TreeNode relativesNode      = new TreeNode();
        private TreeNode othersNode         = new TreeNode();
        private byte friendsNodesIndex = 0x00;
        private byte colleaguesNodesIndex = 0x00;
        private byte relativesNodesIndex = 0x00;
        private byte othersNodesIndex = 0x00;
        private string selectedCategorie = null;
        private TreeNode selection = null;
        private byte mode = 0x02;
        enum modeE
        {
            LARGE ,
            SMALL,
            LIST,
            DETAILS
        };

        public Contacts()
        {
            InitializeComponent();

            friendsNode.ImageIndex = 2;
            friendsNode.Text = "Prieteni"; 
            colleaguesNode.ImageIndex = 0;
            colleaguesNode.Text = "Colegi";
            relativesNode.ImageIndex = 3;
            relativesNode.Text = "Rude";
            othersNode.ImageIndex = 1;
            othersNode.Text = "Diversi";
            treeView1.Nodes.Add(friendsNode);
            treeView1.Nodes.Add(colleaguesNode);
            treeView1.Nodes.Add(relativesNode);
            treeView1.Nodes.Add(othersNode);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name         = textBoxNume.Text;
            string address      = textBoxAddress.Text;
            string phoneNumber  = textBoxTelefon.Text;
            string categorie    = comboBoxOthers.Text;

            if(name.Length > 2)
            {
                if(address.Length > 0)
                {
                    if(phoneNumber.Length > 0)
                    {
                        Contact contact = new Contact(name, address, phoneNumber, categorie);
                        if(categorie.Equals("Prieteni"))
                        {   
                            bool found = false;
                            foreach(Contact c in friends)
                            {
                                if(c.getName().Equals(contact.getName()))
                                {
                                    found = true;
                                    break;
                                }
                            }
                            if(found)
                            {
                                MessageBox.Show("Contactul se afla deja in categoria selectata!", "Info");
                            }
                            else 
                            {
                                friends.Add(contact);
                                addTreeNode(contact);
                            }
                            
                        }
                        else if(categorie.Equals("Colegi"))
                        {
                            bool found = false;
                            foreach (Contact c in colleagues)
                            {
                                if (c.getName().Equals(contact.getName()))
                                {
                                    found = true;
                                    break;
                                }
                            }
                            if (found)
                            {
                                MessageBox.Show("Contactul se afla deja in categoria selectata!", "Info");
                            }
                            else
                            {
                                colleagues.Add(contact);
                                addTreeNode(contact);
                            }
                        }
                        else if(categorie.Equals("Rude"))
                        {
                            bool found = false;
                            foreach (Contact c in relatives)
                            {
                                if (c.getName().Equals(contact.getName()))
                                {
                                    found = true;
                                    break;
                                }
                            }
                            if (found)
                            {
                                MessageBox.Show("Contactul se afla deja in categoria selectata!", "Info");
                            }
                            else
                            {
                                relatives.Add(contact);
                                addTreeNode(contact);
                            }
                        }
                        else 
                        {
                            bool found = false;
                            foreach (Contact c in others)
                            {
                                if (c.getName().Equals(contact.getName()))
                                {
                                    found = true;
                                    break;
                                }
                            }
                            if (found)
                            {
                                MessageBox.Show("Contactul se afla deja in categoria selectata!", "Info");
                            }
                            else
                            {
                                others.Add(contact);
                                addTreeNode(contact);
                            }
                        }
                        
                    }
                    else
                    {
                        MessageBox.Show("Nu ati introdus un numar de telefon!", "Eroare!");
                    }
                }
                else
                {
                    MessageBox.Show("Campul de adresa este gol!", "Eroare!");
                }
            }
            else if(name.Length == 0)
            {
                MessageBox.Show("Nu ati introdus niciun nume!", "Eroare!");
            }
            else 
            {
                MessageBox.Show("Numele este prea scurt!","Eroare!");
            }
        }

        private void Large_Click(object sender, EventArgs e)
        {
            listView1.View = View.LargeIcon;
        }

        private void Small_Click(object sender, EventArgs e)
        {
            listView1.View = View.SmallIcon;
        }

        private void List_Click(object sender, EventArgs e)
        {
            listView1.View = View.List;
        }

        private void Details_Click(object sender, EventArgs e)
        {
            listView1.View = View.Details;
        }

        private void Sterge_din_categorie_Click(object sender, EventArgs e)
        {
            if (selection != null)
            {
                if (selection.Parent == null)
                {
                    if (selectedCategorie.Equals("Prieteni"))
                    {
                        friends.Clear();
                        friendsNode.Nodes.Clear();
                        friendsNodesIndex = 0x00;
                        listView1.Items.Clear();
                    }
                    else if (selectedCategorie.Equals("Colegi"))
                    {
                        colleagues.Clear();
                        colleaguesNode.Nodes.Clear();
                        colleaguesNodesIndex = 0x00;
                        listView1.Items.Clear();
                    }
                    else if (selectedCategorie.Equals("Rude"))
                    {
                        relatives.Clear();
                        colleaguesNode.Nodes.Clear();
                        colleaguesNodesIndex = 0x00;
                        listView1.Items.Clear();
                    }
                    else
                    {
                        others.Clear();
                        othersNode.Nodes.Clear();
                        colleaguesNodesIndex = 0x00;
                        listView1.Items.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("Ati selectat un contact nu o categorie!");
                }
            }
            else
            {
                MessageBox.Show("Nu ati selectat nicio categorie!");
            }
        }

        private void Sterge_Click(object sender, EventArgs e)
        {
            if(selection.Parent != null)
            {
                int index = 0;
                List<Contact> list = null;
                
                if (selection.Parent.Text.Equals("Prieteni"))
                {
                   
                    foreach (Contact c in friends)
                    {
                       
                        if (c.getName().Equals(selection.Text))
                        {
                            break;
                        }
                        index++;
                    }
                    if(index < friends.Count())
                    {
                        friends.RemoveAt(index);
                        friendsNode.Nodes.Remove(selection);
                    }
                    
                    list = friends;
                }
                else if (selection.Parent.Text.Equals("Colegi"))
                {
                    
                    foreach (Contact c in colleagues)
                    {
                       
                        if (c.getName().Equals(selection.Text))
                        {
                            break;
                        }
                        index++;
                    }
                
                    if (index < colleagues.Count())
                    {
                        colleagues.RemoveAt(index);
                        colleaguesNode.Nodes.Remove(selection);
                    }
                    list = colleagues;
                }
                else if (selection.Parent.Text.Equals("Rude"))
                {
                    
                    foreach (Contact c in relatives)
                    {
                       
                        if (c.getName().Equals(selection.Text))
                        {
                            break;
                        }
                        index++;
                    }
                    
                    if (index < relatives.Count())
                    {
                        relatives.RemoveAt(index);
                        relativesNode.Nodes.Remove(selection);
                    }
                    list = relatives;
                }
                else
                {
                    
                    foreach (Contact c in others)
                    {
                       
                        if (c.getName().Equals(selection.Text))
                        {
                            break;
                        }
                        index++;
                    }
                    
                    if (index < others.Count())
                    {
                        others.RemoveAt(index);
                        othersNode.Nodes.Remove(selection);
                    }
                    list = others;
                }
                reDrawListView(list);
            }
            else
            {
                MessageBox.Show("Selectati contactul din partea stanga!");
            }
        }
        private void reDrawListView(List<Contact> list)
        {
            listView1.Items.Clear();
            foreach(Contact c in list)
            {
                string row = c.getName();
                ListViewItem listViewItem = new ListViewItem(row);
                listViewItem.ImageIndex = 2;
                listViewItem.SubItems.Add(c.getPhoneNumber());
                listViewItem.SubItems.Add(c.getAddress());
                listView1.Items.Add(listViewItem);
            }
        }
        private void addTreeNode(Contact contact)
        {
            if(contact.getCategorie().Equals("Prieteni"))
            {
                TreeNode childNode = new TreeNode(); 
                childNode.Name = friendsNodesIndex++.ToString(); 
                childNode.Text = contact.getName(); 
                childNode.ImageIndex = 2; 
                friendsNode.Nodes.Add(childNode);
            }
            else if(contact.getCategorie().Equals("Colegi"))
            {
                TreeNode childNode = new TreeNode();
                childNode.Name = colleaguesNodesIndex++.ToString();
                childNode.Text = contact.getName();
                childNode.ImageIndex = 0;
                colleaguesNode.Nodes.Add(childNode);
            }
            else if(contact.getCategorie().Equals("Rude"))
            {
                TreeNode childNode = new TreeNode();
                childNode.Name = relativesNodesIndex++.ToString();
                childNode.Text = contact.getName();
                childNode.ImageIndex = 3;
                relativesNode.Nodes.Add(childNode);
            }
            else
            {
                TreeNode childNode = new TreeNode();
                childNode.Name = othersNodesIndex++.ToString();
                childNode.Text = contact.getName();
                childNode.ImageIndex = 1;
                othersNode.Nodes.Add(childNode);
            }

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
           this.selectedCategorie = e.Node.Text;
           this.selection = e.Node;
           listView1.Items.Clear();

           if (selection.Parent == null)
           {
               if (selectedCategorie.Equals("Prieteni"))
               {

                   foreach (Contact c in friends)
                   {
                       string row = c.getName();
                       ListViewItem listViewItem = new ListViewItem(row);
                       listViewItem.ImageIndex = 2;
                       listViewItem.SubItems.Add(c.getPhoneNumber());
                       listViewItem.SubItems.Add(c.getAddress());
                       listView1.Items.Add(listViewItem);
                   }

               }
               else if (selectedCategorie.Equals("Colegi"))
               {
                   foreach (Contact c in colleagues)
                   {
                       string row = c.getName();
                       ListViewItem listViewItem = new ListViewItem(row);
                       listViewItem.ImageIndex = 0;
                       listViewItem.SubItems.Add(c.getPhoneNumber());
                       listViewItem.SubItems.Add(c.getAddress());
                       listView1.Items.Add(listViewItem);
                   }
               }
               else if (selectedCategorie.Equals("Rude"))
               {

                   foreach (Contact c in relatives)
                   {
                       string row = c.getName();
                       ListViewItem listViewItem = new ListViewItem(row);
                       listViewItem.ImageIndex = 3;
                       listViewItem.SubItems.Add(c.getPhoneNumber());
                       listViewItem.SubItems.Add(c.getAddress());
                       listView1.Items.Add(listViewItem);
                   }
               }
               else
               {
                   foreach (Contact c in others)
                   {
                       string row = c.getName();
                       ListViewItem listViewItem = new ListViewItem(row);
                       listViewItem.ImageIndex = 1;
                       listViewItem.SubItems.Add(c.getPhoneNumber());
                       listViewItem.SubItems.Add(c.getAddress());
                       listView1.Items.Add(listViewItem);
                   }

               }
           }
            else
           {
               if(selection.Parent.Text.Equals("Prieteni"))
               {
                   foreach(Contact c in friends)
                   {
                       if(c.getName().Equals(selection.Text))
                       {
                           string row = c.getName();
                           ListViewItem listViewItem = new ListViewItem(row);
                           listViewItem.ImageIndex = 2;
                           listViewItem.SubItems.Add(c.getPhoneNumber());
                           listViewItem.SubItems.Add(c.getAddress());
                           listView1.Items.Add(listViewItem);
                       }
                   }
               }
               else if (selection.Parent.Text.Equals("Colegi"))
               {
                   foreach (Contact c in colleagues)
                   {
                       if (c.getName().Equals(selection.Text))
                       {
                           string row = c.getName();
                           ListViewItem listViewItem = new ListViewItem(row);
                           listViewItem.ImageIndex = 0;
                           listViewItem.SubItems.Add(c.getPhoneNumber());
                           listViewItem.SubItems.Add(c.getAddress());
                           listView1.Items.Add(listViewItem);
                       }
                   }
               }
               else if (selection.Parent.Text.Equals("Rude"))
               {
                   foreach (Contact c in relatives)
                   {
                       if (c.getName().Equals(selection.Text))
                       {
                           string row = c.getName();
                           ListViewItem listViewItem = new ListViewItem(row);
                           listViewItem.ImageIndex = 3;
                           listViewItem.SubItems.Add(c.getPhoneNumber());
                           listViewItem.SubItems.Add(c.getAddress());
                           listView1.Items.Add(listViewItem);
                       }
                   }
               }
               else
               {
                   foreach (Contact c in others)
                   {
                       if (c.getName().Equals(selection.Text))
                       {
                           string row = c.getName();
                           ListViewItem listViewItem = new ListViewItem(row);
                           listViewItem.ImageIndex = 1;
                           listViewItem.SubItems.Add(c.getPhoneNumber());
                           listViewItem.SubItems.Add(c.getAddress());
                           listView1.Items.Add(listViewItem);
                       }
                   }
               }
              
           }
        }
    }
}
