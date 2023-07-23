using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MailKit.Net.Smtp;
using MimeKit;
using MailKit;
using System.Threading;
using System.IO.Compression;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Xml.Serialization;

namespace Wysylanie_na_maila
{
    public partial class Sender_Man : Form
    {
        private int counter = 0;
        private int file_counter = 1;
        List<string> List_file_names;

        string config_path;
        string file_paths;
        string authorization_path;
        string authorization_path_check;
        List<Config_info> config;
        List<string> paths;
        List<Config_info> authorization;
        List<Config_info> authorization_check;

        string text_from_config;
        string bool_statement;

        string authorization_gmail;
        string authorization_password;        
        bool authorization_pass;

        List<string> emails;
        string emials_list_path;        

        public Sender_Man()
        {
            InitializeComponent();
            label3.Text = "";
            label_invalid_data.Text = "";
            label_how_many_loaded_files.Text = "";
            label_file_path_valid.Text = "";
            textBox_for_file_paths.Text = "";
            List_file_names = new List<string>();

            // S:\Programy Visual Studio\Wysylanie na maila\Wysylanie na maila\Config\

            config_path = @"Config\Properties.txt";
            file_paths = @"Config\File paths.txt";
            emials_list_path = @"Config\Emails_List.txt";
            authorization_path = @"Config\Email_Send_Authorization.txt";
            authorization_path_check = @"Config\Authorization_Check.txt";
            config = new List<Config_info>();
            paths = new List<string>();
            authorization = new List<Config_info>();
            authorization_check = new List<Config_info>();
            
            text_from_config = "";
            bool_statement = "";

            // gmail authorization
            authorization_gmail = "";
            authorization_password = "";
            authorization_pass = true;

            emails = new List<string>();


            // serializacja
            {
                /*
                 * serailize_to = "emials.xml";

                try
                {
                    My_Serialization.Deserialize(emails, serailize_to);
                    label6.Text = "deserializacja";
                }
                catch { }

                foreach (string s in emails)
                {
                    comboBox_send_mail_to.Items.Add(s);
                }
                */
            }


            // załadowanie authorization data            
            {
                // Z pliku do listy
                {
                    bool info_part = true;
                    string name;
                    string data;
                    foreach (string line in System.IO.File.ReadLines(authorization_path))
                    {
                        // setup
                        info_part = true;
                        name = "";
                        data = "";

                        foreach (char c in line)
                        {
                            if (c == ':')
                            {
                                info_part = false;
                                continue;
                            }

                            if (info_part) name += c;
                            else data += c;
                        }

                        // if nothing 
                        if (data == "")
                        {
                            if (name == "gmail") data = "nothing";
                            else if (name == "app_password") data = "nothing";
                        }

                        authorization.Add(new Config_info(name, data));
                    }
                }

                // Z listy do string
                {
                    // gmail
                    authorization_gmail = (authorization.Find(x => x.Name() == "gmail")).Data();

                    // password
                    authorization_password = (authorization.Find(x => x.Name() == "app_password")).Data();
                }
            }

            // załadowanie properties z pliku
            {
                // z pliku na do listy z odpowiednim nazewnictwem
                {
                    if (File.Exists(config_path))
                    {
                        bool info_part = true;
                        string name;
                        string data;
                        foreach (string line in System.IO.File.ReadLines(config_path))
                        {
                            // setup
                            info_part = true;
                            name = "";
                            data = "";

                            foreach (char c in line)
                            {
                                if (c == ':')
                                {
                                    info_part = false;
                                    continue;
                                }

                                if (info_part) name += c;
                                else data += c;
                            }

                            // if nothing 
                            if (data == "")
                            {
                                if (name == "from") data = "Application Sender";
                                else if (name == "tytle") data = "Tytle";
                                else if (name == "file_name") data = "pack";

                                else if (name == "add_date") data = "false";
                                else if (name == "add_hour") data = "false";
                                else if (name == "load_file_paths") data = "false";
                                else if (name == "zip") data = "false";
                                else if (name == "close_after_sending") data = "false";
                            }

                            config.Add(new Config_info(name, data));
                        }
                    }
                    else
                    {
                        using (StreamWriter sw = File.CreateText(config_path))
                        {
                            sw.WriteLine("from:Application Sender");
                            sw.WriteLine("tytle:Moja Klasa");
                            sw.WriteLine("file_name:code");
                            sw.WriteLine("add_date:true");
                            sw.WriteLine("add_hour:false");
                            sw.WriteLine("load_file_paths:true");
                            sw.WriteLine("zip:true");
                            sw.Write("close_after_sending:true");
                        }
                    }
                }

                // załadowanie danych z listy
                // jak coś tutaj zmieniam to trzeba też dodać dla save preferencess
                {
                    // from
                    text_from_config = (config.Find(x => x.Name() == "from")).Data();
                    textBox_from.Text = text_from_config;

                    // tytle
                    text_from_config = (config.Find(x => x.Name() == "tytle")).Data();
                    textBox_tytle.Text = text_from_config;

                    // file name
                    text_from_config = (config.Find(x => x.Name() == "file_name")).Data();
                    textBox_file_name.Text = text_from_config;

                    // add date
                    bool_statement = (config.Find(x => x.Name() == "add_date")).Data();
                    if (bool_statement == "true") checkBox_date.Checked = true;
                    else checkBox_date.Checked = false;

                    // add hour
                    bool_statement = (config.Find(x => x.Name() == "add_hour")).Data();
                    if (bool_statement == "true") checkBox_hour.Checked = true;
                    else checkBox_hour.Checked = false;

                    // load file from file paths
                    bool_statement = (config.Find(x => x.Name() == "load_file_paths")).Data();
                    if (bool_statement == "true") checkBox_load_file_paths.Checked = true;
                    else checkBox_load_file_paths.Checked = false;

                    // zip
                    bool_statement = (config.Find(x => x.Name() == "zip")).Data();
                    if (bool_statement == "true") checkBox_zip.Checked = true;
                    else checkBox_zip.Checked = false;

                    // close after sending
                    bool_statement = (config.Find(x => x.Name() == "close_after_sending")).Data();
                    if (bool_statement == "true") checkBox_close_after_sending.Checked = true;
                    else checkBox_close_after_sending.Checked = false;
                }
            }

            // załadowanie file paths
            {
                var lines = File.ReadLines(file_paths);
                foreach (var line in lines)
                {
                    paths.Add(line);
                    textBox_for_file_paths.Text += (line + "\r\n" + "\r\n");
                }
            }

            // załadowanie email list
            {
                var lines = File.ReadLines(emials_list_path);
                bool first = true;
                foreach (var line in lines)
                {
                    if (line != "\r\n")
                    {
                        if (first) comboBox_send_mail_to.Text = line;

                        emails.Add(line);
                        comboBox_send_mail_to.Items.Add(line);
                        first = false;
                    }
                }
            }

            // check co załadował
            {
                /*
                Console.WriteLine("loaded from file");
                foreach (Config_info o in config)
                {
                    Console.WriteLine("" + o.Name() + ":" + o.Data());
                }
                */
            }
                        
            // authorization check
            {
                bool need_for_check = true;
                if (File.Exists(authorization_path_check))
                {
                    // loading data from \Authorization_Check.txt
                    {
                        bool info_part = true;
                        string name;
                        string data;
                        foreach (string line in System.IO.File.ReadLines(authorization_path_check))
                        {
                            // setup
                            info_part = true;
                            name = "";
                            data = "";

                            foreach (char c in line)
                            {
                                if (c == ':')
                                {
                                    info_part = false;
                                    continue;
                                }

                                if (info_part) name += c;
                                else data += c;
                            }

                            authorization_check.Add(new Config_info(name, data));
                        }
                    }

                    // odczytywanie wartości
                    {
                        // gmail
                        string gmail_from_config = (authorization_check.Find(x => x.Name() == "gmail")).Data();

                        // tytle
                        string password_from_config = (authorization_check.Find(x => x.Name() == "app_password")).Data();

                        if (authorization_gmail == gmail_from_config && authorization_password == password_from_config) need_for_check = false;
                    }
                }
                
                if(need_for_check)
                { 
                    Authorization_Check();

                    // creating Authorization_Check.txt or removing old one
                    if (authorization_pass)
                    {
                        if (File.Exists(authorization_path_check)) File.Delete(authorization_path_check);
                        
                        using (StreamWriter sw = File.CreateText(authorization_path_check))
                        {
                            sw.WriteLine("gmail:" + authorization_gmail);
                            sw.Write("app_password:" + authorization_password);
                        }                        
                    }

                    else
                    {
                        // label3.Text = "Change configuration and restart";
                        // button_wyslij.Text = "Wrong authorization";
                    }
                }
            }
        }

