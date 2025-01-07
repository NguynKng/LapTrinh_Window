using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chuongtrinhquanlygarage.Logic
{
    public class ListViewItemComparer : IComparer
    {
        private int _columnIndex;
        private bool _ascending;

        public ListViewItemComparer(int columnIndex, bool ascending)
        {
            _columnIndex = columnIndex;
            _ascending = ascending;
        }

        public int Compare(object x, object y)
        {
            ListViewItem itemX = x as ListViewItem;
            ListViewItem itemY = y as ListViewItem;

            if (itemX == null || itemY == null) return 0;

            string textX = itemX.SubItems[_columnIndex].Text;
            string textY = itemY.SubItems[_columnIndex].Text;

            int result;

            // Handle date sorting
            if (_columnIndex == 7 && DateTime.TryParse(textX, out var dateX) && DateTime.TryParse(textY, out var dateY))
            {
                result = dateX.CompareTo(dateY);
            }
            // Handle numeric sorting
            else if (decimal.TryParse(textX, out var numX) && decimal.TryParse(textY, out var numY))
            {
                result = numX.CompareTo(numY);
            }
            // Handle string sorting
            else
            {
                result = string.Compare(textX, textY, StringComparison.CurrentCultureIgnoreCase);
            }

            // Reverse result for descending order
            return _ascending ? result : -result;
        }
    }
}
