using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Repositories.Models
{
    public enum EventTypes
    {
        click = 0,
        focus,
        blur,
        keydown,
        keyup,
        keypress,
        load,
        submit,
        mousedown,
        mouseup,
        mouseenter,
        mouseleave
    }
}