        // send
        private async void button_wyslij_Click(object sender, EventArgs e)
        {
            if (textBox_tytle.Text != "" && textBox_file_name.Text != "" && comboBox_send_mail_to.Text != ""
                    && (List_file_names.Count() > 0 || ((paths.Count() > 0 || (textBox_for_file_paths.Text != "")) && checkBox_load_file_paths.Checked))
                    && is_there_internet_connection())
            {
                bool wrong_path = false;
                bool invalid_data = false;
                bool valid_email = false;

                if (authorization_pass)
                {
                    Application.UseWaitCursor = true;

                    try
                    {
                        string from_combo_box = comboBox_send_mail_to.Text;
                        if (IsValid(from_combo_box)) valid_email = true;                        

                        await Task.Run(() =>
                    {
                        // relict
                        {
                            /*
                            // dodaje 1 plik .txt
                            string file_name = textBox_file_name.Text + ".txt";

                            if (!File.Exists(file_name)) // If file does not exists
                            {
                                File.Create(file_name).Close(); // Create file
                                using (StreamWriter sw = File.AppendText(file_name))
                                {                        
                                    sw.WriteLine(textBox_body.Text); // Write text to .txt file
                                }
                            }
                            else // If file already exists
                            {
                                File.WriteAllText(file_name, String.Empty); // Clear file
                                using (StreamWriter sw = File.AppendText(file_name))
                                {
                                    sw.WriteLine(textBox_body.Text); // Write text to .txt file
                                }
                            }
                            */
                        }

                        var email = new MimeMessage();

                        // Application 
                        email.From.Add(new MailboxAddress(textBox_from.Text, "secret@gmail.com"));

                        // if (textBox_send_to.Text.Contains("@gmail.com")) email.To.Add(new MailboxAddress("Receiver Name", textBox_send_to.Text));
                        if (valid_email) email.To.Add(new MailboxAddress("Receiver Name", from_combo_box));
                        else
                        {
                            // label_invalid_data.Text = "invalid gmail";
                            invalid_data = true;
                            return;
                        }
                        // label_invalid_data.Text = "";


                        string tytle = textBox_tytle.Text;
                        string added = "";
                        DateTime date = DateTime.Now;

                        // date + hours
                        if (checkBox_hour.Checked && checkBox_date.Checked)
                        {
                            added += " " + date.ToString();
                            added = added.Remove(17);
                        }
                        // only date
                        else if (checkBox_date.Checked)
                        {
                            added += " " + date.ToString();
                            added = added.Remove(11);
                        }
                        // only hours
                        else if (checkBox_hour.Checked)
                        {
                            added += " " + date.ToString();
                            added = added.Remove(0, 11);
                            added = added.Remove(6);
                        }



                        tytle += added;
                        email.Subject = tytle;
                        var builder = new BodyBuilder();

                        // treść wiadomości
                        builder.TextBody = @"";



                        // z file path textBox --- sprawdzanie czy istnieje itd.  --- lista paths jest teraz pełna poprawnych ścieżek
                        if (checkBox_load_file_paths.Checked)
                        {
                            {
                                string lines = textBox_for_file_paths.Text;
                                var listStrLineElements = lines.Split('\n', (char)StringSplitOptions.RemoveEmptyEntries).ToList();

                                paths.Clear();
                                string helper;
                                foreach (string line in listStrLineElements)
                                {
                                    if (line != "\r" && line != "")
                                    {
                                        helper = line.TrimEnd('\r');
                                        paths.Add(helper);
                                    }
                                }

                                // sprawdzenie, czy można wysłać ---
                                foreach (string path in paths) if (!File.Exists(path))
                                    {
                                        // label_file_path_valid.Text = "wrong path";
                                        wrong_path = true;
                                        return;
                                    }

                            }
                        }

                        // zip
                        if (checkBox_zip.Checked)
                        {
                            string tmp_folder = @"tmp_for_zip";

                            Directory.CreateDirectory(tmp_folder);

                            // kopiujemy tam wszystko co chcemy wysłać
                            foreach (string name in List_file_names) System.IO.File.Copy(name, tmp_folder + "\\" + Path.GetFileName(name), true);

                            // kopiowanie ścieżek
                            if (checkBox_load_file_paths.Checked)
                                foreach (string p in paths) System.IO.File.Copy(p, tmp_folder + "\\" + Path.GetFileName(p), true);


                            string final = @"";
                            if (textBox_file_name.Text != "") final += textBox_file_name.Text + ".zip";
                            else final += "zip container.zip";
                            ZipFile.CreateFromDirectory(tmp_folder, final);

                            builder.Attachments.Add(final);



                            File.Delete(final);
                            Directory.Delete(tmp_folder, true);
                        }
                        // bez zip
                        else
                        {
                            // dodawanie załączników
                            foreach (string name in List_file_names) builder.Attachments.Add(name);

                            // dodawanie ścieżek
                            if (checkBox_load_file_paths.Checked)
                                foreach (string p in paths) builder.Attachments.Add(p);
                        }

                        // autoryzacja
                        email.Body = builder.ToMessageBody();
                        using (var smtp = new MailKit.Net.Smtp.SmtpClient())
                        {
                            // nowy stuff
                            {
                                smtp.SslProtocols = System.Security.Authentication.SslProtocols.Tls11;
                                smtp.ServerCertificateValidationCallback = (mysender, certificate, chain, sslPolicyErrors) => { return true; };
                                smtp.CheckCertificateRevocation = false;
                            }

                            smtp.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);


                            smtp.Authenticate(authorization_gmail, authorization_password);                            

                            smtp.Send(email);
                            smtp.Disconnect(true);
                        }
                    });
                    }
                    catch
                    {
                        Application.UseWaitCursor = false;
                        label3.Text = "something went wrong";                        
                        return;
                    }
                    Application.UseWaitCursor = false;
                }                

                if (wrong_path) label_file_path_valid.Text = "wrong path";
                else if(invalid_data) label_invalid_data.Text = "invalid gmail";                
                else if(!authorization_pass) label3.Text = "Change configuration and restart";
                else
                {
                    // czyszczenie
                    {
                        // usuwamy wszystko z listy
                        foreach (string name in List_file_names) File.Delete(name);
                        List_file_names.Clear();

                        counter++;
                        file_counter = 1;
                        label_how_many_loaded_files.Text = "";
                        label_file_path_valid.Text = "";
                        label_invalid_data.Text = "";
                    }

                    label3.Text = counter.ToString() + " Wiadomość wysłana";
                }

                // are we closing
                if(checkBox_close_after_sending.Checked)
                {
                    System.Windows.Forms.Application.Exit();
                }
            }
            else
            {
                label3.Text = "";
                label_invalid_data.Text = "niewypełnione dane lub brak załączonych plików";
            }
        }

