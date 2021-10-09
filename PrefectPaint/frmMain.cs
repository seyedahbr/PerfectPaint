using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;
using PerfectPaint.Properties;
using AdvancedGraphics;

namespace PerfectPaint
{
    public enum Shapes : byte
    {
        FreeForm,
        Line,
        Rectangle,
        Ellipse,
        Triangle
    }
    public enum DrawTools : byte
    {
        Pencile,        
        Filler,
        Eraser,
        ColorPicker
    }

    public partial class frmMain : Form
    {
        public static Bitmap PadBmpImage;
        public static bool MouseClickSelected;
        public static bool CtrlHolded;
        public static bool IsSaved;
        public static string SavePath;
        public static Point OldMousePosition;
        public static Graphics PadGraphic;
        public static Graphics SaveGraphic;
        public static Pen PadPen;
        public static SolidBrush PadBrush;
        public static Rectangle LatestRect;
        public static Stack<Bitmap> PadImagesUndoStck;
        public static Stack<Bitmap> PadImagesRedoStck;
        public static DrawTools PadTool;
        public static Shapes PadShape;

        public frmMain()
        {
            InitializeComponent();

            //set other controling and drawing settings
            PadBmpImage = new Bitmap(picBoxPad.Width, picBoxPad.Height);
            PadPen = new Pen(Color.Black);
            PadBrush = new SolidBrush(Color.Black);
            PadImagesUndoStck = new Stack<Bitmap>();
            PadImagesRedoStck = new Stack<Bitmap>();
            picBoxPad.Image = PadBmpImage;
            Graphics.FromImage(picBoxPad.Image).Clear(Color.White);
            SaveGraphic = Graphics.FromImage(PadBmpImage);
            PadGraphic = picBoxPad.CreateGraphics();
            PadTool = DrawTools.Pencile;
            PadShape = Shapes.FreeForm;
            MouseClickSelected = false;
            IsSaved = true;
            CtrlHolded = true;
            SavePath = null;
            drpSize.SelectedIndex = 0;
        }

        private void btnMenu_MouseEnter(object sender, EventArgs e)
        {
            btnMenu.Image = Resources.MenuImageSelected;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

            toolBoxTools.Image = Resources.ToolsPencil;
        }

        private void btnMenu_MouseLeave(object sender, EventArgs e)
        {
            btnMenu.Image = Resources.MenuImage;
        }

        private void picBoxPad_Click(object sender, EventArgs e)
        {
            mnuMenu.Visible = false;
        }

        private void picBoxPad_MouseMove(object sender, MouseEventArgs e)
        {
            if(PadTool == DrawTools.Pencile && MouseClickSelected)
            {
                switch(PadShape)
                {
                    case Shapes.FreeForm:
                        DrawPencilProc(e);
                        break;
                    case Shapes.Rectangle:
                        DrawRectangleProc(e);
                        break;
                    case Shapes.Line:
                        DrawLineProc(e);
                        break;
                    case Shapes.Ellipse:
                        DrawEllipseProc(e);
                        break;
                    case Shapes.Triangle:
                        DrawTriangleProc(e);
                        break;
                }
            }
            else if(PadTool == DrawTools.Eraser && MouseClickSelected)
            {
                DrawEraserProc(e);
            }
        }
       
        private void picBoxPad_MouseDown(object sender, MouseEventArgs e)
        {
            //close menu and other settings
            mnuMenu.Visible = false;
            MouseClickSelected = true;
            
            //initialize first old mouse pointer position that if pencel draw selected we have 
            //posision needed
            OldMousePosition.X = e.X;
            OldMousePosition.Y = e.Y;

            //push the current picture pad state for undo process
            Bitmap tempForPush = new Bitmap(PadBmpImage);
            PadImagesUndoStck.Push(tempForPush);
            IsSaved = false;

            //cleare the redo stack
            PadImagesRedoStck.Clear();

            if(PadTool == DrawTools.Pencile)
            {
                //select proper shaping
                switch(PadShape)
                {
                    case Shapes.FreeForm:
                        PadBmpImage.SetPixel(OldMousePosition.X, OldMousePosition.Y, PadPen.Color);
                        break;
                }
            }
            else if(PadTool == DrawTools.Eraser)
            {
                PadBmpImage.SetPixel(OldMousePosition.X, OldMousePosition.Y, Color.White);
            }
            else if(PadTool == DrawTools.ColorPicker)
            {
                PadImagesUndoStck.Pop();
                PadPen.Color = PadBmpImage.GetPixel(e.X, e.Y);
                toolBoxPadColor.BackColor = PadPen.Color;
            }
            else if((PadTool == DrawTools.Filler))
            {
                FillRegion(PadPen.Color, PadBmpImage.GetPixel(e.X, e.Y), e.X, e.Y);
            }
            
        }       

