# How to add a custom data marker in WinUI Chart (SfCartesianChart)?

This example illustrates how to add a custom view as chart Data Label and customize the appearance based on its Y value in the [WinUI charts](https://www.syncfusion.com/winui-controls/charts).

**Step 1:** By using the [ContentTemplate](https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.ChartDataLabelSettings.html#Syncfusion_UI_Xaml_Charts_ChartDataLabelSettings_ContentTemplate) property of [CartesianDataLabelSettings](https://help.syncfusion.com/cr/winui/Syncfusion.UI.Xaml.Charts.CartesianDataLabelSettings.html), we can add the data label with custom view. The following code example explains how to add a circle ring shape as a data label using the Border control.

```
…
<chart:SfCartesianChart.Resources>
    <DataTemplate x:Key="dataLabelTemplate">
        <Border Height="10" Width="10" CornerRadius="20"
                BorderBrush="Red " BorderThickness="2"
                Background="WhiteSmoke" >
        </Border>
    </DataTemplate>
</chart:SfCartesianChart.Resources>

<chart:SplineAreaSeries ItemsSource="{Binding Data}"
                        XBindingPath="XValue" YBindingPath="YValue" 
                        ShowDataLabels="True">
    <chart:SplineAreaSeries.DataLabelSettings>
        <chart:CartesianDataLabelSettings ContentTemplate="{StaticResource dataLabelTemplate}"/>
    </chart:SplineAreaSeries.DataLabelSettings>
</chart:SplineAreaSeries>
```

**Step 2:** Using IValueConverter, we can customize the appearance of the BorderBrush color based on the "Y" data point value for the custom data labels as shown in the following code example.

```
…
<chart:SfCartesianChart.Resources>
    <local:BorderColorConverter x:Key="borderColorConverter"/>
    <DataTemplate x:Key="dataLabelTemplate">
        <Border Height="10" Width="10" CornerRadius="20"
                BorderBrush="{Binding Converter={StaticResource borderColorConverter}}" 
                Background="WhiteSmoke" BorderThickness="2">
        </Border>
    </DataTemplate>
    …
</chart:SfCartesianChart.Resources>
…
<chart:SplineAreaSeries ItemsSource="{Binding Data}"
                        XBindingPath="XValue" YBindingPath="YValue" 
                        ShowDataLabels="True"
                        PaletteBrushes="{StaticResource customBrushes}">
    <chart:SplineAreaSeries.DataLabelSettings>
        <chart:CartesianDataLabelSettings ContentTemplate="{StaticResource dataLabelTemplate}"/>
    </chart:SplineAreaSeries.DataLabelSettings>
</chart:SplineAreaSeries>
```

**BorderColorConverter.cs**
```
public class BorderColorConverter : IValueConverter
{
    static double YValue = 0;
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        if (value != null)
        {
            var yData =  System.Convert.ToDouble(value);
            if (yData >= YValue)
            {
                //if y value increased
                YValue = yData;
                return new SolidColorBrush(Colors.Green);
            }
            else
            {
                //if y value decreased
                YValue = yData;
                return new SolidColorBrush(Colors.Red);
            }
        }

        return new SolidColorBrush(Colors.Transparent);
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        return value;
    }
}
```

### Output



### See also

[How to customize the data label in WinUI Chart (SfCartesianChart)?](https://help.syncfusion.com/winui/cartesian-charts/datalabels#template)

[How to customize the appearance in WinUI Chart (SfCartesianChart)?](https://help.syncfusion.com/winui/cartesian-charts/appearance)