        // save to preferrences --- zmiana listy i przepisanie danych z listy do pliku
        private void button_save_to_config_Click(object sender, EventArgs e)
        {
            // Properties
            {
                // zmiana obiektów na liście
                {
                    Config_info tmp;

                    // from
                    tmp = config.Find(x => x.Name() == "from");
                    tmp.Data(textBox_from.Text);

                    // tytle
                    tmp = config.Find(x => x.Name() == "tytle");
                    tmp.Data(textBox_tytle.Text);

                    // file name
                    tmp = config.Find(x => x.Name() == "file_name");
                    tmp.Data(textBox_file_name.Text);

                    // add date
                    tmp = config.Find(x => x.Name() == "add_date");
                    if (checkBox_date.Checked == true) tmp.Data("true");
                    else tmp.Data("false");

                    // add hour
                    tmp = config.Find(x => x.Name() == "add_hour");
                    if (checkBox_hour.Checked == true) tmp.Data("true");
                    else tmp.Data("false");

                    // load file from file paths
                    tmp = config.Find(x => x.Name() == "load_file_paths");
                    if (checkBox_load_file_paths.Checked == true) tmp.Data("true");
                    else tmp.Data("false");

                    // zip
                    tmp = config.Find(x => x.Name() == "zip");
                    if (checkBox_zip.Checked == true) tmp.Data("true");
                    else tmp.Data("false");

                    // close after sending
                    tmp = config.Find(x => x.Name() == "close_after_sending");
                    if (checkBox_close_after_sending.Checked == true) tmp.Data("true");
                    else tmp.Data("false");
                }

                // przepisanie listy na string i nadpisanie pliku
                {
                    string current_config = "";

                    Config_info last = config.Last();
                    foreach (Config_info obj in config)
                    {
                        if(obj != last)
                            current_config += (obj.Name() + ":" + obj.Data() + "\n");
                        else
                            current_config += (obj.Name() + ":" + obj.Data());
                    }
                    File.WriteAllText(config_path, current_config);
                }
            }

            // File Paths
            {
                // textBox_for_file_paths -> na plik                
                string lines = textBox_for_file_paths.Text;                
                var listStrLineElements = lines.Split('\n', (char)StringSplitOptions.RemoveEmptyEntries).ToList();
                List<string> final = new List<string>();

                string helper;
                foreach (string line in listStrLineElements)
                {
                    if (line != "\r" && line != "")
                    {
                        helper = line.TrimEnd('\r');
                        final.Add(helper);
                    }
                }

                string tmp = "";
                if (final.Count() > 0)
                {
                    string last = final.Last();
                    foreach (string s in final)
                    {
                        tmp += s;
                        if (s != last) tmp += "\r\n";
                    }
                }

                // przepisanie listy na string i nadpisanie pliku
                File.WriteAllText(file_paths, tmp);                
            }
        }



