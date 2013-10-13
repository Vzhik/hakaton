using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Repositories.Models
{
    public enum EventTypes
    {
        click = 0,
        focus = 1,
        blur = 2,
        keydown = 3,
        keyup = 4,
        keypress = 5,
        load = 6,
        submit = 7,
        mousedown = 8,
        mouseup = 9,
        mouseenter = 10,
        mouseleave = 11
    }
}