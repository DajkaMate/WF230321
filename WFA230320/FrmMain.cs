namespace WFA230320
{
    public partial class FrmMain : Form
    {
        #region Hungarian Notation
        //frm -> form
        //mnu -> menu
        //btn -> button
        //cmd -> command / command button
        //chk -> check box / check button
        //lbl -> text label
        //txt -> text edit/input
        //pic -> picture
        //lst -> listbox
        //cbo -> combo box
        //tmr -> timer
        //pd  -> picture box
        //uc  -> user control
        //opt -> radio button
        #endregion

        private static Random rnd = new();
        public int Score { get; set; } = 0;
        public List<PictureBox> Targets { get; set; } = new();
        public FrmMain()
        {
            InitializeComponent();
            tmrUpdate.Tick += OnTmrUpdateTick;
            this.Load += OnFrmMainLoad;
        }
        private void OnTmrUpdateTick(object? sender, EventArgs e)
        {
            if (rnd.Next(100) < 30)
            {
                var pb = GetNewRandomTarget();
                pb.Click += OnTargetClick;
                pnl.Click += OnTargetMissClick;
                pnl.Controls.Add(pb);
            }
        }
        private void OnFrmMainLoad(object? sender, EventArgs e)
        {
            tmrUpdate.Start();
        }
        private void OnTargetClick(object? sender, EventArgs e)
        {
            label1.Text = $"Score: {++Score}";
            (sender as PictureBox)!.Dispose();
        }
        private void OnTargetMissClick(object? sender, EventArgs e)
        {      
            label1.Text = $"Score: {Score = Score - 10}";
        }
        private PictureBox GetNewRandomTarget()
        {
            int size = rnd.Next(20,100);
            int pX = rnd.Next(0, pnl.Width - size);
            int pY = rnd.Next(0, pnl.Height - size);
            Color color = Color.FromArgb(
                red: rnd.Next(0, 256),
                green: rnd.Next(0, 256),
                blue: rnd.Next(0, 256)
                );

            return new PictureBox()
            {
                BackColor = color,
                Bounds = new()
                {
                    X = pX,
                    Y = pY,
                    Height = size,
                    Width = size,
                },
                Image = null,
            };
        }

    }
}