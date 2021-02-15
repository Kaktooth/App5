using System;
using System.Collections.Generic;
using System.Text;

namespace App5.Model
{
   public interface IClickModel
    {
        void OnClick();

        void Reset();

        int Clicks { get; }
    }
}
