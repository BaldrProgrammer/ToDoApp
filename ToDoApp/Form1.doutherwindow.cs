namespace TodoApp;

public class Form2 : Form
{
    public string NovoeIme { get; private set; } = "";
    
    private Label lblVvedi;
    private TextBox txtVvesti;
    private Button btnOtpravit;
    
    public Form2()
    {
         this.Text = "Edycja zadania";
         this.Size = new Size(200, 150);

         lblVvedi = new Label();
         lblVvedi.Text = "wprowadz nowe zadanie";
         lblVvedi.Size = new Size(175, 25);
         lblVvedi.Location = new Point(25, 10);

         txtVvesti = new TextBox();
         txtVvesti.Size = new Size(150, 25);
         txtVvesti.Location = new Point(20, 40);
         
         btnOtpravit = new Button();
         btnOtpravit.Text = "zatwierdzic";
         btnOtpravit.Size = new Size(150, 25);
         btnOtpravit.Location = new Point(20, 75);
         btnOtpravit.Click += btn_otpravit_click;
         
         Controls.Add(lblVvedi);
         Controls.Add(txtVvesti);
         Controls.Add(btnOtpravit);
    }

    public void btn_otpravit_click(object sender, EventArgs e)
    {
        this.NovoeIme = txtVvesti.Text;
        this.Close();
    }
}