        private void picBoxPad_MouseUp(object sender, MouseEventArgs e)
        {
            MouseClickSelected = false;
            picBoxPad.Image = PadBmpImage;
            if(PadTool == DrawTools.Pencile)
            {
                //select proper shaping
                SaveGraphic = Graphics.FromImage(PadBmpImage);
                switch(PadShape)
                {
                    case Shapes.Rectangle:                        
                        if (chkFill.Checked)
                            SaveGraphic.FillRectangle(PadBrush, LatestRect);
                        else
                            SaveGraphic.DrawRectangle(PadPen, LatestRect);
                        break;
                    case Shapes.Ellipse:                        
                        if (chkFill.Checked)
                            SaveGraphic.FillEllipse(PadBrush, LatestRect);
                        else
                            SaveGraphic.DrawEllipse(PadPen, LatestRect);
                        break;
                    case Shapes.Triangle:                        
                        DrawTriangle(SaveGraphic, PadPen, LatestRect);
                        break;
                    case Shapes.Line:                        
                        SaveGraphic.DrawLine(PadPen, OldMousePosition.X, OldMousePosition.Y, e.X, e.Y);
                        break;
                }
            }
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            RibbonMenuOpenClose();
        }

        private void frmMain_Click(object sender, EventArgs e)
        {
            mnuMenu.Visible = false;
        }

