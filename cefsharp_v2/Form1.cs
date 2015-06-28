using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;
using CefSharp;
using CefSharp.WinForms;

namespace cefsharp_v2
{
  public partial class FrmMainForm : Form
  {
    private static readonly string _myPath = Application.StartupPath;
    private static readonly string _pagesPath = Path.Combine(_myPath, "Pages");
    private ChromiumWebBrowser _browser;

    private static string _savedName = String.Empty;
    private static string _savedEmail = String.Empty;

    private FormEntryHandler _formEntryHandler;

    private string GetPagePath(string pageName)
    {
      return Path.Combine(_pagesPath, pageName);
    }

    private void ChangePage(string pageName)
    {
      _browser.Load(GetPagePath(pageName));
    }

    public FrmMainForm()
    {
      InitializeComponent();

      WindowState = FormWindowState.Maximized;
      InitializeBrowserControl();
    }

    private void InitializeBrowserControl()
    {
      _formEntryHandler = new FormEntryHandler();
      _formEntryHandler.FormSave += _formEntryHandler_FormSave;
      _formEntryHandler.FormPost += _formEntryHandler_FormPost;

      _browser = new ChromiumWebBrowser(GetPagePath("start.html"))
      {
        Dock = DockStyle.Fill
      };

      PnlHtml.Controls.Add(_browser);

      _browser.AddressChanged += BrowserAddressChanged;
      _browser.ConsoleMessage += BrowserConsoleMessage;
      _browser.LoadError += BrowserLoadError;
      _browser.StatusMessage += BrowserStatusMessage;
      _browser.NavStateChanged += BrowserNavStateChanged;
      _browser.TitleChanged += BrowserTitleChanged;

      _browser.RegisterJsObject("formEntryHandler", _formEntryHandler);
    }

    void _formEntryHandler_FormPost(object sender, FormEntryEventArgs e)
    {
      if(e.Name.Equals("admin") && e.Email.Equals("admin@admin.com"))
      {
        ChangePage("admin.html");
        return;
      }

      ChangePage("");
    }

    void _formEntryHandler_FormSave(object sender, FormEntryEventArgs e)
    {
      _savedName = e.Name;
      _savedEmail = e.Email;
      MessageBox.Show("Form elements saved, now change or empty the form contents, and you'll be able to re-populate them", ".NET Alert Box");
    }

    void BrowserTitleChanged(object sender, TitleChangedEventArgs e)
    {
      LogMessage("TITLE CHANGED: " + e.Title);
    }

    void BrowserNavStateChanged(object sender, NavStateChangedEventArgs e)
    {
      string navStatus = String.Format("Back ({0}) : Forward ({1}) : Reload ({2}) : Loading({3})",
        e.CanGoBack,
        e.CanGoForward,
        e.CanReload,
        e.IsLoading);
      LogMessage("NAVSTATE CHANGED: " + navStatus);
    }

    void BrowserStatusMessage(object sender, StatusMessageEventArgs e)
    {
      LogMessage("STATUS MESSAGE: " + e.Value);
    }

    void BrowserLoadError(object sender, LoadErrorEventArgs e)
    {
      string messageText = String.Format("{0} ({1} [{2}])", e.ErrorText, e.FailedUrl, e.ErrorCode);
      LogMessage("LOAD ERROR: " + messageText);
    }

    void BrowserConsoleMessage(object sender, ConsoleMessageEventArgs e)
    {
      string messageText = String.Format("{0}: {1} ({2})", e.Line, e.Message, e.Source);
      LogMessage("CONSOLE MESSAGE: " + messageText);
    }

    void BrowserAddressChanged(object sender, AddressChangedEventArgs e)
    {
      LogMessage("ADDRESS CHANGED: " + e.Address);
    }

    private void LogMessage(string messageText)
    {
      if (LsbMessages.InvokeRequired)
      {
        LsbMessages.Invoke(new Action(() => LogMessage(messageText)));
        return;
      }
      LsbMessages.Items.Add(messageText);

      int visibleItems = LsbMessages.ClientSize.Height / LsbMessages.ItemHeight;
      LsbMessages.TopIndex = Math.Max(LsbMessages.Items.Count - visibleItems + 1, 0);
    }

    private void BtnChangeHeaderClick(object sender, EventArgs e)
    {
      string script = "";
      script += "var header = $('#pageHeader');";
      script += "$(header).children('h1').children('small').text('Welcome to the future of UI').addClass('text-success');";

      _browser.ExecuteScriptAsync(script);
    }

    private void BtnPopulateFormClick(object sender, EventArgs e)
    {

      if(String.IsNullOrEmpty(_savedName) || String.IsNullOrEmpty(_savedEmail))
      {
        MessageBox.Show(
          "Please save a name and email to reuse before populating the form, you can do this by entering values in the form then clicking the 'save button'",
          ".NET Alert Box");
        return;
      }

      string name = _savedName;
      string email = _savedEmail;

      string script = "";
      script += "$('#inputName').val('" + name + "');";
      script += "$('#inputEmail').val('" + email + "');";

      _browser.ExecuteScriptAsync(script);
    }

  }
}
