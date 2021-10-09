namespace PerfectPaint
{
    public partial class frmMain:System.Windows.Forms.Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        public System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if(disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.dlgBoxOpen = new System.Windows.Forms.OpenFileDialog();
            this.dlgBoxSave = new System.Windows.Forms.SaveFileDialog();
            this.drpSize = new System.Windows.Forms.ComboBox();
            this.txtSizeEdit = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dlgBoxColor = new System.Windows.Forms.ColorDialog();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.btnRedo = new System.Windows.Forms.Button();
            this.btnUndo = new System.Windows.Forms.Button();
            this.mnuMenu = new System.Windows.Forms.PictureBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.toolBoxPadColor = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.toolBoxColorsMore = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.toolBoxColors = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.toolBoxShapes = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolBoxTools = new System.Windows.Forms.PictureBox();
            this.picBoxPad = new System.Windows.Forms.PictureBox();
            this.btnMenu = new System.Windows.Forms.PictureBox();
            this.chkFill = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mnuMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toolBoxPadColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toolBoxColorsMore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toolBoxColors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toolBoxShapes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toolBoxTools)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxPad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // dlgBoxOpen
            // 
            this.dlgBoxOpen.FileName = "openFileDialog1";
            // 
            // dlgBoxSave
            // 
            this.dlgBoxSave.CheckPathExists = false;
            this.dlgBoxSave.DefaultExt = "bmp";
            this.dlgBoxSave.FileName = "New Image";
            this.dlgBoxSave.Filter = "24-bit Bitmap|*.bmp|JPEG|*.jpg|GIF|*.gif|PNG|*.png|TIFF|*.tiff|ICON|*.ico|EMF|*.e" +
                "mf";
            // 
            // drpSize
            // 
            this.drpSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.drpSize.FormattingEnabled = true;
            this.drpSize.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.drpSize.Items.AddRange(new object[] {
            " 1                 point",
            " 2                 point",
            " 3                 point",
            " 4                 point",
            " 5                 point ",
            " 6                 point",
            " 7                 point",
            " 8                 point",
            " 9                 point",
            " 10               point"});
            this.drpSize.Location = new System.Drawing.Point(633, 49);
            this.drpSize.Name = "drpSize";
            this.drpSize.Size = new System.Drawing.Size(110, 21);
            this.drpSize.TabIndex = 16;
            this.drpSize.SelectedIndexChanged += new System.EventHandler(this.drpSize_SelectedIndexChanged);
            // 
            // txtSizeEdit
            // 
            this.txtSizeEdit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSizeEdit.Location = new System.Drawing.Point(769, 50);
            this.txtSizeEdit.Name = "txtSizeEdit";
            this.txtSizeEdit.Size = new System.Drawing.Size(58, 20);
            this.txtSizeEdit.TabIndex = 19;
            this.txtSizeEdit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSizeEdit_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Candara", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(774, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 14);
            this.label1.TabIndex = 20;
            this.label1.Text = "Edit size";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dlgBoxColor
            // 
            this.dlgBoxColor.FullOpen = true;
            // 
            // pictureBox9
            // 
            this.pictureBox9.Image = global::PerfectPaint.Properties.Resources.Sep;
            this.pictureBox9.InitialImage = null;
            this.pictureBox9.Location = new System.Drawing.Point(856, 33);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(15, 53);
            this.pictureBox9.TabIndex = 23;
            this.pictureBox9.TabStop = false;
            // 
            // btnRedo
            // 
            this.btnRedo.BackColor = System.Drawing.Color.LightGray;
            this.btnRedo.BackgroundImage = global::PerfectPaint.Properties.Resources.Redo;
            this.btnRedo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnRedo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnRedo.FlatAppearance.BorderSize = 3;
            this.btnRedo.Location = new System.Drawing.Point(897, 63);
            this.btnRedo.Name = "btnRedo";
            this.btnRedo.Size = new System.Drawing.Size(62, 25);
            this.btnRedo.TabIndex = 22;
            this.btnRedo.UseVisualStyleBackColor = false;
            this.btnRedo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnRedo_MouseDown);
            // 
            // btnUndo
            // 
            this.btnUndo.BackColor = System.Drawing.Color.LightGray;
            this.btnUndo.BackgroundImage = global::PerfectPaint.Properties.Resources.Undo;
            this.btnUndo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnUndo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnUndo.FlatAppearance.BorderSize = 3;
            this.btnUndo.Location = new System.Drawing.Point(897, 33);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(62, 25);
            this.btnUndo.TabIndex = 21;
            this.btnUndo.UseVisualStyleBackColor = false;
            this.btnUndo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnUndo_MouseDown);
            // 
            // mnuMenu
            // 
            this.mnuMenu.Location = new System.Drawing.Point(0, 22);
            this.mnuMenu.Name = "mnuMenu";
            this.mnuMenu.Size = new System.Drawing.Size(417, 290);
            this.mnuMenu.TabIndex = 4;
            this.mnuMenu.TabStop = false;
            this.mnuMenu.Visible = false;
            this.mnuMenu.MouseClick += new System.Windows.Forms.MouseEventHandler(this.mnuMenu_MouseClick);
            this.mnuMenu.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mnuMenu_MouseMove);
            // 
            // pictureBox8
            // 
            this.pictureBox8.Image = global::PerfectPaint.Properties.Resources.SizeCaption;
            this.pictureBox8.InitialImage = null;
            this.pictureBox8.Location = new System.Drawing.Point(678, 93);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(24, 10);
            this.pictureBox8.TabIndex = 18;
            this.pictureBox8.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = global::PerfectPaint.Properties.Resources.Sep;
            this.pictureBox6.InitialImage = null;
            this.pictureBox6.Location = new System.Drawing.Point(597, 33);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(15, 53);
            this.pictureBox6.TabIndex = 17;
            this.pictureBox6.TabStop = false;
            // 
            // toolBoxPadColor
            // 
            this.toolBoxPadColor.BackColor = System.Drawing.Color.Black;
            this.toolBoxPadColor.InitialImage = null;
            this.toolBoxPadColor.Location = new System.Drawing.Point(253, 36);
            this.toolBoxPadColor.Name = "toolBoxPadColor";
            this.toolBoxPadColor.Size = new System.Drawing.Size(30, 46);
            this.toolBoxPadColor.TabIndex = 15;
            this.toolBoxPadColor.TabStop = false;
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = global::PerfectPaint.Properties.Resources.ColorsMoreCaption;
            this.pictureBox7.InitialImage = null;
            this.pictureBox7.Location = new System.Drawing.Point(534, 75);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(32, 24);
            this.pictureBox7.TabIndex = 14;
            this.pictureBox7.TabStop = false;
            // 
            // toolBoxColorsMore
            // 
            this.toolBoxColorsMore.Image = global::PerfectPaint.Properties.Resources.ColorsMore;
            this.toolBoxColorsMore.InitialImage = null;
            this.toolBoxColorsMore.Location = new System.Drawing.Point(527, 29);
            this.toolBoxColorsMore.Name = "toolBoxColorsMore";
            this.toolBoxColorsMore.Size = new System.Drawing.Size(46, 46);
            this.toolBoxColorsMore.TabIndex = 13;
            this.toolBoxColorsMore.TabStop = false;
            this.toolBoxColorsMore.Click += new System.EventHandler(this.toolBoxColorsMore_Click);
            this.toolBoxColorsMore.MouseEnter += new System.EventHandler(this.toolBoxColorsMore_MouseEnter);
            this.toolBoxColorsMore.MouseLeave += new System.EventHandler(this.toolBoxColorsMore_MouseLeave);
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::PerfectPaint.Properties.Resources.ColorsCaption;
            this.pictureBox5.InitialImage = null;
            this.pictureBox5.Location = new System.Drawing.Point(386, 92);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(35, 12);
            this.pictureBox5.TabIndex = 12;
            this.pictureBox5.TabStop = false;
            // 
            // toolBoxColors
            // 
            this.toolBoxColors.Image = global::PerfectPaint.Properties.Resources.Colors;
            this.toolBoxColors.InitialImage = null;
            this.toolBoxColors.Location = new System.Drawing.Point(299, 36);
            this.toolBoxColors.Name = "toolBoxColors";
            this.toolBoxColors.Size = new System.Drawing.Size(222, 46);
            this.toolBoxColors.TabIndex = 11;
            this.toolBoxColors.TabStop = false;
            this.toolBoxColors.MouseClick += new System.Windows.Forms.MouseEventHandler(this.toolBoxColors_MouseClick);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::PerfectPaint.Properties.Resources.Sep;
            this.pictureBox4.InitialImage = null;
            this.pictureBox4.Location = new System.Drawing.Point(219, 33);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(15, 53);
            this.pictureBox4.TabIndex = 10;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::PerfectPaint.Properties.Resources.ShapeCaption;
            this.pictureBox3.InitialImage = null;
            this.pictureBox3.Location = new System.Drawing.Point(140, 93);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(37, 12);
            this.pictureBox3.TabIndex = 9;
            this.pictureBox3.TabStop = false;
            // 
            // toolBoxShapes
            // 
            this.toolBoxShapes.Image = global::PerfectPaint.Properties.Resources.Shapes;
            this.toolBoxShapes.InitialImage = null;
            this.toolBoxShapes.Location = new System.Drawing.Point(116, 35);
            this.toolBoxShapes.Name = "toolBoxShapes";
            this.toolBoxShapes.Size = new System.Drawing.Size(81, 20);
            this.toolBoxShapes.TabIndex = 8;
            this.toolBoxShapes.TabStop = false;
            this.toolBoxShapes.MouseClick += new System.Windows.Forms.MouseEventHandler(this.toolBoxShapes_MouseClick);
            this.toolBoxShapes.MouseEnter += new System.EventHandler(this.toolBoxShapes_MouseEnter);
            this.toolBoxShapes.MouseLeave += new System.EventHandler(this.toolBoxShapes_MouseLeave);
            this.toolBoxShapes.MouseMove += new System.Windows.Forms.MouseEventHandler(this.toolBoxShapes_MouseMove);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::PerfectPaint.Properties.Resources.Sep;
            this.pictureBox2.InitialImage = null;
            this.pictureBox2.Location = new System.Drawing.Point(83, 33);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(15, 53);
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PerfectPaint.Properties.Resources.ToolsCaption;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(24, 92);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(35, 12);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // toolBoxTools
            // 
            this.toolBoxTools.Image = global::PerfectPaint.Properties.Resources.Tools;
            this.toolBoxTools.InitialImage = null;
            this.toolBoxTools.Location = new System.Drawing.Point(16, 33);
            this.toolBoxTools.Name = "toolBoxTools";
            this.toolBoxTools.Size = new System.Drawing.Size(49, 53);
            this.toolBoxTools.TabIndex = 5;
            this.toolBoxTools.TabStop = false;
            this.toolBoxTools.MouseClick += new System.Windows.Forms.MouseEventHandler(this.toolBoxTools_MouseClick);
            this.toolBoxTools.MouseEnter += new System.EventHandler(this.toolBoxTools_MouseEnter);
            this.toolBoxTools.MouseLeave += new System.EventHandler(this.toolBoxTools_MouseLeave);
            this.toolBoxTools.MouseMove += new System.Windows.Forms.MouseEventHandler(this.toolBoxTools_MouseMove);
            // 
            // picBoxPad
            // 
            this.picBoxPad.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picBoxPad.BackColor = System.Drawing.Color.White;
            this.picBoxPad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBoxPad.Location = new System.Drawing.Point(5, 110);
            this.picBoxPad.Name = "picBoxPad";
            this.picBoxPad.Size = new System.Drawing.Size(1045, 502);
            this.picBoxPad.TabIndex = 2;
            this.picBoxPad.TabStop = false;
            this.picBoxPad.Click += new System.EventHandler(this.picBoxPad_Click);
            this.picBoxPad.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picBoxPad_MouseDown);
            this.picBoxPad.MouseEnter += new System.EventHandler(this.picBoxPad_MouseEnter);
            this.picBoxPad.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picBoxPad_MouseMove);
            this.picBoxPad.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picBoxPad_MouseUp);
            // 
            // btnMenu
            // 
            this.btnMenu.Image = global::PerfectPaint.Properties.Resources.MenuImage;
            this.btnMenu.Location = new System.Drawing.Point(0, -2);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(56, 24);
            this.btnMenu.TabIndex = 3;
            this.btnMenu.TabStop = false;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            this.btnMenu.MouseEnter += new System.EventHandler(this.btnMenu_MouseEnter);
            this.btnMenu.MouseLeave += new System.EventHandler(this.btnMenu_MouseLeave);
            // 
            // chkFill
            // 
            this.chkFill.AutoSize = true;
            this.chkFill.Location = new System.Drawing.Point(155, 66);
            this.chkFill.Name = "chkFill";
            this.chkFill.Size = new System.Drawing.Size(50, 17);
            this.chkFill.TabIndex = 24;
            this.chkFill.Text = "Filled";
            this.chkFill.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(233)))), ((int)(((byte)(246)))));
            this.ClientSize = new System.Drawing.Size(1054, 616);
            this.Controls.Add(this.mnuMenu);
            this.Controls.Add(this.pictureBox9);
            this.Controls.Add(this.chkFill);
            this.Controls.Add(this.btnRedo);
            this.Controls.Add(this.btnUndo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSizeEdit);
            this.Controls.Add(this.pictureBox8);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.drpSize);
            this.Controls.Add(this.toolBoxPadColor);
            this.Controls.Add(this.pictureBox7);
            this.Controls.Add(this.toolBoxColorsMore);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.toolBoxColors);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.toolBoxShapes);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.toolBoxTools);
            this.Controls.Add(this.picBoxPad);
            this.Controls.Add(this.btnMenu);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Perfect Paint";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResizeEnd += new System.EventHandler(this.frmMain_ResizeEnd);
            this.Click += new System.EventHandler(this.frmMain_Click);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMain_KeyDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmMain_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mnuMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toolBoxPadColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toolBoxColorsMore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toolBoxColors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toolBoxShapes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toolBoxTools)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxPad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMenu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.PictureBox picBoxPad;
        private System.Windows.Forms.PictureBox btnMenu;        
        private System.Windows.Forms.OpenFileDialog dlgBoxOpen;
        private System.Windows.Forms.SaveFileDialog dlgBoxSave;
        private System.Windows.Forms.PictureBox toolBoxTools;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox toolBoxShapes;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox toolBoxColors;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox toolBoxColorsMore;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.PictureBox toolBoxPadColor;
        private System.Windows.Forms.ComboBox drpSize;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.MaskedTextBox txtSizeEdit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox mnuMenu;
        private System.Windows.Forms.ColorDialog dlgBoxColor;
        private System.Windows.Forms.Button btnUndo;
        private System.Windows.Forms.Button btnRedo;
        private System.Windows.Forms.CheckBox chkFill;
        private System.Windows.Forms.PictureBox pictureBox9;       
    }
}

