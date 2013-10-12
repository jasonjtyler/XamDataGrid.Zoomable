using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace XamDataGrid.Zoomable
{
    class MouseWheelZooming : DependencyObject
    {
        public static readonly DependencyProperty IsEnabledProperty = DependencyProperty.RegisterAttached("IsEnabled", typeof(bool), typeof(MouseWheelZooming),
                                                                                                          new FrameworkPropertyMetadata(false)
                                                                                                          {
                                                                                                              PropertyChangedCallback = ZoomEnabledChanged,
                                                                                                              BindsTwoWayByDefault = true
                                                                                                          });

        public static readonly DependencyProperty ZoomAmountProperty = DependencyProperty.RegisterAttached("ZoomAmount", typeof(double), typeof(MouseWheelZooming), new PropertyMetadata(1.0));

        public static readonly DependencyProperty ZoomMinimumProperty = DependencyProperty.RegisterAttached("ZoomMinimum", typeof(double), typeof(MouseWheelZooming), new PropertyMetadata(0.2));

        public static readonly DependencyProperty ZoomMaximumProperty = DependencyProperty.RegisterAttached("ZoomMaximum", typeof(double), typeof(MouseWheelZooming), new PropertyMetadata(4.0));

        public bool GetIsEnabled(DependencyObject item)
        {
            return (bool)item.GetValue(IsEnabledProperty);
        }
        public void SetIsEnabled(DependencyObject item, bool value)
        {
            item.SetValue(IsEnabledProperty, value);
        }

        public double GetZoomAmount(DependencyObject item)
        {
            return (double)item.GetValue(ZoomAmountProperty);
        }
        public void SetZoomAmount(DependencyObject item, double value)
        {
            item.SetValue(ZoomAmountProperty, value);
        }

        public double GetZoomMinimum(DependencyObject item)
        {
            return (double)item.GetValue(ZoomMinimumProperty);
        }
        public void SetZoomMinimum(DependencyObject item, double value)
        {
            item.SetValue(ZoomMinimumProperty, value);
        }

        public double GetZoomMaximum(DependencyObject item)
        {
            return (double)item.GetValue(ZoomMaximumProperty);
        }
        public void SetZoomMaximum(DependencyObject item, double value)
        {
            item.SetValue(ZoomMaximumProperty, value);
        }

        private static void ZoomEnabledChanged(DependencyObject s, DependencyPropertyChangedEventArgs args)
        {
            Control c = (Control)s;
            bool wasEnabled = (bool)args.OldValue;
            bool isEnabled = (bool)args.NewValue;

            if (wasEnabled)
                c.RemoveHandler(Control.PreviewMouseWheelEvent, new MouseWheelEventHandler(PreviewMouseWheel));

            if (isEnabled)
                c.AddHandler(Control.PreviewMouseWheelEvent, new MouseWheelEventHandler(PreviewMouseWheel), true);
        }

        private static void PreviewMouseWheel(Object sender, MouseWheelEventArgs e)
        {
            if (Keyboard.Modifiers == ModifierKeys.Control)
            {
                Control zoomableControl = (Control)sender;

                double zoomAmount = (double)zoomableControl.GetValue(ZoomAmountProperty);
                double zoomMinimum = (double)zoomableControl.GetValue(ZoomMinimumProperty);
                double zoomMaximum = (double)zoomableControl.GetValue(ZoomMaximumProperty);

                if (e.Delta > 0)
                    zoomAmount *= 1.1;
                else
                    zoomAmount *= 0.90909090909090906;

                if (zoomAmount > zoomMaximum)
                    zoomAmount = zoomMaximum;
                else if (zoomAmount < zoomMinimum)
                    zoomAmount = zoomMinimum;

                zoomAmount = Math.Round(zoomAmount, 2);

                zoomableControl.SetValue(ZoomAmountProperty, zoomAmount);
            }
        }

    }
}
