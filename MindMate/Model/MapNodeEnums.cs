﻿/* Author: Syed Umar Anis (mail@umaranis.com)                    
 * Copyright (c) 2014 Syed Umar Anis                             
 * This software is license under MIT license (see LICENSE.txt)    
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MindMate.Model
{
    public enum NodeRichContentType { NONE, NODE, NOTE }

    public enum NodeShape { None, Fork, Bubble, Box }

    public enum NodePosition : int { Root = 0, Left = 1, Right = 2, Undefined = -1 };

    public enum NodeProperties
    {
        Text,
        Folded,
        Bold,
        Italic,
        FontName,
        FontSize,
        Link,
        BackColor,
        Color,
        Shape,
        LineWidth,
        LinePattern,
        LineColor,
        RichContentType,
        RichContentText
    }

    public enum IconChange
    {
        Added,
        Removed
    }

    public enum TreeStructureChange
    {
        New,
        MoveLeft, // applicable only to childs of root node
        MoveRight, // applicable only to childs of root node
        Detach,
        Attach,
        Delete,
        MoveUp,
        MoveDown
    }


    public enum NodeLinkType
    {
        ExternalFile,
        MindMapNode,
        Executable,
        InternetLink,
        Empty
    }    
    
}
