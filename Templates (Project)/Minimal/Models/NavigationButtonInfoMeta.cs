using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace Minimal.Models
{
    public class NavigationButtonInfoMeta
    {
        public Type PageType { get; set; }
        public string PageParameter { get; set;  }
        public Symbol Symbol { get; set; }
        public string Text { get; set; }

        public NavigationButtonInfoMeta()
        {
            this.PageType = this.GetType();
            this.PageParameter = string.Empty;
            this.Symbol = Symbol.Globe;
            this.Text = string.Empty;
        }

        public override string ToString()
        {
            return string.Format("{0}({1})", PageType, PageParameter);
        }
    }
}
