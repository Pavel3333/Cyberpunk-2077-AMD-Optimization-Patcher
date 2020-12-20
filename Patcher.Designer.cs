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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Patcher));
            this.patchButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.cyberpunkPathLabel = new System.Windows.Forms.Label();
            this.changePathButton = new System.Windows.Forms.Button();
            this.textboxErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.patchingBGWorker = new System.ComponentModel.BackgroundWorker();
            this.chooseCyberpunkFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textboxErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // patchButton
            // 
            resources.ApplyResources(this.patchButton, "patchButton");
            this.textboxErrorProvider.SetError(this.patchButton, resources.GetString("patchButton.Error"));
            this.textboxErrorProvider.SetIconAlignment(this.patchButton, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("patchButton.IconAlignment"))));
            this.textboxErrorProvider.SetIconPadding(this.patchButton, ((int)(resources.GetObject("patchButton.IconPadding"))));
            this.patchButton.Name = "patchButton";
            this.patchButton.UseVisualStyleBackColor = true;
            this.patchButton.Click += new System.EventHandler(this.patchButton_Click);
            // 
            // exitButton
            // 
            resources.ApplyResources(this.exitButton, "exitButton");
            this.textboxErrorProvider.SetError(this.exitButton, resources.GetString("exitButton.Error"));
            this.textboxErrorProvider.SetIconAlignment(this.exitButton, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("exitButton.IconAlignment"))));
            this.textboxErrorProvider.SetIconPadding(this.exitButton, ((int)(resources.GetObject("exitButton.IconPadding"))));
            this.exitButton.Name = "exitButton";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.progressBar1);
            this.panel1.Controls.Add(this.cyberpunkPathLabel);
            this.panel1.Controls.Add(this.patchButton);
            this.panel1.Controls.Add(this.changePathButton);
            this.panel1.Controls.Add(this.exitButton);
            this.textboxErrorProvider.SetError(this.panel1, resources.GetString("panel1.Error"));
            this.textboxErrorProvider.SetIconAlignment(this.panel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("panel1.IconAlignment"))));
            this.textboxErrorProvider.SetIconPadding(this.panel1, ((int)(resources.GetObject("panel1.IconPadding"))));
            this.panel1.Name = "panel1";
            // 
            // textBox1
            // 
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textboxErrorProvider.SetError(this.textBox1, resources.GetString("textBox1.Error"));
            this.textBox1.ForeColor = System.Drawing.Color.Gray;
            this.textboxErrorProvider.SetIconAlignment(this.textBox1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("textBox1.IconAlignment"))));
            this.textboxErrorProvider.SetIconPadding(this.textBox1, ((int)(resources.GetObject("textBox1.IconPadding"))));
            this.textBox1.Name = "textBox1";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.Enter += new System.EventHandler(this.textBox1_Enter);
            this.textBox1.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // progressBar1
            // 
            resources.ApplyResources(this.progressBar1, "progressBar1");
            this.textboxErrorProvider.SetError(this.progressBar1, resources.GetString("progressBar1.Error"));
            this.textboxErrorProvider.SetIconAlignment(this.progressBar1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("progressBar1.IconAlignment"))));
            this.textboxErrorProvider.SetIconPadding(this.progressBar1, ((int)(resources.GetObject("progressBar1.IconPadding"))));
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Step = 5;
            // 
            // cyberpunkPathLabel
            // 
            resources.ApplyResources(this.cyberpunkPathLabel, "cyberpunkPathLabel");
            this.textboxErrorProvider.SetError(this.cyberpunkPathLabel, resources.GetString("cyberpunkPathLabel.Error"));
            this.textboxErrorProvider.SetIconAlignment(this.cyberpunkPathLabel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("cyberpunkPathLabel.IconAlignment"))));
            this.textboxErrorProvider.SetIconPadding(this.cyberpunkPathLabel, ((int)(resources.GetObject("cyberpunkPathLabel.IconPadding"))));
            this.cyberpunkPathLabel.Name = "cyberpunkPathLabel";
            // 
            // changePathButton
            // 
            resources.ApplyResources(this.changePathButton, "changePathButton");
            this.textboxErrorProvider.SetError(this.changePathButton, resources.GetString("changePathButton.Error"));
            this.textboxErrorProvider.SetIconAlignment(this.changePathButton, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("changePathButton.IconAlignment"))));
            this.textboxErrorProvider.SetIconPadding(this.changePathButton, ((int)(resources.GetObject("changePathButton.IconPadding"))));
            this.changePathButton.Name = "changePathButton";
            this.changePathButton.UseVisualStyleBackColor = true;
            this.changePathButton.Click += new System.EventHandler(this.changePathButton_Click);
            // 
            // textboxErrorProvider
            // 
            this.textboxErrorProvider.ContainerControl = this;
            resources.ApplyResources(this.textboxErrorProvider, "textboxErrorProvider");
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
            resources.ApplyResources(this.chooseCyberpunkFileDialog, "chooseCyberpunkFileDialog");
            this.chooseCyberpunkFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.chooseCyberpunkFileDialog_FileOk);
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.textboxErrorProvider.SetError(this.pictureBox1, resources.GetString("pictureBox1.Error"));
            this.textboxErrorProvider.SetIconAlignment(this.pictureBox1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("pictureBox1.IconAlignment"))));
            this.textboxErrorProvider.SetIconPadding(this.pictureBox1, ((int)(resources.GetObject("pictureBox1.IconPadding"))));
            this.pictureBox1.Image = global::Cyberpunk_2077_AMD_Optimization_Patcher.Properties.Resources.cyberpunk;
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // Patcher
            // 
            resources.ApplyResources(this, "$this");
            this.AllowDrop = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Patcher";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Patcher_FormClosing);
            this.Load += new System.EventHandler(this.Patcher_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Patcher_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Patcher_DragEnter);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textboxErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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

