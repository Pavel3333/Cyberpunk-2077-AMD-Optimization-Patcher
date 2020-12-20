using MouseEventHandler = System.Windows.Forms.MouseEventHandler;
using MouseEventArgs = System.Windows.Forms.MouseEventArgs;

namespace Cyberpunk_2077_AMD_Optimization_Patcher
{
    partial class Patcher
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.patchButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.cyberpunkPathLabel = new System.Windows.Forms.Label();
            this.changePathButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textboxErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.patchingBGWorker = new System.ComponentModel.BackgroundWorker();
            this.chooseCyberpunkFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textboxErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // patchButton
            // 
            this.patchButton.Enabled = false;
            this.patchButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.patchButton.Location = new System.Drawing.Point(12, 44);
            this.patchButton.Name = "patchButton";
            this.patchButton.Size = new System.Drawing.Size(141, 31);
            this.patchButton.TabIndex = 0;
            this.patchButton.Text = "Patch!";
            this.patchButton.UseVisualStyleBackColor = true;
            this.patchButton.Click += new System.EventHandler(this.patchButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.exitButton.Location = new System.Drawing.Point(543, 44);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(69, 32);
            this.exitButton.TabIndex = 2;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.progressBar1);
            this.panel1.Controls.Add(this.cyberpunkPathLabel);
            this.panel1.Controls.Add(this.patchButton);
            this.panel1.Controls.Add(this.changePathButton);
            this.panel1.Controls.Add(this.exitButton);
            this.panel1.Location = new System.Drawing.Point(0, 354);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(624, 87);
            this.panel1.TabIndex = 2;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.ForeColor = System.Drawing.Color.Gray;
            this.textBox1.Location = new System.Drawing.Point(159, 11);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(369, 23);
            this.textBox1.TabIndex = 4;
            this.textBox1.Text = "Path to Cyberpunk2077.exe";
            this.textBox1.Enter += new System.EventHandler(textBox1_Enter);
            this.textBox1.Leave += new System.EventHandler(textBox1_Leave);
            this.textBox1.TextChanged += new System.EventHandler(textBox1_TextChanged);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(159, 44);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(369, 31);
            this.progressBar1.Step = 5;
            this.progressBar1.TabIndex = 3;
            // 
            // cyberpunkPathLabel
            // 
            this.cyberpunkPathLabel.AutoSize = true;
            this.cyberpunkPathLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cyberpunkPathLabel.Location = new System.Drawing.Point(9, 17);
            this.cyberpunkPathLabel.Name = "cyberpunkPathLabel";
            this.cyberpunkPathLabel.Size = new System.Drawing.Size(144, 17);
            this.cyberpunkPathLabel.TabIndex = 2;
            this.cyberpunkPathLabel.Text = "Cyberpunk 2077 path";
            this.cyberpunkPathLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // changePathButton
            // 
            this.changePathButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.changePathButton.Location = new System.Drawing.Point(543, 6);
            this.changePathButton.Name = "changePathButton";
            this.changePathButton.Size = new System.Drawing.Size(69, 32);
            this.changePathButton.TabIndex = 1;
            this.changePathButton.Text = "Choose";
            this.changePathButton.UseVisualStyleBackColor = true;
            this.changePathButton.Click += new System.EventHandler(this.changePathButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Cyberpunk_2077_AMD_Optimization_Patcher.Properties.Resources.cyberpunk;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(624, 351);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // textboxErrorProvider
            // 
            this.textboxErrorProvider.ContainerControl = this;
            // 
            // patchingBGWorker
            // 
            this.patchingBGWorker.WorkerReportsProgress = true;
            this.patchingBGWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.patchingBGWorker_DoWork);
            this.patchingBGWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.patchingBGWorker_ProgressChanged);
            this.patchingBGWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.patchingBGWorker_RunWorkerCompleted);
            // 
            // chooseCyberpunkFileDialog
            // 
            this.chooseCyberpunkFileDialog.Filter = "Cyberpunk 2077 executable file|Cyberpunk2077.exe";
            this.chooseCyberpunkFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.chooseCyberpunkFileDialog_FileOk);
            // 
            // Patcher
            // 
            this.AllowDrop = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.DoubleBuffered = true;
            this.DragDrop += new System.Windows.Forms.DragEventHandler(Patcher_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(Patcher_DragEnter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Patcher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cyberpunk 2077 AMD Optimization Patcher";
            this.Load += new System.EventHandler(Patcher_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Patcher_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textboxErrorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button patchButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label cyberpunkPathLabel;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button changePathButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ErrorProvider textboxErrorProvider;
        private System.ComponentModel.BackgroundWorker patchingBGWorker;
        private System.Windows.Forms.OpenFileDialog chooseCyberpunkFileDialog;
    }
}