        // load next txt file
        private void button_load_next_file_Click(object sender, EventArgs e)
        {
            if (textBox_tytle.Text != "" && textBox_body.Text != "" && textBox_file_name.Text != "" && comboBox_send_mail_to.Text != "")
            {
                // dodaje 1 plik .txt
                string file_name = textBox_file_name.Text + ".txt";

                if (List_file_names.Count() > 0 && List_file_names.Contains(file_name))
                {
                    int c = 1;
                    file_name = textBox_file_name.Text + "_" + c.ToString() + ".txt";
                    while (List_file_names.Contains(file_name))
                    {
                        c++;
                        file_name = textBox_file_name.Text + "_" + c.ToString() + ".txt";
                    }
                }
                List_file_names.Add(file_name);


                File.Create(file_name).Close(); // Create file
                using (StreamWriter sw = File.AppendText(file_name))
                {
                    sw.WriteLine(textBox_body.Text); // Write text to .txt file
                }

                label_how_many_loaded_files.Text = file_counter + " Załadowany plik";
                file_counter++;
            }            
        }

        // file explorer
        private void button_open_explorer_Click(object sender, EventArgs e)
        {
            OpenFileDialog choofdlog = new OpenFileDialog();
            choofdlog.Filter = "All Files (*.*)|*.*";
            choofdlog.FilterIndex = 1;
            choofdlog.Multiselect = true;

            if (choofdlog.ShowDialog() == DialogResult.OK)
            {                
                string[] arrAllFiles = choofdlog.FileNames; //used when Multiselect = true           
                foreach(string p in arrAllFiles)
                {
                    textBox_for_file_paths.Text += p + "\r\n" + "\r\n";
                }
            }
        }

