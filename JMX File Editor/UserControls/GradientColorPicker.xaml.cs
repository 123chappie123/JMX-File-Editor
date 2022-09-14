﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace JMXFileEditor.UserControls
{
    /// <summary>
    /// Lógica de interacción para GradientColorPicker.xaml
    /// </summary>
    public partial class GradientColorPicker : UserControl
    {
        #region Dependecy Properties
        /// <summary>
        /// Gradient item collection being displayed
        /// </summary>
        public GradientStopCollection GradientItems
        {
            get => (GradientStopCollection)GetValue(GradientItemsProperty);
            set => SetValue(GradientItemsProperty, value);
        }
        public static DependencyProperty GradientItemsProperty =
           DependencyProperty.Register("GradientItems", typeof(GradientStopCollection), typeof(GradientColorPicker));
        /// <summary>
        /// Gradient items
        /// </summary>
        public IEnumerable<GradientColorPickerVM.GradientColorData> GradientItemsSource
        {
            get => (IEnumerable<GradientColorPickerVM.GradientColorData>)GetValue(GradientItemsSourceProperty);
            set => SetValue(GradientItemsSourceProperty, value);
        }

        public static readonly DependencyProperty GradientItemsSourceProperty =
            DependencyProperty.Register("GradientItemsSource", typeof(IEnumerable<GradientColorPickerVM.GradientColorData>), typeof(GradientColorPicker),
            new PropertyMetadata(null, new PropertyChangedCallback(OnItemsSourceChanged)));
        #endregion

        #region Constructor
        public GradientColorPicker()
        {
            var vm = new GradientColorPickerVM();
            DataContext = vm;
            GradientItemsSource = vm.GradientItemsSource;
            InitializeComponent();
        }
        #endregion

        #region Private Helpers
        /// <summary>
        /// Updates GradientItems everytime GradientItemsSource updates
        /// </summary>
        private static void OnItemsSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.OldValue == e.NewValue)
                return;
            var _this = d as GradientColorPicker;
            if (e.OldValue is ObservableCollection<GradientColorPickerVM.GradientColorData>)
            {
                var c = e.OldValue as ObservableCollection<GradientColorPickerVM.GradientColorData>;
                c.CollectionChanged -= _this.GradientItemsSourceCollectionChanged;
            }
            if (e.NewValue is ObservableCollection<GradientColorPickerVM.GradientColorData>)
            {
                var c = e.NewValue as ObservableCollection<GradientColorPickerVM.GradientColorData>;
                c.CollectionChanged += _this.GradientItemsSourceCollectionChanged;
            }
            _this.UpdateItems();
        }
        private void GradientItemsSourceCollectionChanged(object sender, NotifyCollectionChangedEventArgs e) => UpdateItems();
        private void GradientItemsSourcePropertyChanged(object sender, PropertyChangedEventArgs e) => UpdateItems();
        private void UpdateItems() => GradientItems = new GradientStopCollection(GradientItemsSource.Select(x => new GradientStop(x.Color, x.Offset)));
        #endregion
    }
}
