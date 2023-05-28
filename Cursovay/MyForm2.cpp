using namespace System;
using namespace System::ComponentModel;
using namespace System::Collections;
using namespace System::Windows::Forms;
using namespace System::Data;
using namespace System::Drawing;
using namespace std;

void SolveEquation(String^ selectedFunction, double A, double B, double C, String^% solution)
{
    if (selectedFunction == "0*x = 0")
    {
        solution = "Ответом является любое значение Х";
        return;
    }
    else if (selectedFunction == "A * x^2 = 0")
    {
        if (A == 0)
        {
            solution = "Ответом является любое значение Х";
            return;
        }
        else
        {
            double x = 0;
            solution = "x = " + x.ToString();
            return;
        }
    }
    else if (selectedFunction == "C = 0")
    {
        if (C == 0)
        {
            solution = "Корней нет";
            return;
        }
        else
        {
            solution = "Корней нет";
            return;
        }
    }
    else if (selectedFunction == "A * x^2 + C = 0")
    {
        if (A == 0 && C == 0)
        {
            solution = "Ответом является любое значение Х";
            return;
        }
        else if (A == 0)
        {
            solution = "Нет решений";
            return;
        }
        else if ((A > 0 && C < 0) || (A < 0 && C > 0))
        {
            double x = Math::Sqrt(-C / A);
            solution = "x = " + x.ToString() + " или x = " + (-x).ToString();
            return;
        }
        else
        {
            solution = "Нет решений";
            return;
        }

    }
    else if (selectedFunction == "B * x + C = 0")
    {
        if (B == 0 && C == 0)
        {
            solution = "Ответом является любое значение Х";
            return;
        }
        else if (B == 0)
        {
            solution = "Нет решений";
            return;
        }
        else
        {
            double x = -C / B;
            solution = "x = " + x.ToString();
            return;
        }
    }
    else if (selectedFunction == "A * x^2 + B * x + C = 0")
    {
        double D = Math::Pow(B, 2) - 4 * A * C;

        if (D > 0)
        {
            double x1 = (-B + Math::Sqrt(D)) / (2 * A);
            double x2 = (-B - Math::Sqrt(D)) / (2 * A);
            solution = "x1 = " + x1.ToString() + ", x2 = " + x2.ToString();
        }
        else if (A == 0 && B == 0 && C == 0)
        {
            solution = "Ответом является любое значение X";
        }
        else if (D == 0)
        {
            double x = -B / (2 * A);
            solution = "x = " + x.ToString();
        }
        else 
        {
            solution = "Нет реальных корней";
        }

        return;
    }
    else if (selectedFunction == "B * x = 0")
    {
        if (B == 0)
        {
            solution = "Ответом является любое значение Х";
            return;
        }

        else
        {
            double x = 0;
            solution = "x = " + x.ToString();
            return;
        }
    }
    else if (selectedFunction == "A * x^2 + B * x = 0")
    {
        double D = Math::Pow(B, 2) - 4 * A * 0;

        if (D > 0)
        {
            double x1 = (-B + Math::Sqrt(D)) / (2 * A);
            double x2 = (-B - Math::Sqrt(D)) / (2 * A);
            solution = "x1 = " + x1.ToString() + ", x2 = " + x2.ToString();
        }
        else if (A == 0 && B == 0)
        {
            solution = "Ответом является любое значение X";
        }

        else if (D == 0)
        {
            double x = -B / (2 * A);
            solution = "x = " + x.ToString();
        }
        else
        {
            solution = "Нет реальных корней";
        }

        return;
    }
}
public ref class MainForm : public System::Windows::Forms::Form
{
private:
    Button^ closeButton;
    ComboBox^ comboBox;
    TextBox^ textBoxA;
    TextBox^ textBoxB;
    TextBox^ textBoxC;
    Button^ buttonSolve;
    Label^ label4;
    Label^ labelSolution;
public:
    MainForm()
    {
        closeButton = gcnew Button();
        closeButton->Text = "х";
        closeButton->Location = System::Drawing::Point(540, 20);
        closeButton->Width = 40;
        closeButton->Height = 40;
        this->closeButton->Font = (gcnew System::Drawing::Font(L"Arial", 12, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point, static_cast<System::Byte>(204)));
        closeButton->BackColor = Color::Blue;
        closeButton->ForeColor = Color::White;
        closeButton->Click += gcnew System::EventHandler(this, &MainForm::OnCloseButtonClick); 
        this->Controls->Add(closeButton); 

        this->Text = "Решение уравнений";
        this->Width = 600;
        this->Height = 570;

Label^ label1 = gcnew Label();
label1->Text = "Выберите тип уравнения";
label1->Location = System::Drawing::Point(123, 95);
label1->AutoSize = true;
label1->Font = (gcnew System::Drawing::Font(L"Arial", 20, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
static_cast<System::Byte>(204)));
label1->ForeColor = System::Drawing::Color::Blue;
this->Controls->Add(label1);

comboBox = gcnew ComboBox();
comboBox->Location = System::Drawing::Point(130, 145);
comboBox->Width = 340;
comboBox->Items->Add("0*x = 0");
comboBox->Items->Add("A * x^2 = 0");
comboBox->Items->Add("C = 0");
comboBox->Items->Add("A * x^2 + C = 0");
comboBox->Items->Add("B * x + C = 0");
comboBox->Items->Add("A * x^2 + B * x + C = 0");
comboBox->Items->Add("B * x = 0");
comboBox->Items->Add("A * x^2 + B * x = 0");
comboBox->SelectedIndexChanged += gcnew System::EventHandler(this, &MainForm::OnComboBoxSelectedIndexChanged);
this->Controls->Add(comboBox);

Label^ label2 = gcnew Label();
label2->Text = "Введите коэффициент ";
label2->Location = System::Drawing::Point(138, 195);
label2->Font = (gcnew System::Drawing::Font(L"Arial", 20, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
static_cast<System::Byte>(204)));
label2->ForeColor = System::Drawing::Color::Blue;
label2->AutoSize = true;
this->Controls->Add(label2);

Label^ label3 = gcnew Label();
label3->Text = "Введенные коэффициенты не должны \n равняться 0";
label3->Location = System::Drawing::Point(130, 245);
label3->Font = (gcnew System::Drawing::Font(L"Arial", 12, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
    static_cast<System::Byte>(204)));
label3->AutoSize = true;
this->Controls->Add(label3);

Label^ labelA = gcnew Label();
labelA->Text = "A:";
labelA->Location = System::Drawing::Point(130, 295);
labelA->Font = (gcnew System::Drawing::Font(L"Arial", 12, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
static_cast<System::Byte>(204)));
labelA->AutoSize = true;
this->Controls->Add(labelA);

textBoxA = gcnew TextBox();
textBoxA->Location = System::Drawing::Point(160,295);
textBoxA->Width = 310;
this->Controls->Add(textBoxA);

Label^ labelB = gcnew Label();
labelB->Text = "B:";
labelB->Location = System::Drawing::Point(130, 320);
labelB->Font = (gcnew System::Drawing::Font(L"Arial", 12, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
static_cast<System::Byte>(204)));
labelB->AutoSize = true;
this->Controls->Add(labelB);

textBoxB = gcnew TextBox();
textBoxB->Location = System::Drawing::Point(160, 320);
textBoxB->Width = 310;
this->Controls->Add(textBoxB);

Label^ labelC = gcnew Label();
labelC->Text = "C:";
labelC->Location = System::Drawing::Point(130, 345);
labelC->Font = (gcnew System::Drawing::Font(L"Arial", 12, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
static_cast<System::Byte>(204)));
labelC->AutoSize = true;
this->Controls->Add(labelC);

textBoxC = gcnew TextBox();
textBoxC->Location = System::Drawing::Point(160, 345);
textBoxC->Width = 310;
this->Controls->Add(textBoxC);

buttonSolve = gcnew Button();
buttonSolve->Text = "Решить";
buttonSolve->Location = System::Drawing::Point(130, 385);
buttonSolve->Width = 340;
buttonSolve->Height = 40;
this->buttonSolve->Font = (gcnew System::Drawing::Font(L"Arial", 12, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point, static_cast<System::Byte>(204)));
buttonSolve->BackColor = Color::Blue;
buttonSolve->ForeColor = Color::White;
buttonSolve->Click += gcnew System::EventHandler(this, &MainForm::OnButtonSolveClick);
this->Controls->Add(buttonSolve);

Label^ label4 = gcnew Label();
label4->Text = "Решение: ";
label4->Font = (gcnew System::Drawing::Font(L"Arial", 20, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
    static_cast<System::Byte>(204)));
label4->ForeColor = System::Drawing::Color::Blue;
label4->Location = System::Drawing::Point(230, 450);
label4->AutoSize = true;
this->Controls->Add(label4);

labelSolution = gcnew Label();
labelSolution->Text = " ";
labelSolution->Font = (gcnew System::Drawing::Font(L"Arial", 12, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
    static_cast<System::Byte>(204)));
labelSolution->Location = System::Drawing::Point(130, 500);
labelSolution->AutoSize = true;
this->Controls->Add(labelSolution);

    }
private:
    void OnCloseButtonClick(System::Object^ sender, System::EventArgs^ e)
    {
        this->Close();
    }
    void OnComboBoxSelectedIndexChanged(System::Object^ sender, System::EventArgs^ e)
    {
       
        String^ selectedFunction = comboBox->SelectedItem->ToString();
        if (selectedFunction == "0*x = 0")
        {
            textBoxA->Enabled = false;
            textBoxB->Enabled = false;
            textBoxC->Enabled = false;
        }
        else if (selectedFunction == "C = 0")
        {
            textBoxA->Enabled = false;
            textBoxB->Enabled = false;
            textBoxC->Enabled = true;
        }
        else if (selectedFunction == "B * x = 0")
        {
            textBoxA->Enabled = false;
            textBoxB->Enabled = true;
            textBoxC->Enabled = false;
        }
        else if (selectedFunction == "A * x^2 = 0")
        {
            textBoxA->Enabled = true;
            textBoxB->Enabled = false;
            textBoxC->Enabled = false;
        }
        else if (selectedFunction == "A * x^2 + C = 0")
        {
            textBoxA->Enabled = true;
            textBoxB->Enabled = false;
            textBoxC->Enabled = true;
        }
        else if (selectedFunction == "A * x^2 + B * x + C = 0")
        {
            textBoxA->Enabled = true;
            textBoxB->Enabled = true;
            textBoxC->Enabled = true;
        }
        else if (selectedFunction == "A * x^2 + B * x = 0")
        {
            textBoxA->Enabled = true;
            textBoxB->Enabled = true;
            textBoxC->Enabled = false;
        }
        else if (selectedFunction == "B * x + C = 0")
        {
            textBoxA->Enabled = false;
            textBoxB->Enabled = true;
            textBoxC->Enabled = true;
        }

    }
    void OnButtonSolveClick(System::Object^ sender, System::EventArgs^ e)
    {
        String^ selectedFunction = comboBox->SelectedItem->ToString();
        double A, B, C;
        double::TryParse(textBoxA->Text, A);
        double::TryParse(textBoxB->Text, B);
        double::TryParse(textBoxC->Text, C);

        String^ solution = "";
        SolveEquation(selectedFunction, A, B, C, solution);

        labelSolution->Text = " " + solution;
        
       
    }
};
 
[STAThread]
int main(array<System::String^>^ args)
{
    Application::EnableVisualStyles();
    Application::SetCompatibleTextRenderingDefault(false);
    MainForm form;

    form.FormBorderStyle = FormBorderStyle::None;

    Application::Run(% form);

    return 0;
}