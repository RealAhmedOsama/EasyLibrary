using EasyLibrary.WinForms.About;
using EasyLibrary.WinForms.BookManagement;
using EasyLibrary.WinForms.BorrowTransactions;
using EasyLibrary.WinForms.CategoryManagement;
using EasyLibrary.WinForms.Dashboard;
using EasyLibrary.WinForms.MemberManagement;
using EasyLibrary.WinForms.ReservationTransactions;
using EasyLibrary.WinForms.RolesManagement;
using EasyLibrary.WinForms.UserManagement;

namespace EasyLibrary.WinForms;

public partial class MainForm : Form
{
    private readonly Dictionary<Type, Form> _formInstances = new();

    public MainForm()
    {
        InitializeComponent();
    }

    private void ShowForm<T>() where T : Form, new()
    {
        var formType = typeof(T);

        if (!_formInstances.ContainsKey(formType) || _formInstances[formType].IsDisposed)
        {
            var form = new T();
            form.FormClosed += (s, args) => _formInstances.Remove(formType);
            _formInstances[formType] = form;
        }

        var existingForm = _formInstances[formType];
        if (existingForm.Visible)
        {
            existingForm.Focus();
            existingForm.BringToFront();
        }
        else
        {
            existingForm.Show();
        }
    }

    private void BtnDashboard_Click(object sender, EventArgs e)
    {
        ShowForm<DashboardForm>();
    }

    private void BtnBooksManagement_Click(object sender, EventArgs e)
    {
        ShowForm<BookManagementForm>();
    }

    private void BtnCategoriesManagement_Click(object sender, EventArgs e)
    {
        ShowForm<CategoryManagementForm>();
    }

    private void BtnMembersManagement_Click(object sender, EventArgs e)
    {
        ShowForm<MemberManagementForm>();
    }

    private void BtnUsersManagement_Click(object sender, EventArgs e)
    {
        ShowForm<UsersManagementForm>();
    }

    private void BtnRolesManagement_Click(object sender, EventArgs e)
    {
        ShowForm<RolesManagementForm>();
    }

    private void BtnReservationTransactions_Click(object sender, EventArgs e)
    {
        ShowForm<ReservationTransactionsForm>();
    }

    private void BtnBorrowTransactions_Click(object sender, EventArgs e)
    {
        ShowForm<BorrowTransactionsForm>();
    }

    private void BtnAbout_Click(object sender, EventArgs e)
    {
        ShowForm<AboutForm>();
    }
}