        private void mnuMenu_MouseMove(object sender, MouseEventArgs e)
        {
            int cursorX = e.X;
            int cursorY = e.Y;

            if(cursorX > 1 && cursorX < 215)
            {
                if(cursorY > 2 && cursorY < 45)
                    mnuMenu.Image = Resources.MenuNew;
                else if(cursorY > 46 && cursorY < 89)
                    mnuMenu.Image = Resources.MenuOpen;
                else if(cursorY > 90 && cursorY < 133)
                    mnuMenu.Image = Resources.MenuSave;
                else if(cursorY > 134 && cursorY < 177)
                    mnuMenu.Image = Resources.MenuSaveAs;
                else if(cursorY > 182 && cursorY < 225)
                    mnuMenu.Image = Resources.MenuAbout;
                else if(cursorY > 228 && cursorY < 281)
                    mnuMenu.Image = Resources.MenuExit;
            }
            else
                mnuMenu.Image = Resources.Menu;
        }

        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Z && PadImagesUndoStck.Count != 0)
            {
                Bitmap tempForCopy = PadImagesUndoStck.Pop();
                picBoxPad.Image = new Bitmap(tempForCopy);
                PadBmpImage = new Bitmap(tempForCopy);
            }
        }

        private void mnuMenu_MouseClick(object sender, MouseEventArgs e)
        {
            int cursorX = e.X;
            int cursorY = e.Y;
            RibbonMenuOpenClose();

            if(cursorX > 1 && cursorX < 215)
            {
                if (cursorY > 2 && cursorY < 45)
                    NewImageProc();
                else if (cursorY > 46 && cursorY < 89)
                    OpenImageProc();
                else if (cursorY > 90 && cursorY < 133)
                    SaveImageProc();
                else if (cursorY > 134 && cursorY < 177)
                    SaveAsImageProc();
                else if (cursorY > 182 && cursorY < 225)
                {
                    frmAbout newAbout = new frmAbout();
                    newAbout.Show();
                }
                else if (cursorY > 228 && cursorY < 281)
                    Application.Exit();
            }
        }

        private void toolBoxTools_MouseMove(object sender, MouseEventArgs e)
        {
            int cursorX = e.X;
            int cursorY = e.Y;

            if(cursorX >= 1 && cursorX <= 22)
            {
                if(cursorY >= 1 && cursorY <= 22)
                    toolBoxTools.Image = Resources.ToolsPencil;
                else if(cursorY >= 30 && cursorY <= 51)
                    toolBoxTools.Image = Resources.ToolsEraser;
            }
            else if(cursorX >= 24 && cursorX <= 47)
            {
                if(cursorY >= 1 && cursorY <= 22)
                    toolBoxTools.Image = Resources.ToolsFiller;
                else if(cursorY >= 30 && cursorY <= 51)
                    toolBoxTools.Image = Resources.ToolsPicker;
            }
            else
                toolBoxTools.Image = Resources.Tools;

        }

        private void toolBoxTools_MouseLeave(object sender, EventArgs e)
        {
            if(PadShape == Shapes.FreeForm)
            {
                switch(PadTool)
                {
                    case DrawTools.Pencile:
                        toolBoxTools.Image = Resources.ToolsPencil;
                        break;
                    case DrawTools.Eraser:
                        toolBoxTools.Image = Resources.ToolsEraser;
                        break;
                    case DrawTools.Filler:
                        toolBoxTools.Image = Resources.ToolsFiller;
                        break;
                    case DrawTools.ColorPicker:
                        toolBoxTools.Image = Resources.ToolsPicker;
                        break;
                    default:
                        toolBoxTools.Image = Resources.Tools;
                        break;
                }
            }
            else
            {
                toolBoxTools.Image = Resources.Tools;
            }
        }

        private void toolBoxTools_MouseClick(object sender, MouseEventArgs e)
        {
            int cursorX = e.X;
            int cursorY = e.Y;

            toolBoxShapes.Image = Resources.Shapes;
            PadShape = Shapes.FreeForm;
            if(cursorX >= 1 && cursorX <= 22)
            {
                if(cursorY >= 1 && cursorY <= 22)
                {
                    PadTool = DrawTools.Pencile;
                    PadShape = Shapes.FreeForm;
                    toolBoxTools.Image = Resources.ToolsPencil;
                }
                else if(cursorY >= 30 && cursorY <= 51)
                {
                    PadTool = DrawTools.Eraser;
                    toolBoxTools.Image = Resources.ToolsEraser;
                }
            }
            else if(cursorX >= 24 && cursorX <= 47)
            {
                if(cursorY >= 1 && cursorY <= 22)
                {
                    PadTool = DrawTools.Filler;
                    toolBoxTools.Image = Resources.ToolsFiller;
                }
                else if(cursorY >= 30 && cursorY <= 51)
                {
                    PadTool = DrawTools.ColorPicker;
                    toolBoxTools.Image = Resources.ToolsPicker;
                }
            }
       }       

        private void picBoxPad_MouseEnter(object sender, EventArgs e)
        {
            switch(PadTool)
            {
                case DrawTools.Pencile:
                    switch(PadShape)
                    {
                        case Shapes.FreeForm:
                            picBoxPad.Cursor = Cursors.Cross;
                            break;                        
                    }
                    break;
                case DrawTools.Eraser:
                    picBoxPad.Cursor = Cursors.Hand;
                    break;
                case DrawTools.Filler:
                    picBoxPad.Cursor = Cursors.Cross;
                    break;
                case DrawTools.ColorPicker:
                    picBoxPad.Cursor = Cursors.Hand;
                    break;
            }
        }

        private void frmMain_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.X >= 12 && e.X <= 61 && e.Y >= 33 && e.Y <= 86)
                toolBoxTools.Focus();
            else
                this.Focus();

        }

        private void toolBoxShapes_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.X >= 1 && e.X <= 20)
                toolBoxShapes.Image = Resources.ShapesLine;
            else if(e.X >= 22 && e.X <= 39)
                toolBoxShapes.Image = Resources.ShapesTriangle;
            else if(e.X >= 41 && e.X <= 60)
                toolBoxShapes.Image = Resources.ShapesOval;
            else if(e.X >= 61 && e.X <= 69)
                toolBoxShapes.Image = Resources.ShapesRect;
        }

        private void toolBoxShapes_MouseClick(object sender, MouseEventArgs e)
        {
            toolBoxTools.Image = Resources.Tools;
            PadTool = DrawTools.Pencile;
            if(e.X >= 1 && e.X <= 20)
            {                
                PadShape = Shapes.Line;
                chkFill.Enabled = true;
            }
            else if(e.X >= 22 && e.X <= 39)
            {
                PadShape = Shapes.Triangle;
                chkFill.Enabled = false;
            }
            else if(e.X >= 41 && e.X <= 60)
            {
                PadShape = Shapes.Ellipse;
                chkFill.Enabled = true;
            }
            else if(e.X >= 62 && e.X <= 69)
            {
                PadShape = Shapes.Rectangle;
                chkFill.Enabled = true;
            }
        }

        private void toolBoxShapes_MouseEnter(object sender, EventArgs e)
        {
            if(MousePosition.X >= 1 && MousePosition.X <= 20)
                toolBoxShapes.Image = Resources.ShapesLine;
            else if(MousePosition.X >= 22 && MousePosition.X <= 39)
                toolBoxShapes.Image = Resources.ShapesTriangle;
            else if(MousePosition.X >= 41 && MousePosition.X <= 60)
                toolBoxShapes.Image = Resources.ShapesOval;
            else if(MousePosition.X >= 61 && MousePosition.X <= 69)
                toolBoxShapes.Image = Resources.ShapesRect;
        }

        private void toolBoxShapes_MouseLeave(object sender, EventArgs e)
        {
            if(PadTool == DrawTools.Pencile)
            {
                switch(PadShape)
                {
                    case Shapes.Line:
                        toolBoxShapes.Image = Resources.ShapesLineSel;
                        break;
                    case Shapes.Triangle:
                        toolBoxShapes.Image = Resources.ShapesTriangleSel;
                        break;
                    case Shapes.Ellipse:
                        toolBoxShapes.Image = Resources.ShapesOvalSel;
                        break;
                    case Shapes.Rectangle:
                        toolBoxShapes.Image = Resources.ShapesRectSel;
                        break;
                    case Shapes.FreeForm:
                        toolBoxShapes.Image = Resources.Shapes;
                        break;
                }
            }
            else
            {
                toolBoxShapes.Image = Resources.Shapes;
            }
        }

        private void toolBoxTools_MouseEnter(object sender, EventArgs e)
        {

            int cursorX = MousePosition.X;
            int cursorY = MousePosition.Y;

            if(cursorX >= 1 && cursorX <= 22)
            {
                if(cursorY >= 1 && cursorY <= 22)
                    toolBoxTools.Image = Resources.ToolsPencil;
                else if(cursorY >= 30 && cursorY <= 51)
                    toolBoxTools.Image = Resources.ToolsEraser;
            }
            else if(cursorX >= 24 && cursorX <= 46)
            {
                if(cursorY >= 1 && cursorY <= 22)
                    toolBoxTools.Image = Resources.ToolsFiller;
                else if(cursorY >= 30 && cursorY <= 51)
                    toolBoxTools.Image = Resources.ToolsPicker;
            }
            else
                toolBoxTools.Image = Resources.Tools;
        }

        private void toolBoxColorsMore_MouseEnter(object sender, EventArgs e)
        {
            toolBoxColorsMore.Image = Resources.ColorsMoreSel;
        }

        private void toolBoxColorsMore_MouseLeave(object sender, EventArgs e)
        {
            toolBoxColorsMore.Image = Resources.ColorsMore;
        }

        private void txtSizeEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                drpSize.SelectedItem = null;
                try
                {
                    PadPen.Width = (float)Convert.ToDouble(txtSizeEdit.Text);
                }
                catch
                {
                    MessageBox.Show("This is not a valid number.", "Perfect Paint - Invalid Number",
                                     MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSizeEdit.Clear();
                    drpSize.SelectedIndex = 0;

                }
                picBoxPad.Focus();
            }
        }

        private void drpSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(drpSize.SelectedItem != null)
                txtSizeEdit.Clear();
            PadPen.Width = Convert.ToInt32(drpSize.SelectedIndex);

        }

        private void toolBoxColors_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Y >= 2 && e.Y <= 21)
            {
                if(e.X >= 2 && e.X <= 21)
                    toolBoxPadColor.BackColor = Color.FromArgb(0, 0, 0);
                else if(e.X >= 24 && e.X <=43 )
                    toolBoxPadColor.BackColor = Color.FromArgb(127,127,127);
                else if(e.X >= 46 && e.X <= 65)
                    toolBoxPadColor.BackColor = Color.FromArgb(136, 0, 21);
                else if(e.X >= 68 && e.X <= 87)
                    toolBoxPadColor.BackColor = Color.FromArgb(237, 28, 36);
                else if(e.X >= 90 && e.X <= 109)
                    toolBoxPadColor.BackColor = Color.FromArgb(255, 127, 29);
                else if(e.X >= 112 && e.X <= 131)
                    toolBoxPadColor.BackColor = Color.FromArgb(255, 242, 0);
                else if(e.X >= 134 && e.X <= 153)
                    toolBoxPadColor.BackColor = Color.FromArgb(34, 177, 76);
                else if(e.X >= 156 && e.X <= 175)
                    toolBoxPadColor.BackColor = Color.FromArgb(0, 162, 232);
                else if(e.X >= 178 && e.X <= 197)
                    toolBoxPadColor.BackColor = Color.FromArgb(63, 72, 204);
                else if(e.X >= 200 && e.X <= 219)
                    toolBoxPadColor.BackColor = Color.FromArgb(163, 73, 164);
            }
            else if(e.Y >= 24 && e.Y <= 43)
            {
                if(e.X >= 2 && e.X <= 21)
                    toolBoxPadColor.BackColor = Color.FromArgb(255, 255, 255);
                else if(e.X >= 24 && e.X <= 43)
                    toolBoxPadColor.BackColor = Color.FromArgb(195, 195, 195);
                else if(e.X >= 46 && e.X <= 65)
                    toolBoxPadColor.BackColor = Color.FromArgb(185, 122, 87);
                else if(e.X >= 68 && e.X <= 87)
                    toolBoxPadColor.BackColor = Color.FromArgb(255, 174, 201);
                else if(e.X >= 90 && e.X <= 109)
                    toolBoxPadColor.BackColor = Color.FromArgb(255, 201, 14);
                else if(e.X >= 112 && e.X <= 131)
                    toolBoxPadColor.BackColor = Color.FromArgb(239, 228, 176);
                else if(e.X >= 134 && e.X <= 153)
                    toolBoxPadColor.BackColor = Color.FromArgb(181, 230, 29);
                else if(e.X >= 156 && e.X <= 175)
                    toolBoxPadColor.BackColor = Color.FromArgb(153, 217, 234);
                else if(e.X >= 178 && e.X <= 197)
                    toolBoxPadColor.BackColor = Color.FromArgb(112, 146, 190);
                else if(e.X >= 200 && e.X <= 219)
                    toolBoxPadColor.BackColor = Color.FromArgb(200, 191, 231);
            }

            //set the color pen of the program to selected color from tool box
            PadPen.Color = toolBoxPadColor.BackColor;
            PadBrush.Color = PadPen.Color;
        }

        private void toolBoxColorsMore_Click(object sender, EventArgs e)
        {
            dlgBoxColor.Color = PadPen.Color;
            if(dlgBoxColor.ShowDialog() == DialogResult.OK)
            {
                PadPen.Color = dlgBoxColor.Color;
                PadBrush.Color = PadPen.Color;
                toolBoxPadColor.BackColor = dlgBoxColor.Color;
            }
        }

        private void frmMain_ResizeEnd(object sender, EventArgs e)
        {
            Bitmap tempBmp = new Bitmap(PadBmpImage);
            PadBmpImage = new Bitmap(picBoxPad.Width, picBoxPad.Height);
            SaveGraphic = Graphics.FromImage(PadBmpImage);
            PadGraphic = picBoxPad.CreateGraphics();
            SaveGraphic.DrawImage(tempBmp, 0, 0);
            PadGraphic.DrawImage(tempBmp, 0, 0);
            picBoxPad.Image = PadBmpImage;
            SaveGraphic = Graphics.FromImage(PadBmpImage);
            tempBmp.Dispose();
        }

        private void btnUndo_MouseDown(object sender, MouseEventArgs e)
        {
            if(PadImagesUndoStck.Count != 0)
            {
                //set redo stack
                Bitmap tempForPush = new Bitmap(PadBmpImage);
                PadImagesRedoStck.Push(tempForPush);

                Bitmap tempForCopy = PadImagesUndoStck.Pop();
                picBoxPad.Image = new Bitmap(tempForCopy);                
                PadBmpImage = new Bitmap(tempForCopy);
                SaveGraphic = Graphics.FromImage(tempForCopy);
            }
        }

        private void btnRedo_MouseDown(object sender, MouseEventArgs e)
        {
            if(PadImagesRedoStck.Count != 0)
            {
                //set undo stack
                Bitmap tempForPush = new Bitmap(PadBmpImage);
                PadImagesUndoStck.Push(tempForPush);

                Bitmap tempForCopy = PadImagesRedoStck.Pop();
                picBoxPad.Image = new Bitmap(tempForCopy);
                PadBmpImage = new Bitmap(tempForCopy);
                SaveGraphic = Graphics.FromImage(tempForCopy);
            }
        }       

        /// <summary>
        /// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// //OTHER METHODS for control and drawing
        /// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// </summary>
        
        public void SaveImageProc()
        {
            if (!IsSaved && SavePath == null)
            {
                dlgBoxSave.Title = "Save";
                dlgBoxSave.FileName = "New Image";
                if (dlgBoxSave.ShowDialog() == DialogResult.OK)                    
                    switch (dlgBoxSave.FileName.Substring(dlgBoxSave.FileName.Length-3,3))
                    {
                        case "bmp":                            
                            picBoxPad.Image.Save(dlgBoxSave.FileName, System.Drawing.Imaging.ImageFormat.Bmp);
                            break;
                        case "jpg":
                            picBoxPad.Image.Save(dlgBoxSave.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                            break;
                        case "gif":
                            picBoxPad.Image.Save(dlgBoxSave.FileName, System.Drawing.Imaging.ImageFormat.Gif);
                            break;
                        case "png":
                            picBoxPad.Image.Save(dlgBoxSave.FileName, System.Drawing.Imaging.ImageFormat.Png);
                            break;
                        case "iff":
                            picBoxPad.Image.Save(dlgBoxSave.FileName, System.Drawing.Imaging.ImageFormat.Tiff);
                            break;
                        case "ico":
                            picBoxPad.Image.Save(dlgBoxSave.FileName, System.Drawing.Imaging.ImageFormat.Icon);
                            break;
                        case "emf":
                            picBoxPad.Image.Save(dlgBoxSave.FileName, System.Drawing.Imaging.ImageFormat.Emf);
                            break;
                    }
                SavePath = dlgBoxSave.FileName;
                IsSaved = true;
            }
            else if (!IsSaved && SavePath != null)
            {
                switch (SavePath.Substring(dlgBoxSave.FileName.Length - 3, 3))
                {
                    case "bmp":
                        picBoxPad.Image.Save(SavePath, System.Drawing.Imaging.ImageFormat.Bmp);
                        break;
                    case "jpg":
                        picBoxPad.Image.Save(SavePath, System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;
                    case "gif":
                        picBoxPad.Image.Save(SavePath, System.Drawing.Imaging.ImageFormat.Gif);
                        break;
                    case "png":
                        picBoxPad.Image.Save(SavePath, System.Drawing.Imaging.ImageFormat.Png);
                        break;
                    case "iff":
                        picBoxPad.Image.Save(SavePath, System.Drawing.Imaging.ImageFormat.Tiff);
                        break;
                    case "ico":
                        picBoxPad.Image.Save(SavePath, System.Drawing.Imaging.ImageFormat.Icon);
                        break;
                    case "emf":
                        picBoxPad.Image.Save(SavePath, System.Drawing.Imaging.ImageFormat.Emf);
                        break;
                }
                IsSaved = true;
            }                    
        }

        private void SaveAsImageProc()
        {
            throw new NotImplementedException();
        }

        public void OpenImageProc()
        {
            throw new NotImplementedException();
        }

        public void NewImageProc()
        {            
            PadBmpImage = new Bitmap(picBoxPad.Width, picBoxPad.Height);
            SaveGraphic.Clear(Color.White);
            SaveGraphic = Graphics.FromImage(PadBmpImage);            
            PadGraphic.Clear(Color.White);
        }

        public void RibbonMenuOpenClose()
        {
            if(mnuMenu.Visible)
            {
                mnuMenu.Visible = false;
            }
            else
            {
                mnuMenu.Visible = true;
                mnuMenu.Image = Resources.Menu;
            }
        }

        public void DrawPencilProc(MouseEventArgs e)
        {
            //Graphic pad draw without image changing for
            //user view only
            float wid = PadPen.Width;
            PadGraphic.DrawLine(PadPen, OldMousePosition.X, OldMousePosition.Y, e.X, e.Y);
            PadGraphic.FillEllipse(PadBrush, e.X - 0.5F * wid, e.Y - 0.5F * wid, wid, wid);
            //Also we need to do same process for changing in saved image background
            SaveGraphic = Graphics.FromImage(PadBmpImage);
            SaveGraphic.DrawLine(PadPen, OldMousePosition.X, OldMousePosition.Y, e.X, e.Y);
            SaveGraphic.FillEllipse(PadBrush, e.X - 0.5F * wid, e.Y - 0.5F * wid, wid, wid);
            //reset old mouse positions to have an allied sape in next mouce movement event
            OldMousePosition.X = e.X;
            OldMousePosition.Y = e.Y;
        }

        public void DrawEraserProc(MouseEventArgs e)
        {
            //Graphic pad draw without image changing for
            //user view only
            float wid = PadPen.Width;
            Pen whitePen = new Pen(Color.White, PadPen.Width);
            SolidBrush whiteBrush=new SolidBrush(Color.White);
            PadGraphic.DrawLine(whitePen, OldMousePosition.X, OldMousePosition.Y, e.X, e.Y);
            PadGraphic.FillEllipse(whiteBrush, e.X - 0.5F * wid, e.Y - 0.5F * wid, wid, wid);
            //Also we need to do same process for changing in saved image background
            SaveGraphic = Graphics.FromImage(PadBmpImage);
            SaveGraphic.DrawLine(whitePen, OldMousePosition.X, OldMousePosition.Y, e.X, e.Y);
            SaveGraphic.FillEllipse(whiteBrush, e.X - 0.5F * wid, e.Y - 0.5F * wid, wid, wid);
            //reset old mouse positions to have an allied sape in next mouce movement event
            OldMousePosition.X = e.X;
            OldMousePosition.Y = e.Y;
        }

        private void DrawRectangleProc(MouseEventArgs e)
        {
            int x0, y0, width, height;
            x0 = OldMousePosition.X;
            y0 = OldMousePosition.Y;
            width = Math.Abs(e.X - OldMousePosition.X);
            height = Math.Abs(e.Y - OldMousePosition.Y);

            //draw main picture again to show that the rectangle drawing is movable
            PadGraphic.DrawImage(PadBmpImage, 0, 0);

            if(ModifierKeys == Keys.Shift)
            {
                width = height;
                if(e.X >= OldMousePosition.X && e.Y <= OldMousePosition.Y)
                {
                    x0 = OldMousePosition.X;
                    y0 = OldMousePosition.Y - height;
                }
                else if(OldMousePosition.X >= e.X && OldMousePosition.Y < e.Y)
                {
                    x0 = OldMousePosition.X - width;
                    y0 = OldMousePosition.Y;
                }
                else if(OldMousePosition.X >= e.X && OldMousePosition.Y >= e.Y)
                {
                    x0 = OldMousePosition.X - width;
                    y0 = OldMousePosition.Y - height;
                }
                LatestRect = new Rectangle(x0, y0, width, height);
            }
            else
            {
                if(e.X >= OldMousePosition.X && e.Y <= OldMousePosition.Y)
                {
                    x0 = OldMousePosition.X;
                    y0 = OldMousePosition.Y - height;
                }
                else if(OldMousePosition.X >= e.X && OldMousePosition.Y < e.Y)
                {
                    x0 = OldMousePosition.X - width;
                    y0 = OldMousePosition.Y;
                }
                else if(OldMousePosition.X >= e.X && OldMousePosition.Y >= e.Y)
                {
                    x0 = OldMousePosition.X - width;
                    y0 = OldMousePosition.Y - height;
                }
                LatestRect = new Rectangle(x0, y0, width, height);
            }

            //draw latest rectangle and proper it for next mouse move
            if (chkFill.Checked)
                PadGraphic.FillRectangle(PadBrush, LatestRect);
            else
                PadGraphic.DrawRectangle(PadPen, LatestRect);
        }

        private void DrawLineProc(MouseEventArgs e)
        {
            //draw main picture again to show that the rectangle drawing is movable
            PadGraphic.DrawImage(PadBmpImage, 0, 0);

            //draw Line from old mouse position to current mouse position
            PadGraphic.DrawLine(PadPen, OldMousePosition.X, OldMousePosition.Y, e.X, e.Y);
        }

        private void DrawTriangleProc(MouseEventArgs e)
        {
            int x0, y0, width, height;
            x0 = OldMousePosition.X;
            y0 = OldMousePosition.Y;
            width = Math.Abs(e.X - OldMousePosition.X);
            height = Math.Abs(e.Y - OldMousePosition.Y);

            //draw main picture again to show that the ellipse drawing is movable
            PadGraphic.DrawImage(PadBmpImage, 0, 0);

            if (ModifierKeys == Keys.Shift)
            {
                width = height;
                if (e.X >= OldMousePosition.X && e.Y <= OldMousePosition.Y)
                {
                    x0 = OldMousePosition.X;
                    y0 = OldMousePosition.Y - height;
                }
                else if (OldMousePosition.X >= e.X && OldMousePosition.Y < e.Y)
                {
                    x0 = OldMousePosition.X - width;
                    y0 = OldMousePosition.Y;
                }
                else if (OldMousePosition.X >= e.X && OldMousePosition.Y >= e.Y)
                {
                    x0 = OldMousePosition.X - width;
                    y0 = OldMousePosition.Y - height;
                }
                LatestRect = new Rectangle(x0, y0, width, height);
            }
            else
            {
                if (e.X >= OldMousePosition.X && e.Y <= OldMousePosition.Y)
                {
                    x0 = OldMousePosition.X;
                    y0 = OldMousePosition.Y - height;
                }
                else if (OldMousePosition.X >= e.X && OldMousePosition.Y < e.Y)
                {
                    x0 = OldMousePosition.X - width;
                    y0 = OldMousePosition.Y;
                }
                else if (OldMousePosition.X >= e.X && OldMousePosition.Y >= e.Y)
                {
                    x0 = OldMousePosition.X - width;
                    y0 = OldMousePosition.Y - height;
                }
                LatestRect = new Rectangle(x0, y0, width, height);
            }

            //draw triangle with latest rectangle that provide in current subrotine and use
            //the DRAWTRIANGLE subrotine in this form class

            DrawTriangle(PadGraphic, PadPen, LatestRect);
        }

        private void DrawEllipseProc(MouseEventArgs e)
        {
            int x0, y0, width, height;
            x0 = OldMousePosition.X;
            y0 = OldMousePosition.Y;
            width = Math.Abs(e.X - OldMousePosition.X);
            height = Math.Abs(e.Y - OldMousePosition.Y);

            //draw main picture again to show that the ellipse drawing is movable
            PadGraphic.DrawImage(PadBmpImage, 0, 0);

            if(ModifierKeys == Keys.Shift)
            {
                width = height;
                if(e.X >= OldMousePosition.X && e.Y <= OldMousePosition.Y)
                {
                    x0 = OldMousePosition.X;
                    y0 = OldMousePosition.Y - height;
                }
                else if(OldMousePosition.X >= e.X && OldMousePosition.Y < e.Y)
                {
                    x0 = OldMousePosition.X - width;
                    y0 = OldMousePosition.Y;
                }
                else if(OldMousePosition.X >= e.X && OldMousePosition.Y >= e.Y)
                {
                    x0 = OldMousePosition.X - width;
                    y0 = OldMousePosition.Y - height;
                }
                LatestRect = new Rectangle(x0, y0, width, height);
            }
            else
            {
                if(e.X >= OldMousePosition.X && e.Y <= OldMousePosition.Y)
                {
                    x0 = OldMousePosition.X;
                    y0 = OldMousePosition.Y - height;
                }
                else if(OldMousePosition.X >= e.X && OldMousePosition.Y < e.Y)
                {
                    x0 = OldMousePosition.X - width;
                    y0 = OldMousePosition.Y;
                }
                else if(OldMousePosition.X >= e.X && OldMousePosition.Y >= e.Y)
                {
                    x0 = OldMousePosition.X - width;
                    y0 = OldMousePosition.Y - height;
                }
                LatestRect = new Rectangle(x0, y0, width, height);
            }

            //draw ellipse with latest rectangle that provide in current subrotine and proper it for next mouse move
            if (chkFill.Checked)
                PadGraphic.FillEllipse(PadBrush, LatestRect);
            else
                PadGraphic.DrawEllipse(PadPen, LatestRect);
        }

        public static void DrawTriangle(Graphics graph,Pen pen, Rectangle rect)
        {
            Point[] pSeries = new Point[4];
            pSeries[0] = pSeries[3] = new Point(rect.X + (int)(rect.Width / 2), rect.Y);
            pSeries[1] = new Point(rect.X, rect.Y + rect.Height);
            pSeries[2] = new Point(rect.X + rect.Width, rect.Y + rect.Height);
            graph.DrawLines(pen, pSeries);
        }

        private void FillRegion(Color fillingC,Color padC,int pointX,int pointY)
        {
            PadBmpImage.SetPixel(pointX, pointY, fillingC);
            RecursiveFillRegion(fillingC, padC, pointX - 1, pointY);
            RecursiveFillRegion(fillingC, padC, pointX + 1, pointY);
            RecursiveFillRegion(fillingC, padC, pointX, pointY - 1);
            RecursiveFillRegion(fillingC, padC, pointX, pointY + 1);
        }

        private void RecursiveFillRegion(Color fillingC,Color padC, int pointX, int pointY)
        {
            Color cl = PadBmpImage.GetPixel(pointX, pointY);
            if (cl == fillingC || cl != padC)
                return;
            PadBmpImage.SetPixel(pointX, pointY, fillingC); 
            RecursiveFillRegion(fillingC, padC, pointX - 1, pointY);
            RecursiveFillRegion(fillingC, padC, pointX + 1, pointY);
            RecursiveFillRegion(fillingC, padC, pointX, pointY - 1);
            RecursiveFillRegion(fillingC, padC, pointX, pointY + 1);
        }
    }
}