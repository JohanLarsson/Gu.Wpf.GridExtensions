namespace Gu.Wpf.GridExtensions
{
    using System.Windows;

    /// <summary> Defines an attached property for setting Grid.RowDefinitions as a string. </summary>
    public static class Row
    {
        /// <summary> A string like Auto Auto *. </summary>
        public static readonly DependencyProperty DefinitionsProperty = DependencyProperty.RegisterAttached(
            "Definitions",
            typeof(RowDefinitions),
            typeof(Row),
            new FrameworkPropertyMetadata(
                default(RowDefinitions),
                FrameworkPropertyMetadataOptions.NotDataBindable,
                OnDefinitionsChanged));

        /// <summary>Helper for setting <see cref="DefinitionsProperty"/> on <paramref name="element"/>.</summary>
        /// <param name="element"><see cref="Grid"/> to set <see cref="DefinitionsProperty"/> on.</param>
        /// <param name="value">Definitions property value.</param>
        public static void SetDefinitions(System.Windows.Controls.Grid element, RowDefinitions? value)
        {
            if (element is null)
            {
                throw new System.ArgumentNullException(nameof(element));
            }

            element.SetValue(DefinitionsProperty, value);
        }

        /// <summary>Helper for getting <see cref="DefinitionsProperty"/> from <paramref name="element"/>.</summary>
        /// <param name="element"><see cref="Grid"/> to read <see cref="DefinitionsProperty"/> from.</param>
        /// <returns>Definitions property value.</returns>
        [AttachedPropertyBrowsableForChildren(IncludeDescendants = false)]
        [AttachedPropertyBrowsableForType(typeof(System.Windows.Controls.Grid))]
        public static RowDefinitions? GetDefinitions(System.Windows.Controls.Grid element)
        {
            if (element is null)
            {
                throw new System.ArgumentNullException(nameof(element));
            }

            return (RowDefinitions?)element.GetValue(DefinitionsProperty);
        }

        private static void OnDefinitionsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var grid = (System.Windows.Controls.Grid)d;
            grid.RowDefinitions.Clear();

            var rowDefinitions = (RowDefinitions?)e.NewValue;
            if (rowDefinitions is null)
            {
                return;
            }

            foreach (var rowDefinition in rowDefinitions)
            {
                grid.RowDefinitions.Add(rowDefinition);
            }
        }
    }
}
