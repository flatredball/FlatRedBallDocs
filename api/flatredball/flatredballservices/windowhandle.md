## Introduction

The WindowHandle is an IntPtr referencing the Form that is hosting the XNA game. This can be used to get access to the form to perform customization and handle events.

## Accessing a Form

The following code can be used to get the current Form:

    Form form = Form.FromHandle(FlatRedBallServices.WindowHandle) as Form;

## Disabling FRB when minimized

If your application uses the \[STAThread\] attribute on your program's Main function (often to interact with winforms), your FRB apps may not resume properly when minimized. To correct this you can simply disable the FRB engine from performing logic when its host window is minimized. To do this:

**Add the following code to Initialize:**

    Form form = Form.FromHandle(FlatRedBallServices.WindowHandle) as Form;
    form.Resize += HandleResize;

**Add the following code to your Game class:**

    private void HandleResize(object sender, EventArgs e)
    {
        Form form = Form.FromHandle(FlatRedBallServices.WindowHandle) as Form;
        if (form.WindowState == FormWindowState.Minimized)
        {
            FlatRedBallServices.SuspendEngine();
        }
        else
        {
            FlatRedBallServices.UnsuspendEngine();
        }
    }