        // Email list
        private bool Is_email_on_the_list(string mabey_new_input)
        {
            foreach (string s in emails)
            {
                if (s == mabey_new_input) return true;
            }
            return false;
        }
        private void Save_list_to_file()
        {
            string tmp = "";
            if(emails.Count() > 0)
            { 
                string last = emails.Last();
                foreach (string s in emails)
                {
                    tmp += s;
                    if (s != last) tmp += ("\r\n");
                }
            }

            // przepisanie listy na string i nadpisanie pliku
            File.WriteAllText(emials_list_path, tmp);
        }        
        private void button_check_Click(object sender, EventArgs e)
        {
            string input = comboBox_send_mail_to.Text;
            if (Is_email_on_the_list(input))
            {
                emails.Remove(input);
                comboBox_send_mail_to.Items.Remove(input);
                comboBox_send_mail_to.Text = "";


                Save_list_to_file();
                // My_Serialization.SerializeObject(emails, serailize_to);
            }
        }
        private void button_email_add_Click(object sender, EventArgs e)
        {
            string input = comboBox_send_mail_to.Text;
            if (input != "" && !Is_email_on_the_list(input))
            {
                comboBox_send_mail_to.Items.Add(input);
                emails.Add(input);

                Save_list_to_file();
            }
        }

