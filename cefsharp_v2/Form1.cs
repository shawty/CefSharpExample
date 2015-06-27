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

      if (e.Name.Equals("magic") && e.Email.Equals("magic@magic.com"))
      {
        CreateVirtualPage();
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

    private void CreateVirtualPage()
    {
      XElement myHtmlDocument = new XElement("html");
      //myHtmlDocument
/*
<!DOCTYPE html>

<html lang="en">

  <head>
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>CefSharp Example Admin Page</title>
    <link href="Styles/bootstrap.min.css" rel="stylesheet" type="text/css" />
  </head>

  <body>

    <div class="container">

      <div class="page-header" id="pageHeader">
        <h1>.NET Nuts and Bolts <small>HTML5 UI's in desktop applications</small></h1>
      </div>

      <p class="lead text-success">You have requested the ADMIN page, as an admin you can do anything here that might be an admin function.
      </p>

      <p>
        This however is just a demo, so there's actually nothing like that in here. Use your imagination though, what you currently have here
        is in effect a custom browser, so you could do all sorts of interesting stuff, such as using something on the local machine to
        authenticate a user, or have a web-page JS function trigger a native fucntion and send the data to a server.
      </p>

      <p>
        Your UI doesn't have to be local pages, they can be pages loaded from elswhere, but controled in a kiosk like experience,
        ensuring that your app is the only app running (Great for corporate client machines).
      </p>

      <p>
        Best of all, the core is based on the chrome web-kit engine, so you get all kinds of nice HTML5 goodness to play with.
      </p>

      <a href="start.html" class="btn btn-primary">Click here to go back to the start page.</a>

    </div>


    <script src="Scripts/jquery-1.9.1.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    
  </body>

</html>
  */    
    }

  }
}
