using System.Drawing;
using System.Windows.Forms;

namespace EncompassBrowserTab.Objects.Interface
{
    public interface IMenuItemBase
    {
        ToolStripItem CreateToolStripMenu(Image image, string Name);
    }
}