        // Authorization
        public void Authorization_Check()
        {
            // different exception
            {
                /*
                catch (SmtpCommandException e)
                {
                    authorization_pass = false;
                    button_wyslij.Text = "1";
                }
                catch (SmtpFailedRecipientsException e)
                {
                    authorization_pass = false;
                    button_wyslij.Text = "2";
                }
                catch (SmtpFailedRecipientException e)
                {
                    authorization_pass = false;
                    button_wyslij.Text = "3";
                }                
                catch (SmtpProtocolException e)
                {
                    authorization_pass = false;
                    button_wyslij.Text = "4";
                }
                catch (SmtpException e)
                {
                    authorization_pass = false;
                    button_wyslij.Text = "SMPT Exception No internet Connection";
                }
                */
            }

            using (var smtp = new MailKit.Net.Smtp.SmtpClient())
            {
                // Internet
                if (!is_there_internet_connection())
                {
                    button_wyslij.Text = "No internet connection";
                    authorization_pass = false; 
                    return;
                }

                // nowy stuff
                {
                    smtp.SslProtocols = System.Security.Authentication.SslProtocols.Tls11;
                    smtp.ServerCertificateValidationCallback = (mysender, certificate, chain, sslPolicyErrors) => { return true; };
                    smtp.CheckCertificateRevocation = false;
                }

                // Ability to connect to SMTP
                try
                {                    
                    smtp.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                }
                catch
                {
                    authorization_pass = false;
                    label3.Text = "SMTP server is unreachable";
                    button_wyslij.Text = "Unable to authorize";
                    smtp.Disconnect(true); return;
                }                

                // Is authorization right
                try 
                {
                    smtp.Authenticate(authorization_gmail, authorization_password);
                }
                catch
                {
                    authorization_pass = false;
                    label3.Text = "Change configuration and restart";
                    button_wyslij.Text = "Wrong authorization";
                }

                smtp.Disconnect(true);
            }
        }
        bool is_there_internet_connection()
        {
            try
            {
                Ping myPing = new Ping();
                String host = "google.com";
                byte[] buffer = new byte[32];
                int timeout = 1000;
                PingOptions pingOptions = new PingOptions();
                PingReply reply = myPing.Send(host, timeout, buffer, pingOptions);
                return (reply.Status == IPStatus.Success);
            }
            catch (Exception)
            {
                return false;
            }
        }
        private static bool IsValid(string email)
        {
            var valid = true;

            try { var emailAddress = new MailAddress(email); }
            catch { valid = false; }

            return valid;
        }

        // drag and drop
        private void textBox_for_file_paths_DragDrop(object sender, DragEventArgs e)
        {
            string[] file_paths = (string[])e.Data.GetData(DataFormats.FileDrop);            
            foreach (string p in file_paths)
            {
                textBox_for_file_paths.Text += p + "\r\n" + "\r\n";
            }
        }
        private void textBox_for_file_paths_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        // ComboBox not highlighted
        void comboBox1_DropDownClosed(object sender, EventArgs e)
        {
            this.BeginInvoke(new Action(() => { comboBox_send_mail_to.Select(0, 0); }));
        }        
    }
}
