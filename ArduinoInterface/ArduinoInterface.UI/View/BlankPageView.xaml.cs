﻿namespace ArduinoInterface.UI.View;

public partial class BlankPageView : UserControl
{
    public BlankPageView()
    {
        InitializeComponent();
    }
    public BlankPageView(BlankPageViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }

}