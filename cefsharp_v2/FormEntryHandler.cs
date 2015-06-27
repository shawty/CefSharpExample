namespace cefsharp_v2
{
  public delegate void FormActionDelegate(object sender, FormEntryEventArgs e);

  public class FormEntryHandler
  {
    public event FormActionDelegate FormSave;
    public event FormActionDelegate FormPost;

    public void SaveCredentials(string name, string email)
    {
      OnFormSave(new FormEntryEventArgs
      {
        Name = name,
        Email = email
      });
    }

    public void PostForm(string name, string email)
    {
      OnFormPost(new FormEntryEventArgs
      {
        Name = name,
        Email = email
      });
    }

    protected virtual void OnFormSave(FormEntryEventArgs e)
    {
      var handler = FormSave;
      if (handler != null) handler(this, e);
    }

    protected virtual void OnFormPost(FormEntryEventArgs e)
    {
      var handler = FormPost;
      if (handler != null) handler(this, e);
    }

  }
}
