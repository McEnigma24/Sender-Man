namespace Wysylanie_na_maila
{
    partial class Sender_Man
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sender_Man));
            this.button_wyslij = new System.Windows.Forms.Button();
            this.textBox_tytle = new System.Windows.Forms.TextBox();
            this.textBox_body = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_file_name = new System.Windows.Forms.TextBox();
            this.button_load_next_file = new System.Windows.Forms.Button();
            this.label_how_many_loaded_files = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label_invalid_data = new System.Windows.Forms.Label();
            this.checkBox_date = new System.Windows.Forms.CheckBox();
            this.checkBox_hour = new System.Windows.Forms.CheckBox();
            this.button_save_to_config = new System.Windows.Forms.Button();
            this.textBox_for_file_paths = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.checkBox_load_file_paths = new System.Windows.Forms.CheckBox();
            this.label_file_path_valid = new System.Windows.Forms.Label();
            this.button_open_explorer = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.checkBox_zip = new System.Windows.Forms.CheckBox();
            this.comboBox_send_mail_to = new System.Windows.Forms.ComboBox();
            this.button_email_delete = new System.Windows.Forms.Button();
            this.button_email_add = new System.Windows.Forms.Button();
            this.checkBox_close_after_sending = new System.Windows.Forms.CheckBox();
            this.textBox_from = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_wyslij
            // 
            this.button_wyslij.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button_wyslij.Location = new System.Drawing.Point(224, 364);
            this.button_wyslij.Name = "button_wyslij";
            this.button_wyslij.Size = new System.Drawing.Size(216, 43);
            this.button_wyslij.TabIndex = 0;
            this.button_wyslij.Text = "Send";
            this.button_wyslij.UseVisualStyleBackColor = true;
            this.button_wyslij.Click += new System.EventHandler(this.button_wyslij_Click);
            // 
            // textBox_tytle
            // 
            this.textBox_tytle.Location = new System.Drawing.Point(239, 52);
            this.textBox_tytle.Name = "textBox_tytle";
            this.textBox_tytle.Size = new System.Drawing.Size(201, 20);
            this.textBox_tytle.TabIndex = 1;
            // 
            // textBox_body
            // 
            this.textBox_body.Location = new System.Drawing.Point(32, 111);
            this.textBox_body.MaxLength = 2147483647;
            this.textBox_body.Multiline = true;
            this.textBox_body.Name = "textBox_body";
            this.textBox_body.Size = new System.Drawing.Size(408, 232);
            this.textBox_body.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(235, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "Title";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(28, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 24);
            this.label2.TabIndex = 4;
            this.label2.Text = "Body";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(277, 347);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Wiadomość wysłana";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(452, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 24);
            this.label4.TabIndex = 7;
            this.label4.Text = "File Name";
            // 
            // textBox_file_name
            // 
            this.textBox_file_name.Location = new System.Drawing.Point(456, 52);
            this.textBox_file_name.Name = "textBox_file_name";
            this.textBox_file_name.Size = new System.Drawing.Size(102, 20);
            this.textBox_file_name.TabIndex = 6;
            // 
            // button_load_next_file
            // 
            this.button_load_next_file.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button_load_next_file.Location = new System.Drawing.Point(32, 364);
            this.button_load_next_file.Name = "button_load_next_file";
            this.button_load_next_file.Size = new System.Drawing.Size(150, 43);
            this.button_load_next_file.TabIndex = 8;
            this.button_load_next_file.Text = "Load next file";
            this.button_load_next_file.UseVisualStyleBackColor = true;
            this.button_load_next_file.Click += new System.EventHandler(this.button_load_next_file_Click);
            // 
            // label_how_many_loaded_files
            // 
            this.label_how_many_loaded_files.AutoSize = true;
            this.label_how_many_loaded_files.Location = new System.Drawing.Point(64, 347);
            this.label_how_many_loaded_files.Name = "label_how_many_loaded_files";
            this.label_how_many_loaded_files.Size = new System.Drawing.Size(86, 13);
            this.label_how_many_loaded_files.TabIndex = 9;
            this.label_how_many_loaded_files.Text = "Załadowany plik";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(28, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 24);
            this.label6.TabIndex = 13;
            this.label6.Text = "To";
            // 
            // label_invalid_data
            // 
            this.label_invalid_data.AutoSize = true;
            this.label_invalid_data.Location = new System.Drawing.Point(171, 89);
            this.label_invalid_data.Name = "label_invalid_data";
            this.label_invalid_data.Size = new System.Drawing.Size(239, 13);
            this.label_invalid_data.TabIndex = 14;
            this.label_invalid_data.Text = "niewypełnone dane lub brak załączonych plików";
            // 
            // checkBox_date
            // 
            this.checkBox_date.AutoSize = true;
            this.checkBox_date.Location = new System.Drawing.Point(371, 25);
            this.checkBox_date.Name = "checkBox_date";
            this.checkBox_date.Size = new System.Drawing.Size(69, 17);
            this.checkBox_date.TabIndex = 17;
            this.checkBox_date.Text = "Add date";
            this.checkBox_date.UseVisualStyleBackColor = true;
            // 
            // checkBox_hour
            // 
            this.checkBox_hour.AutoSize = true;
            this.checkBox_hour.Location = new System.Drawing.Point(296, 25);
            this.checkBox_hour.Name = "checkBox_hour";
            this.checkBox_hour.Size = new System.Drawing.Size(69, 17);
            this.checkBox_hour.TabIndex = 18;
            this.checkBox_hour.Text = "Add hour";
            this.checkBox_hour.UseVisualStyleBackColor = true;
            // 
            // button_save_to_config
            // 
            this.button_save_to_config.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button_save_to_config.Location = new System.Drawing.Point(530, 353);
            this.button_save_to_config.Name = "button_save_to_config";
            this.button_save_to_config.Size = new System.Drawing.Size(163, 54);
            this.button_save_to_config.TabIndex = 19;
            this.button_save_to_config.Text = "Save Preferences";
            this.button_save_to_config.UseVisualStyleBackColor = true;
            this.button_save_to_config.Click += new System.EventHandler(this.button_save_to_config_Click);
            // 
            // textBox_for_file_paths
            // 
            this.textBox_for_file_paths.AllowDrop = true;
            this.textBox_for_file_paths.Location = new System.Drawing.Point(456, 111);
            this.textBox_for_file_paths.MaxLength = 2147483647;
            this.textBox_for_file_paths.Multiline = true;
            this.textBox_for_file_paths.Name = "textBox_for_file_paths";
            this.textBox_for_file_paths.Size = new System.Drawing.Size(237, 189);
            this.textBox_for_file_paths.TabIndex = 20;
            this.textBox_for_file_paths.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBox_for_file_paths_DragDrop);
            this.textBox_for_file_paths.DragEnter += new System.Windows.Forms.DragEventHandler(this.textBox_for_file_paths_DragEnter);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(452, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 24);
            this.label5.TabIndex = 21;
            this.label5.Text = "File path";
            // 
            // checkBox_load_file_paths
            // 
            this.checkBox_load_file_paths.AutoSize = true;
            this.checkBox_load_file_paths.Location = new System.Drawing.Point(456, 306);
            this.checkBox_load_file_paths.Name = "checkBox_load_file_paths";
            this.checkBox_load_file_paths.Size = new System.Drawing.Size(138, 17);
            this.checkBox_load_file_paths.TabIndex = 22;
            this.checkBox_load_file_paths.Text = "Load files while sending";
            this.checkBox_load_file_paths.UseVisualStyleBackColor = true;
            // 
            // label_file_path_valid
            // 
            this.label_file_path_valid.AutoSize = true;
            this.label_file_path_valid.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_file_path_valid.Location = new System.Drawing.Point(564, 84);
            this.label_file_path_valid.Name = "label_file_path_valid";
            this.label_file_path_valid.Size = new System.Drawing.Size(129, 20);
            this.label_file_path_valid.TabIndex = 23;
            this.label_file_path_valid.Text = "invalid file path";
            // 
            // button_open_explorer
            // 
            this.button_open_explorer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button_open_explorer.Location = new System.Drawing.Point(600, 306);
            this.button_open_explorer.Name = "button_open_explorer";
            this.button_open_explorer.Size = new System.Drawing.Size(93, 28);
            this.button_open_explorer.TabIndex = 24;
            this.button_open_explorer.Text = "Find file";
            this.button_open_explorer.UseVisualStyleBackColor = true;
            this.button_open_explorer.Click += new System.EventHandler(this.button_open_explorer_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(608, 337);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "or drag and drop";
            // 
            // checkBox_zip
            // 
            this.checkBox_zip.Location = new System.Drawing.Point(446, 390);
            this.checkBox_zip.Name = "checkBox_zip";
            this.checkBox_zip.Size = new System.Drawing.Size(78, 20);
            this.checkBox_zip.TabIndex = 26;
            this.checkBox_zip.Text = "pack to zip";
            this.checkBox_zip.UseVisualStyleBackColor = true;
            // 
            // comboBox_send_mail_to
            // 
            this.comboBox_send_mail_to.FormattingEnabled = true;
            this.comboBox_send_mail_to.Location = new System.Drawing.Point(32, 52);
            this.comboBox_send_mail_to.Name = "comboBox_send_mail_to";
            this.comboBox_send_mail_to.Size = new System.Drawing.Size(192, 21);
            this.comboBox_send_mail_to.TabIndex = 27;
            this.comboBox_send_mail_to.DropDown += new System.EventHandler(this.comboBox1_DropDownClosed);
            this.comboBox_send_mail_to.DropDownClosed += new System.EventHandler(this.comboBox1_DropDownClosed);
            // 
            // button_email_delete
            // 
            this.button_email_delete.Location = new System.Drawing.Point(174, 20);
            this.button_email_delete.Name = "button_email_delete";
            this.button_email_delete.Size = new System.Drawing.Size(50, 26);
            this.button_email_delete.TabIndex = 28;
            this.button_email_delete.Text = "Delete";
            this.button_email_delete.UseVisualStyleBackColor = true;
            this.button_email_delete.Click += new System.EventHandler(this.button_check_Click);
            // 
            // button_email_add
            // 
            this.button_email_add.Location = new System.Drawing.Point(118, 20);
            this.button_email_add.Name = "button_email_add";
            this.button_email_add.Size = new System.Drawing.Size(50, 26);
            this.button_email_add.TabIndex = 29;
            this.button_email_add.Text = "Add";
            this.button_email_add.UseVisualStyleBackColor = true;
            this.button_email_add.Click += new System.EventHandler(this.button_email_add_Click);
            // 
            // checkBox_close_after_sending
            // 
            this.checkBox_close_after_sending.AutoSize = true;
            this.checkBox_close_after_sending.Location = new System.Drawing.Point(456, 326);
            this.checkBox_close_after_sending.Name = "checkBox_close_after_sending";
            this.checkBox_close_after_sending.Size = new System.Drawing.Size(116, 17);
            this.checkBox_close_after_sending.TabIndex = 31;
            this.checkBox_close_after_sending.Text = "Close after sending";
            this.checkBox_close_after_sending.UseVisualStyleBackColor = true;
            // 
            // textBox_from
            // 
            this.textBox_from.Location = new System.Drawing.Point(568, 52);
            this.textBox_from.Name = "textBox_from";
            this.textBox_from.Size = new System.Drawing.Size(125, 20);
            this.textBox_from.TabIndex = 32;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label8.Location = new System.Drawing.Point(564, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 24);
            this.label8.TabIndex = 33;
            this.label8.Text = "From";
            // 
            // Sender_Man
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 427);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox_from);
            this.Controls.Add(this.checkBox_close_after_sending);
            this.Controls.Add(this.button_email_add);
            this.Controls.Add(this.button_email_delete);
            this.Controls.Add(this.comboBox_send_mail_to);
            this.Controls.Add(this.checkBox_zip);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button_open_explorer);
            this.Controls.Add(this.label_file_path_valid);
            this.Controls.Add(this.checkBox_load_file_paths);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox_for_file_paths);
            this.Controls.Add(this.button_save_to_config);
            this.Controls.Add(this.checkBox_hour);
            this.Controls.Add(this.checkBox_date);
            this.Controls.Add(this.label_invalid_data);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label_how_many_loaded_files);
            this.Controls.Add(this.button_load_next_file);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_file_name);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_body);
            this.Controls.Add(this.textBox_tytle);
            this.Controls.Add(this.button_wyslij);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.Name = "Sender_Man";
            this.Text = "Sender Man";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_wyslij;
        private System.Windows.Forms.TextBox textBox_tytle;
        private System.Windows.Forms.TextBox textBox_body;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_file_name;
        private System.Windows.Forms.Button button_load_next_file;
        private System.Windows.Forms.Label label_how_many_loaded_files;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label_invalid_data;
        private System.Windows.Forms.CheckBox checkBox_date;
        private System.Windows.Forms.CheckBox checkBox_hour;
        private System.Windows.Forms.Button button_save_to_config;
        private System.Windows.Forms.TextBox textBox_for_file_paths;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkBox_load_file_paths;
        private System.Windows.Forms.Label label_file_path_valid;
        private System.Windows.Forms.Button button_open_explorer;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox checkBox_zip;
        private System.Windows.Forms.ComboBox comboBox_send_mail_to;
        private System.Windows.Forms.Button button_email_delete;
        private System.Windows.Forms.Button button_email_add;
        private System.Windows.Forms.CheckBox checkBox_close_after_sending;
        private System.Windows.Forms.TextBox textBox_from;
        private System.Windows.Forms.Label label8;
    }
}

