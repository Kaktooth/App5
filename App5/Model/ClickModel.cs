using System;
using System.Collections.Generic;
using System.Text;

namespace App5.Model
{
    public class ClickModel : IClickModel
    {
         public int Clicks { get; private set; }

        void IClickModel.OnClick()
        {
            Clicks++;
        }

        void IClickModel.Reset()
        {
            Clicks = 0;
        }
    }
}
