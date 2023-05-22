using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace custom_projD
{
    public class UserInputHandler
    {
        public bool IsMouseClicked(MouseButton button)
        {
            return SplashKit.MouseClicked(button);
        }

        public int GetMouseX()
        {
            return (int)SplashKit.MouseX();
        }

        public int GetMouseY()
        {
            return (int)SplashKit.MouseY();
        }
    }

}
